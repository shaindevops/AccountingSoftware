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
    public class DALSendSms
    {
        DB db = new DB();

        //public string SendSMS(string SID, string AuthKey, string Sender, string To, string Body)
        //{
        //    try
        //    {
        //        var AccountSID = SID;
        //        var AuthToken = AuthKey;
        //        TwilioClient.Init(AccountSID, AuthToken);

        //        var messageOptions = new CreateMessageOptions(new PhoneNumber(To))
        //        {
        //            From = new PhoneNumber(Sender),
        //            Body = Body
        //        };

        //        var message = MessageResource.Create(messageOptions);
        //        return $"Message sent successfully. Message text : {message.Body}";
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"Error sending SMS: {ex.Message}";
        //    }
        //}


        public string Create(SendSMS sms)
        {

            db.SendSMS.Add(sms);
            db.SaveChanges();
            return "Sms is registered successfully";
        }

        public SendSMS ReadId(int id)
        {
            return db.SendSMS.Where(i => i.id ==  id).FirstOrDefault();
        }

        public string UpdateSms(int id, SendSMS sms)
        {
            var q = db.SendSMS.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.PanelName = sms.PanelName;
                q.SID = sms.SID;
                q.AuthKey = sms.AuthKey;
                q.SenderNumber = sms.SenderNumber;
                q.Tonumber = sms.Tonumber;
                q.SmsBody = sms.SmsBody;
                q.Status = sms.Status;
                q.SendDate = sms.SendDate;
                q.SmsId = sms.SmsId;
                db.SaveChanges();
                return "SMS status has been edited successfully";
            }
            else
            {
                return "Unfortunately, there was no SMS with this code!!!";
            }
        }

        public DataTable FillSendedSms()
        {
            string cmd = "SELECT        TOP (100) PERCENT dbo.SendSMS.id, dbo.SendSMS.SmsPanel_id, dbo.SendSMS.PanelName, dbo.SendSMS.SID, dbo.SendSMS.AuthKey, dbo.SendSMS.SenderNumber AS [Sender Number], \r\n                         dbo.SendSMS.Tonumber AS [Receiver Number], dbo.SendSMS.SmsBody AS [Message Text], dbo.SendSMS.SendDate AS [Send Date], dbo.SendSMS.SmsId AS [Message Code]\r\nFROM            dbo.SendSMS \r\nORDER BY [Send Date]";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
