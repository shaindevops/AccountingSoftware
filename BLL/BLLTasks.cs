using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLTasks
    {
        DALTasks dal = new DALTasks();

        public bool ExistTask()
        {
            return dal.ExistTask();
        }
        public string Create(Tasks T, int GroupId, int UserId)
        {
            return dal.Create(T, GroupId, UserId);
        }
        public Tasks ReadId(int id)
        {
            return dal.ReadId(id);
        }

        public DataTable FillTaskByUser(int CurrentUserId)
        {
            return dal.FillTaskByUser(CurrentUserId);
        }
        public DataTable FillNonDoneTaskByUser(int CurrentUserId)
        {
            return dal.FillNonDoneTaskByUser(CurrentUserId);
        }
        public DataTable FillIsDoneTaskByUser(int CurrentUserId)
        {
            return dal.FillIsDoneTaskByUser(CurrentUserId);
        }
        public DataTable FillTaskAlarmToday(int CurrentUserId, DateTime Date)
        {
            return dal.FillTaskAlarmToday(CurrentUserId, Date);
        }
        public string Update(int id, Tasks T)
        {
            return dal.Update(id, T);
        }
        public string UpdateIsDone(int id)
        {
            return dal.UpdateIsDone(id);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public string TasksCount()
        {
            return dal.TasksCount();
        }
        public string TasksCountIsDone()
        {
            return dal.TasksCountIsDone();
        }
        public string TasksCountNotDone()
        {
            return dal.TasksCountNotDone();
        }
        public string TasksCountToday()
        {
            return dal.TasksCountToday();
        }
        public void UpdateTaskDueDates()
        {
            dal.UpdateTaskDueDates();
        }
    }
}
