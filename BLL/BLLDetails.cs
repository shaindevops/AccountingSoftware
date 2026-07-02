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
    public class BLLDetails
    {
        DALDetails dal = new DALDetails();

        public string Create(Details D, int FactorId, int DepotId, int ProductId)
        {
            return dal.Create(D, FactorId, DepotId, ProductId);
        }

        public DataTable FillDetailsByFactId(int FactorId)
        {
            return dal.FillDetailsByFactId(FactorId);
        }
        public string UpdateDetail(int DetailId, int? DepotId)
        {
            return dal.UpdateDetail(DetailId, DepotId);
        }
    }
}
