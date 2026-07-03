using BE;
using BE.Logging;
using BLL;
using SSG.Depots_Forms;
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

namespace SSG.Stocks_Forms
{
    public partial class FrmInOutStock : Form
    {
        public FrmInOutStock()
        {
            InitializeComponent();
        }
        Stocks S = new Stocks();
        BLLStocks bll = new BLLStocks();

        Products P = new Products();
        BLLProducts bllpro = new BLLProducts();

        Depots D = new Depots();
        BLLDepot blld = new BLLDepot();
        msgclass msg = new msgclass();

        public int StockId = 0;

        int SumStock = 0;

        string strToday = "";

        public bool InOut = false;

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

            if(bllu.AccessTo(LoggedUser, "Depots", 1))
            {
                btnadddepot.Enabled = true;
            }
            else
            {
                btnadddepot.Enabled = false;
            }

            if (bllu.AccessTo(LoggedUser, "Factors", 1))
            {
                btnaddgroup.Enabled = true;
            }
            else
            {
                btnaddgroup.Enabled = false;
            }
        }
        public void FrmInOutStock_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();

                if(btnsave.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
                }
                cmbdepot.DataSource = null;
                cmbdepot.DataSource = blld.ReadFillGrid();
                cmbdepot.DisplayMember = "Name";
                if(InOut)
                {
                    grpinoutstock.Text = "Enter the product manually";
                    lbltitle.Text = grpinoutstock.Text;
                }
                else
                {
                    grpinoutstock.Text = "Leave the product manually";
                    lbltitle.Text = grpinoutstock.Text;
                }

                strToday = DateTime.Now.ToShortDateString();
                mskregdate.Text = strToday;
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmInOutStock.FrmInOutStock_Load", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        public void txtsearchproduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmbproduct.DataSource = null;
                cmbproduct.DataSource = bllpro.SearchProducts(txtsearchproduct.Text);
                cmbproduct.DisplayMember = "Product Name";
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmInOutStock.txtsearchproduct_TextChanged", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                S.RegDate = mskregdate.Text;
                S.Description = txtdesc.Text;
                S.FactorId = 0;

                P = bllpro.ProductName(cmbproduct.Text);
                S.Product = P;
                S.ProductId = P.id;

                D = blld.DepotName(cmbdepot.Text);
                S.DepotId = D.id;

                if (InOut)
                {
                    S.StockIn = intcount.Value;
                    S.StockOut = 0;
                }
                else
                {
                    SumStock = bll.GetProductSttockInDepot(S.DepotId, S.ProductId);
                    if (intcount.Value > SumStock)
                    {
                        ep.SetError(intcount, "There is not enough stock");
                        intcount.Focus();
                    }
                    else
                    {
                        S.StockIn = 0;
                        S.StockOut = intcount.Value;
                    }
                }

                if (btnsave.Text == "Save")
                {
                    msg.MyMessagebox("Registration Message", bll.Create(S, 0, D.id, P.id), 0, 0);
                }
                else if (btnsave.Text == "Edit")
                {
                    msg.MyMessagebox("Registration Message", bll.UpdateStock(StockId, S), 0, 0);
                    btnsave.Text = "Save";
                }

                var frmshowstock = Application.OpenForms["FrmShowStocks"] as FrmShowStocks;
                if (frmshowstock != null)
                {
                    frmshowstock.FrmShowStocks_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmInOutStock.btnsave_Click", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnaddgroup_Click(object sender, EventArgs e)
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
