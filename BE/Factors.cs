using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Factors
    {
        public Factors()
        {
            DelStatus = false;
        }
        public int id { get; set; }
        public bool FactorType { get; set; }
        public string FactorNumber { get; set; }
        public string FactorDate { get; set; }
        public int FactorPrice { get; set; }
        public double FactorDefaultTax { get; set; }
        public int FactorTaxPrice { get; set; }
        public int FactorServicePrice { get; set; }
        public int FactorDiscountPrice { get; set; }
        public int FactorSumPrice { get; set; }
        public int PersonId { get; set; }
        public People Person { get; set; }
        public List<Details> Details { get; set; } = new List<Details>();
        public bool DelStatus { get; set; }
    }
}
