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
    public class BLLOrderDetails
    {
        DALOrderDetails dal = new DALOrderDetails();
        public string Create(OrderDetails OD, int OrderId, int ProductId)
        {

            return dal.Create(OD, OrderId, ProductId);
        }

        public DataTable FillOrderDetailsByOrderId(int OrderId)
        {
            return dal.FillOrderDetailsByOrderId(OrderId);
        }

    }
}
