using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CostGroup
    {
        public CostGroup()
        {
            Delstatus = false;
        }
        public int id { get; set; }
        public bool Type { get; set; }
        public bool Static { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Regdate { get; set; }
        public bool Delstatus { get; set; }
        public List<AccountBook> AccountBooks { get; set; } = new List<AccountBook>();
        public List<Documents> Documents { get; set; } = new List<Documents>();
    }
}
