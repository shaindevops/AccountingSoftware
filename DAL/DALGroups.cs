using BE;
using BE.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALGroups
    {
        public string Create(Groups G)
        {
            try
            {
                using (var db = new DB())
                {
                    db.Groups.Add(G);
                    db.SaveChanges();
                    return "Group created successfully";
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError("DALGroups.Create", e);
                return "There was a problem creating the group: \n" + e.Message;
            }
        }
        public Groups ReadId(int id)
        {
            using (var db = new DB())
            {
                return db.Groups.Where(i => i.id == id).FirstOrDefault();
            }
        }
        public DataTable ReadFillGroup()
        {
            const string cmd = "SELECT DISTINCT TOP (100) PERCENT dbo.Groups.id, dbo.Groups.Name AS [Group Name], dbo.Groups.Unit1 AS [Unit 1], dbo.Groups.Unit2 AS [Unit 2], dbo.Groups.Regdate\r\nFROM            dbo.Groups WHERE        (dbo.Groups.DelStatuse = 0)\r\nORDER BY [Group Name] DESC";
            return AdoHelper.ExecuteQuery("DALGroups.ReadFillGroup", cmd);
        }
        public string Update(int id, Groups G)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Groups.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.Name = G.Name;
                        q.Unit1 = G.Unit1;
                        q.Unit2 = G.Unit2;
                        db.SaveChanges();
                        return "The desired group was edited";
                    }
                    else
                    {
                        return "The desired group was not found";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALGroups.Update(id={id})", e);
                return "There was a problem editing the group: \n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Groups.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.DelStatuse = true;
                        db.SaveChanges();
                        return "The desired group was edited";
                    }
                    else
                    {
                        return "The desired group was not found";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALGroups.Delete(id={id})", e);
                return "There was a problem deleting the group: \n" + e.Message;
            }
        }
        public string GroupCount()
        {
            using (var db = new DB())
            {
                return db.Groups.Where(i => i.DelStatuse == false).Count().ToString();
            }
        }
        public List<string> GroupName()
        {
            using (var db = new DB())
            {
                return db.Groups.Where(i => i.DelStatuse == false).Select(i => i.Name).ToList();
            }
        }
        public Groups GName(string G)
        {
            using (var db = new DB())
            {
                return db.Groups.Where(i => i.Name == G).FirstOrDefault();
            }
        }

        public void GetGroupUnit(int productId, out string unit1, out string unit2)
        {
            using (var db = new DB())
            {
                var groupUnits = (from p in db.Products
                                  join g in db.Groups on p.Group.id equals g.id
                                  where p.id == productId
                                  select new { g.Unit1, g.Unit2 }).FirstOrDefault();

                if (groupUnits != null)
                {
                    unit1 = groupUnits.Unit1;
                    unit2 = groupUnits.Unit2;
                }
                else
                {
                    unit1 = string.Empty;
                    unit2 = string.Empty;
                }
            }
        }
    }
}
