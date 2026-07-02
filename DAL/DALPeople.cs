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
    public class DALPeople
    {
        DB db = new DB();

        public bool ExistPeople(People P)
        {
            var q = db.People.Where(i => i.Mobile ==  P.Mobile);
            if(q.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public string Create(People P)
        {
            if (ExistPeople(P))
            {
                db.People.Add(P);
                db.SaveChanges();
                return "The desired person has been registered successfully";
            }
            return "The desired information is duplicate";
        }
        public DataTable ReadFillPeople()
        {
            string cmd = "SELECT DISTINCT TOP (100) PERCENT id, Type, Name, Tel, Mobile, Email, Address, Description, Regdate\r\nFROM            dbo.People\r\nWHERE        (Delstatus = 0)\r\nORDER BY Type DESC";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable ReadFillNameAndMobile()
        {
            string cmd = "SELECT  Distinct TOP (100) Name, Mobile\r\nFROM            dbo.People\r\nWHERE        (Delstatus = 0)\r\nORDER BY Name DESC";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillPerson1(string PersonName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.FillPerson1");
                SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@PersonName", PersonName);
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
        public DataTable ReadFillPeopleById(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.FillPeopleById");
                SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", id);
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
        public DataTable SearchPeople(string P, int Index)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.SearchPeople");
                if(Index == 0)
                {
                    cmd.CommandText = "dbo.SearchPeople";
                }
                else if(Index == 1)
                {
                    cmd.CommandText = "dbo.SearchPeopleByName";
                }
                else if (Index == 2)
                {
                    cmd.CommandText = "dbo.SearchPeopleByTel";
                }
                else if(Index == 3)
                {
                    cmd.CommandText = "dbo.SearchPeopleByMobile";
                }
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
        public People ReadId(int id)
        {
            return db.People.Where(i => i.id == id).FirstOrDefault();
        }
        public string Update(int id, People P)
        {
            var q = db.People.Where(i => i.Delstatus == false).Where(i => i.id == id).FirstOrDefault();
            if(q != null)
            {
                q.Type = P.Type;
                q.Name = P.Name;
                q.Tel = P.Tel;
                q.Mobile = P.Mobile;
                q.Email = P.Email;
                q.Address = P.Address;
                q.Description = P.Description;
                q.Debtor = P.Debtor;
                q.Creditor = P.Creditor;
                db.SaveChanges();
                return "The person's information has been edited successfully";
            }
            else
            {
                return "The person was not found";
            }
        }
        public string Delete(int id)
        {
            var q = db.People.Include("Documents").Include("Accounts").Include("AccountBooks").Include("Factors").Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Delstatus = true;
                foreach (var doc in q.Documents)
                {
                    doc.Delstatus = true;
                }
                foreach (var account in q.Accounts)
                {
                    account.Delstatus = true;
                }
                foreach (var book in q.AccountBooks)
                {
                    book.Delstatus = true;
                }
                foreach (var factor in q.Factors)
                {
                    factor.DelStatus = true;
                }
                db.SaveChanges();
                return "The person's information has been deleted successfully";
            }
            else
            {
                return "The person was not found";
            }
        }
        public string PeopleCount()
        {
            return db.People.Where(i => i.Delstatus == false).Count().ToString();
        }

        public People ReadN(string P)
        {
            try
            {
                return db.People.Where(i => i.Name == P).FirstOrDefault();

            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<string> SelectPersonName()
        {
            return db.People.Where(i => i.Delstatus == false).Select(i => i.Name).ToList();
        }

        public int GetDebtor(int id)
        {
            int Debtor = 0;
            Debtor = db.People.Where(i => i.id == id).Sum(i => (int?)i.Debtor) ?? 0;
            return Debtor;
        }
        public int GetCreditor(int id)
        {
            int Creditor = 0;
            Creditor = db.People.Where(i => i.id == id).Sum(i => (int?)i.Creditor) ?? 0;
            return Creditor;
        }

        public void UpdateDebtor(int id, int Debtor)
        {
            var q = db.People.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Debtor = q.Debtor - Debtor;
                db.SaveChanges();
            }
        }
        public void UpdateCreditor(int id, int Creditor)
        {
            var q = db.People.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Creditor = q.Creditor - Creditor;
                db.SaveChanges();
            }
        }
    }

}
