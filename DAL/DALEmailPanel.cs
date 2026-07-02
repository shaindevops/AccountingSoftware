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
    public class DALEmailPanel
    {
        DB db = new DB();

        public string Create(EmailPanel EP)
        {
            db.EmailPanel.Add(EP);
            db.SaveChanges();
            return "Email have been registered successfully";
        }

        public EmailPanel ReadId(int id)
        {
            return db.EmailPanel.Where(i => i.id == id).FirstOrDefault();
        }

        public string ReadFrom(int id)
        {
            return db.EmailPanel.Where(i => i.id == id).Select(i => i.EmailSender).FirstOrDefault();
        }
        public string ReadPassword(int id)
        {
            return db.EmailPanel.Where(i => i.id == id).Select(i => i.Password).FirstOrDefault();
        }

        public string UpdateEmailPanel(int id, EmailPanel EP)
        {
            var q = db.EmailPanel.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.EmailSender = EP.EmailSender;
                q.Password = EP.Password;
                db.SaveChanges();
                return "This panel is edited successfully";
            }
            else
            {
                return "Panel not found";
            }
        }
        public string DeleteEmailPanel(int id)
        {
            var q = db.EmailPanel.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Delstatus = true;
                db.SaveChanges();
                return "This panel is edited successfully";
            }
            else
            {
                return "Panel not found";
            }
        }

        public string EmailPanelCount()
        {
            return db.EmailPanel.Where(i => i.Delstatus == false).Count().ToString();
        }

        public DataTable FillEmailPanel()
        {
            string cmd = "SELECT        id, EmailSender AS [Email Sender], Password\r\nFROM            dbo.EmailPanels\r\nWHERE        (Delstatus = 0)";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable GetEmailPanel(out string Usernamepanel, out string PassPanel)
        {
            Usernamepanel = "";
            PassPanel = "";

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true"))
            using (SqlCommand cmd = new SqlCommand("dbo.GetEmailPanel", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // پارامترهای خروجی
                SqlParameter user = new SqlParameter("@User", SqlDbType.NVarChar, 100); // فرض شده که نام کاربری رشته است
                user.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(user);

                SqlParameter pass = new SqlParameter("@Pass", SqlDbType.NVarChar, 150); // فرض شده که پسورد رشته است
                pass.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pass);

                // باز کردن اتصال و اجرای پروسیجر
                con.Open();

                // استفاده از SqlDataAdapter برای پر کردن DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                // دریافت مقادیر خروجی
                Usernamepanel = cmd.Parameters["@User"].Value.ToString();
                PassPanel = cmd.Parameters["@Pass"].Value.ToString();

            }
            return dt;
        }
    }
}
