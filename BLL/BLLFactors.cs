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
    public class BLLFactors
    {
        DALFactors dal = new DALFactors();

        public bool ExistSaleNumber(Factors Number)
        {
            return dal.ExistSaleNumber(Number);
        }
        public string Create(Factors F, int PersonId)
        {
            return dal.Create(F, PersonId);
        }
        public Factors ReadId(int id)
        {
            return dal.ReadId(id);
        }

        public string DeleteFactor(int id)
        {
            return dal.DeleteFactor(id);
        }

        public int GetFactorId()
        {
            return dal.GetFactorId();
        }
        public string GetMaxSaleNumber()
        {
            return dal.GetMaxSaleNumber();
        }
        public DataTable FillFactor()
        {
            return dal.FillFactor();
        }
        public DataTable FilterFactorBuyDate(string Date1, string Date2)
        {
            return dal.FilterFactorBuyDate(Date1, Date2);
        }
        public DataTable FilterFactorSaleDate(string Date1, string Date2)
        {
            return dal.FilterFactorSaleDate(Date1, Date2);
        }
        public DataTable FillViewFactorsDetails(int FactorId)
        {
            return dal.FillViewFactorsDetails(FactorId);
        }
        public DataTable FillFactorByPerson(int PersonId)
        {
           return dal.FillFactorByPerson(PersonId);
        }
        public string FactorSaleCount()
        {
            return dal.FactorSaleCount();
        }
        public string FactorBuyCount()
        {
            return dal.FactorBuyCount();
        }
        public void GetSumFactorsByPerson(int personId, out int SumBuy, out int SumSale)
        {
            dal.GetSumFactorsByPerson(personId, out SumBuy, out SumSale);
        }

        public DataTable FilterBuyFactor(string Date1, string Date2)
        {
            return dal.FilterBuyFactor(Date1, Date2);
        }
        public DataTable FilterSaleFactor(string Date1, string Date2)
        {
            return dal.FilterSaleFactor(Date1, Date2);
        }

        public DataTable GetSumBuyFactor(string Date1, string Date2, out int SumFactor, out int SumBook)
        {
            return dal.GetSumBuyFactor(Date1, Date2, out SumFactor, out SumBook);
        }

        public DataTable GetSumSaleFactor(string Date1, string Date2, out int SumFactor, out int SumBook)
        {
            return dal.GetSumSaleFactor(Date1, Date2, out SumFactor, out SumBook);
        }

        /// <summary>
        /// گزارش مالی برای فرم FrmMoneyReport برای 6 متغیر
        /// </summary>
        /// <param name="Date1">تاریخ اول</param>
        /// <param name="Date2">تا تاریخ</param>
        /// <param name="Cost1">برای درآمدها</param>
        /// <param name="Cost2">برای هزینه ها</param>
        ///<param name="ِDoc1">برای اسناد دریافتی</param>
        ///<param name="Doc2">برای اسناد پرداختی</param>
        ///<param name="Sale">مجموع فروش</param>
        ///<param name="Buy">مجموع خرید</param>
        /// 
        /// <returns></returns>
        /// 

        public DataTable GetMoneyReportByDate(string Date1, string Date2, out int Cost1, out int Cost2, out int Doc1, out int Doc2, out int Sale, out int Buy)
        {
            return dal.GetMoneyReportByDate(Date1, Date2, out Cost1, out Cost2, out Doc1, out Doc2, out Sale, out Buy);
        }

        public DataTable GetMoneyReportByYear(string Year, out int Cost1, out int Cost2, out int Doc1, out int Doc2, out int Sale, out int Buy)
        {
            return dal.GetMoneyReportByYear(Year, out Cost1, out Cost2, out Doc1, out Doc2, out Sale, out Buy);
        }
    }
}
