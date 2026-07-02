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
    public class BLLUsergroup
    {
        DALUsergroup dal = new DALUsergroup();
        public string Create(Usergroup UG)
        {
            return dal.Create(UG);
        }
        public bool Read(string name)
        {
            return dal.Read(name);
        }
        public List<string> ReadUGNames()
        {
            return dal.ReadUGNames();
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public Usergroup Read(int id)
        {
            return dal.Read(id);
        }
        public Usergroup ReadN(string s)
        {
            return dal.ReadN(s);
        }
        public DataTable ReadTitle(string ug)
        {
            return dal.ReadTitle(ug);
        }
        public string Usergroupcount()
        {
            return dal.Usergroupcount();
        }
    }
}
