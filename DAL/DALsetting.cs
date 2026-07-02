using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.Entity;

namespace DAL
{
    public class DALsetting
    {
        DB db = new DB();
        public bool Exictsetting()
        {
            return db.Setting.Any();
            
        }
        public string Create(Setting s)
        {
            if (!Exictsetting())
            {
                db.Setting.Add(s);
                db.SaveChanges();
                return "The settings have been applied";
            }
            else
            {
                return "The settings have been applied";
            }
        }
        public DataTable Read()
        {
            string cmd = "SELECT        id, comname AS [Company Name], factoraddress AS [Factor Address], factortel AS [Factor Tel], depotaddress AS [Depot Address], depottel AS [Depot Tel], SMSpaneluser AS [User Sms Panel], \r\n                         SMSpanelpassword AS [Sms Panel Password], Smssendernumber AS [Panel Phone Number], alarm1 AS [First Alarm], alarm2 AS [Second Alarm], Banksend AS [Bank Send], Factorsend AS [Factor Send]\r\nFROM            dbo.Settings";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public Setting ReadId(int id)
        {
            return db.Setting.Where(i => id == i.id).FirstOrDefault();
        }
        public string Update(int id, Setting s)
        {
            var q = db.Setting.Where(i => i.id == s.id).FirstOrDefault();
            if (q != null)
            {
                q.factoraddress = s.factoraddress;
                q.factortel = s.factortel;
                q.depotaddress = s.depotaddress;
                q.depottel = s.depottel;
                q.SMSpaneluser = s.SMSpaneluser;
                q.SMSpanelpassword = s.SMSpanelpassword;
                q.Smssendernumber = s.Smssendernumber;
                q.alarm1 = s.alarm1;
                q.alarm2 = s.alarm2;
                q.Banksend = s.Banksend;
                q.Factorsend = s.Factorsend;
                q.comname = s.comname;
                db.SaveChanges();
                return "The settings have been edited";
            }
            else
            {
                return "The settings have been edited";
            }
        }
        public string SettingCount()
        {
            return db.Setting.Count().ToString();
        }

        public bool GetSettingFactorSend()
        {
            bool isSend = db.Setting.Select(s => s.Factorsend).FirstOrDefault();
            return isSend;
        }

        public void GetFactorDetails(out string factorAddress, out string factorTel, out string depotAddress, out string depotTel, out string CompanyName)
        {
            var settings = db.Setting.FirstOrDefault();

            if (settings != null)
            {
                factorAddress = settings.factoraddress;
                factorTel = settings.factortel;
                depotAddress = settings.depotaddress;
                depotTel = settings.depottel;
                CompanyName = settings.comname;
            }
            else
            {
                factorAddress = string.Empty;
                factorTel = string.Empty;
                depotAddress = string.Empty;
                depotTel = string.Empty;
                CompanyName = string.Empty;
            }
        }

        public void GetAlarmSetting(out int Alm1, out int Alm2)
        {
            // فرض می‌کنیم که تنها یک رکورد در جدول Settings وجود دارد
            var setting = db.Setting.FirstOrDefault();

            if (setting != null)
            {
                Alm1 = setting.alarm1;
                Alm2 = setting.alarm2;
            }
            else
            {
                Alm1 = 0; // مقدار پیش‌فرض در صورت نبودن رکورد
                Alm2 = 0; // مقدار پیش‌فرض در صورت نبودن رکورد
            }
        }
        public DataTable AlarmDocuments(string today, int from, int to)
        {
            SqlCommand cmd = new SqlCommand("dbo.AlarmDocuments");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Today", today);
            cmd.Parameters.AddWithValue("@From", from);
            cmd.Parameters.AddWithValue("@To", to);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

    }
}
