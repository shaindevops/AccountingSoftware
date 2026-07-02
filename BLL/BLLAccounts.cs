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
    public class BLLAccounts
    {

        DALAccounts dal = new DALAccounts();

        public bool ExistAccount(Accounts A)
        {
            return dal.ExistAccount(A);
        }
        public string Create(Accounts A, int PersonId)
        {
            return dal.Create(A, PersonId);
        }
        public Accounts ReadId(int id)
        {
            return dal.ReadId(id);
        }
        public DataTable FillAccounts()
        {
            return dal.FillAccounts();
        }
        public DataTable FillAccountsBYType0()
        {
            return dal.FillAccountsBYType0();
        }
        public DataTable FillAccountsBYType1()
        {
            return dal.FillAccountsBYType1();
        }
        public string Update(int id, Accounts CG)
        {
            return dal.Update(id, CG);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public Accounts ReadN(string A)
        {
            return dal.ReadN(A);
        }
    }
}
