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

namespace SSG
{
    public partial class FrmTax : Form
    {
        public FrmTax()
        {
            InitializeComponent();
        }
        Tax T = new Tax();
        BLLTaxs bll = new BLLTaxs();
        msgclass msg = new msgclass();

        Users Loggeduser = new Users();
        BLLUser bllu = new BLLUser();
        public void permisions()
        {
            Loggeduser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
            if (bllu.AccessTo(Loggeduser, "Settings", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }

        }
        private void FrmTax_Load(object sender, EventArgs e)
        {
            try
            {
                bll.FillTax();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                msg.MyMessagebox("Message", bll.UpdateandCreateTax(dblbuy.Value / 100, dblsale.Value / 100), 0, 0);

                Close();

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
    }
}
