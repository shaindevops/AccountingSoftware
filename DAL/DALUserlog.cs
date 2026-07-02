using BE;
using BE.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DAL
{
    public class DALUserlog
    {
        public void Create(UserLogs ul, int u)
        {
            using (var db = new DB())
            {
                var user = new Users { id = u };
                db.Users.Attach(user);
                ul.User = user;

                db.UserLogs.Add(ul);
                db.SaveChanges();
            }
        }
        public int ReadId()
        {
            using (var db = new DB())
            {
                return db.UserLogs.OrderByDescending(i => i.id).Select(i => i.id).FirstOrDefault();
            }
        }
        public UserLogs Getlogid(int logid, int userid)
        {
            using (var db = new DB())
            {
                return db.UserLogs.Include("User").Where(i => i.User.id == userid).Where(i => i.id == logid).OrderByDescending(i => logid).FirstOrDefault();
            }
        }
        public DataTable Read(int userid)
        {
            const string cmd = "SELECT Distinct TOP (100) PERCENT id, User_id, LogIn AS [Login Date and Time], LogOut AS [Log Out Date and Time], Username\r\nFROM            dbo.UserLogs\r\nWHERE        (User_id = @userid)\r\nORDER BY id DESC";
            try
            {
                using (var con = new SqlConnection(ConnectionHelper.ConnectionString))
                using (var sqlCommand = new SqlCommand(cmd, con))
                {
                    sqlCommand.Parameters.AddWithValue("@userid", userid);
                    using (var sqladapter = new SqlDataAdapter(sqlCommand))
                    {
                        var commandbuilder = new SqlCommandBuilder(sqladapter);
                        var ds = new DataSet();
                        sqladapter.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALUserlog.Read(userid={userid})", e);
                return null;
            }
        }
        public void Update(int logid, string logout)
        {
            using (var db = new DB())
            {
                logid = db.UserLogs.OrderByDescending(i => i.id).Select(i => i.id).FirstOrDefault();
                var q = db.UserLogs.Where(i => i.id == logid).OrderByDescending(i => i.id).FirstOrDefault();
                if (q != null)
                {
                    q.LogOut = logout;
                    db.SaveChanges();
                }
            }
        }
    }
}
