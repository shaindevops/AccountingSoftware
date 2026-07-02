using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALOrderDetails
    {
        DB db =new DB();

        public string Create(OrderDetails OD, int OrderId, int ProductId)
        {
            var order = db.Orders.FirstOrDefault(o => o.id == OrderId);
            if (order != null)
            {
                OD.OrderId = order.id;
            }

            var product = db.Products.FirstOrDefault(o => o.id == ProductId);
            if(product != null)
            {
                OD.Product = product;
            }

            db.OrderDetails.Add(OD);
            db.SaveChanges();
            return "The order details have been registered successfully";
        }

        public DataTable FillOrderDetailsByOrderId(int OrderId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.FillOrderDetailsByOrderId");
                SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
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
    }
}
