using BE;
using BE.Logging;
using BLL;
using SSG.Products_Forms;
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

namespace SSG.Depots_Forms
{
    public partial class FrmMovmentProductToDepot : Form
    {
        public FrmMovmentProductToDepot()
        {
            InitializeComponent();
        }
        Depots D = new Depots();
        BLLDepot blld = new BLLDepot();

        Products P = new Products();
        BLLProducts bllp = new BLLProducts();

        BLLStocks blls = new BLLStocks();

        msgclass msg = new msgclass();

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

        public void FrmMovmentProductToDepot_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
                if(btnsave.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
                }


                cmbfromdepot.DataSource = blld.ReadFillGrid();
                cmbfromdepot.DisplayMember = "Name";

                cmbtodepot.DataSource = blld.ReadFillGrid();
                cmbtodepot.DisplayMember = "Name";

                mskdate.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmMovmentProductToDepot.FrmMovmentProductToDepot_Load", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        public void txtsearchproduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmbproduct.DataSource = bllp.SearchProducts(txtsearchproduct.Text);
                cmbproduct.DisplayMember = "Product Name";
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmMovmentProductToDepot.txtsearchproduct_TextChanged", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (cmbfromdepot.Text == cmbtodepot.Text)
                {
                    ep.SetError(intcount, "Be careful in choosing Depots!!!");
                    intcount.Focus();
                }
                else
                {
                    ep.Clear();

                    D = blld.DepotName(cmbfromdepot.Text);
                    P = bllp.ProductName(cmbproduct.Text);
                    Depots toDepot = blld.DepotName(cmbtodepot.Text);

                    string result = blls.TransferStock(D.id, toDepot.id, P.id, intcount.Value, mskdate.Text);

                    if (result == "There is not enough stock")
                    {
                        ep.SetError(intcount, "There is not enough stock");
                        intcount.Focus();
                    }
                    else
                    {
                        msg.MyMessagebox("Movement Message", result, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmMovmentProductToDepot.btnsave_Click", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnaddproduct_Click(object sender, EventArgs e)
        {
            if (bllu.AccessTo(LoggedUser, "Factors", 1))
            {
                new FrmAddProduct().ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
            
        }

        private void btnadddepot_Click(object sender, EventArgs e)
        {
            if (bllu.AccessTo(LoggedUser, "Depots", 1))
            {
                new FrmAddDepot().ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
            
        }
    }
}
