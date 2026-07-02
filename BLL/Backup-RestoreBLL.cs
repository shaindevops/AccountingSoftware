using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Backup_RestoreBLL
    {
        Backup_RestoreDAL dal = new Backup_RestoreDAL();
        public string Backup(string Path)
        {
            return dal.Backup(Path);
        }
        public string Restore(string Path)
        {
            return dal.Restore(Path);
        }
    }
}
