using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SendEmail
    {
        public int id { get; set; }
        public string From { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string File { get; set; }
        public string Regdate { get; set; }
    }
}
