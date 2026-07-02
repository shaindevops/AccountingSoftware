using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Orders
    {
        public int id { get; set; }
        public string OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string OrderDescription { get; set; }
        public string StatusType { get; set; }
        public People People { get; set; }
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
