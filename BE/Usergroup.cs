using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usergroup
    {
        public int id { get; set; }
        public string Title { get; set; }
        public List<Users> Users { get; set; } = new List<Users>();
        public List<Userroles> Roles { get; set; } = new List<Userroles>();
    }
}
