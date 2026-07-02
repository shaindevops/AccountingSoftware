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

namespace SSG.CostGroup_Forms
{
    public partial class FrmCostGroup : Form
    {
        public FrmCostGroup()
        {
            InitializeComponent();
        }
        CostGroup CG = new CostGroup();
        BLLCostGroup bll = new BLLCostGroup();
        msgclass msg = new msgclass();

        // daramad = 1    hazineh = 0

        public bool CostType = false;
        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Accounts", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }

        private void FrmCostGroup_Load(object sender, EventArgs e)
        {
            Permisions();
            if(btnsave.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
            }

            if (CostType)
            {
                grpcost.Text = "Income Specifications";
            }
            else
            {
                grpcost.Text = "Cost Specifications";
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            ErrorProvider ep = new ErrorProvider();
            if(txtname.Text == string.Empty)
            {
                ep.SetError(txtname, "This field is required");

                txtname.Focus();
            }
            else
            {
                ep.Clear();
                CG.Type = CostType;
                CG.Static = false;
                CG.Name = txtname.Text;
                CG.Description = txtdesc.Text;
                string date = DateTime.Now.ToString("yyyy/MM/dd");
                string time = DateTime.Now.ToString("HH : mm : ss");
                string DT = date + " " + time;
                CG.Regdate = DT;
                if (btnsave.Text == "Save")
                {
                    msg.MyMessagebox("Create New", bll.Create(CG), 0, 0);
                    ((FrmShowCostGroup)Application.OpenForms["FrmShowCostGroup"]).FrmShowCostGroup_Load(null, null);
                    txtname.Text = string.Empty;
                    txtdesc.Text = string.Empty;
                    txtname.Focus();
                }
                else if(btnsave.Text == "Edit")
                {
                    int id = ((FrmShowCostGroup)Application.OpenForms["FrmShowCostGroup"]).id;
                    msg.MyMessagebox("", bll.Update(id, CG), 0, 0);
                    btnsave.Text = "Save";
                    ((FrmShowCostGroup)Application.OpenForms["FrmShowCostGroup"]).FrmShowCostGroup_Load(null, null);
                }
            }
        }
    }
}
