using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tasks
    {
        public Tasks() 
        {
            IsDone = false;
        }

        public int id { get; set; }
        public string  Title { get; set; }
        public string Description { get; set; }
        public DateTime TaskDate { get; set; }
        public DateTime TaskTime { get; set; }
        public DateTime TaskAlarmDate { get; set; }
        public DateTime TaskAlarmTime { get; set; }
        public bool IsDone { get; set; }
        public bool Alarm {  get; set; }
        public Users Users { get; set; }
        public TaskGroup TaskGroup { get; set; }
    }
}
