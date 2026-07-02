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
    public class BLLSmsPanel
    {
        DALSmsPanel dal = new DALSmsPanel();

        public string Create(SmsPanel SP)
        {
            return dal.Create(SP);
        }

        public SmsPanel ReadId(int id)
        {
            return dal.ReadId(id);
        }

        public string Update(int id, SmsPanel SP)
        {
            return dal.Update(id, SP);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }

        public DataTable FillSmsPanel()
        {
            return dal.FillSmsPanel();
        }
    }
}
