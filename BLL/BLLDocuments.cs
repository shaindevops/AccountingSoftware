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
    public class BLLDocuments
    {
        DALDocuments dal = new DALDocuments();

        public bool ExistDocNumber(Documents D)
        {
            return dal.ExistDocNumber(D);
        }
        public string Create(Documents D, int AccountId, int CostGroupId)
        {
            return dal.Create(D, AccountId, CostGroupId);
        }

        public Documents ReadId(int id)
        {
            return dal.ReadId(id);
        }

        public DataTable FillDocumentNotPass()
        {
            return dal.FillDocumentNotPass();
        }

        public DataTable FillDocumentPass()
        {
            return FillDocumentPass();
        }

        public DataTable FilterDocumentIncomeByNumber(string Num)
        {
            return dal.FilterDocumentIncomeByNumber(Num);
        }
        public DataTable FilterDocumentPayByNumber(string Num)
        {
            return dal.FilterDocumentPayByNumber(Num);
        }
        public DataTable FillDocumentsByPerson(int PersonId)
        {
            return dal.FillDocumentsByPerson(PersonId);
        }
        public string Update(int id, Documents D)
        {
            return dal.Update(id, D);
        }
        public string UpdateDocPass(int id)
        {
            return dal.UpdateDocPass(id);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public void GetSumDocumentByPerson(int personId, out int SumBuy, out int SumSale)
        {
            dal.GetSumDocumentByPerson(personId, out SumBuy, out SumSale);
        }
    }
}
