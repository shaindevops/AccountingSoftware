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
    public class BLLUserlog
    {
        DALUserlog dal = new DALUserlog();
        public void Create(UserLogs ul, int u)
        {
            dal.Create(ul, u);
        }
        public int ReadId()
        {
            return dal.ReadId();
        }
        public UserLogs Getlogid(int logid, int userid)
        {
            return dal.Getlogid(logid, userid);
        }
        public DataTable Read(int userid)
        {
            return dal.Read(userid);
        }
        public void Update(int logid, string logout)
        {
           dal.Update(logid, logout);
        }
    }
}
