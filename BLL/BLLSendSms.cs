using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLSendSms
    {
        DALSendSms dal = new DALSendSms();

        //public string SendSMS(string SID, string AuthKey, string Sender, string To, string Body)
        //{
        //    return dal.SendSMS(SID, AuthKey, Sender, To, Body);
        //}

        public string Create(SendSMS sms)
        {
            return dal.Create(sms);
        }
        public SendSMS ReadId(int id)
        {
            return dal.ReadId(id);
        }
        public string UpdateSms(int id, SendSMS sms)
        {
            return dal.UpdateSms(id, sms);
        }

        public DataTable FillSendedSms()
        {
            return dal.FillSendedSms();
        }
    }
}
