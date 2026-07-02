using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SmsPanel
    {
        public int id { get; set; }
        public string PanelName { get; set; }
        public string PanelSID { get; set; }
        public string PanelAuthKey { get; set; }
        public string PanelNumber { get; set; }
        public List<SendSMS> SendSMS { get; set; } = new List<SendSMS>();
    }
}
