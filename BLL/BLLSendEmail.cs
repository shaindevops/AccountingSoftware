using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;

namespace BLL
{
    public class BLLSendEmail
    {
        DALSendEmail dal = new DALSendEmail();

        public string SendEmail(string From, string Password, string DisplayName, string To, string Subject, string Body, string fileName)
        {
            return dal.SendEmail(From, Password, DisplayName, To, Subject, Body, fileName);
        }

        public string Create(SendEmail SE)
        {
            return dal.Create(SE);
        }

        public void DeletePastEmail()
        {
            dal.DeletePastEmail();
        }
        public DataTable FillSendEmailsByPanelId(string Sender, string Date1, string Date2)
        {
            return dal.FillSendEmailsByPanelId(Sender, Date1, Date2);
        }
    }
}
