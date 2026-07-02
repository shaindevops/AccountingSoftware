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
    public class DALDepot
    {
        /// <summary>
        /// True if a Depot with this name already exists. Renamed from
        /// "ExistDepot" (which returned true when the depot did NOT exist -
        /// same inverted-naming issue fixed for Products.IsDuplicateProduct).
        /// </summary>
        public bool IsDuplicateDepot(Depots D)
        {
            using (var db = new DB())
            {
                return db.Depots.Any(i => i.Name == D.Name);
            }
        }
        public string Create(Depots D)
        {
            try
            {
                using (var db = new DB())
                {
                    if (IsDuplicateDepot(D))
                    {
                        return "Duplicate information.";
                    }

                    db.Depots.Add(D);
                    db.SaveChanges();
                    return "Congratulations!! -- The new Depot was registered";
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError("DALDepot.Create", e);
                return "There was a problem registering the Depot: \n" + e.Message;
            }
        }

        public Depots ReadId(int id)
        {
            using (var db = new DB())
            {
                return db.Depots.Where(i => i.id == id).FirstOrDefault();
            }
        }
        public DataTable ReadFillGrid()
        {
            const string cmd = "SELECT DISTINCT TOP (100) PERCENT dbo.Depots.id, dbo.Depots.Name FROM  dbo.Depots WHERE (dbo.Depots.DelStatus = 0) ORDER BY dbo.Depots.id DESC";
            return AdoHelper.ExecuteQuery("DALDepot.ReadFillGrid", cmd);
        }
        public DataTable FillDepotByProducts(int ProducId)
        {
            return AdoHelper.ExecuteStoredProcedure(
                $"DALDepot.FillDepotByProducts(ProducId={ProducId})",
                "dbo.FillDepotByProducts",
                new SqlParameter("@ProductId", ProducId));
        }
        public string Update(int id, Depots D)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Depots.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.Name = D.Name;
                        db.SaveChanges();
                        return "The Depot information has been edited successfully";
                    }
                    else
                    {
                        return "There is no Depot with this specification";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALDepot.Update(id={id})", e);
                return "There was a problem editing the Depot: \n" + e.Message;
            }
        }
        public string DeleteDepot(int id)
        {
            try
            {
                using (var db = new DB())
                {
                    var q = db.Depots.Include("Stocks").Include("Details").Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.DelStatus = true;
                        foreach (var stocks in q.Stocks)
                        {
                            stocks.DelStatus = true;
                        }
                        foreach (var details in q.Details)
                        {
                            details.Delstatus = true;
                        }
                        db.SaveChanges();
                        return "The Depot information has been Deleted successfully";
                    }
                    else
                    {
                        return "There is no Depot with this specification";
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.LogError($"DALDepot.DeleteDepot(id={id})", e);
                return "There was a problem deleting the Depot: \n" + e.Message;
            }
        }
        public string CountDepot()
        {
            using (var db = new DB())
            {
                return db.Depots.Where(i => i.DelStatus == false).Count().ToString();
            }
        }
        public Depots DepotName(string Name)
        {
            using (var db = new DB())
            {
                return db.Depots.Where(i => i.Name == Name).FirstOrDefault();
            }
        }

        public int GetDefaultDepotId()
        {
            using (var db = new DB())
            {
                return db.Depots.Min(i => (int?)i.id) ?? 0;
            }
        }
    }
}
