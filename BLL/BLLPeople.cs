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
    public class BLLPeople
    {
        DALPeople dal = new DALPeople();
        public bool ExistPeople(People P)
        {
            return dal.ExistPeople(P);
        }
        public string Create(People P)
        {
            return dal.Create(P);
        }
        public DataTable ReadFillPeople()
        {
            return dal.ReadFillPeople();
        }

        public DataTable ReadFillNameAndMobile()
        {
            return dal.ReadFillNameAndMobile();
        }
        public DataTable FillPerson1(string PersonName)
        {
            return dal.FillPerson1(PersonName);
        }
        public DataTable ReadFillPeopleById(int id)
        {
            return dal.ReadFillPeopleById(id);
        }
        public DataTable SearchPeople(string P, int Index)
        {
            return dal.SearchPeople(P, Index);
        }
        public People ReadId(int id)
        {
            return dal.ReadId(id);
        }
        public string Update(int id, People P)
        {
            return dal.Update(id, P);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public string PeopleCount()
        {
            return dal.PeopleCount();
        }
        public People ReadN(string P)
        {
            return dal.ReadN(P);
        }
        public List<string> SelectPersonName()
        {
            return dal.SelectPersonName();
        }
        public int GetDebtor(int id)
        {
            return dal.GetDebtor(id);
        }
        public int GetCreditor(int id)
        {
            return dal.GetCreditor(id);
        }
        public void UpdateDebtor(int id, int Debtor)
        {
            dal.UpdateDebtor(id, Debtor);
        }
        public void UpdateCreditor(int id, int Creditor)
        {
            dal.UpdateCreditor(id, Creditor);
        }
    }
}
