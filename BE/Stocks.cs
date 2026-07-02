using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Stocks
    {
        public Stocks()
        {
            DelStatus = false;
        }
        public int id { get; set; }
        public string RegDate { get; set; }
        public string Description { get; set; }
        public int StockIn { get; set; }
        public int StockOut { get; set;}
        public int? FactorId { get; set; }
        public int? DepotId { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public bool DelStatus { get; set; }

    }
}
