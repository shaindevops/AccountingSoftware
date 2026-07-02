using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALPosDevice
    {
        DB db = new DB();

        public string Create(PosDevice PD)
        {
            db.PosDevices.Add(PD);
            db.SaveChanges();
            return "The EFTPos device is registered successfully";
        }

        public PosDevice ReadId(int id)
        {
            // کد برای دریافت اطلاعات دستگاه بر اساس شناسه
            return db.PosDevices.Where(i => i.id == id).FirstOrDefault();
        }
        public DataTable FillDevices()
        {
            string cmd = "SELECT        TOP (100) PERCENT id, DeviceName, DeviceType, PortName, BaudRate, IsDefault, Status\r\nFROM            dbo.PosDevices\r\nORDER BY DeviceName";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillEFTPOS()
        {
            string cmd = "SELECT        TOP (100) PERCENT id, DeviceName, DeviceType, PortName, BaudRate, IsDefault, Status FROM dbo.PosDevices WHERE(DeviceType = N'EFTPOS') ORDER BY DeviceName";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable FillPrinter()
        {
            string cmd = "SELECT        TOP (100) PERCENT id, DeviceName, DeviceType, PortName, BaudRate, IsDefault, Status FROM dbo.PosDevices WHERE(DeviceType = N'Printer') ORDER BY DeviceName";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string Update(int id, PosDevice PD)
        {
            var q = db.PosDevices.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.DeviceName = PD.DeviceName;
                q.DeviceType = PD.DeviceType;
                q.PortName = PD.PortName;
                q.BaudRate = PD.BaudRate;
                q.IsDefault = PD.IsDefault;
                q.Status = PD.Status;
                db.SaveChanges();
                return "The info of device are edited successfully";
            }
            else
            {
                return "The info of device are not found";
            }
        }

        public string Delete(int id)
        {
            var q = db.PosDevices.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                db.PosDevices.Remove(q);
                db.SaveChanges();
                return "The device deleted successfully";
            }
            else
            {
                return "The device not found";
            }
        }

        public string GetDefaultPos()
        {
            return db.PosDevices.Where(i => i.IsDefault == true && i.DeviceType == "EFTPOS").Select(i => i.DeviceName).FirstOrDefault();
        }
        public string GetDefaultPrinter()
        {
            return db.PosDevices.Where(i => i.IsDefault == true && i.DeviceType == "Printer").Select(i => i.DeviceName).FirstOrDefault();
        }

    }
}
