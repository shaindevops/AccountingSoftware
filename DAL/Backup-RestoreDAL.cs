using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Backup_RestoreDAL
    {
        public string Backup(string Path)
        {
            SqlConnection con = new SqlConnection("data source=.; initial catalog=SpadanDB; integrated security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"Backup Database SpadanDB To Disk = '" + Path + @"\BackUp.bak'";
            cmd.ExecuteNonQuery();
            con.Close();
            return "Congratulations!!\n\nThe backup operation was completed successfully";
        }
        public string Restore(string Path)
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=.; initial catalog=master; integrated security=true");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"Restore Database SpadanDB From Disk = '" + Path + "' with replace";
                cmd.ExecuteNonQuery();
                con.Close();
                return "Congratulations!!\n\nThe restore operation was completed successfully";
            }
            catch (Exception m)
            {

                return m.Message;
            }
            
        }
    }
}
