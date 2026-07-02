using BE;
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
        DB db = new DB();

        public string Create(Stocks S, int FactorId, int DepotId, int ProductId)
        {
            var factor = db.Factors.FirstOrDefault(f => f.id == FactorId);
            if(factor != null)
            {
                S.FactorId = factor.id;
            }
            else { S.FactorId = 0; }

            var depot = db.Depots.FirstOrDefault(d => d.id == DepotId);
            if(depot != null)
            {
                S.DepotId = depot.id;
            }
            else { S.DepotId = 0; }


            var product = db.Products.FirstOrDefault(p => p.id == ProductId);
            if(product != null)
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

        public Stocks ReadId(int id)
        {
            return db.Stocks.Where(i => i.id == id).FirstOrDefault();
        }

        public string UpdateStock(int id, Stocks S)
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
        public string DeleteStock(int id)
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
        public DataTable FillStock()
        {
            string cmd = "SELECT  Distinct  dbo.Stocks.id, dbo.Groups.Name AS [Group Name], dbo.Products.Code, dbo.Products.Name, dbo.Stocks.RegDate, dbo.Stocks.StockIn, dbo.Stocks.StockOut, dbo.Groups.Unit2, dbo.Groups.id AS GroupId,  dbo.Products.id AS ProductId FROM            dbo.Stocks INNER JOIN dbo.Products ON dbo.Stocks.ProductId = dbo.Products.id INNER JOIN dbo.Groups ON dbo.Products.Group_id = dbo.Groups.id";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FilterStockByIds(int DepotId, int ProductId)
        {
            SqlCommand cmd = new SqlCommand("dbo.FilterStockByIds");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@DepotId", DepotId);
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable FilterStock(string Name)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.FilterStocks");
                SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.CommandType = CommandType.StoredProcedure;
                var sqladapter = new SqlDataAdapter();
                sqladapter.SelectCommand = cmd;
                var commandbuilder = new SqlCommandBuilder(sqladapter);
                var ds = new DataSet();
                sqladapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception)
            {

                return null;
            }
        }

        public int GetProductSttockInDepot(int? DepotId,  int ProductId)
        {
            int? ProductStock = 0;
            var StockIn = db.Stocks
                    .Where(i => i.DepotId == DepotId && i.ProductId == ProductId)
                    .Sum(i => (int?)i.StockIn) ?? 0;

            var StockOut = db.Stocks
                             .Where(i => i.DepotId == DepotId && i.ProductId == ProductId)
                             .Sum(i => (int?)i.StockOut) ?? 0;
            ProductStock = StockIn - StockOut;
            return (int)ProductStock;
        }

        public DataTable FillStockAlerm()
        {
            string cmd = "SELECT * FROM ViewStocks WHERE (Alarm > Total) ORDER BY Name";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
