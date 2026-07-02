using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace DAL
{
    public class DALAccountBook
    {
        DB db = new DB();
        public string Create(AccountBook AB, int AccountId, int CostGroupId, int PersonId)
        {
            try
            {
                var account = db.Accounts.FirstOrDefault(a => a.id == AccountId);
                if (account != null)
                {
                    AB.AccountName = account.AccountName;
                    AB.AccountId = account;
                }
                var costgroup = db.CostGroups.FirstOrDefault(a => a.id == CostGroupId);
                if (account != null)
                {
                    AB.CostGroupName = costgroup.Name;
                    AB.CostGroupId = costgroup;
                }
                var person = db.People.FirstOrDefault(a => a.id == PersonId);
                if (account != null)
                {
                    AB.PersonName = person.Name;
                    AB.PeopleId = person;
                }

                db.AccountBooks.Add(AB);
                db.SaveChanges();
                return "Account Book has been registered successfully";
            }
            catch
            {
                return "Server Connection" + " " + "Connection to the server has been lost";
            }
        }
        public DataTable FillAccountBook(int AccountId)
        {
            SqlCommand cmd = new SqlCommand("dbo.FillAccountBook");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@AccountId", AccountId);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable FilterAccountBookByDate(int AccountId, string FromDate, string ToDate)
        {

            DateTime From = DateTime.Parse(FromDate);
            DateTime To = DateTime.Parse(ToDate);

            SqlCommand cmd = new SqlCommand("dbo.FilterAccountBookByDate");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@AccountId", AccountId);
            cmd.Parameters.AddWithValue("@FromDate", From);
            cmd.Parameters.AddWithValue("@ToDate", To);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillBookByPerson(int PersonId)
        {
            SqlCommand cmd = new SqlCommand("dbo.FillBookByPerson");
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
        public AccountBook ReadId(int id)
        {
            return db.AccountBooks.Where(i => i.id == id).FirstOrDefault();
        }

        public string Update(int id, AccountBook AB)
        {
            var q = db.AccountBooks.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Date = AB.Date;
                q.Time = AB.Time;
                q.Description = AB.Description;
                q.Price = AB.Price;
                q.AccountName = AB.AccountName;
                q.AccountId = AB.AccountId;
                q.CostGroupName = AB.CostGroupName;
                q.CostGroupId = AB.CostGroupId;
                q.PeopleId = AB.PeopleId;
                db.SaveChanges();
                return "Account book was edited with all the details";
            }
            else
            {
                return "Account book not found";
            }
        }
        public string Delete(int id)
        {
            var q = db.AccountBooks.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Delstatus = true;
                db.SaveChanges();
                return "Account book was deleted with all the details";
            }
            else
            {
                return "Account book not found";
            }
        }

        public int GetSumAccountBook(int accountId)
        {
            int Sum = 0;
            // جمع هزینه‌ها (Type = false)
            var Cost = db.AccountBooks
                .Where(i => i.AccountId.id == accountId && i.CostGroupId.Type == false && i.AccountId.Delstatus == false && i.CostGroupId.Delstatus == false)
                .Sum(i => (int?)i.Price) ?? 0;

            // جمع درآمدها (Type = true)
            var Income = db.AccountBooks
                .Where(i => i.AccountId.id == accountId && i.CostGroupId.Type == true && i.AccountId.Delstatus == false && i.CostGroupId.Delstatus == false)
                .Sum(i => (int?)i.Price) ?? 0;

            Sum = Income - Cost;
            return Sum;
        }

        public void GetSumBookByPerson(int personId, out int SumBuy, out int SumSale)
        {
            // محاسبه مجموع خرید
            SumBuy = db.AccountBooks
                        .Where(f => f.CostGroupId.id == 5 && f.PeopleId.id == personId)
                        .Sum(f => (int?)f.Price) ?? 0;

            // محاسبه مجموع فروش
            SumSale = db.AccountBooks
                        .Where(f => f.CostGroupId.id == 2 && f.PeopleId.id == personId)
                        .Sum(f => (int?)f.Price) ?? 0;
        }
    }
}
