using BE;
using BE.Logging;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLProducts
    {
        DALProducts dal = new DALProducts();

        /// <summary>
        /// True if a product with the same code and name already exists.
        /// </summary>
        public bool IsDuplicateProduct(Products P)
        {
           return dal.IsDuplicateProduct(P);
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

        /// <summary>
        /// Copies a product image into the app's local Propic folder, named
        /// after the product code, and returns the stored path. Moved here
        /// from FrmAddProduct.SavePic so the presentation layer only wires
        /// up the OpenFileDialog and doesn't own the storage convention.
        /// Behavior (folder layout, naming, and swallow-and-report-error on
        /// failure) is unchanged from the original form code.
        /// </summary>
        public string SaveProductImage(string sourceFilePath, string productCode)
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Propic");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string destinationPath = Path.Combine(folder, productCode + ".JPG");
            try
            {
                File.Copy(sourceFilePath, destinationPath, true);
            }
            catch (Exception e)
            {
                AppLogger.LogError($"BLLProducts.SaveProductImage(productCode='{productCode}')", e);
                throw;
            }

            return destinationPath;
        }
    }
}
