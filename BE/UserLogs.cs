using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UserLogs
    {
        public UserLogs() 
        {
            Delstatus = false;
        }
        public int id { get; set; }
        public string LogIn { get; set; }
        public string LogOut { get; set; }
        public string Username { get; set; }
        public Users User { get; set; }

        public bool Delstatus { get; set; }
    }
}
