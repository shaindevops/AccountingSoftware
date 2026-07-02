using BE;
using BLL;
using SSG.People_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.CostGroup_Forms
{
    public partial class FrmShowCostGroup : Form
    {
        public FrmShowCostGroup()
        {
            InitializeComponent();
        }
        CostGroup CG = new CostGroup();
        BLLCostGroup bll = new BLLCostGroup();
        msgclass msg = new msgclass();

        public bool CostType = false;

        public int id;
        string MessageBody = "";

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Accounts", 3) && bllu.AccessTo(LoggedUser, "Accounts", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = true;
            }
            else if (bllu.AccessTo(LoggedUser, "Accounts", 3) && !bllu.AccessTo(LoggedUser, "Accounts", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = false;
            }
            else if (!bllu.AccessTo(LoggedUser, "Accounts", 3) && bllu.AccessTo(LoggedUser, "Accounts", 4))
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


        public void FrmShowCostGroup_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();

                if(btnedit.Enabled == false && btndelete.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Edit and Delete this section!!!", 2, 2);
                }
                else if (btnedit.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Edit this section!!!", 2, 2);
                }
                else if (btndelete.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Delete this section!!!", 2, 2);
                }

                if (CostType)
                {
                    grpshowcostgroup.Text = "Show Income List";
                    dgvcostgroup.DataSource = null;
                    dgvcostgroup.DataSource = bll.FillCostGroupBYTypeIncome();
                    dgvcostgroup.Columns["id"].Visible = false;
                    MessageBody = "Income";
                }
                else
                {
                    grpshowcostgroup.Text = "Show Cost List";
                    dgvcostgroup.DataSource = null;
                    dgvcostgroup.DataSource = bll.FillCostGroupBYTypeCosts();
                    dgvcostgroup.Columns["id"].Visible = false;
                    MessageBody = "Cost";
                }
                if(dgvcostgroup.Rows.Count == 0)
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
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCostGroup fcg = new FrmCostGroup();
                fcg.CostType = CostType;
                if (CostType)
                {
                    fcg.grpcost.Text = "Cost Specification";
                }
                else
                {
                    fcg.grpcost.Text = "Income Specification";
                }
                fcg.ShowDialog();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                CG = bll.ReadId(id);
                if( CG != null )
                {
                    FrmCostGroup fcg = new FrmCostGroup();
                    fcg.CostType = CostType;
                    if (CostType)
                    {
                        fcg.grpcost.Text = "Cost Specification";
                    }
                    else
                    {
                        fcg.grpcost.Text = "Income Specification";
                    }
                    fcg.lbltitle.Text = "Edit Selected";
                    fcg.txtname.Text = CG.Name;
                    fcg.txtdesc.Text = CG.Description;
                    fcg.ShowDialog();
                }
                
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                CG = bll.ReadId(id);
                if (CG != null)
                {
                    if (msg.MyMessagebox("Deletion", "Are you sure you want to remove this " + MessageBody + " ?", 1, 1) == DialogResult.Yes)
                    {
                        bll.Delete(id);
                    }
                }
                FrmShowCostGroup_Load(null, null);
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }

        }

        private void dgvcostgroup_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dgvcostgroup.SelectedRows.Count > 0)
                {
                    id = (int)dgvcostgroup.SelectedRows[0].Cells["id"].Value;
                }
                
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
