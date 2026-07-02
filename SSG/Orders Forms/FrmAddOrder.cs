using BE;
using BLL;
using SSG.People_Forms;
using SSG.Products_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SSG.Orders_Forms
{
    public partial class FrmAddOrder : Form
    {
        public FrmAddOrder()
        {
            InitializeComponent();
        }

        Products P = new Products();
        BLLProducts bllpro = new BLLProducts();

        People Person = new People();
        BLLPeople bllPer = new BLLPeople();

        OrderDetails OD = new OrderDetails();
        BLLOrderDetails bllod = new BLLOrderDetails();

        Orders O = new Orders();
        BLLOrders bllo = new BLLOrders();

        Stocks S = new Stocks();
        BLLStocks blls = new BLLStocks();

        msgclass msg = new msgclass();

        int LastOrderId = 0;
        string strToday = "";

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Orders", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }

        private void FrmAddOrder_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
                if(btnsave.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
                }

                btnnext.Enabled = true;
                btnprev.Enabled = false;

                btnsend.Enabled = false;
                superTabControl1.SelectedTab = superTabItem1;


                strToday = DateTime.Now.ToString("MM/dd/yyyy");
                mskdate.Text = strToday;

                string strYear = strToday.Substring(8, 2);

                if (!bllo.ExistOrderNumber(O))
                {
                    string LastNumber = bllo.GetMaxOrderNumber();
                    string strLast = LastNumber.Substring(3, 4);
                    if (strYear == LastNumber.Substring(0, 2))
                    {
                        txtordernumber.Text = strYear + "-" + (Convert.ToInt32(strLast) + 1).ToString("1000");
                    }
                    else
                    {
                        txtordernumber.Text = strYear + "-" + "1000";
                    }
                }
                else
                {
                    txtordernumber.Text = strYear + "-" + "1000";
                }

                cmbperson.DataSource = null;
                cmbperson.DataSource = bllPer.ReadFillPeople();
                cmbperson.DisplayMember = "Name";


                chknew.Checked = true;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }

        }

        private void cmbperson_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtmobile.Text = ((DataRowView)cmbperson.SelectedItem)["Mobile"].ToString();

                txtemail.Text = ((DataRowView)cmbperson.SelectedItem)["Email"].ToString();

                lblperson.Text = cmbperson.Text;
                lblmobile.Text = txtmobile.Text;
                lblemail.Text = txtemail.Text;
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + ex.Message, 2, 2);
            }
            
        }

        private void btnaddperson_Click(object sender, EventArgs e)
        {
            if (bllu.AccessTo(LoggedUser, "Persons", 1))
            {
                new FrmAddPeople().ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorProvider ep = new ErrorProvider();
                if (superTabControl1.SelectedTab == superTabItem1)
                {
                    if (cmbperson.Text == string.Empty)
                    {
                        ep.SetError(cmbperson, "Select Person Here \n If there is no person in the list,\n click on the opposite button\n and add the person you want to the program.");
                        cmbperson.Focus();
                    }
                    else
                    {
                        ep.Clear();
                        superTabControl1.SelectedTab = superTabItem2;
                        btnprev.Enabled = true;
                    }
                }
                else if (superTabControl1.SelectedTab == superTabItem2)
                {
                    if (dgvOrder.Rows.Count == 0)
                    {
                        ep.SetError(cmbProduct, "Select Product Here");
                        cmbProduct.Focus();
                    }
                    else
                    {
                        
                        ep.Clear();
                        superTabControl1.SelectedTab = superTabItem3;
                        btnnext.Enabled = false;
                    }
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnprev_Click(object sender, EventArgs e)
        {
            try
            {
                if (superTabControl1.SelectedTab == superTabItem3)
                {
                    superTabControl1.SelectedTab = superTabItem2;
                    btnnext.Enabled = true;

                }
                else if (superTabControl1.SelectedTab == superTabItem2)
                {
                    superTabControl1.SelectedTab = superTabItem1;
                    btnprev.Enabled = false;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void txtProductFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtProductFilter.Text.Length != 0)
                {
                    cmbProduct.DataSource = null;
                    cmbProduct.DataSource = blls.FilterStock(txtProductFilter.Text);
                    cmbProduct.DisplayMember = "Name";
                }
                else
                {
                    cmbProduct.DataSource = null;
                }

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
            
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtsize.Text = ((DataRowView)cmbProduct.SelectedItem)["Size"].ToString();
                txtunit1.Text = ((DataRowView)cmbProduct.SelectedItem)["Unit1"].ToString();
                txtUnit2.Text = ((DataRowView)cmbProduct.SelectedItem)["Unit2"].ToString();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                int ProductId = (int)((DataRowView)cmbProduct.SelectedItem)["id"];

                dgvOrder.Rows.Add(cmbProduct.Text, intValue2.Text, txtunit1.Text, ProductId, txtsize.Text);
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvOrder.Rows.RemoveAt(dgvOrder.CurrentRow.Index);
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
                O.OrderDate = mskdate.Text;
                O.OrderNumber = txtordernumber.Text;
                if (chknew.Checked)
                {
                    O.StatusType = chknew.Text;
                }
                else
                {
                    O.StatusType = chkready.Text;
                }
                O.OrderDescription = txtdescription.Text;

                Person = bllPer.ReadN(cmbperson.Text);
                O.People = Person;

                

                bllo.Create(O, Person.id);

                LastOrderId = bllo.GetOrderId();

                for (int i = 0; i < dgvOrder.Rows.Count; i++)
                {
                    double MyValue = (Convert.ToInt32(dgvOrder.Rows[i].Cells[1].Value) * Convert.ToInt32(dgvOrder.Rows[i].Cells[4].Value));
                    OD.DetailValue1 = MyValue;
                    OD.DetailValue2 = Convert.ToInt32(dgvOrder.Rows[i].Cells[1].Value);
                    OD.OrderId = LastOrderId;

                    P = bllpro.ProductName(dgvOrder.Rows[i].Cells[0].Value.ToString());
                    OD.Product = P;

                }
                msg.MyMessagebox("Order Message", bllod.Create(OD, O.id, P.id), 0, 0);

                btnsend.Enabled = true;

                UCShowOrderFrom uc = new UCShowOrderFrom();
                uc.UCShowOrderFrom_Load(null, null);
                
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + ex.Message, 2, 2);
            }
        }
        private void intValue2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtvalue1.Text = (Convert.ToInt32(txtsize.Text) * intValue2.Value).ToString();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnaddproduct_Click(object sender, EventArgs e)
        {
            if (bllu.AccessTo(LoggedUser, "Factors", 1))
            {
                new FrmShowProducts().ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
        }
    }
}
