using BE;
using BLL;
using Stimulsoft.Report;
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
    public partial class FrmShowFactors : Form
    {
        public FrmShowFactors()
        {
            InitializeComponent();
        }

        Factors F  = new Factors();
        BLLFactors bll = new BLLFactors();

        msgclass msg = new msgclass();

        public bool FrmType = false;


        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Factors", 3) && bllu.AccessTo(LoggedUser, "Factors", 4))
            {
                btnShow.Enabled = true;
                btnpreview.Enabled = true;
                btndelete.Enabled = true;
            }
            else if (bllu.AccessTo(LoggedUser, "Factors", 3) && !bllu.AccessTo(LoggedUser, "Factors", 4))
            {
                btnShow.Enabled = true;
                btnpreview.Enabled = true;
                btndelete.Enabled = false;
            }
            else if (!bllu.AccessTo(LoggedUser, "Factors", 3) && bllu.AccessTo(LoggedUser, "Factors", 4))
            {
                btnShow.Enabled = false;
                btnpreview.Enabled = false;
                btndelete.Enabled = true;
            }
            else
            {
                btnShow.Enabled = false;
                btnpreview.Enabled = false;
                btndelete.Enabled = false;
            }
        }

        public void FrmShowFactors_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();

                if(btnShow.Enabled == false && btnpreview.Enabled == false && btndelete.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Show Details, Preview and Delete this section!!!", 2, 2);
                }
                else if (btnShow.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Show Details this section!!!", 2, 2);
                }
                else if (btnpreview.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Preview this section!!!", 2, 2);
                }
                else if (btndelete.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Delete this section!!!", 2, 2);
                }

                mskdate1.Text = DateTime.Now.ToString("MM/dd/yyyy");
                mskdate2.Text = DateTime.Now.ToString("MM/dd/yyyy");

                if (FrmType)
                {
                    dgvFactors.DataSource = bll.FilterFactorBuyDate(mskdate1.Text, mskdate2.Text);
                    btncount.Text = bll.FactorBuyCount();
                    dgvFactors.Columns["id"].Visible = false;
                    dgvFactors.Columns["PersonId"].Visible = false;
                    dgvFactors.Columns["FactorType"].Visible = false;
                }
                else
                {
                    dgvFactors.DataSource = bll.FilterFactorSaleDate(mskdate1.Text, mskdate2.Text);
                    btncount.Text = bll.FactorSaleCount();
                    dgvFactors.Columns["id"].Visible = false;
                    dgvFactors.Columns["PersonId"].Visible = false;
                    dgvFactors.Columns["FactorType"].Visible = false;
                }
                if(dgvFactors.Rows.Count == 0)
                {
                    btnShow.Enabled = false;
                    btndelete.Enabled = false;
                }
                else
                {
                    btnShow.Enabled = true;
                    btndelete.Enabled = true;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(msg.MyMessagebox("Confirm Deletion", "Are you sure you want to delete the Factor?\r\nBy deleting the Factor, all the items related to the Factor will be removed!!!", 1, 1) == DialogResult.Yes)
                {
                    bll.DeleteFactor((int)dgvFactors.CurrentRow.Cells[0].Value);
                }
                FrmShowFactors_Load(null, null);
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            FrmAddFactor addf = new FrmAddFactor();
            addf.FrmType = FrmType;
            addf.ShowDialog();
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            try
            {
                StiReport report = new StiReport();
                if (FrmType)
                {
                    report.Load("Reports/rptShowBuyFactor.mrt");
                }
                else
                {
                    report.Load("Reports/rptShowSaleFactor.mrt");
                }
                report.Compile();

                report["strDate1"] = mskdate1.Text;
                report["strDate2"] = mskdate2.Text;

                report.ShowWithRibbonGUI();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                FrmConfirm fc = new FrmConfirm();
                fc.FactorId = (int)dgvFactors.CurrentRow.Cells[0].Value;
                fc.FrmType = (bool)dgvFactors.CurrentRow.Cells[4].Value;
                fc.ShowDialog();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void mskdate1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (FrmType)
                {
                    dgvFactors.DataSource = bll.FilterFactorBuyDate(mskdate1.Text, mskdate2.Text);
                    btncount.Text = bll.FactorBuyCount();
                    dgvFactors.Columns["id"].Visible = false;
                    dgvFactors.Columns["PersonId"].Visible = false;
                }
                else
                {
                    dgvFactors.DataSource = bll.FilterFactorSaleDate(mskdate1.Text, mskdate2.Text);
                    btncount.Text = bll.FactorSaleCount();
                    dgvFactors.Columns["id"].Visible = false;
                    dgvFactors.Columns["PersonId"].Visible = false;
                }
                if (dgvFactors.Rows.Count == 0)
                {
                    btnShow.Enabled = false;
                    btndelete.Enabled = false;
                }
                else
                {
                    btnShow.Enabled = true;
                    btndelete.Enabled = true;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void mskdate2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (FrmType)
                {
                    dgvFactors.DataSource = bll.FilterFactorBuyDate(mskdate1.Text, mskdate2.Text);
                    btncount.Text = bll.FactorBuyCount();
                    dgvFactors.Columns["id"].Visible = false;
                    dgvFactors.Columns["PersonId"].Visible = false;
                }
                else
                {
                    dgvFactors.DataSource = bll.FilterFactorSaleDate(mskdate1.Text, mskdate2.Text);
                    btncount.Text = bll.FactorSaleCount();
                    dgvFactors.Columns["id"].Visible = false;
                    dgvFactors.Columns["PersonId"].Visible = false;
                }
                if (dgvFactors.Rows.Count == 0)
                {
                    btnShow.Enabled = false;
                    btndelete.Enabled = false;
                }
                else
                {
                    btnShow.Enabled = true;
                    btndelete.Enabled = true;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
