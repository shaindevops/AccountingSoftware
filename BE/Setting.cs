using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Setting
    {
        public int id { get; set; }
        public string factoraddress { get; set; }
        public string factortel { get; set; }
        public string depotaddress { get; set; }
        public string depottel { get; set; }
        public string SMSpaneluser { get; set; }
        public string SMSpanelpassword { get; set; }
        public string Smssendernumber { get; set; }
        public int alarm1 { get; set; }
        public int alarm2 { get; set; }
        public bool Banksend { get; set; }
        public bool Factorsend { get; set; }
        public DateTime regdate { get; set; }
        public string comname { get; set; }
        public Tbl_Company company { get; set; }
    }
}
