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
    public class BLLDepot
    {
        DALDepot dal = new DALDepot();
        /// <summary>
        /// True if a Depot with this name already exists.
        /// </summary>
        public bool IsDuplicateDepot(Depots D)
        {
            return dal.IsDuplicateDepot(D);
        }
        public string Create(Depots D)
        {
            return dal.Create(D);
        }
        public Depots ReadId(int id)
        {
            return dal.ReadId(id);
        }
        public DataTable ReadFillGrid()
        {
            return dal.ReadFillGrid();
        }
        public DataTable FillDepotByProducts(int ProducId)
        {
            return dal.FillDepotByProducts(ProducId);
        }
        public string Update(int id, Depots D)
        {
            return dal.Update(id, D);
        }
        public string DeleteDepot(int id)
        {
            return dal.DeleteDepot(id);
        }
        public string CountDepot()
        {
            return dal.CountDepot();
        }
        public Depots DepotName(string Name)
        {
            return dal.DepotName(Name);
        }
        public int GetDefaultDepotId()
        {
            return dal.GetDefaultDepotId();
        }
    }
}
