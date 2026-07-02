using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class OrderDetails
    {
        public int id { get; set; }
        public double DetailValue1 { get; set; }
        public int DetailValue2 { get; set; }
        public int OrderId { get; set; }
        public Products Product { get; set; }
    }
}
