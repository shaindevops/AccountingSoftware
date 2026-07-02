using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALUserroles
    {
        DB db = new DB();
        public void Create(Userroles ul)
        {
            db.UserRoles.Add(ul);
            db.SaveChanges();
        }
    }
}
