using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EmailPanel
    {
        public EmailPanel() 
        {
            Delstatus = false;
        }
        public int id { get; set; }
        public string EmailSender { get; set; }
        public string Password { get; set; }

        public string Regdate { get; set; }
        public bool Delstatus { get; set; }

    }
}
