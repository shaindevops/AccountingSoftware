using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Products
    {
        public Products()
        {
            DelStatus = false;
        }
        public int id { get; set; }
        public string Image { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public int DefaultPrice { get; set; }
        public string Description { get; set; }
        public int Alarm { get; set; }
        public string Regdate { get; set; }
        public bool DelStatus { get; set; }
        public string GroupName { get; set; }
        public Groups Group {  get; set; }
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public List<Stocks> Stocks { get; set; } = new List<Stocks>();
        public List<Details> Details { get; set; } = new List<Details>();

    }
}
