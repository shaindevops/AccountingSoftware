using BE;
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
        DB db = new DB();

        public void Create(UserLogs ul, int u)
        {
            var user = new Users { id = u };
            db.Users.Attach(user);
            ul.User = user;

            db.UserLogs.Add(ul);
            db.SaveChanges();
        }
        public int ReadId()
        {
            return db.UserLogs.OrderByDescending(i => i.id).Select(i => i.id).FirstOrDefault();
        }
        public UserLogs Getlogid(int logid, int userid)
        {
            var q = db.UserLogs.Include("User").Where(i => i.User.id == userid).Where(i => i.id == logid).OrderByDescending(i=> logid).FirstOrDefault();
            if (q != null)
            {
                return q;
            }
            else
            {
                return null;
            }
        }
        public DataTable Read(int userid)
        {
            string cmd = "SELECT  Distinct  TOP (100) PERCENT id, User_id, LogIn AS [Login Date and Time], LogOut AS [Log Out Date and Time], Username\r\nFROM            dbo.UserLogs\r\nWHERE        (User_id = " + userid+")\r\nORDER BY id DESC";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public void Update(int logid, string logout)
        {
            logid = ReadId();
            var q = db.UserLogs.Where(i => i.id == logid).OrderByDescending(i => i.id).FirstOrDefault();
            if (q != null)
            {
                q.LogOut = logout;
                db.SaveChanges();
            }
        }
    }
}
