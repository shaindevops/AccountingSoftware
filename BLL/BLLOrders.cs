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
    public class BLLOrders
    {
        DALOrders dal = new DALOrders();

        public bool ExistOrderNumber(Orders Number)
        {
            return dal.ExistOrderNumber(Number);
        }
        
        public string Create(Orders O, int PersonId)
        {
            return dal.Create(O, PersonId);
        }

        public Orders ReadId(int id)
        {
            return dal.ReadId(id);
        }

        public string DeleteOrder(int id)
        {
            return dal.DeleteOrder(id);
        }
        public int GetOrderId()
        {
            return dal.GetOrderId();
        }
        public string GetMaxOrderNumber()
        {
            return dal.GetMaxOrderNumber();
        }
        public DataTable FilterOrderByDate(string Date1, string Date2)
        {
            return dal.FilterOrderByDate(Date1, Date2);
        }

        public DataTable FillViewOrderDetails(int OrderId)
        {
            return dal.FillViewOrderDetails(OrderId);
        }
        public DataTable FillOrderByStatus(string Status)
        {
            return dal.FillOrderByStatus(Status);
        }
        public string UpdateStatus(int id, Orders O)
        {
            return dal.UpdateStatus(id, O);
        }
    }
}
