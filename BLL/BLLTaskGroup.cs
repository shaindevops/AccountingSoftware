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
    public class BLLTaskGroup
    {
        DALTaskGroup dal = new DALTaskGroup();
        public string Create(TaskGroup TG)
        {
            return dal.Create(TG);
        }
        public TaskGroup ReadId(int id)
        {
            return dal.ReadId(id);
        }
        public DataTable FillTaskGroup()
        {
            return dal.FillTaskGroup();
        }
        public string Update(int id, TaskGroup TG)
        {
            return dal.Update(id, TG);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public List<string> ReadTaskGroupTitle()
        {
            return dal.ReadTaskGroupTitle();
        }
        public TaskGroup ReadTaskGroupTitle(string s)
        {
            return dal.ReadTaskGroupTitle(s);
        }
    }
}
