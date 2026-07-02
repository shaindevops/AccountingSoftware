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

namespace SSG.Factors_Forms
{
    public partial class FrmConfirm : Form
    {
        public FrmConfirm()
        {
            InitializeComponent();
        }

        Details D = new Details();
        BLLDetails blld = new BLLDetails();

        Depots De = new Depots();
        BLLDepot bllde = new BLLDepot();

        Stocks St = new Stocks();
        BLLStocks BLLStocks = new BLLStocks();

        Products p = new Products();
        BLLProducts bllp = new BLLProducts();
        BLLFactors bllf = new BLLFactors();

        msgclass msg = new msgclass();

        public int FactorId = 0;
        int ProductStock = 0;
        int productId = 0;
        public bool FrmType = false;


        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Factors", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }

        private void FrmConfirm_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
                if(btnsave.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
                }

                dgvproducts.DataSource = null;
                dgvproducts.DataSource = bllf.FillViewFactorsDetails(FactorId);
                dgvproducts.Columns["id"].Visible = false;
                dgvproducts.Columns["FactorId"].Visible = false;
                dgvproducts.Columns["DepotId"].Visible = false;
                dgvproducts.Columns["ProductId"].Visible = false;
                dgvproducts.Columns["FactorNumber"].Visible = false;
                dgvproducts.Columns["Group_id"].Visible = false;
                dgvproducts.Columns["PersonId"].Visible = false;
                dgvproducts.Columns["Product Name"].Visible = false;
                dgvproducts.Columns["FactorType"].Visible = false;
                dgvproducts.Columns["FactorDate"].Visible = false;
                dgvproducts.Columns["FactorPrice"].Visible = false;
                dgvproducts.Columns["FactorDefaultTax"].Visible = false;
                dgvproducts.Columns["FactorTaxPrice"].Visible = false;
                dgvproducts.Columns["FactorServicePrice"].Visible = false;
                dgvproducts.Columns["FactorDiscountPrice"].Visible = false;
                dgvproducts.Columns["FactorSumPrice"].Visible = false;
                dgvproducts.Columns["Size"].Visible = false;
                dgvproducts.Columns["DefaultPrice"].Visible = false;
                dgvproducts.Columns["Number"].Visible = false;
                dgvproducts.Columns["Amount"].Visible = false;
                dgvproducts.Columns["First Unit"].Visible = false;
                dgvproducts.Columns["DetailExit"].Visible = false;

                if (FrmType)
                {
                    grpdepot.Enabled = false;
                    btnsave.Enabled = false;
                }
                else
                {
                    grpdepot.Enabled = true;
                    btnsave.Enabled = true;
                    if(dgvproducts.CurrentRow != null)
                    {
                        p = bllp.ProductName(dgvproducts.CurrentRow.Cells[9].Value.ToString());
                        productId = p.id;
                        int depotId = (int)dgvproducts.CurrentRow.Cells["DepotId"].Value;
                        // تنظیم دیتا سورس کمبوباکس انبار
                        cmbDepot.DataSource = null; // پاک کردن دیتا سورس قبلی
                        cmbDepot.DataSource = bllde.FillDepotByProducts(productId);
                        cmbDepot.ValueMember = "id";
                        cmbDepot.DisplayMember = "Name";

                        // تنظیم موجودی محصول و نمایش آن

                        ProductStock = BLLStocks.GetProductSttockInDepot(depotId, productId);
                        txtstock.Text = ProductStock.ToString();

                        txtunit2.Text = dgvproducts.CurrentRow.Cells["Unit2"].Value.ToString();
                    }
                    
                }
                
                
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
                if ((bool)dgvproducts.CurrentRow.Cells[15].Value == true)
                {
                    msg.MyMessagebox("Attention!!!", "This product has already been approved", 3, 3);
                }
                else
                {
                    St.FactorId = FactorId;
                    p = bllp.ProductName(dgvproducts.CurrentRow.Cells[8].Value.ToString());
                    St.Product = p;
                    St.ProductId = p.id;

                    De = bllde.DepotName(cmbDepot.Text);
                    St.DepotId = De.id;

                    St.RegDate = dgvproducts.CurrentRow.Cells[12].Value.ToString();
                    St.Description = "Sale by number: " + dgvproducts.CurrentRow.Cells[2].Value.ToString();
                    St.StockIn = 0;
                    St.StockOut = (int)dgvproducts.CurrentRow.Cells[12].Value;
                    

                    BLLStocks.Create(St, FactorId, De.id, p.id);

                    blld.UpdateDetail((int)dgvproducts.CurrentRow.Cells[0].Value, St.DepotId);

                    msg.MyMessagebox("Message", "The Factor confirmation operation was successfully completed.\r\nAlso, the Stock of Depot was updated.", 0, 0);

                    FrmConfirm_Load(null, null);
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void dgvproducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (FrmType)
                {
                    grpdepot.Enabled = false;
                    btnsave.Enabled = false;
                }
                else
                {
                    grpdepot.Enabled = true;
                    btnsave.Enabled = true;
                    if (dgvproducts.CurrentRow != null)
                    {
                        p = bllp.ProductName(dgvproducts.CurrentRow.Cells[8].Value.ToString());
                        productId = p.id;
                        int depotId = (int)dgvproducts.CurrentRow.Cells["DepotId"].Value;
                        // تنظیم دیتا سورس کمبوباکس انبار
                        cmbDepot.DataSource = null; // پاک کردن دیتا سورس قبلی
                        cmbDepot.DataSource = bllde.FillDepotByProducts(productId);
                        
                        cmbDepot.DisplayMember = "DepotName";

                        // تنظیم موجودی محصول و نمایش آن

                        ProductStock = BLLStocks.GetProductSttockInDepot(depotId, productId);
                        txtstock.Text = ProductStock.ToString();

                        txtunit2.Text = dgvproducts.CurrentRow.Cells["Unit2"].Value.ToString();
                    }
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void dgvproducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (FrmType)
                {
                    grpdepot.Enabled = false;
                    btnsave.Enabled = false;
                }
                else
                {
                    grpdepot.Enabled = true;
                    btnsave.Enabled = true;
                    if (dgvproducts.CurrentRow != null)
                    {
                        productId = (int)dgvproducts.CurrentRow.Cells["ProductId"].Value;
                        int depotId = (int)dgvproducts.CurrentRow.Cells["DepotId"].Value;
                        // تنظیم دیتا سورس کمبوباکس انبار
                        cmbDepot.DataSource = null; // پاک کردن دیتا سورس قبلی
                        cmbDepot.DataSource = bllde.FillDepotByProducts(productId);
                        cmbDepot.ValueMember = "id";
                        cmbDepot.DisplayMember = "Name";

                        // تنظیم موجودی محصول و نمایش آن

                        ProductStock = BLLStocks.GetProductSttockInDepot(depotId, productId);

                        txtstock.Text = ProductStock.ToString();

                        txtunit2.Text = dgvproducts.CurrentRow.Cells[16].Value.ToString();
                    }
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
