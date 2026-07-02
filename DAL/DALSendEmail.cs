using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace DAL
{
    public class DALSendEmail
    {
        DB db = new DB();

        public string SendEmail(string from, string password, string displayName, string to, string subject, string body, string fileName)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;

                // Add attachment if available
                if (!string.IsNullOrEmpty(fileName))
                {
                    mail.Attachments.Add(new Attachment(fileName));
                }

                using (SmtpClient smtpClient = new SmtpClient("mail.spadangallery.com"))
                {
                    smtpClient.Credentials = new NetworkCredential(from, password);
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mail);
                }

                return "The email was successfully sent.";
            }
            catch (Exception ex)
            {
                return $"Error sending email: {ex.Message}";
            }
        }

        public string Create(SendEmail SE)
        {
            db.SendEmail.Add(SE);
            db.SaveChanges();
            return "The email have been registered successfully";
        }

        public void DeletePastEmail()
        {
            var cutoffDate = DateTime.Now.AddDays(-14);

            // انتخاب و حذف ایمیل‌هایی که قبل از تاریخ محاسبه شده ثبت شده‌اند
            var emailsToDelete = db.SendEmail.Where(i => Convert.ToDateTime(i.Regdate) <= cutoffDate);

            db.SendEmail.RemoveRange(emailsToDelete);
            db.SaveChanges();
        }
        public DataTable FillSendEmailsByPanelId(string Sender, string Date1, string Date2)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.FillSendEmailsByPanelId");
                SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Sender", Sender);
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
            catch (Exception)
            {

                return null;
            }
        }
    }
}
