using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Details
    {
        public Details()
        {
            Delstatus = false;
        }
        public int id { get; set; }
        public double DetailValue1 { get; set; }
        public int DetailValue2 { get; set; }
        public int DefaultPrice { get; set; }
        public int DetailPrice { get; set; }
        public bool DetailExit { get; set; }
        public int FactorId { get; set; }
        public int? DepotId { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public bool Delstatus { get; set; }

    }
}
