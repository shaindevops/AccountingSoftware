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
    public class BLLStocks
    {
        DALStocks dal = new DALStocks();

        public string Create(Stocks S, int FactorId, int DepotId, int ProductId)
        {
            return dal.Create(S, FactorId, DepotId, ProductId);
        }

        public Stocks ReadId(int id)
        {
            return dal.ReadId(id);
        }

        public string UpdateStock(int id, Stocks S)
        {
            return dal.UpdateStock(id, S);
        }
        public string DeleteStock(int id)
        {
            return dal.DeleteStock(id);
        }

        public DataTable FillStock()
        {
            return dal.FillStock();
        }
        public DataTable FilterStockByIds(int DepotId, int ProductId)
        {
            return dal.FilterStockByIds(DepotId, ProductId);
        }

        public DataTable FilterStock(string Name)
        {
            return dal.FilterStock(Name);
        }
        public int GetProductSttockInDepot(int? DepotId, int ProductId)
        {
            return dal.GetProductSttockInDepot(DepotId, ProductId);
        }
        public DataTable FillStockAlerm()
        {
            return dal.FillStockAlerm();
        }
    }
}
