using BE;
using BE.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCostGroup
    {
        public string Create(CostGroup CG)
        {
            try
            {
                using (var db = new DB())
                {
                    db.CostGroups.Add(CG);
                    db.SaveChanges();
                    return "The Cost Group has been registered successfully";
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError("DALCostGroup.Create", e);
                return "There was a problem registering the Cost Group: \n" + e.Message;
            }
        }
        public CostGroup ReadId(int id)
        {
            using (var db = new DB())
            {
                return db.CostGroups.Where(i => i.id == id).FirstOrDefault();
            }
        }
        public DataTable FillCostGroup()
        {
            const string cmd = "SELECT Distinct TOP (100) PERCENT id, Name, Description, Regdate AS [Reg Date]\r\nFROM            dbo.CostGroups\r\nWHERE        (Static = 0) AND (Delstatus = 0)\r\nORDER BY Name";
            return AdoHelper.ExecuteQuery("DALCostGroup.FillCostGroup", cmd);
        }
        public DataTable FillCostGroupBYTypeIncome()
        {
            const string cmd = "SELECT        dbo.CostGroups.id, dbo.CostGroups.Name, dbo.CostGroups.Description, dbo.CostGroups.Regdate\r\nFROM            dbo.CostGroups \r\nWHERE        (dbo.CostGroups.Delstatus = 0) AND (dbo.CostGroups.Static = 0) AND (dbo.CostGroups.Type = 1)";
            return AdoHelper.ExecuteQuery("DALCostGroup.FillCostGroupBYTypeIncome", cmd);
        }
        public DataTable FillCostGroupBYTypeCosts()
        {
            const string cmd = "SELECT        dbo.CostGroups.id, dbo.CostGroups.Name, dbo.CostGroups.Description, dbo.CostGroups.Regdate\r\nFROM            dbo.CostGroups \r\nWHERE        (dbo.CostGroups.Delstatus = 0) AND (dbo.CostGroups.Static = 0) AND (dbo.CostGroups.Type = 0)";
            return AdoHelper.ExecuteQuery("DALCostGroup.FillCostGroupBYTypeCosts", cmd);
        }
        public string Update(int id, CostGroup CG)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.CostGroups.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.Type = CG.Type;
                        q.Static = CG.Static;
                        q.Name = CG.Name;
                        q.Description = CG.Description;
                        db.SaveChanges();
                        return "The Cost Group information has been edited successfully";
                    }
                    else
                    {
                        return "The person was not found";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALCostGroup.Update(id={id})", e);
                return "There was a problem editing the Cost Group: \n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.CostGroups.Include("AccountBooks").Include("Documents").Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.Delstatus = true;
                        foreach (var book in q.AccountBooks)
                        {
                            book.Delstatus = true;
                        }
                        foreach (var doc in q.Documents)
                        {
                            doc.Delstatus = true;
                        }
                        db.SaveChanges();
                        return "The Cost Group information has been deleted successfully";
                    }
                    else
                    {
                        return "The person was not found";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALCostGroup.Delete(id={id})", e);
                return "There was a problem deleting the Cost Group: \n" + e.Message;
            }
        }
        public CostGroup ReadN(string CG)
        {
            try
            {
                using (var db = new DB())
                {
                    return db.CostGroups.Where(i => i.Name == CG).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALCostGroup.ReadN(CG='{CG}')", e);
                return null;
            }
        }

        public bool GetCostGroupStatus(int id)
        {
            using (var db = new DB())
            {
                return db.CostGroups.Where(i => i.id == id).Select(i => i.Type).FirstOrDefault();
            }
        }
    }
}
