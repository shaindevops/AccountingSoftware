using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.Factors_Forms
{
    public partial class FrmFactorReports : Form
    {
        public FrmFactorReports()
        {
            InitializeComponent();
        }

        BLLFactors bllf = new BLLFactors();

        msgclass msg = new msgclass();

        int SumBook = 0;
        int SumFactor = 0;

        public bool FrmType = false;

        public void FillGridByDates()
        {
            try
            {
                mskdate1.Text = DateTime.Now.ToString("MM/dd/yyyy");
                mskdate2.Text = DateTime.Now.ToString("MM/dd/yyyy");

                if (FrmType)
                {
                   grp1.Text = "View Purchases Reports";
                }
                else
                {
                    grp1.Text = "View Sales Reports";
                }

                dgvfactors.Columns["id"].Visible = false;
                dgvfactors.Columns["PersonId"].Visible = false;
                dgvfactors.Columns["FactorType"].Visible = false;

            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Warning", "Connection to the server has been lost!!!" + ex.Message, 3, 3);
            }
        }
        private void FrmFactorReports_Load(object sender, EventArgs e)
        {
           FillGridByDates();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mskdate1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int intSumFactor = 0;
                int intSumBook = 0;

                if (FrmType)
                {
                    dgvfactors.DataSource = bllf.FilterBuyFactor(mskdate1.Text, mskdate2.Text);
                    bllf.GetSumBuyFactor(mskdate1.Text, mskdate2.Text, out SumFactor, out SumBook);
                }
                else
                {
                    dgvfactors.DataSource = bllf.FilterSaleFactor(mskdate1.Text, mskdate2.Text);
                    bllf.GetSumSaleFactor(mskdate1.Text, mskdate2.Text, out SumFactor, out SumBook);
                }

                dgvfactors.Columns["id"].Visible = false;
                dgvfactors.Columns["PersonId"].Visible = false;
                dgvfactors.Columns["FactorType"].Visible = false;

                intSumFactor = SumFactor;
                intSumBook = SumBook;

                txtfactorsum.Text = intSumFactor.ToString("N0");
                txtsettle.Text = intSumBook.ToString("N0");
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Warning", "The system cannot save the Product's photo!!!" + ex.Message, 3, 3);
            }
            
        }

        private void mskdate2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int intSumFactor = 0;
                int intSumBook = 0;

                if (FrmType)
                {
                    dgvfactors.DataSource = bllf.FilterBuyFactor(mskdate1.Text, mskdate2.Text);
                    bllf.GetSumBuyFactor(mskdate1.Text, mskdate2.Text, out SumFactor, out SumBook);
                }
                else
                {
                    dgvfactors.DataSource = bllf.FilterSaleFactor(mskdate1.Text, mskdate2.Text);
                    bllf.GetSumSaleFactor(mskdate1.Text, mskdate2.Text, out SumFactor, out SumBook);
                }

                dgvfactors.Columns["id"].Visible = false;
                dgvfactors.Columns["PersonId"].Visible = false;
                dgvfactors.Columns["FactorType"].Visible = false;

                intSumFactor = SumFactor;
                intSumBook = SumBook;

                txtfactorsum.Text = intSumFactor.ToString("N0");
                txtsettle.Text = intSumBook.ToString("N0");
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Warning", "The system cannot save the Product's photo!!!" + ex.Message, 3, 3);
            }
        }
    }
}
