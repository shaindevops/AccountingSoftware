using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SendSMS
    {
        public int id { get; set; }
        public string PanelName { get; set; }
        public string SID { get; set; }
        public string AuthKey { get; set; }
        public string SenderNumber { get; set; }
        public string Tonumber { get; set; }
        public string SmsBody { get; set; }
        public string Status {  get; set; }
        public string SendDate { get; set; }
        public string SmsId { get; set; }

    }
}
