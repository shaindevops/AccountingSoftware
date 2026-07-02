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
    public class BLLCostGroup
    {
        DALCostGroup dal = new DALCostGroup();

        public string Create(CostGroup CG)
        {
           return dal.Create(CG);
        }
        public CostGroup ReadId(int id)
        {
            return dal.ReadId(id);
        }
        public CostGroup ReadId28(int id)
        {
            return dal.ReadId28(id);
        }
        public CostGroup ReadId29(int id)
        {
            return dal.ReadId29(id);
        }
        public DataTable FillCostGroup()
        {
            return dal.FillCostGroup();
        }
        public DataTable FillCostGroupBYTypeIncome()
        {
            return dal.FillCostGroupBYTypeIncome();
        }
        public DataTable FillCostGroupBYTypeCosts()
        {
            return dal.FillCostGroupBYTypeCosts();
        }
        public string Update(int id, CostGroup CG)
        {
           return dal.Update(id, CG);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public CostGroup ReadN(string CG)
        {
            return dal.ReadN(CG);
        }
        public bool GetCostGroupStatus(int id)
        {
            return dal.GetCostGroupStatus(id);
        }
    }
}
