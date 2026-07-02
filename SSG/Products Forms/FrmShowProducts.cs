using BE;
using BE.Logging;
using BLL;
using SSG.Groups_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.Products_Forms
{
    public partial class FrmShowProducts : Form
    {
        public FrmShowProducts()
        {
            InitializeComponent();
        }
        Products P = new Products();
        BLLProducts bll = new BLLProducts();
        Groups G = new Groups();
        BLLGroups bllG = new BLLGroups();
        msgclass msg = new msgclass();
        public int id;
        int GroupId = 0;
        public void FillGridProducts()
        {
            try
            {
                dgvprolist.DataSource = null;
                btncount.Text = bll.ProductCount();

                chkprogroup.Checked = false;
                cmbsearchby.Enabled = false;
                dgvprolist.DataSource = bll.SearchProducts(txtsearch.Text);
                dgvprolist.Columns["id"].Visible = false;

                if (dgvprolist.Rows.Count == 0)
                {
                    btnedit.Enabled = false;
                    btndelete.Enabled = false;
                }
                else
                {
                    btnedit.Enabled = true;
                    btndelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmShowProducts.FillGridProducts", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
            
            
        }

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Factors", 3) && bllu.AccessTo(LoggedUser, "Factors", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = true;
            }
            else if (bllu.AccessTo(LoggedUser, "Factors", 3) && !bllu.AccessTo(LoggedUser, "Factors", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = false;
            }
            else if (!bllu.AccessTo(LoggedUser, "Factors", 3) && bllu.AccessTo(LoggedUser, "Factors", 4))
            {
                btnedit.Enabled = false;
                btndelete.Enabled = true;
            }
            else
            {
                btnedit.Enabled = false;
                btndelete.Enabled = false;
            }
        }
        private void FrmShowProducts_Load(object sender, EventArgs e)
        {
            Permisions();
            if(btnedit.Enabled == false || btndelete.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Edit and Delete this section!!!", 2, 2);
            }
            else if (btnedit.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Edit this section!!!", 2, 2);
            }
            else if(btndelete.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Delete this section!!!", 2, 2);
            }

            FillGridProducts();
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            P = bll.ReadId(id);
            if(P != null)
            {
                FrmAddProduct fp = new FrmAddProduct();
                fp.lbltitle.Text = "Edit Product Selected";
                fp.cmbgroup.Text = P.GroupName;
                fp.propic.Image = Image.FromFile(P.Image);
                fp.txtprocode.Text = P.Code;
                fp.txtproname.Text = P.Name;
                fp.dblsize.Value = P.Size;
                fp.intprice.Value = P.DefaultPrice;
                fp.intalarm.Value = P.Alarm;
                fp.txtdesc.Text = P.Description;
                fp.btnsave.Text = "Edit";
                fp.ShowDialog();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            P = bll.ReadId(id);
            if (P != null)
            {
                if(msg.MyMessagebox("Remove the product", "Are you sure you want to delete the product?", 1, 1) == DialogResult.Yes)
                {
                    bll.Delete(id);
                }
            }
            FillGridProducts();
        }
        
        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvprolist_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvprolist.SelectedRows.Count > 0)
                {
                    id = (int)dgvprolist.SelectedRows[0].Cells["id"].Value;
                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmShowProducts.dgvprolist_SelectionChanged", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            new FrmAddProduct().ShowDialog();
        }

        private void chkprogroup_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                cmbsearchby.Enabled = chkprogroup.Checked;
                cmbsearchby.DataSource = bllG.GroupName();
                if (chkprogroup.Checked)
                {
                    // NOTE: `G` is a field initialized once as `new Groups()` and never
                    // reassigned anywhere in this form, so `G != null` is always true and
                    // the "no product in this group" branch below is unreachable dead code.
                    // This looks like a pre-existing bug (probably meant to check the result
                    // of a group lookup), left unchanged pending confirmation of intended behavior.
                    if (G != null)
                    {
                        dgvprolist.DataSource = bll.SearchProductsBYGroup(cmbsearchby.Text, txtsearch.Text);
                    }
                    else
                    {
                        msg.MyMessagebox("Server Connection", "Apparently there is no product in this group!!!", 2, 2);
                    }
                }
                else
                {
                    cmbsearchby.Enabled = false;
                    dgvprolist.DataSource = bll.SearchProducts(txtsearch.Text);
                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmShowProducts.chkprogroup_CheckedChanged_1", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnaddgroup_Click_1(object sender, EventArgs e)
        {
            new FrmAddGroups().ShowDialog();

        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                dgvprolist.DataSource = bll.SearchProducts(txtsearch.Text);
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmShowProducts.txtsearch_TextChanged_1", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
