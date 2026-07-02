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
    public class BLLGroups
    {
        DALGroups dal = new DALGroups();
        public string Create(Groups G)
        {
            return dal.Create(G);
        }
        public Groups ReadId(int id)
        {
            return dal.ReadId(id);
        }
        public DataTable ReadFillGroup()
        {
            return dal.ReadFillGroup();
        }
        public string Update(int id, Groups G)
        {
            return dal.Update(id, G);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public string GroupCount()
        {
            return dal.GroupCount();
        }
        public List<string> GroupName()
        {
            return dal.GroupName();
        }
        public Groups GName(string G)
        {
            return dal.GName(G);
        }
        public void GetGroupUnit(int productId, out string unit1, out string unit2)
        {
            dal.GetGroupUnit(productId, out unit1, out unit2);
        }
    }
}
