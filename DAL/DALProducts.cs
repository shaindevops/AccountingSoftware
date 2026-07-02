using BE;
using BE.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALProducts
    {
        /// <summary>
        /// True if a product with the same code and name already exists
        /// (i.e. creating one would be a duplicate). Renamed from the
        /// original "ExistProduct" (which confusingly returned true when
        /// the product did NOT exist) - same underlying query, clearer
        /// name and non-inverted result.
        /// </summary>
        public bool IsDuplicateProduct(Products P)
        {
            using (var db = new DB())
            {
                return db.Products.Any(i => i.Code == P.Code && i.Name == P.Name);
            }
        }

        public string Create(Products P, int ProductGroupId)
        {
            try
            {
                using (var db = new DB())
                {
                    if (IsDuplicateProduct(P))
                    {
                        return "The product in question is a duplicate";
                    }

                    var group = db.Groups.FirstOrDefault(g => g.id == ProductGroupId);
                    if (group != null)
                    {
                        P.GroupName = group.Name;
                        P.Group = group;
                    }

                    db.Products.Add(P);
                    db.SaveChanges();
                    return "The product has been successfully registered";
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError("DALProducts.Create", e);
                return "There was a problem registering the product: \n" + e.Message;
            }
        }

        public Products ReadId(int id)
        {
            using (var db = new DB())
            {
                return db.Products.Where(i => i.id == id).FirstOrDefault();
            }
        }

        public DataTable FillGridProducts()
        {
            const string cmd = "SELECT DISTINCT \r\n                         TOP (100) PERCENT dbo.Products.id, dbo.Groups.Name AS [Group Name], dbo.Products.Code AS [Product Code], dbo.Products.Name AS [Product Name], dbo.Products.Size AS [Product Size], \r\n                         dbo.Products.DefaultPrice AS [Sell Price $], dbo.Products.Description, dbo.Products.Alarm AS Alert, dbo.Products.Regdate AS [Date Register]\r\nFROM            dbo.Products INNER JOIN\r\n                         dbo.Groups ON dbo.Products.Group_id = dbo.Groups.id\r\nWHERE        (dbo.Products.DelStatus = 0)\r\nORDER BY [Group Name] DESC, [Product Name] DESC";
            return AdoHelper.ExecuteQuery("DALProducts.FillGridProducts", cmd);
        }

        public DataTable SearchProducts(string P)
        {
            return AdoHelper.ExecuteStoredProcedure(
                $"DALProducts.SearchProducts(P='{P}')",
                "dbo.SearchProduct",
                new SqlParameter("@search", P));
        }

        public DataTable SearchProductsBYGroup(string G, string P)
        {
            return AdoHelper.ExecuteStoredProcedure(
                $"DALProducts.SearchProductsBYGroup(G='{G}', P='{P}')",
                "dbo.SearchProductByGroup",
                new SqlParameter("@groupname", G),
                new SqlParameter("@search", P));
        }

        public string Update(int id, Products P)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Products.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.Code = P.Code;
                        q.Name = P.Name;
                        q.Image = P.Image;
                        q.Size = P.Size;
                        q.Alarm = P.Alarm;
                        q.DefaultPrice = P.DefaultPrice;
                        q.Description = P.Description;
                        q.GroupName = P.GroupName;
                        db.SaveChanges();
                        return "The product was edited successfully";
                    }
                    else
                    {
                        return "No product found";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALProducts.Update(id={id})", e);
                return "There was a problem editing the product: \n" + e.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Products.Include("Stocks").Include("Details").Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.DelStatus = true;
                        foreach (var stocks in q.Stocks)
                        {
                            stocks.DelStatus = true;
                        }
                        foreach (var details in q.Details)
                        {
                            details.Delstatus = true;
                        }
                        db.SaveChanges();
                        return "The product was Deleted successfully";
                    }
                    else
                    {
                        return "No product found";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALProducts.Delete(id={id})", e);
                return "There was a problem deleting the product: \n" + e.Message;
            }
        }

        public string ProductCount()
        {
            using (var db = new DB())
            {
                return db.Products.Where(i => i.DelStatus == false).Count().ToString();
            }
        }

        public Products ProductName(string Name)
        {
            using (var db = new DB())
            {
                return db.Products.Where(i => i.Name == Name).FirstOrDefault();
            }
        }
    }
}
