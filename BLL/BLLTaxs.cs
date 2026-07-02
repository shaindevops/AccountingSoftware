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
    public class BLLTaxs
    {
        DALTaxs dal = new DALTaxs();
        public bool ExistTax()
        {
            return dal.ExistTax();
        }
        public string UpdateandCreateTax(double BUy, double Sale)
        {
            return dal.UpdateandCreateTax(BUy, Sale);
        }

        public DataTable FillTax()
        {
            return dal.FillTax();
        }
        public void GetDefaultTax(out double saleTax, out double buyTax)
        {
            dal.GetDefaultTax(out saleTax, out buyTax);
        }
    }
}
