using BE;
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
        DB db = new DB();
        public bool ExistProduct(Products P)
        {
            var q = db.Products.Where(i => i.Code == P.Code && i.Name == P.Name);
            if(q.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public string Create(Products P, int ProductGroupId)
        {
            if(ExistProduct(P))
            {
                var group = db.Groups.FirstOrDefault(g => g.id == ProductGroupId);
                if(group != null)
                {
                    P.GroupName = group.Name;
                    P.Group = group;
                }

                db.Products.Add(P);
                db.SaveChanges();
                return "The product has been successfully registered";
            }
            else
            {
                return "The product in question is a duplicate";
            }

        }
        public Products ReadId(int id)
        {
            return db.Products.Where(i => i.id == id).FirstOrDefault();
        }
        public DataTable FillGridProducts()
        {
            string cmd = "SELECT DISTINCT \r\n                         TOP (100) PERCENT dbo.Products.id, dbo.Groups.Name AS [Group Name], dbo.Products.Code AS [Product Code], dbo.Products.Name AS [Product Name], dbo.Products.Size AS [Product Size], \r\n                         dbo.Products.DefaultPrice AS [Sell Price $], dbo.Products.Description, dbo.Products.Alarm AS Alert, dbo.Products.Regdate AS [Date Register]\r\nFROM            dbo.Products INNER JOIN\r\n                         dbo.Groups ON dbo.Products.Group_id = dbo.Groups.id\r\nWHERE        (dbo.Products.DelStatus = 0)\r\nORDER BY [Group Name] DESC, [Product Name] DESC";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        
        public DataTable SearchProducts(string P)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.SearchProduct");
                SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@search", P);
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
        public DataTable SearchProductsBYGroup(string G, string P)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.SearchProductByGroup");
                SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@groupname", G);
                cmd.Parameters.AddWithValue("@search", P);
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
        public string Update(int id, Products P)
        {
            var q = db.Products.Where(i => i.id == id).FirstOrDefault();
            if(q != null)
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
        public string Delete(int id)
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
        public string ProductCount()
        {
            return db.Products.Where(i => i.DelStatus == false).Count().ToString();
        }

        public Products ProductName(string Name)
        {
            return db.Products.Where(i => i.Name == Name).FirstOrDefault();
        }

    }
}
