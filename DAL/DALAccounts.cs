using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALAccounts
    {
        DB db = new DB();

        public bool ExistAccount(Accounts A)
        {
            var q = db.Accounts.Where(i => i.AccountName == A.AccountName && i.AccountNumber == A.AccountNumber);
            if (q.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public string Create(Accounts A, int PersonId)
        {
            if (ExistAccount(A))
            {
                var person = db.People.FirstOrDefault(a => a.id == PersonId);
                if(person != null)
                {
                    A.AccountPerson = person.Name;
                    A.People = person;
                }

                db.Accounts.Add(A);
                db.SaveChanges();
                return "The Account has been registered successfully";
            }
            else
            {
                return "The financial account with these specifications has already been registered!!!";
            }
            
        }
        public Accounts ReadId(int id)
        {
            return db.Accounts.Where(i => i.id == id).FirstOrDefault();
        }

        public DataTable FillAccounts()
        {
            string cmd = "SELECT        TOP (100) PERCENT dbo.Accounts.id, dbo.Accounts.People_id, dbo.Accounts.AccountName AS [Account Name], dbo.Accounts.AccountNumber AS [Account Number], \r\n                         dbo.Accounts.AccountPerson AS [Account Person]\r\nFROM            dbo.Accounts WHERE        (dbo.Accounts.Delstatus = 0) \r\nORDER BY [Account Name]";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillAccountsBYType0()
        {
            string cmd = "SELECT        TOP (100) PERCENT dbo.Accounts.id, dbo.Accounts.People_id, dbo.Accounts.AccountName AS [Account Name], dbo.Accounts.AccountNumber AS [Account Number], \r\n                         dbo.Accounts.AccountPerson AS [Account Person]\r\nFROM            dbo.Accounts  \r\nWHERE        (dbo.Accounts.Delstatus = 0) AND (dbo.Accounts.AccountType = 0)\r\nORDER BY [Account Name]";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillAccountsBYType1()
        {
            string cmd = "SELECT        TOP (100) PERCENT dbo.Accounts.id, dbo.Accounts.People_id, dbo.Accounts.AccountName AS [Account Name], dbo.Accounts.AccountNumber AS [Account Number], \r\n                         dbo.Accounts.AccountPerson AS [Account Person]\r\nFROM            dbo.Accounts        \r\nWHERE        (dbo.Accounts.Delstatus = 0) AND (dbo.Accounts.AccountType = 1)\r\nORDER BY [Account Name]";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string Update(int id, Accounts CG)
        {
            var q = db.Accounts.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.AccountName = CG.AccountName;
                q.AccountNumber = CG.AccountNumber;
                q.AccountPerson = CG.AccountPerson;
                q.AccountType = CG.AccountType;
                db.SaveChanges();
                return "The Account information has been edited successfully";
            }
            else
            {
                return "The Account was not found";
            }
        }
        public string Delete(int id)
        {
            var q = db.Accounts.Include("AccountBooks").Include("Documents").Where(i => i.id == id).FirstOrDefault();
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
                return "The Account information has been deleted successfully";
            }
            else
            {
                return "The Account was not found";
            }
        }
        public Accounts ReadN(string A)
        {
            try
            {
                return db.Accounts.Where(i => i.AccountName == A).SingleOrDefault();

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
