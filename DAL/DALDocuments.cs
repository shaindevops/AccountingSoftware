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
    public class DALDocuments
    {
        DB db = new DB();

        public bool ExistDocNumber(Documents D)
        {
            var q = db.Documents.Where(i => i.Number == D.Number);
            if(q.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public string Create(Documents D, int AccountId, int CostGroupId)
        {
            if (!ExistDocNumber(D))
            {
                var account = db.Accounts.FirstOrDefault(i => i.id == AccountId);
                if(account != null)
                {
                    D.Accounts = account;
                }
                var costgroup = db.CostGroups.FirstOrDefault(i => i.id == CostGroupId);
                if(costgroup != null)
                {
                    D.CostGroup = costgroup;
                }

                db.Documents.Add(D);
                db.SaveChanges();
                return "The new document has been registered successfully";
            }
            else
            {
                return "A document with this document number is already registered";
            }
            
        }

        public Documents ReadId(int id)
        {
            return db.Documents.Where(i => i.id == id).FirstOrDefault();
        }

        public DataTable FillDocumentNotPass()
        {
            string cmd = "SELECT Distinct TOP (100) PERCENT id, Date1 AS [Document registration date], Date2 AS [Due Date], Number, Description, Price, Ok AS Passed\r\nFROM            dbo.Documents\r\nWHERE        (Delstatus = 0) AND (Ok = 0)\r\nORDER BY [Due Date] DESC, [Document registration date] DESC";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable FillDocumentPass()
        {
            string cmd = "SELECT        TOP (100) PERCENT id, Date1 AS [Document registration date], Date2 AS [Due Date], Number, Description, Price, Ok AS Passed\r\nFROM            dbo.Documents\r\nWHERE        (Delstatus = 0) AND (Ok = 1)\r\nORDER BY [Document registration date] DESC";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable FilterDocumentIncomeByNumber(string Num)
        {
            SqlCommand cmd = new SqlCommand("dbo.FilterDocumentIncomeByNumber");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Num", Num);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FilterDocumentPayByNumber(string Num)
        {
            SqlCommand cmd = new SqlCommand("dbo.FilterDocumentPayByNumber");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Num", Num);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillDocumentsByPerson(int PersonId)
        {
            SqlCommand cmd = new SqlCommand("dbo.FillDocumentsByPerson");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@PersonId", PersonId);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string Update(int id, Documents D)
        {
            var q = db.Documents.Where(i => i.id == id).FirstOrDefault();
            if(q != null)
            {
                if (ExistDocNumber(D))
                {
                    q.Date1 = D.Date1;
                    q.Date2 = D.Date2;
                    q.Number = D.Number;
                    q.Description = D.Description;
                    q.Price = D.Price;
                    q.Accounts = D.Accounts;
                    q.CostGroup = D.CostGroup;
                    q.People = D.People;
                    db.SaveChanges();
                    return "The document has been edited successfully";
                }
                else
                {
                    return "A document with this document number is already registered";
                }
                
            }
            else
            {
                return "Document not found";
            }
        }
        public string UpdateDocPass(int id)
        {
            var q = db.Documents.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Ok = true;
                db.SaveChanges();
                return "The document has changed to a passed status";
            }
            else
            {
                return "Document not found";
            }
        }
        public string Delete(int id)
        {
            var q = db.Documents.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Delstatus = true;
                db.SaveChanges();
                return "The document has been deleted successfully";
            }
            else
            {
                return "Document not found";
            }
        }
        public void GetSumDocumentByPerson(int personId, out int SumBuy, out int SumSale)
        {
            // محاسبه مجموع خرید
            SumBuy = db.Documents
                        .Where(f => f.CostGroup.id == 5 && f.People.id == personId)
                        .Sum(f => (int?)f.Price) ?? 0;

            // محاسبه مجموع فروش
            SumSale = db.Documents
                        .Where(f => f.CostGroup.id == 2 && f.People.id == personId)
                        .Sum(f => (int?)f.Price) ?? 0;
        }
    }
}
