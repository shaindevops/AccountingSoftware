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
using static Stimulsoft.Base.Drawing.Win32;

namespace SSG.Factors_Forms
{
    public partial class FrmShowFactorFactures : Form
    {
        public FrmShowFactorFactures()
        {
            InitializeComponent();
        }
        BLLFactors bllf = new BLLFactors();


        public int PersonId = 0;
        public int SumSaleFactor = 0;
        public int SumBuyFactor = 0;


        public string PersonName = "";

        msgclass msg = new msgclass();

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Factors", 3))
            {
                btnprint.Enabled = true;
            }
            else
            {
                btnprint.Enabled = false;
            }
        }

        private void FrmShowFactorFactures_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();

                if(btnprint.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Preview this section!!!", 2, 2);
                }

                dgvfactor.DataSource = null;
                dgvfactor.DataSource = bllf.FillFactorByPerson(PersonId);
                dgvfactor.Columns["Type"].DisplayIndex = 11;
                dgvfactor.Columns["id"].Visible = false;
                dgvfactor.Columns["PersonId"].Visible = false;
                dgvfactor.Columns["FactorType"].Visible = false;
                dgvfactor.Columns["FactorDefaultTax"].Visible = false;
                dgvfactor.Columns["FactorDiscountPrice"].Visible = false;
                dgvfactor.Columns["User_id"].Visible = false;

                for (int i = 0; i < dgvfactor.Rows.Count; i++)
                {
                    if ((bool)dgvfactor.Rows[i].Cells[4].Value == false)
                    {
                        dgvfactor.Rows[i].Cells[0].Value = "Sale";
                    }
                    else
                    {
                        dgvfactor.Rows[i].Cells[0].Value = "Buy";
                    }
                }
                txtsales.Text = SumSaleFactor.ToString("N0");
                txtbuys.Text = SumBuyFactor.ToString("N0");

            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                StiReport report = new StiReport();
                report.Compile();

                report.Load("Reports/rptFactureFactors.mrt");
                
                report["PersonId"] = PersonId;
                report["strPersonName"] = PersonName;

                report.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
