using BE;
using BE.Logging;
using BLL;
using DevComponents.DotNetBar.Charts;
using SSG.Depots_Forms;
using SSG.Factors_Forms;
using SSG.Groups_Forms;
using SSG.Stocks_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SSG.Products_Forms
{
    public partial class FrmAddProduct : Form
    {
        public FrmAddProduct()
        {
            InitializeComponent();
        }
        Products P = new Products();
        BLLProducts bll = new BLLProducts();
        Groups G = new Groups();
        BLLGroups bllG = new BLLGroups();
        msgclass msg = new msgclass();
        OpenFileDialog ofd = new OpenFileDialog();
        Image pic;
        public void FillCMB()
        {
            cmbgroup.DataSource = null;
            cmbgroup.DataSource = bllG.GroupName();
        }
        void Clear()
        {
            txtprocode.Text = string.Empty;
            txtproname.Text = string.Empty;
            dblsize.Value = 0;
            intprice.Value = 0;
            intalarm.Value = 0;
            txtdesc.Text = string.Empty;
        }

        private void btnaddgroup_Click(object sender, EventArgs e)
        {
            if (bllu.AccessTo(LoggedUser, "Factors", 1))
            {
                new FrmAddGroups().ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
            
        }

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Factors", 2) )
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
            
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            Permisions();

            if(btnsave.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }


            FillCMB();
        }
        private void btnselectpic_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG(*.JPG)|*.JPG";
            ofd.Title = "Select user image";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic = Image.FromFile(ofd.FileName);
                propic.Image = pic;
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorProvider ep = new ErrorProvider();
                if (cmbgroup.Text == string.Empty)
                {
                    ep.SetError(cmbgroup, "You haven't defined a group yet.\n To register a product, first define a group");
                    cmbgroup.Focus();
                }
                else if (txtproname.Text == string.Empty)
                {
                    ep.Clear();
                    ep.SetError(txtproname, "This Feild Is Required");
                    txtproname.Focus();
                }
                else
                {
                    ep.Clear();
                    P.Code = txtprocode.Text;
                    P.Name = txtproname.Text;
                    P.Size = dblsize.Value;
                    P.DefaultPrice = intprice.Value;
                    P.Alarm = intalarm.Value;
                    P.Description = txtdesc.Text;
                    string date = DateTime.Now.ToString("yyyy/MM/dd");
                    string time = DateTime.Now.ToString("HH : mm : ss");
                    string DT = date + " " + time;
                    P.Regdate = DT;
                    G = bllG.GName(cmbgroup.Text);
                    P.Group = G;

                    if (btnsave.Text == "Save")
                    {
                        try
                        {
                            P.Image = bll.SaveProductImage(ofd.FileName, txtprocode.Text);
                        }
                        catch (Exception imgEx)
                        {
                            msg.MyMessagebox("Warning", "The system cannot save the Product's photo!!!" + imgEx.Message, 3, 3);
                        }
                        msg.MyMessagebox("Create New Product", bll.Create(P, G.id), 0, 0);
                    }
                    else if (btnsave.Text == "Edit")
                    {
                        int id = ((FrmShowProducts)Application.OpenForms["FrmShowProducts"]).id;
                        msg.MyMessagebox("Edition Product", bll.Update(id, P), 0, 0);
                        btnsave.Text = "Save";
                    }
                    var frmshowproducts = Application.OpenForms["FrmShowProducts"] as FrmShowProducts;
                    if (frmshowproducts != null)
                    {
                        frmshowproducts.FillGridProducts();
                    }
                    var frminoutstock = Application.OpenForms["FrmInOutStock"] as FrmInOutStock;
                    if (frminoutstock != null)
                    {
                        frminoutstock.txtsearchproduct_TextChanged(null, null);
                    }
                    var frmaddfactor = Application.OpenForms["FrmInOutStock"] as FrmAddFactor;
                    if (frmaddfactor != null)
                    {
                        frmaddfactor.txtProductFilter_TextChanged(null, null);
                    }
                    var frmmoveproducttodepot = Application.OpenForms["FrmMovmentProductToDepot"] as FrmMovmentProductToDepot;
                    if (frmmoveproducttodepot != null)
                    {
                        frmmoveproducttodepot.txtsearchproduct_TextChanged(null, null);
                    }

                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmAddProduct.btnsave_Click", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
