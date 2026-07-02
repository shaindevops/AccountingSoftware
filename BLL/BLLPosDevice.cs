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
    public class BLLPosDevice
    {
        DALPosDevice dal =  new DALPosDevice();

        public string Create(PosDevice PD)
        {
            return dal.Create(PD);
        }

        public PosDevice ReadId(int id)
        {
            // کد برای دریافت اطلاعات دستگاه بر اساس شناسه
            return dal.ReadId(id);
        }
        public DataTable FillDevices()
        {
            return dal.FillDevices();
        }
        public DataTable FillEFTPOS()
        {
            return dal.FillEFTPOS();
        }
        public DataTable FillPrinter()
        {
            return dal.FillPrinter();
        }

        public string Update(int id, PosDevice PD)
        {
            return dal.Update(id, PD);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }

        public string GetDefaultPos()
        {
            return dal.GetDefaultPos();
        }
        public string GetDefaultPrinter()
        {
            return dal.GetDefaultPrinter();
        }
    }
}
