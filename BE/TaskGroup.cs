using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TaskGroup
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
