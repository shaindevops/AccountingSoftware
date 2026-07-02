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
    public class BLLMessages
    {
        DALMessages dal = new DALMessages();
        public string Create(Messages M)
        {
            return dal.Create(M);
        }
        public Messages ReadId(int id)
        {
            return dal.ReadId(id);
        }

        public DataTable FillMessage()
        {
            return dal.FillMessage();
        }
        public string DeleteMessage(int id)
        {
            return dal.DeleteMessage(id);
        }
        public string MessageCount()
        {
            return dal.MessageCount();
        }
        public bool ExistMessage()
        {
            return dal.ExistMessage();
        }
        public void GetRandomMessage(out string MessageText)
        {
            dal.GetRandomMessage(out MessageText);
        }
    }
}
