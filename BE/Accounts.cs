using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Accounts
    {
        public Accounts() 
        {
            Delstatus = false;
        }
        public int id { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountPerson { get; set; }
        public bool AccountType { get; set; }
        public string Regdate { get; set; }
        public bool Delstatus { get; set; }
        public People People { get; set; }
        public List<AccountBook> AccountBooks { get; set; } = new List<AccountBook>();
        public List<Documents> Documents { get; set; } = new List<Documents>();
    }
}
