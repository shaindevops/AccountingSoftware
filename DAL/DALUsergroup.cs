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
    public class DALUsergroup
    {
        public bool ExistUserGroup(Usergroup G)
        {
            using (var db = new DB())
            {
                var q = db.UserGroups.Where(i => i.Title == G.Title).FirstOrDefault();
                return q == null;
            }
        }

        public string Create(Usergroup UG)
        {
            try
            {
                using (var db = new DB())
                {
                    if (ExistUserGroup(UG))
                    {
                        db.UserGroups.Add(UG);
                        db.SaveChanges();
                        return "The user group was created successfully";
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError("DALUsergroup.Create", e);
                return "There was a problem creating the user group" + e.Message;
            }
        }
        public bool Read(string name)
        {
            using (var db = new DB())
            {
                return db.UserGroups.Any(i => i.Title == name);
            }
        }
        public List<string> ReadUGNames()
        {
            using (var db = new DB())
            {
                return db.UserGroups.Select(i => i.Title).ToList();
            }
        }
        public DataTable Read()
        {
            string cmd = "SELECT DISTINCT dbo.Usergroups.id, dbo.Usergroups.Title AS [User Type Title], dbo.Userroles.section AS [Access To Section], dbo.Userroles.canenter AS [Entry Permit], dbo.Userroles.cancreate AS [Add Permission], \r\n                         dbo.Userroles.canedit AS [Editing Permission], dbo.Userroles.candelete AS [Delete Permission]\r\nFROM            dbo.Usergroups INNER JOIN\r\n                         dbo.Userroles ON dbo.Usergroups.id = dbo.Userroles.Usergroup_id";
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
                AppLogger.LogError("DALUsergroup.Read()", e);
                return null;
            }
        }
        public Usergroup Read(int id)
        {
            try
            {
                using (var db = new DB())
                {
                    return db.UserGroups.Where(i => i.id == id).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALUsergroup.Read(id={id})", e);
                return null;
            }
        }
        public Usergroup ReadN(string s)
        {
            try
            {
                using (var db = new DB())
                {
                    return db.UserGroups.Where(i => i.Title == s).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALUsergroup.ReadN(s='{s}')", e);
                return null;
            }
        }
        public DataTable ReadTitle(string ug)
        {
            try
            {
                // NOTE: this calls the "SearchUser" stored procedure, which
                // searches the Users table, not Usergroups - this looks like
                // a pre-existing copy/paste bug. Left as-is (unchanged
                // behavior); flagged for follow-up since fixing it would
                // change what this method returns.
                using (var con = new SqlConnection(ConnectionHelper.ConnectionString))
                using (var cmd = new SqlCommand("dbo.SearchUser", con))
                {
                    cmd.Parameters.AddWithValue("@search", ug);
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
                AppLogger.LogError($"DALUsergroup.ReadTitle(ug='{ug}')", e);
                return null;
            }
        }
        public string Usergroupcount()
        {
            using (var db = new DB())
            {
                return db.UserGroups.Count().ToString();
            }
        }
    }
}
