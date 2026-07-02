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
    public class DALTaskGroup
    {
        DB db =new DB();

        public bool ExistGroup(TaskGroup TG)
        {
            var q = db.TaskGroups.Where(i => i.Title == TG.Title).FirstOrDefault();
            if (q == null)
            {
                return true;
            }
            return false;
        }

        public string Create(TaskGroup TG)
        {
            if (ExistGroup(TG))
            {
                db.TaskGroups.Add(TG);
                db.SaveChanges();
                return "The Task Group has been rgistered successfully";
            }
            else
            {
                return "This task group is already";
            }
            
        }
        public TaskGroup ReadId(int id)
        {
            return db.TaskGroups.Where(i => i.id == id).FirstOrDefault();
        }

        public DataTable FillTaskGroup()
        {
            string cmd = "SELECT DISTINCT TOP (100) PERCENT dbo.TaskGroups.id, dbo.TaskGroups.Title, dbo.TaskGroups.Description\r\nFROM            dbo.TaskGroups";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string Update(int id, TaskGroup TG)
        {
            var q = db.TaskGroups.Include("Tasks").Where(i => i.id == id).FirstOrDefault();
            if(q != null)
            {
                q.Title = TG.Title;
                q.Description = TG.Description;

                foreach (var task in q.Tasks)
                {
                    if (task.TaskGroup != TG)
                    {
                        task.TaskGroup = TG;
                    }
                }
                db.SaveChanges();
                return "The task group edited successfully";
            }
            else
            {
                return "Task group not found";
            }
        }
        public string Delete(int id)
        {
            var q = db.TaskGroups.Include("Tasks").FirstOrDefault(i => i.id == id);
            if (q != null)
            {
                // حذف تمامی وظایف مرتبط با گروه
                db.Tasks.RemoveRange(q.Tasks);

                // سپس حذف گروه وظایف
                db.TaskGroups.Remove(q);

                db.SaveChanges();
                return "The task group and related tasks were deleted successfully.";
            }
            else
            {
                return "Task group not found";
            }
        }
        public List<string> ReadTaskGroupTitle()
        {
            return db.TaskGroups.Select(i => i.Title).ToList();
        }
        public TaskGroup ReadTaskGroupTitle(string s)
        {
            return db.TaskGroups.Where(i => i.Title == s).SingleOrDefault();
        }
    }
}
