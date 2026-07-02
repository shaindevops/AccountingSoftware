using BE;
using BLL;
using SSG.Groups_Forms;
using SSG.Products_Forms;
using SSG.Stocks_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.Depots_Forms
{
    public partial class FrmAddDepot : Form
    {
        Depots D = new Depots();
        BLLDepot bll = new BLLDepot();
        msgclass msg = new msgclass();

        public FrmAddDepot()
        {
            InitializeComponent();
        }
        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Depots", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }


        private void FrmAddDepot_Load(object sender, EventArgs e)
        {
            Permisions();
            if(btnsave.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
            }
            txtdepotname.Focus();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtdepotname.Text == string.Empty)
                {
                    ErrorProvider ep = new ErrorProvider();
                    ep.SetError(txtdepotname, "This Field is Required");
                }
                else
                {
                    D.Name = txtdepotname.Text;
                    string date = DateTime.Now.ToString("yyyy/MM/dd");
                    string time = DateTime.Now.ToString("HH : mm : ss");
                    string DT = date + time;
                    D.Regdate = DT;
                    if (btnsave.Text == "Save")
                    {
                        msg.MyMessagebox("New Depot", bll.Create(D), 0, 0);
                    }
                    else if (btnsave.Text == "Edit")
                    {
                        int id = ((FrmShowDepots)Application.OpenForms["FrmShowDepots"]).id;
                        msg.MyMessagebox("Edition Depot", bll.Update(id, D), 0, 0);
                        btnsave.Text = "Save";
                    }
                }
                txtdepotname.Text = string.Empty;
                txtdepotname.Focus();
                FrmAddDepot_Load(null, null);

                var FrmShowDepots = Application.OpenForms["FrmShowDepots"] as FrmShowDepots;
                if (FrmShowDepots != null)
                {
                    FrmShowDepots.FrmShowDepots_Load(null, null);
                }

                var FrmInOutStock = Application.OpenForms["FrmShowProducts"] as FrmInOutStock;
                if (FrmInOutStock != null)
                {
                    FrmInOutStock.FrmInOutStock_Load(null, null);
                }

                var FrmMovmentProductToDepot = Application.OpenForms["FrmInOutStock"] as FrmMovmentProductToDepot;
                if (FrmMovmentProductToDepot != null)
                {
                    FrmMovmentProductToDepot.FrmMovmentProductToDepot_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmAddDepot.btnsave_Click", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }


        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
