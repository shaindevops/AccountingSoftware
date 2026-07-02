using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALUsers
    {
        DB db = new DB();
        public string Create(Users U, Usergroup UG)
        {
            try
            {
                if (Read(U))
                {
                    U.Usergroup = db.UserGroups.Find(UG.id);
                    db.Users.Add(U);
                    db.SaveChanges();
                    return "The registration of the desired user was done successfully";
                }
                else
                {
                    return "The user is duplicate!!!";
                }
            }
            catch (Exception e)
            {

                return "User registration encountered a problem!!! \n" + e.Message;
            }

        }
        public bool IsRegistered()
        {
            return db.Users.Count() > 0;
        }
        public bool Read(Users U)
        {
            var q = db.Users.Where(i => i.Username == U.Username && i.PhoneNo == U.PhoneNo && i.Email == U.Email).FirstOrDefault();
            if (q == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable Read()
        {
            string cmd = "SELECT DISTINCT \r\n                         dbo.Users.id, dbo.Users.Fullname AS [Full Name], dbo.Users.NationalID AS [National Id], dbo.Users.PhoneNo AS Phone, dbo.Users.Email, dbo.Users.Username, dbo.Users.Regdate AS [Register Date], \r\n                         dbo.Usergroups.Title AS [User Type]\r\nFROM            dbo.Users INNER JOIN\r\n                         dbo.Usergroups ON dbo.Users.Usergroup_id = dbo.Usergroups.id\r\nWHERE        (dbo.Users.DelStatus = 0)";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Read(string u, int index)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.SearchUser");
                if (index == 0)
                {
                    cmd.CommandText = "dbo.SearchUser";
                }
                else if (index == 1)
                {
                    cmd.CommandText = "dbo.SearchUserName";
                }
                else if (index == 2)
                {
                    cmd.CommandText = "dbo.SearchUserPhone";
                }
                else if (index == 3)
                {
                    cmd.CommandText = "dbo.SearchUserNationalId";
                }
                else if (index == 4)
                {
                    cmd.CommandText = "dbo.SearchUserGroup";
                }
                SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@search", u);
                cmd.CommandType = CommandType.StoredProcedure;
                var sqladapter = new SqlDataAdapter();
                sqladapter.SelectCommand = cmd;
                var commandbuilder = new SqlCommandBuilder(sqladapter);
                var ds = new DataSet();
                sqladapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Users Read(int id)
        {
            return db.Users.Where(i => i.id == id).FirstOrDefault();
        }
        public Users ReadU(string s)
        {
            return db.Users.Where(i => i.Fullname == s).SingleOrDefault();
        }
        public List<string> ReadUserName()
        {
            return db.Users.Where(i => i.DelStatus == false).Select(i => i.Fullname).ToList();
        }
        public string Update(int id, Users U)
        {
            var q = db.Users.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Fullname = U.Fullname;
                    q.PhoneNo = U.PhoneNo;
                    q.NationalID = U.NationalID;
                    q.Username = U.Username;
                    q.password = U.password;
                    q.pic = U.pic;
                    db.SaveChanges();
                    return "The user information has been successfully edited";
                }
                else
                {
                    return "The desired user was not found!!!";
                }
            }
            catch (Exception e)
            {

                return "There was a problem editing user information: \n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var u = db.Users.Include("UserLogs").Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (u != null)
                {
                    u.DelStatus = true;
                    foreach (var logs in u.UserLogs)
                    {
                        logs.Delstatus = true;
                    }
                    db.SaveChanges();
                    return "The deletion of user information was done successfully!";
                }
                else
                {
                    return "The desired user was not found!!!";
                }
            }
            catch (Exception e)
            {

                return "There was a problem deleting user information: \n" + e.Message;
            }
        }
        public List<Users> ActivityRegistered()
        {
            return db.Users.Include("Activities").Where(i => i.DelStatus == false).ToList();
        }
        public Users Login(string username, string Pass)
        {
            return db.Users.Include("Usergroup").Where(i => i.Username == username && i.password == Pass).SingleOrDefault();
        }
        public bool AccessTo(Users U, string S, int A)
        {
            Usergroup UG = db.UserGroups.Include("Roles").Where(i => i.id == U.Usergroup.id).FirstOrDefault();
            Userroles UAR = UG.Roles.Where(z => z.section == S).FirstOrDefault();
            if (A == 1)
            {
                return UAR.canenter;
            }
            else if (A == 2)
            {
                return UAR.cancreate;
            }
            else if (A == 3)
            {
                return UAR.canedit;
            }
            else
            {
                return UAR.candelete;
            }
        }
        public string Usercount()
        {
            return db.Users.Where(i => i.DelStatus == false).Count().ToString();
        }
        public string ReadUsername()
        {
            if (IsRegistered())
            {
                return db.Users.Select(i => i.Username).FirstOrDefault();
            }
            return null;
        }
        public string Readname()
        {
            if (IsRegistered())
            {
                return db.Users.Select(i => i.Fullname).FirstOrDefault();
            }
            return null;
        }

        public string UpdateIsActive(int LoggedUserId)
        {
            var q = db.Users.Where(i => i.id == LoggedUserId).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.IsActive = true;
                    db.SaveChanges();
                    return "The user Aictived";
                }
                else
                {
                    return "The user not found!!!";
                }
            }
            catch (Exception e)
            {

                return "There was a problem editing user information: \n" + e.Message;
            }
        }
    }
}
