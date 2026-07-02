using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Depots
    {
        public Depots() 
        {
            DelStatus = false;
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Regdate { get; set; }
        public bool DelStatus { get; set; }
        public List<Stocks> Stocks { get; set; } = new List<Stocks>();
        public List<Details> Details { get; set; } = new List<Details>();
    }
}
