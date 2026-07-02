using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class Tbl_CompanyDAL
    {
        DB db = new DB();

        public bool ExistCompany()
        {
            return db.Tbl_Companies.Any();
        }
        public bool Read(Tbl_Company com)
        {
            var q = db.Tbl_Companies.Where(i=> i.code == com.code && i.Comphone == com.Comphone);
            if(q.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public string Create(Tbl_Company com)
        {
            try
            {
                if (!Read(com))
                {
                    db.Tbl_Companies.Add(com);
                    db.SaveChanges();
                    return "Your company has been successfully registered.";
                }
                else
                {
                    return "A company with this profile has already been registered!!!";
                }
                
            }
            catch (Exception m)
            {
                return "There is a problem!!! \n" + m.Message;
            }
        }
        public string GenerateCode(Tbl_Company com)
        {
            Random rnd = new Random();
            string s = rnd.Next(2).ToString();
            var q = db.Tbl_Companies.Where(i => i.code == s);
            while(q.Count() > 0)
            {
                s = rnd.Next(2).ToString();
            }
            com.code = s;
            return s;
        }
        public Tbl_Company ReadID(int id)
        {
            return db.Tbl_Companies.Where(i => i.id == id).FirstOrDefault();
        }
        public DataTable ReadList()
        {
            string cmd = "SELECT        id, code, Comname AS Name, Comowner AS Owner, Comcurrency AS Currency, Comeconimiccode AS [Econimi Code], Comregnumber AS [Refistartion Number], Comphone AS Phone, Comzipcode AS [Zip Code], \r\n                         Comprovince AS Province, Comcity AS City, Comaddress AS Address, Comlogo AS Logo, Comemail AS Email\r\nFROM            dbo.Tbl_Company\r\nWHERE        (Comstatus = 0)";
            SqlConnection con = new SqlConnection(@"data source=.; initial catalog=SpadanDB; integrated security=true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string ReadComName(Tbl_Company C)
        {
            var q = db.Tbl_Companies.Where (i => i.id == C.id);
            if(q != null)
            {
                return db.Tbl_Companies.Select(i => i.Comname).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public string ReadComOwner(Tbl_Company C)
        {
            var q = db.Tbl_Companies.Where(i => i.id == C.id);
            if (q != null)
            {
                return db.Tbl_Companies.Select(i => i.Comowner).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public string ReadComLogo(Tbl_Company C)
        {
            var q = db.Tbl_Companies.Where(i => i.id == C.id);
            if (q != null)
            {
                return db.Tbl_Companies.Select(i => i.Comlogo).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public Tbl_Company ReadN(string s)
        {
            return db.Tbl_Companies.Where(i => i.Comname == s).SingleOrDefault();
        }

    }
}
