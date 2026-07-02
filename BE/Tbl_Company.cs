using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tbl_Company
    {
        public Tbl_Company() 
        {
            Comstatus = false;
        }

        public int id { get; set; }
        public string code { get; set; }
        public string Comname { get; set; }
        public string Comowner { get; set; }
        public string Comcurrency { get; set; }
        public string Comeconimiccode { get; set; }
        public string Comregnumber { get; set; }
        public string Comphone { get; set; }
        public string Comemail { get; set; }
        public string Comzipcode { get; set; }
        public string Comprovince { get; set; }
        public string Comcity { get; set; }
        public string Comaddress { get; set; }
        public string Comlogo { get; set; }
        public DateTime Comsysregdate { get; set; }
        public DateTime Comsysregtime { get; set; }
        public bool Comstatus { get; set; }
        public List<Setting> Settings { get; set; } = new List<Setting>();

    }
}
