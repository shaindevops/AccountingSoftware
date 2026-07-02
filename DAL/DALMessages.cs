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
    public class DALMessages
    {
        DB db = new DB();
        public string Create(Messages M)
        {
            db.Messages.Add(M);
            db.SaveChanges();
            return "The message was successfully registered";
        }
        public Messages ReadId(int id)
        {
            return db.Messages.Where(i => i.id == id).FirstOrDefault();
        }

        public DataTable FillMessage()
        {
            string cmd = "SELECT        dbo.Messages.id, dbo.Messages.MessageText\r\nFROM            dbo.Messages\r\nWHERE        (dbo.Messages.Delstatus = 0)";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string DeleteMessage(int id)
        {
            var q = db.Messages.Where(i=> i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Delstatus = false;
                db.SaveChanges();
                return "The message was deleted successfully";
            }
            else
            {
                return "Message not found";
            }
        }

        public string MessageCount()
        {
            return db.Messages.Where(i => i.Delstatus == false).Count().ToString();
        }

        public bool ExistMessage()
        {
            bool ExistMessage = db.Messages.Any();

            return ExistMessage;
        }

        public void GetRandomMessage(out string MessageText)
        {
            MessageText = "";

            using (SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true"))
            using (SqlCommand cmd = new SqlCommand("dbo.GetRandomMessage", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // پارامتر خروجی
                SqlParameter msg = new SqlParameter("@MessageText", SqlDbType.NVarChar, 255); // فرض می‌کنیم طول متن خروجی حداکثر 255 کاراکتر باشد
                msg.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(msg);

                // باز کردن اتصال و اجرای پروسیجر
                con.Open();
                cmd.ExecuteNonQuery();

                // دریافت مقدار خروجی
                MessageText = cmd.Parameters["@MessageText"].Value.ToString();
            }
        }
    }
}
