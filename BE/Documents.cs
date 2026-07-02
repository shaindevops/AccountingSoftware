using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Documents
    {
        public Documents()
        {
            Delstatus = false;
            Ok = false;
        }

        public int id { get; set; }
        public string Date1 { get; set; }
        public string Date2 { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Ok { get; set; }

        public bool Delstatus { get; set; }
        public Accounts Accounts { get; set; }
        public CostGroup CostGroup { get; set; }
        public People People { get; set; }
    }
}
