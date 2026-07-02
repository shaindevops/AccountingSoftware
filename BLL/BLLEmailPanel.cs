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
    public class BLLEmailPanel
    {
        DALEmailPanel dal = new DALEmailPanel();

        public string Create(EmailPanel EP)
        {
            return dal.Create(EP);
        }

        public EmailPanel ReadId(int id)
        {
            return dal.ReadId(id);
        }

        public string ReadFrom(int id)
        {
            return dal.ReadFrom(id);
        }
        public string ReadPassword(int id)
        {
            return dal.ReadPassword(id);
        }

        public string UpdateEmailPanel(int id, EmailPanel EP)
        {
            return dal.UpdateEmailPanel(id, EP);
        }
        public string DeleteEmailPanel(int id)
        {
            return dal.DeleteEmailPanel(id);
        }

        public string EmailPanelCount()
        {
            return dal.EmailPanelCount();
        }
        public DataTable FillEmailPanel()
        {
            return dal.FillEmailPanel();
        }

        public DataTable GetEmailPanel(out string Usernamepanel, out string PassPanel)
        {
            return dal.GetEmailPanel(out Usernamepanel, out PassPanel);
        }
    }
}
