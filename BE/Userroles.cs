using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Userroles
    {
        public int id { get; set; }
        public string section { get; set; }
        public bool canenter { get; set; }
        public bool cancreate { get; set; }
        public bool canedit { get; set; }
        public bool candelete { get; set; }
        public Usergroup Usergroup { get; set; }
    }
}
