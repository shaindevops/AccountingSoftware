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
    public class BLLAccountBook
    {
        DALAccountBook dal = new DALAccountBook();

        public string Create(AccountBook AB, int AccountId, int CostGroupId, int PersonId)
        {
            return dal.Create(AB, AccountId, CostGroupId, PersonId);
        }
        public DataTable FillAccountBook(int AccountId)
        {
            return dal.FillAccountBook(AccountId);
        }

        public DataTable FilterAccountBookByDate(int AccountId, string FromDate, string ToDate)
        {
            return dal.FilterAccountBookByDate(AccountId, FromDate, ToDate);
        }
        public DataTable FillBookByPerson(int PersonId)
        {
            return dal.FillBookByPerson(PersonId);
        }
        public AccountBook ReadId(int id)
        {
            return dal.ReadId(id);
        }

        public string Update(int id, AccountBook AB)
        {
            return dal.Update(id, AB);
        }
        public string Delete(int id)
        {
           return dal.Delete(id);
        }
        public int GetSumAccountBook(int accountId)
        {
            return dal.GetSumAccountBook(accountId);
        }
        public void GetSumBookByPerson(int personId, out int SumBuy, out int SumSale)
        {
           dal.GetSumBookByPerson(personId, out SumBuy, out SumSale);
        }
    }

}
