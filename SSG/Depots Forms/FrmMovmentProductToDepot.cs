using BE;
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

        Stocks S = new Stocks();
        BLLStocks blls = new BLLStocks();

        msgclass msg = new msgclass();

        int SumStock = 0;

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
            catch
            {
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
            catch
            {
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
                    
                    //Out Stock 
                    D = blld.DepotName(cmbfromdepot.Text);
                    S.DepotId = D.id;

                    P = bllp.ProductName(cmbproduct.Text);
                    S.Product = P;
                    S.ProductId = P.id;

                    S.RegDate = mskdate.Text;
                    S.Description = "Move This Product To " + cmbtodepot.Text;
                    S.StockIn = 0;
                    S.StockOut = intcount.Value;
                    SumStock = blls.GetProductSttockInDepot(S.DepotId, S.ProductId);
                    if (intcount.Value > SumStock)
                    {
                        ep.SetError(intcount, "There is not enough stock");
                        intcount.Focus();
                    }
                    else
                    {
                        ep.Clear();
                        blls.Create(S, 0, D.id, P.id);
                        //In Srock
                        D = blld.DepotName(cmbtodepot.Text);
                        S.DepotId = D.id;

                        P = bllp.ProductName(cmbproduct.Text);
                        S.Product = P;
                        S.ProductId = P.id;

                        S.RegDate = mskdate.Text;
                        S.Description = "Move This Product From " + cmbfromdepot.Text;
                        S.StockIn = intcount.Value;
                        S.StockOut = 0;
                        blls.Create(S, 0, D.id, P.id);

                        msg.MyMessagebox("Movement Message", "The operation of transferring the product to another Depot was successfully completed.", 0, 0);
                    }
                }
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
