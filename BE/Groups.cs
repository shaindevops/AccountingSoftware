using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Groups
    {
        public Groups() 
        {
            DelStatuse = false;
        }
        public int id { get; set; }
        public string Name { get; set; }
        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public string Regdate { get; set; }
        public bool DelStatuse { get; set; }
        public List<Products> Products { get; set; } = new List<Products>();
    }
}
