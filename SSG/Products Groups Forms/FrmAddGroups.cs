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

namespace SSG.Groups_Forms
{
    public partial class FrmAddGroups : Form
    {
        public FrmAddGroups()
        {
            InitializeComponent();
        }
        Groups G = new Groups();
        BLLGroups bll = new BLLGroups();
        msgclass msg = new msgclass();

        void Clear()
        {
            txtgroupname.Text = string.Empty;
            txtunit1.Text = string.Empty;
            txtunit2.Text = string.Empty;
        }
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

        private void FrmAddGroups_Load(object sender, EventArgs e)
        {
            Permisions();
            if (!btnsave.Enabled)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorProvider ep = new ErrorProvider();
                if (txtgroupname.Text == string.Empty)
                {
                
                    ep.SetError(txtgroupname, "This Field is Required");
                }
                else if(txtunit1.Text == string.Empty)
                {
                    ep.Clear();
                    ep.SetError(txtunit1, "This Field is Required");
                }
                else if(txtunit2.Text == string.Empty)
                {
                    ep.Clear();
                    ep.SetError(txtunit2, "This Field is Required");
                }
                else
                {
                    ep.Clear();
                    G.Name = txtgroupname.Text;
                    G.Unit1 = txtunit1.Text;
                    G.Unit2 = txtunit2.Text;
                    string date = DateTime.Now.ToString("yyyy/MM/dd");
                    string time = DateTime.Now.ToString("HH : mm : ss");
                    string DT = date + " " + time;
                    G.Regdate = DT;


                    if (btnsave.Text == "Save")
                    {
                        msg.MyMessagebox("Create New Group", bll.Create(G), 0, 0);
                    
                    }
                    else
                    {
                        int id = ((FrmShowGroups)Application.OpenForms["FrmShowGroups"]).id;
                        msg.MyMessagebox("Create New Group", bll.Update(id, G), 0, 0);
                        btnsave.Text = "Save";
                    }
                }
                txtgroupname.Focus();
                Clear();
                var frmShowGroups = Application.OpenForms["FrmShowGroups"] as FrmShowGroups;
                if (frmShowGroups != null)
                {
                    frmShowGroups.FrmShowGroups_Load(null, null);
                }

                var frmShowProducts = Application.OpenForms["FrmShowProducts"] as FrmShowProducts;
                if (frmShowProducts != null)
                {
                    frmShowProducts.FillGridProducts();
                }

                var frmAddProduct = Application.OpenForms["FrmAddProduct"] as FrmAddProduct;
                if (frmAddProduct != null)
                {
                    frmAddProduct.FillCMB();
                }

            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
