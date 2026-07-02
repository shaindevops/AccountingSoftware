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
    public class DALUsergroup
    {
        DB db = new DB();

        public bool ExistUserGroup(Usergroup G)
        {
            var q = db.UserGroups.Where(i => i.Title == G.Title).FirstOrDefault();
            if (q == null)
            {
                return true;
            }
            return false;
        }

        public string Create(Usergroup UG)
        {
            try
            {
                if(ExistUserGroup(UG))
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
            catch (Exception e)
            {

                return "There was a problem creating the user group" + e.Message;
            }
        }
        public bool Read(string name)
        {
            return db.UserGroups.Any(i => i.Title == name);
        }
        public List<string> ReadUGNames()
        {
            return db.UserGroups.Select(i => i.Title).ToList();
        }
        public DataTable Read()
        {
            string cmd = "SELECT DISTINCT dbo.Usergroups.id, dbo.Usergroups.Title AS [User Type Title], dbo.Userroles.section AS [Access To Section], dbo.Userroles.canenter AS [Entry Permit], dbo.Userroles.cancreate AS [Add Permission], \r\n                         dbo.Userroles.canedit AS [Editing Permission], dbo.Userroles.candelete AS [Delete Permission]\r\nFROM            dbo.Usergroups INNER JOIN\r\n                         dbo.Userroles ON dbo.Usergroups.id = dbo.Userroles.Usergroup_id";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public Usergroup Read(int id)
        {
            try
            {
                return db.UserGroups.Where(i => i.id == id).SingleOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Usergroup ReadN(string s)
        {
            try
            {
                return db.UserGroups.Where(i => i.Title == s).SingleOrDefault();

            }
            catch (Exception)
            {

                return null;
            }
        }
        public DataTable ReadTitle(string ug)
        {
            SqlCommand cmd = new SqlCommand("dbo.SearchUser");
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@search", ug);
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string Usergroupcount()
        {
            return db.UserGroups.Count().ToString();
        }
    }
}
