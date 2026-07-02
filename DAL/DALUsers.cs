using BE;
using BE.Logging;
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
        public string Create(Users U, Usergroup UG)
        {
            try
            {
                using (var db = new DB())
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
            }
            catch (Exception e)
            {
                AppLogger.LogError("DALUsers.Create", e);
                return "User registration encountered a problem!!! \n" + e.Message;
            }
        }
        public bool IsRegistered()
        {
            using (var db = new DB())
            {
                return db.Users.Count() > 0;
            }
        }
        public bool Read(Users U)
        {
            using (var db = new DB())
            {
                var q = db.Users.Where(i => i.Username == U.Username && i.PhoneNo == U.PhoneNo && i.Email == U.Email).FirstOrDefault();
                return q == null;
            }
        }
        public DataTable Read()
        {
            string cmd = "SELECT DISTINCT \r\n                         dbo.Users.id, dbo.Users.Fullname AS [Full Name], dbo.Users.NationalID AS [National Id], dbo.Users.PhoneNo AS Phone, dbo.Users.Email, dbo.Users.Username, dbo.Users.Regdate AS [Register Date], \r\n                         dbo.Usergroups.Title AS [User Type]\r\nFROM            dbo.Users INNER JOIN\r\n                         dbo.Usergroups ON dbo.Users.Usergroup_id = dbo.Usergroups.id\r\nWHERE        (dbo.Users.DelStatus = 0)";
            try
            {
                using (var con = new SqlConnection(ConnectionHelper.ConnectionString))
                using (var sqladapter = new SqlDataAdapter(cmd, con))
                {
                    var commandbuilder = new SqlCommandBuilder(sqladapter);
                    var ds = new DataSet();
                    sqladapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError("DALUsers.Read()", e);
                return null;
            }
        }
        public DataTable Read(string u, int index)
        {
            try
            {
                string procedureName;
                switch (index)
                {
                    case 1: procedureName = "dbo.SearchUserName"; break;
                    case 2: procedureName = "dbo.SearchUserPhone"; break;
                    case 3: procedureName = "dbo.SearchUserNationalId"; break;
                    case 4: procedureName = "dbo.SearchUserGroup"; break;
                    default: procedureName = "dbo.SearchUser"; break;
                }

                using (var con = new SqlConnection(ConnectionHelper.ConnectionString))
                using (var cmd = new SqlCommand(procedureName, con))
                {
                    cmd.Parameters.AddWithValue("@search", u);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var sqladapter = new SqlDataAdapter(cmd))
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
                AppLogger.LogError($"DALUsers.Read(u='{u}', index={index})", e);
                return null;
            }
        }
        public Users Read(int id)
        {
            using (var db = new DB())
            {
                return db.Users.Where(i => i.id == id).FirstOrDefault();
            }
        }
        public Users ReadU(string s)
        {
            using (var db = new DB())
            {
                return db.Users.Where(i => i.Fullname == s).SingleOrDefault();
            }
        }
        public List<string> ReadUserName()
        {
            using (var db = new DB())
            {
                return db.Users.Where(i => i.DelStatus == false).Select(i => i.Fullname).ToList();
            }
        }

        /// <summary>
        /// Updates a user's profile fields. If U.password is null, the
        /// existing password hash is left untouched - callers (BLLUser)
        /// pass null to mean "no password change requested".
        /// </summary>
        public string Update(int id, Users U)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Users.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.Fullname = U.Fullname;
                        q.PhoneNo = U.PhoneNo;
                        q.NationalID = U.NationalID;
                        q.Username = U.Username;
                        if (!string.IsNullOrEmpty(U.password))
                        {
                            q.password = U.password;
                        }
                        q.pic = U.pic;
                        db.SaveChanges();
                        return "The user information has been successfully edited";
                    }
                    else
                    {
                        return "The desired user was not found!!!";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALUsers.Update(id={id})", e);
                return "There was a problem editing user information: \n" + e.Message;
            }
        }

        /// <summary>
        /// Persists an already-hashed password for a user, without touching
        /// any other field. Used for the transparent legacy-Base64-to-PBKDF2
        /// upgrade performed on successful login.
        /// </summary>
        public void UpdatePasswordHash(int id, string newPasswordHash)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Users.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.password = newPasswordHash;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                // Non-fatal: if the upgrade write fails, the user still
                // logged in successfully. We'll just try to upgrade them
                // again next time.
                AppLogger.LogError($"DALUsers.UpdatePasswordHash(id={id})", e);
            }
        }

        public string Delete(int id)
        {
            try
            {
                using (var db = new DB())
                {
                    var u = db.Users.Include("UserLogs").Where(i => i.id == id).FirstOrDefault();
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
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALUsers.Delete(id={id})", e);
                return "There was a problem deleting user information: \n" + e.Message;
            }
        }
        public List<Users> ActivityRegistered()
        {
            using (var db = new DB())
            {
                return db.Users.Where(i => i.DelStatus == false).ToList();
            }
        }

        /// <summary>
        /// Fetches a user by username (with their Usergroup eagerly loaded
        /// for permission checks) for the login flow. Password verification
        /// happens in BLLUser.Login via PasswordHasher, not here - PBKDF2
        /// hashes can't be compared with a SQL "=" the way the old Base64
        /// values could.
        /// </summary>
        public Users GetByUsernameWithGroup(string username)
        {
            using (var db = new DB())
            {
                return db.Users.Include("Usergroup").Where(i => i.Username == username).SingleOrDefault();
            }
        }

        public bool AccessTo(Users U, string S, int A)
        {
            using (var db = new DB())
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
        }
        public string Usercount()
        {
            using (var db = new DB())
            {
                return db.Users.Where(i => i.DelStatus == false).Count().ToString();
            }
        }
        public string ReadUsername()
        {
            if (IsRegistered())
            {
                using (var db = new DB())
                {
                    return db.Users.Select(i => i.Username).FirstOrDefault();
                }
            }
            return null;
        }
        public string Readname()
        {
            if (IsRegistered())
            {
                using (var db = new DB())
                {
                    return db.Users.Select(i => i.Fullname).FirstOrDefault();
                }
            }
            return null;
        }

        public string UpdateIsActive(int LoggedUserId)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Users.Where(i => i.id == LoggedUserId).FirstOrDefault();
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
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALUsers.UpdateIsActive(id={LoggedUserId})", e);
                return "There was a problem editing user information: \n" + e.Message;
            }
        }
    }
}
