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
    public class BLLsetting
    {
        DALsetting dal = new DALsetting();
        public bool Exictsetting()
        {
            return dal.Exictsetting();
        }
        public string Create(Setting s)
        {
            return dal.Create(s);
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public Setting ReadId(int id)
        {
            return dal.ReadId(id);
        }
        public string Update(int id, Setting s)
        {
            return dal.Update(id, s);
        }
        public string SettingCount()
        {
            return dal.SettingCount();
        }
        public bool GetSettingFactorSend()
        {
            return dal.GetSettingFactorSend();
        }
        public void GetFactorDetails(out string factorAddress, out string factorTel, out string depotAddress, out string depotTel, out string CompanyName)
        {
            dal.GetFactorDetails(out factorAddress, out factorTel, out depotAddress, out depotTel, out CompanyName);
        }
        public void GetAlarmSetting(out int Alm1, out int Alm2)
        {
            dal.GetAlarmSetting(out Alm1, out Alm2);
        }
        public DataTable AlarmDocuments(string today, int from, int to)
        {
            return dal.AlarmDocuments(today, from, to);
        }
    }
}
