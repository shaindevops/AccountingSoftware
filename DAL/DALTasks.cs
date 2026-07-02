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
    public class DALTasks
    {
        DB db = new DB();

        public bool ExistTask()
        {
            return db.Tasks.Any();
        }
        public string Create(Tasks T, int GroupId, int UserId)
        {
            var user = db.Users.FirstOrDefault(x => x.id == UserId);
            if(user != null)
            {
                T.Users = user;
            }
            else
            {
                T.Users = null;
            }

            var group = db.TaskGroups.FirstOrDefault(x => x.id == GroupId);
            if (user != null)
            {
                T.TaskGroup = group;
            }
            else
            {
                T.TaskGroup = null;
            }

            db.Tasks.Add(T);
            db.SaveChanges();
            return "The Task has been rgistered successfully";
        }
        public Tasks ReadId(int id)
        {
            return db.Tasks.Where(i => i.id == id).FirstOrDefault();
        }

        public DataTable FillTaskByUser(int currentUserId)
        {
            try
            {
                // کانکشن استرینگ به صورت ثابت یا از تنظیمات پیکربندی
                string connectionString = @"data source=.; initial catalog=SpadanDB; integrated security=true";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.FillTaskByUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CurrentUserID", currentUserId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sqlAdapter.Fill(ds);

                        // بررسی وجود داده در جدول
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            return ds.Tables[0];
                        }
                        else
                        {
                            return null; // یا جدول خالی برگردانید
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        
        public DataTable FillNonDoneTaskByUser(int CurrentUserId)
        {
            try
            {
                // کانکشن استرینگ به صورت ثابت یا از تنظیمات پیکربندی
                string connectionString = @"data source=.; initial catalog=SpadanDB; integrated security=true";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.FillNonDoneTaskByUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CurrentUserID", CurrentUserId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sqlAdapter.Fill(ds);

                        // بررسی وجود داده در جدول
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            return ds.Tables[0];
                        }
                        else
                        {
                            return null; // یا جدول خالی برگردانید
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        
        public DataTable FillIsDoneTaskByUser(int CurrentUserId)
        {
            try
            {
                // کانکشن استرینگ به صورت ثابت یا از تنظیمات پیکربندی
                string connectionString = @"data source=.; initial catalog=SpadanDB; integrated security=true";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.FillIsDoneTaskByUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CurrentUserID", CurrentUserId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sqlAdapter.Fill(ds);

                        // بررسی وجود داده در جدول
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            return ds.Tables[0];
                        }
                        else
                        {
                            return null; // یا جدول خالی برگردانید
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public DataTable FillTaskAlarmToday(int CurrentUserId, DateTime Date)
        {
            try
            {
                

                SqlCommand cmd = new SqlCommand("dbo.FillTaskAlarmToday");
                SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@CurrentUserID", CurrentUserId);
                cmd.Parameters.AddWithValue("@Date", Date);
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
        public string Update(int id, Tasks T)
        {
            var q = db.Tasks.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Title = T.Title;
                q.Description = T.Description;
                q.TaskDate = T.TaskDate;
                q.TaskTime = T.TaskTime;
                q.TaskAlarmDate = T.TaskAlarmDate;
                q.TaskAlarmTime = T.TaskAlarmTime;
                q.Users = T.Users;
                db.SaveChanges();
                return "The task  edited successfully";
            }
            else
            {
                return "Task not found";
            }
        }
        public string UpdateIsDone(int id)
        {
            var q = db.Tasks.Where(i => i.id == id && i.IsDone == false).FirstOrDefault();
            if (q != null)
            {
                q.IsDone = true;
                db.SaveChanges();
                return "The task  edited successfully";
            }
            else
            {
                return "Task not found";
            }
        }
        public string Delete(int id)
        {
            var q = db.Tasks.FirstOrDefault(i => i.id == id);
            if (q != null)
            {

                // سپس حذف گروه وظایف
                db.Tasks.Remove(q);

                db.SaveChanges();
                return "The task and related tasks were deleted successfully.";
            }
            else
            {
                return "Task not found";
            }
        }
        public string TasksCount()
        {
            return db.Tasks.Count().ToString();
        }
        public string TasksCountIsDone()
        {
            return db.Tasks.Where(i => i.IsDone == true).Count().ToString();
        }
        public string TasksCountNotDone()
        {
            return db.Tasks.Where(i => i.IsDone == false).Count().ToString();
        }
        public string TasksCountToday()
        {
            return db.Tasks.Where(i => i.IsDone == false && Convert.ToDateTime(i.TaskAlarmDate) == DateTime.Now).Count().ToString();
        }

        public void UpdateTaskDueDates()
        {
            // دریافت تاریخ امروز
            DateTime today = DateTime.Today;

            // دریافت تمام وظایفی که نیاز به به‌روزرسانی دارند و سپس تبدیل به لیست
            var tasks = db.Tasks
                .Where(t => t.IsDone == false && t.Alarm == true)
                .ToList() // دریافت داده‌ها در حافظه
                .Where(t => t.TaskAlarmDate < today)
                .ToList();

            // تغییر تاریخ‌های یادآوری
            foreach (var task in tasks)
            {
                task.TaskAlarmDate = Convert.ToDateTime(today.ToString("MM/dd/yyyy"));
            }

            // ذخیره تغییرات در پایگاه داده
            db.SaveChanges();
        }

    }
}
