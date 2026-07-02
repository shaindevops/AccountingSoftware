using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALTaxs
    {
        DB db = new DB();

        public bool ExistTax()
        {
            return db.Taxs.Any();
        }

        public string UpdateandCreateTax(double BUy, double Sale)
        {
            var q = db.Taxs.Where(i => i.TaxBuy ==  BUy && i.TaxSale == Sale).FirstOrDefault();
            if (q != null)
            {
                q.TaxBuy = BUy;
                q.TaxSale = Sale;
                db.SaveChanges();
                return "Tax edited successfully";
            }
            else
            {
                db.Taxs.Add(new Tax { TaxBuy = BUy, TaxSale = Sale });
                db.SaveChanges();
                return "Tax created successfully";
            }
        }

        public DataTable FillTax()
        {
            string cmd = "SELECT id, TaxBuy AS [Tax Buy], TaxSale AS [Tax Sale]\r\nFROM dbo.Taxes";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public void GetDefaultTax(out double saleTax, out double buyTax)
        {
            var taxes = db.Taxs.FirstOrDefault();

            if (taxes != null)
            {
                saleTax = (double)taxes.TaxSale;
                buyTax = (double)taxes.TaxBuy;
            }
            else
            {
                saleTax = 0;
                buyTax = 0;
            }
        }
    }
}
