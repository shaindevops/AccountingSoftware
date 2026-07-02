using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Users
    {
        public Users() 
        {
            DelStatus = false;
        }
        public int id { get; set; }
        public string Fullname { get; set; }
        public string PhoneNo { get; set; }
        public string NationalID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public string pic { get; set; }
        public DateTime Regdate { get; set; }
        public bool DelStatus { get; set; }
        public bool IsActive { get; set; }
        public Usergroup Usergroup { get; set; }
        public List<UserLogs> UserLogs { get; set; } = new List<UserLogs>();
        public List<int> EmailPanel { get; set; } = new List<int>();
        public List<int> Factors { get; set; } = new List<int>();
    }
}
