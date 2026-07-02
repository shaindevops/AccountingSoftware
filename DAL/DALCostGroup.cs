using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCostGroup
    {
        DB db = new DB();
        
        public string Create(CostGroup CG)
        {
            db.CostGroups.Add(CG);
            db.SaveChanges();
            return "The Cost Group has been registered successfully";
        }
        public CostGroup ReadId(int id)
        {
            return db.CostGroups.Where(i => i.id == id).FirstOrDefault();
        }
        public CostGroup ReadId28(int id)
        {
            return db.CostGroups.Where(i => i.id == id).FirstOrDefault();
        }
        public CostGroup ReadId29(int id)
        {
            return db.CostGroups.Where(i => i.id == id).FirstOrDefault();
        }
        public DataTable FillCostGroup()
        {
            string cmd = "SELECT Distinct TOP (100) PERCENT id, Name, Description, Regdate AS [Reg Date]\r\nFROM            dbo.CostGroups\r\nWHERE        (Static = 0) AND (Delstatus = 0)\r\nORDER BY Name";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillCostGroupBYTypeIncome()
        {
            string cmd = "SELECT        dbo.CostGroups.id, dbo.CostGroups.Name, dbo.CostGroups.Description, dbo.CostGroups.Regdate\r\nFROM            dbo.CostGroups \r\nWHERE        (dbo.CostGroups.Delstatus = 0) AND (dbo.CostGroups.Static = 0) AND (dbo.CostGroups.Type = 1)";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillCostGroupBYTypeCosts()
        {
            string cmd = "SELECT        dbo.CostGroups.id, dbo.CostGroups.Name, dbo.CostGroups.Description, dbo.CostGroups.Regdate\r\nFROM            dbo.CostGroups \r\nWHERE        (dbo.CostGroups.Delstatus = 0) AND (dbo.CostGroups.Static = 0) AND (dbo.CostGroups.Type = 0)";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string Update(int id, CostGroup CG)
        {
            var q = db.CostGroups.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Type = CG.Type;
                q.Static = CG.Static;
                q.Name = CG.Name;
                q.Description = CG.Description;
                db.SaveChanges();
                return "The Cost Group information has been edited successfully";
            }
            else
            {
                return "The person was not found";
            }
        }
        public string Delete(int id)
        {
            var q = db.CostGroups.Include("AccountBooks").Include("Documents").Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Delstatus = true;
                foreach (var book in q.AccountBooks)
                {
                    book.Delstatus = true;
                }
                foreach (var doc in q.Documents)
                {
                    doc.Delstatus = true;
                }
                db.SaveChanges();
                return "The Cost Group information has been deleted successfully";
            }
            else
            {
                return "The person was not found";
            }
        }
        public CostGroup ReadN(string CG)
        {
            try
            {
                return db.CostGroups.Where(i => i.Name == CG).SingleOrDefault();

            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool GetCostGroupStatus(int id)
        {
            var CostStatus = db.CostGroups.Where(i => i.id == id).Select(i => i.Type).FirstOrDefault();
            return CostStatus;
        }
    }
}
