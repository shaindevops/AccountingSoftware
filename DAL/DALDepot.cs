using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALDepot
    {
        DB db = new DB();
        public bool ExistDepot(Depots D)
        {
            var q = db.Depots.Where(i => i.Name == D.Name);
            if (q.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public string Create(Depots D)
        {
            if (ExistDepot(D))
            {
                db.Depots.Add(D);
                db.SaveChanges();
                return "Congratulations!! -- The new Depot was registered";
            }
            else
            {
                return "Duplicate information.";
            }
            
        }
        
        public Depots ReadId(int id)
        {
            return db.Depots.Where(i => i.id == id).FirstOrDefault();
        }
        public DataTable ReadFillGrid()
        {
            string cmd = "SELECT DISTINCT TOP (100) PERCENT dbo.Depots.id, dbo.Depots.Name FROM  dbo.Depots WHERE (dbo.Depots.DelStatus = 0) ORDER BY dbo.Depots.id DESC";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillDepotByProducts(int ProducId)
        {
            SqlCommand cmd = new SqlCommand("dbo.FillDepotByProducts");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ProductId", ProducId);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string Update(int id, Depots D)
        {
            var q = db.Depots.Where(i => i.id == id).FirstOrDefault();
            if(q != null)
            {
                q.Name = D.Name;
                db.SaveChanges();
                return "The Depot information has been edited successfully";
            }
            else
            {
                return "There is no Depot with this specification";
            }
        }
        public string DeleteDepot(int id)
        {
            var q = db.Depots.Include("Stocks").Include("Details").Where(i => i.id == id).FirstOrDefault();
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
                return "The Depot information has been Deleted successfully";
            }
            else
            {
                return "There is no Depot with this specification";
            }
        }
        public string CountDepot()
        {
            return db.Depots.Where(i => i.DelStatus == false).Count().ToString();
        }
        public Depots DepotName(string Name)
        {
            return db.Depots.Where(i => i.Name == Name).FirstOrDefault();
        }

        public int GetDefaultDepotId()
        {
             return db.Depots.Min(i => (int?)i.id) ?? 0;
        }
    }
}
