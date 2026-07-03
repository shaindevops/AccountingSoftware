using BE;
using BE.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class DALStocks
    {
        public string Create(Stocks S, int FactorId, int DepotId, int ProductId)
        {
            try
            {
                using (var db = new DB())
                {
                    var factor = db.Factors.FirstOrDefault(f => f.id == FactorId);
                    S.FactorId = factor?.id ?? 0;

                    var depot = db.Depots.FirstOrDefault(d => d.id == DepotId);
                    S.DepotId = depot?.id ?? 0;

                    var product = db.Products.FirstOrDefault(p => p.id == ProductId);
                    if (product != null)
                    {
                        S.ProductId = product.id;
                        S.Product = product;
                    }
                    else
                    {
                        S.ProductId = 0;
                        S.Product = null;
                    }

                    db.Stocks.Add(S);
                    db.SaveChanges();
                    return "Stock of product is registered successfully";
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError("DALStocks.Create", e);
                return "There was a problem registering the stock movement: \n" + e.Message;
            }
        }

        public Stocks ReadId(int id)
        {
            using (var db = new DB())
            {
                return db.Stocks.Where(i => i.id == id).FirstOrDefault();
            }
        }

        public string UpdateStock(int id, Stocks S)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Stocks.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.RegDate = S.RegDate;
                        q.Description = S.Description;
                        q.StockIn = S.StockIn;
                        q.StockOut = S.StockOut;
                        q.FactorId = S.FactorId;
                        q.DepotId = S.DepotId;
                        q.ProductId = S.ProductId;
                        db.SaveChanges();
                        return "Stock of product is edited successfully";
                    }
                    else
                    {
                        return "Not find this item";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALStocks.UpdateStock(id={id})", e);
                return "There was a problem editing the stock movement: \n" + e.Message;
            }
        }
        public string DeleteStock(int id)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Stocks.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        db.Stocks.Remove(q);
                        db.SaveChanges();
                        return "Stock of product is deleted successfully";
                    }
                    else
                    {
                        return "Not find this item";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALStocks.DeleteStock(id={id})", e);
                return "There was a problem deleting the stock movement: \n" + e.Message;
            }
        }
        public DataTable FillStock()
        {
            const string cmd = "SELECT  Distinct  dbo.Stocks.id, dbo.Groups.Name AS [Group Name], dbo.Products.Code, dbo.Products.Name, dbo.Stocks.RegDate, dbo.Stocks.StockIn, dbo.Stocks.StockOut, dbo.Groups.Unit2, dbo.Groups.id AS GroupId,  dbo.Products.id AS ProductId FROM            dbo.Stocks INNER JOIN dbo.Products ON dbo.Stocks.ProductId = dbo.Products.id INNER JOIN dbo.Groups ON dbo.Products.Group_id = dbo.Groups.id";
            return AdoHelper.ExecuteQuery("DALStocks.FillStock", cmd);
        }
        public DataTable FilterStockByIds(int DepotId, int ProductId)
        {
            return AdoHelper.ExecuteStoredProcedure(
                $"DALStocks.FilterStockByIds(DepotId={DepotId}, ProductId={ProductId})",
                "dbo.FilterStockByIds",
                new SqlParameter("@DepotId", DepotId),
                new SqlParameter("@ProductId", ProductId));
        }

        public DataTable FilterStock(string Name)
        {
            return AdoHelper.ExecuteStoredProcedure(
                $"DALStocks.FilterStock(Name='{Name}')",
                "dbo.FilterStocks",
                new SqlParameter("@Name", Name));
        }

        public int GetProductSttockInDepot(int? DepotId, int ProductId)
        {
            using (var db = new DB())
            {
                return ComputeAvailableStock(db, DepotId, ProductId);
            }
        }

        /// <summary>
        /// Shared stock-balance calculation, taking an existing DB context
        /// so it can participate in an ongoing transaction (see
        /// TransferStock) as well as be used standalone (see
        /// GetProductSttockInDepot).
        /// </summary>
        private static int ComputeAvailableStock(DB db, int? DepotId, int ProductId)
        {
            var stockIn = db.Stocks
                    .Where(i => i.DepotId == DepotId && i.ProductId == ProductId)
                    .Sum(i => (int?)i.StockIn) ?? 0;

            var stockOut = db.Stocks
                             .Where(i => i.DepotId == DepotId && i.ProductId == ProductId)
                             .Sum(i => (int?)i.StockOut) ?? 0;

            return stockIn - stockOut;
        }

        /// <summary>
        /// Moves stock of one product from one depot to another as a single
        /// atomic operation: the availability check and both the
        /// stock-out and stock-in movements happen inside one database
        /// transaction. Previously this was two independent Create() calls
        /// made from the UI layer (FrmMovmentProductToDepot) - if the first
        /// succeeded and the second failed (e.g. a dropped connection),
        /// stock was permanently deducted from the source depot and never
        /// credited to the destination, silently losing inventory. Wrapping
        /// both writes in one transaction here closes that gap; it also
        /// re-checks availability inside the transaction rather than in the
        /// UI beforehand, closing a check-then-act race between concurrent
        /// transfers from the same depot.
        /// </summary>
        public string TransferStock(int fromDepotId, int toDepotId, int productId, int quantity, string regDate)
        {
            using (var db = new DB())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    int available = ComputeAvailableStock(db, fromDepotId, productId);
                    if (quantity > available)
                    {
                        return "There is not enough stock";
                    }

                    var product = db.Products.FirstOrDefault(p => p.id == productId);
                    var fromDepot = db.Depots.FirstOrDefault(d => d.id == fromDepotId);
                    var toDepot = db.Depots.FirstOrDefault(d => d.id == toDepotId);

                    db.Stocks.Add(new Stocks
                    {
                        RegDate = regDate,
                        Description = "Move This Product To " + toDepot?.Name,
                        StockIn = 0,
                        StockOut = quantity,
                        DepotId = fromDepotId,
                        ProductId = productId,
                        Product = product
                    });

                    db.Stocks.Add(new Stocks
                    {
                        RegDate = regDate,
                        Description = "Move This Product From " + fromDepot?.Name,
                        StockIn = quantity,
                        StockOut = 0,
                        DepotId = toDepotId,
                        ProductId = productId,
                        Product = product
                    });

                    db.SaveChanges();
                    transaction.Commit();
                    return "The operation of transferring the product to another Depot was successfully completed.";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    AppLogger.LogError(
                        $"DALStocks.TransferStock(fromDepotId={fromDepotId}, toDepotId={toDepotId}, productId={productId}, quantity={quantity})",
                        e);
                    return "There was a problem transferring the stock: \n" + e.Message;
                }
            }
        }

        public DataTable FillStockAlerm()
        {
            const string cmd = "SELECT * FROM ViewStocks WHERE (Alarm > Total) ORDER BY Name";
            return AdoHelper.ExecuteQuery("DALStocks.FillStockAlerm", cmd);
        }
    }
}
