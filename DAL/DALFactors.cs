using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALFactors
    {
        DB db = new DB();

        public bool ExistSaleNumber(Factors Number)
        {
            var q = db.Factors.Where(i => i.FactorNumber == Number.FactorNumber).Where(i => i.FactorType == false).FirstOrDefault();
            return q != null;
        }
        public string Create(Factors F, int PersonId)
        {
            var person = db.People.FirstOrDefault(i => i.id == PersonId);
            if(person != null)
            {
                F.PersonId = person.id;
                F.Person = person;
            }

            db.Factors.Add(F);
            db.SaveChanges();

            return "The Factor Registered Successfully";
        }
        public Factors ReadId(int id)
        {
            return db.Factors.Where(i => i.id == id).FirstOrDefault();
        }

        public string DeleteFactor(int id)
        {
            var q = db.Factors.Include("Details").FirstOrDefault(i => i.id == id);
            if (q != null)
            {
                q.DelStatus = true;  // حذف منطقی فاکتور
                foreach (var detail in q.Details)
                {
                    detail.Delstatus = true;  // حذف منطقی جزئیات
                }
                db.SaveChanges();
                return "Factor and its details are deleted successfully";
            }
            else
            {
                return "Factor not found";
            }
        }

        public int GetFactorId()
        {
            return db.Factors.Any() ? db.Factors.Max(i => i.id) : 0;
        }
        public string GetMaxSaleNumber()
        {
            var factors = db.Factors.Where(i => i.FactorType == false);
            return factors.Any() ? factors.Max(i => i.FactorNumber) : "No Factor Found";
        }

        public DataTable FillFactor()
        {
            string cmd = "SELECT Distinct  TOP (100) PERCENT dbo.Factors.id, dbo.Factors.PersonId, dbo.People.Name AS [Person Name], dbo.Factors.FactorType, dbo.Factors.FactorNumber, dbo.Factors.FactorDate, \r\n                         dbo.Factors.FactorDefaultTax, dbo.Factors.FactorTaxPrice, dbo.Factors.FactorDiscountPrice, dbo.Factors.FactorSumPrice\r\nFROM            dbo.Factors INNER JOIN\r\n                         dbo.People ON dbo.Factors.PersonId = dbo.People.id\r\nWHERE        (dbo.Factors.DelStatus = 0)\r\nORDER BY dbo.Factors.FactorDate DESC";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable FilterFactorBuyDate(string Date1, string Date2)
        {
            SqlCommand cmd = new SqlCommand("dbo.FilterFactorBuyDate");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Date1", Date1);
            cmd.Parameters.AddWithValue("@Date2", Date2);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FilterFactorSaleDate(string Date1, string Date2)
        {
            SqlCommand cmd = new SqlCommand("dbo.FilterFactorSaleDate");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Date1", Date1);
            cmd.Parameters.AddWithValue("@Date2", Date2);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillViewFactorsDetails(int FactorId)
        {
            SqlCommand cmd = new SqlCommand("dbo.FillViewFactorsDetails");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@FactorId", FactorId);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillFactorByPerson(int PersonId)
        {
            SqlCommand cmd = new SqlCommand("dbo.FillFactorByPerson");
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
        public string FactorSaleCount()
        {
            return db.Factors.Where(i => i.DelStatus == false).Where(i => i.FactorType == false).Count().ToString();
        }
        public string FactorBuyCount()
        {
            return db.Factors.Where(i => i.DelStatus == false).Where(i => i.FactorType == true).Count().ToString();
        }


        public void GetSumFactorsByPerson(int personId, out int SumBuy, out int SumSale)
        {
            // محاسبه مجموع خرید
            SumBuy = db.Factors
                        .Where(f => f.FactorType == true && f.PersonId == personId)
                        .Sum(f => (int?)f.FactorSumPrice) ?? 0;

            // محاسبه مجموع فروش
            SumSale = db.Factors
                        .Where(f => f.FactorType == false && f.PersonId == personId)
                        .Sum(f => (int?)f.FactorSumPrice) ?? 0;
        }
        public DataTable FilterBuyFactor(string Date1, string Date2)
        {
            SqlCommand cmd = new SqlCommand("dbo.FilterBuyFactor");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Date1", Date1);
            cmd.Parameters.AddWithValue("@Date2", Date2);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FilterSaleFactor(string Date1, string Date2)
        {
            SqlCommand cmd = new SqlCommand("dbo.FilterSaleFactor");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Date1", Date1);
            cmd.Parameters.AddWithValue("@Date2", Date2);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable GetSumBuyFactor(string Date1, string Date2, out int SumFactor, out int SumBook)
        {
            SumFactor = 0;
            SumBook = 0;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true"))
            using (SqlCommand cmd = new SqlCommand("dbo.GetSumBuyFactor", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // پارامترهای ورودی
                cmd.Parameters.AddWithValue("@Date1", Date1);
                cmd.Parameters.AddWithValue("@Date2", Date2);

                // پارامترهای خروجی
                SqlParameter sumFactorParam = new SqlParameter("@SumFactor", SqlDbType.Int);
                sumFactorParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumFactorParam);

                SqlParameter sumBookParam = new SqlParameter("@SumBook", SqlDbType.Int);
                sumBookParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumBookParam);

                // باز کردن اتصال و اجرای پروسیجر
                con.Open();

                // استفاده از SqlDataAdapter برای پر کردن DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                // دریافت مقادیر خروجی
                SumFactor = (int)cmd.Parameters["@SumFactor"].Value;
                SumBook = (int)cmd.Parameters["@SumBook"].Value;
            }

            return dt;
        }
        
        public DataTable GetSumSaleFactor(string Date1, string Date2, out int SumFactor, out int SumBook)
        {
            SumFactor = 0;
            SumBook = 0;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true"))
            using (SqlCommand cmd = new SqlCommand("dbo.GetSumSaleFactor", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // پارامترهای ورودی
                cmd.Parameters.AddWithValue("@Date1", Date1);
                cmd.Parameters.AddWithValue("@Date2", Date2);

                // پارامترهای خروجی
                SqlParameter sumFactorParam = new SqlParameter("@SumFactor", SqlDbType.Int);
                sumFactorParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumFactorParam);

                SqlParameter sumBookParam = new SqlParameter("@SumBook", SqlDbType.Int);
                sumBookParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumBookParam);

                // باز کردن اتصال و اجرای پروسیجر
                con.Open();

                // استفاده از SqlDataAdapter برای پر کردن DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                // دریافت مقادیر خروجی
                SumFactor = (int)cmd.Parameters["@SumFactor"].Value;
                SumBook = (int)cmd.Parameters["@SumBook"].Value;
            }

            return dt;
        }
        /// <summary>
        /// گزارش مالی برای فرم FrmMoneyReport برای 6 متغیر
        /// </summary>
        /// <param name="Date1">تاریخ اول</param>
        /// <param name="Date2">تا تاریخ</param>
        /// <param name="Cost1">برای درآمدها</param>
        /// <param name="Cost2">برای هزینه ها</param>
        ///<param name="ِDoc1">برای اسناد دریافتی</param>
        ///<param name="Doc2">برای اسناد پرداختی</param>
        ///<param name="Sale">مجموع فروش</param>
        ///<param name="Buy">مجموع خرید</param>
        /// 
        /// <returns></returns>
        public DataTable GetMoneyReportByDate(string Date1, string Date2, out int Cost1, out int Cost2, out int Doc1, out int Doc2, out int Sale, out int Buy)
        {
            Cost1 = 0;
            Cost2 = 0;
            Doc1 = 0;
            Doc2 = 0;
            Sale = 0;
            Buy = 0;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true"))
            using (SqlCommand cmd = new SqlCommand("dbo.GetMoneyReportByDate", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // پارامترهای ورودی
                cmd.Parameters.AddWithValue("@Date1", Date1);
                cmd.Parameters.AddWithValue("@Date2", Date2);

                // پارامترهای خروجی
                SqlParameter sumcost1 = new SqlParameter("@Cost1", SqlDbType.Int);
                sumcost1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumcost1);

                SqlParameter sumcost2 = new SqlParameter("@Cost2", SqlDbType.Int);
                sumcost2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumcost2);

                SqlParameter sumdoc1 = new SqlParameter("@Doc1", SqlDbType.Int);
                sumdoc1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumdoc1);

                SqlParameter sumdoc2 = new SqlParameter("@Doc2", SqlDbType.Int);
                sumdoc2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumdoc2);

                SqlParameter sumsales = new SqlParameter("@Sale", SqlDbType.Int);
                sumsales.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumsales);

                SqlParameter sumbuys = new SqlParameter("@Buy", SqlDbType.Int);
                sumbuys.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumbuys);
                // باز کردن اتصال و اجرای پروسیجر
                con.Open();

                // استفاده از SqlDataAdapter برای پر کردن DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                // دریافت مقادیر خروجی
                Cost1 = (int)cmd.Parameters["@Cost1"].Value;
                Cost2 = (int)cmd.Parameters["@Cost2"].Value;
                Doc1 = (int)cmd.Parameters["@Doc1"].Value;
                Doc2 = (int)cmd.Parameters["@Doc2"].Value;
                Sale = (int)cmd.Parameters["@Sale"].Value;
                Buy = (int)cmd.Parameters["@Buy"].Value;
            }

            return dt;
        }

        public DataTable GetMoneyReportByYear(string Year, out int Cost1, out int Cost2, out int Doc1, out int Doc2, out int Sale, out int Buy)
        {
            Cost1 = 0;
            Cost2 = 0;
            Doc1 = 0;
            Doc2 = 0;
            Sale = 0;
            Buy = 0;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true"))
            using (SqlCommand cmd = new SqlCommand("dbo.GetMoneyReportByYear", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // پارامترهای ورودی
                cmd.Parameters.AddWithValue("@Year", Year);

                // پارامترهای خروجی
                SqlParameter sumcost1 = new SqlParameter("@Cost1", SqlDbType.Int);
                sumcost1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumcost1);

                SqlParameter sumcost2 = new SqlParameter("@Cost2", SqlDbType.Int);
                sumcost2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumcost2);

                SqlParameter sumdoc1 = new SqlParameter("@Doc1", SqlDbType.Int);
                sumdoc1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumdoc1);

                SqlParameter sumdoc2 = new SqlParameter("@Doc2", SqlDbType.Int);
                sumdoc2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumdoc2);

                SqlParameter sumsales = new SqlParameter("@Sale", SqlDbType.Int);
                sumsales.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumsales);

                SqlParameter sumbuys = new SqlParameter("@Buy", SqlDbType.Int);
                sumbuys.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sumbuys);
                // باز کردن اتصال و اجرای پروسیجر
                con.Open();

                // استفاده از SqlDataAdapter برای پر کردن DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                // دریافت مقادیر خروجی
                Cost1 = (int)cmd.Parameters["@Cost1"].Value;
                Cost2 = (int)cmd.Parameters["@Cost2"].Value;
                Doc1 = (int)cmd.Parameters["@Doc1"].Value;
                Doc2 = (int)cmd.Parameters["@Doc2"].Value;
                Sale = (int)cmd.Parameters["@Sale"].Value;
                Buy = (int)cmd.Parameters["@Buy"].Value;
            }

            return dt;
        }
    }
}
