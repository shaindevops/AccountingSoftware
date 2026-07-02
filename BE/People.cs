using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class People
    {
        public People() 
        {
            Delstatus = false;
        }
        public int id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Debtor { get; set; }
        public int Creditor { get; set; }
        public string Regdate { get; set; }
        public bool Delstatus { get; set; }
        public List<Accounts> Accounts { get; set; } = new List<Accounts>();
        public List<AccountBook> AccountBooks { get; set; } = new List<AccountBook>();
        public List<Factors> Factors { get; set; } = new List<Factors>();
        public List<Documents> Documents { get; set; } = new List<Documents>();
        public List<Orders> Orders { get; set; } = new List<Orders>();
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
