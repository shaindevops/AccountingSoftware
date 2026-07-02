using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Messages
    {
        public Messages()
        {
            Delstatus = false;
        }
        public int id { get; set; }
        public string MessageText { get; set; }
        public bool Delstatus { get; set; }
    }
}
