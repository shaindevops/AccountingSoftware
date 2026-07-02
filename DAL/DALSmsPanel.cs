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
    public class DALSmsPanel
    {
        DB db = new DB();

        public string Create(SmsPanel SP)
        {
            db.SmsPanel.Add(SP);
            db.SaveChanges();
            return "The sms panel is registered successfully";
        }

        public SmsPanel ReadId(int id)
        {
            return db.SmsPanel.Where(i => i.id == id).FirstOrDefault();
        }

        public string Update(int id, SmsPanel SP)
        {
            var q = db.SmsPanel.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.PanelName = SP.PanelName;
                q.PanelSID = SP.PanelSID;
                q.PanelAuthKey = SP.PanelAuthKey;
                q.PanelNumber = SP.PanelNumber;
                db.SaveChanges();
                return "The sms panel is edited successfully";
            }
            else
            {
                return "The sms panel not found";
            }
        }

        public string Delete(int id)
        {
            var q = db.SmsPanel.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                db.SmsPanel.Remove(q);
                db.SaveChanges();
                return "The sms panel is deleted successfully";
            }
            else
            {
                return "The sms panel not found";
            }
        }

        public DataTable FillSmsPanel()
        {
            string cmd = "SELECT        id, PanelName AS [Panel Name], PanelSID AS [API Key], PanelAuthKey AS [API Token], PanelNumber AS [Sender Number]\r\nFROM            dbo.SmsPanels";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
