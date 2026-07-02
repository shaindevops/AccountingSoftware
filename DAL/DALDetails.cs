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
    public class DALDetails
    {
        DB db = new DB();

        public string Create(Details D, int FactorId, int DepotId, int ProductId)
        {
            var factor = db.Factors.FirstOrDefault(f => f.id == FactorId);
            if(factor != null)
            {
                D.FactorId = factor.id;
            }
            var depot = db.Depots.FirstOrDefault(d => d.id == DepotId);
            if (depot != null)
            {
                D.DepotId = depot.id;
            }
            else
            {
                D.DepotId = 0;
            }
            var product = db.Products.FirstOrDefault(p => p.id == ProductId);
            if (factor != null)
            {
                D.ProductId = product.id;
                D.Product = product;
            }

            db.Details.Add(D);
            db.SaveChanges();
            return "The factor details have been registered successfully";
        }

        public DataTable FillDetailsByFactId(int FactorId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.FillDetailsByFactId");
                SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@FactorId", FactorId);
                cmd.CommandType = CommandType.StoredProcedure;
                var sqladapter = new SqlDataAdapter();
                sqladapter.SelectCommand = cmd;
                var commandbuilder = new SqlCommandBuilder(sqladapter);
                var ds = new DataSet();
                sqladapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string UpdateDetail(int DetailId, int? DepotId)
        {
            var q = db.Details.Where(i => i.id == DetailId).FirstOrDefault();
            if (q != null)
            {
                q.DepotId = DepotId;
                q.DetailExit = true;
                db.SaveChanges();
                return "The Factor has been successfully verified";
            }
            else
            {
                return "There is no item";
            }
        }
    }
}
