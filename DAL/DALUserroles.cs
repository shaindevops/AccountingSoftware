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
        public void Create(Userroles ul)
        {
            using (var db = new DB())
            {
                db.UserRoles.Add(ul);
                db.SaveChanges();
            }
        }
    }
}
