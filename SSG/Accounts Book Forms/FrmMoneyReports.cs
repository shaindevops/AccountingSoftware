using BE;
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

namespace SSG.Accounts_Book_Forms
{
    public partial class FrmMoneyReports : Form
    {
        public FrmMoneyReports()
        {
            InitializeComponent();
        }
        BLLFactors bll = new BLLFactors();

        msgclass msg = new msgclass();

        string strToDay = "";

        int Cost1 = 0;
        int Cost2 = 0;
        int Doc1 = 0;
        int Doc2 = 0;
        int Sale = 0;
        int Buy = 0;

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Accounts", 1))
            {
                btnshow.Enabled = true;
            }
            else
            {
                btnshow.Enabled = false;
            }
        }
        private void FrmMoneyReports_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
                if(btnshow.Enabled ==  false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Show Statistics this section!!!", 2, 2);
                }

                chkdate.Checked = true;
                mskdate1.Enabled = true;
                mskdate2.Enabled = true;

                chkyear.Checked = false;
                mskyear.Enabled = false;
                strToDay = DateTime.Now.ToString("MM/dd/yyyy");
                mskdate1.Text = strToDay;
                mskdate2.Text = strToDay;

                mskyear.Text = strToDay.Substring(6, 4);
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Warning", "The system cannot save the Product's photo!!!" + ex.Message, 3, 3);
            }
        }

        private void chkdate_CheckedChanged(object sender, EventArgs e)
        {
            mskdate1.Enabled = chkdate.Checked;
            mskdate2.Enabled = chkdate.Checked;
        }

        private void chkyear_CheckedChanged(object sender, EventArgs e)
        {
            mskyear.Enabled = chkyear.Checked;
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkdate.Checked)
                {
                    bll.GetMoneyReportByDate(mskdate1.Text, mskdate2.Text, out Cost1, out Cost2, out Doc1, out Doc2, out Sale, out Buy);
                }
                else
                {
                    bll.GetMoneyReportByYear(mskyear.Text, out Cost1, out Cost2, out Doc1, out Doc2, out Sale, out Buy);
                }


                lblincome.Text = Cost1.ToString("N0");
                lblcost.Text = Cost2.ToString("N0");
                lbldoc1.Text = Doc1.ToString("N0");
                lbldoc2.Text = Doc2.ToString("N0");
                lblsale.Text = Sale.ToString("N0");
                lblbuy.Text = Buy.ToString("N0");
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Warning", "Connection to the server has been lost!!!" + ex.Message, 3, 3);
            }
        }
    }
}
