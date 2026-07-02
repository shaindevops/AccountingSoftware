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
    public class DALOrders
    {
        DB db = new DB();

        public bool ExistOrderNumber(Orders Number)
        {
            var q = db.Orders.Where(i => i.OrderNumber == Number.OrderNumber).FirstOrDefault();
            return q != null;
        }
        

        public string Create(Orders O, int PersonId)
        {
            var person = db.People.FirstOrDefault(p => p.id == PersonId);
            if( person != null)
            {
                O.People = person;
            }

            db.Orders.Add(O);
            db.SaveChanges();
            return "The Order Is Registered Successfully";
        }

        public Orders ReadId(int id)
        {
            return db.Orders.Where(i => i.id == id ).FirstOrDefault();
        }

        public string DeleteOrder(int id)
        {
            var q = db.Orders.Include("OrderDetails").Where(i => i.id == id).FirstOrDefault();
            if(q != null)
            {
                db.Orders.Remove(q);
                foreach (var details in q.OrderDetails)
                {
                    db.OrderDetails.Remove(details);
                }
                return "Order Is Cancel Successfully";
            }
            else
            {
                return "Order Not Found";
            }
        }
        public int GetOrderId()
        {
            return db.Orders.Any() ? db.Orders.Max(i => i.id) : 0;
        }
        public string GetMaxOrderNumber()
        {
            var orders = db.Orders;
            return orders.Any() ? orders.Max(i => i.OrderNumber) : "No Factor Found";
        }
        public DataTable FilterOrderByDate(string Date1, string Date2)
        {
            SqlCommand cmd = new SqlCommand("dbo.FilterOrderByDate");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Date1", Date1);
            cmd.Parameters.AddWithValue("@Date2", Date2);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable FillViewOrderDetails(int OrderId)
        {
            SqlCommand cmd = new SqlCommand("dbo.FillViewOrderDetails");
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
        public DataTable FillOrderByStatus(string Status)
        {
            SqlCommand cmd = new SqlCommand("dbo.FillOrderByStatus");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string UpdateStatus(int id, Orders O)
        {
            var q = db.Orders.Where(i => i.id == id).FirstOrDefault();
            if(q != null)
            {
                q.StatusType = O.StatusType;
                db.SaveChanges();
                return "Order is edited successfully";
            }
            else
            {
                return "Order not found";
            }
        }
    }
}
