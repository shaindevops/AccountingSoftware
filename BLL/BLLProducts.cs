using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLProducts
    {
        DALProducts dal = new DALProducts();
        public bool ExistProduct(Products P)
        {
           return dal.ExistProduct(P);
        }
        public string Create(Products P, int ProductGroupId)
        {
            return dal.Create(P, ProductGroupId);
        }
        public Products ReadId(int id)
        {
            return dal.ReadId(id);
        }
        public DataTable FillGridProducts()
        {
            return dal.FillGridProducts();
        }
        public DataTable SearchProducts(string P)
        {
            return dal.SearchProducts(P);
        }
        public DataTable SearchProductsBYGroup(string G, string P)
        {
            return dal.SearchProductsBYGroup(G, P);
        }
        public string Update(int id, Products P)
        {
            return dal.Update(id, P);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public string ProductCount()
        {
            return dal.ProductCount();
        }
        public Products ProductName(string Name)
        {
            return dal.ProductName(Name);
        }
    }
}
