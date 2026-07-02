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

namespace SSG.Stocks_Forms
{
    public partial class FrmSelectStock : Form
    {
        public FrmSelectStock()
        {
            InitializeComponent();
        }
        msgclass msg = new msgclass();
        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Depots", 1))
            {
                btnIn.Enabled = true;
                btnOut.Enabled = true;
            }
            else
            {
                btnIn.Enabled = false;
                btnOut.Enabled = false;
            }
        }
        private void FrmSelectStock_Load(object sender, EventArgs e)
        {
            Permisions();

            if(!btnIn.Enabled || !btnOut.Enabled)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            FrmInOutStock IS = new FrmInOutStock();
            IS.InOut = true;
            IS.ShowDialog();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            FrmInOutStock IS = new FrmInOutStock();
            IS.InOut = false;
            IS.ShowDialog();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
