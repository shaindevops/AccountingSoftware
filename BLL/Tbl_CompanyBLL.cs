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
    public class Tbl_CompanyBLL
    {
        Tbl_CompanyDAL dal = new Tbl_CompanyDAL();
        public bool ExistCompany()
        {
            return dal.ExistCompany();
        }
        public bool Read(Tbl_Company com)
        {
            return dal.Read(com);
        }
        public string Create(Tbl_Company com)
        {
            return dal.Create(com);
        }
        public string GenerateCode(Tbl_Company com)
        {
            return dal.GenerateCode(com);
        }
        public Tbl_Company ReadID(int id)
        {
            return dal.ReadID(id);
        }
        public DataTable ReadList()
        {
            return dal.ReadList();
        }
        public string ReadComName(Tbl_Company C)
        {
            return dal.ReadComName(C);
        }
        public string ReadComOwner(Tbl_Company C)
        {
            return dal.ReadComOwner(C);
        }
        public string ReadComLogo(Tbl_Company C)
        {
            return dal.ReadComLogo(C);
        }
        public Tbl_Company ReadN(string s)
        {
            return dal.ReadN(s);
        }
    }
}
