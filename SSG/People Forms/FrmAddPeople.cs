using BE;
using BLL;
using SSG.Factors_Forms;
using SSG.Orders_Forms;
using SSG.Tasks_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.People_Forms
{
    public partial class FrmAddPeople : Form
    {
        public FrmAddPeople()
        {
            InitializeComponent();
        }
        People P = new People();
        BLLPeople bll = new BLLPeople();
        msgclass msg = new msgclass();

        void Clear()
        {
            rdoperson.Checked = false;
            rdocompany.Checked = false;
            txtname.Text = string.Empty;
            txtmobile.Text = string.Empty;
            txttel.Text = string.Empty;
            txtemail.Text = string.Empty;
            intdebtor.Value = 0;
            intcreditor.Value = 0;
            txtaddress.Text = string.Empty;
            txtdesc.Text = string.Empty;

        }
        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Persons", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }

        private void FrmAddPeople_Load(object sender, EventArgs e)
        {
            Permisions();
            if(btnsave.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            ErrorProvider ep = new ErrorProvider();
            if(txtname.Text == string.Empty)
            {
                ep.SetError(txtname, "This field is required");
            }
            else if(txtmobile.Text == string.Empty)
            {
                ep.Clear();
                ep.SetError(txtmobile, "This field is required");
            }
            else
            {
                ep.Clear();
                if(rdoperson.Checked)
                {
                    P.Type = rdoperson.Text;
                }
                else
                {
                    P.Type = rdocompany.Text;
                }

                P.Name = txtname.Text;
                P.Mobile = txtmobile.Text;
                P.Tel = txttel.Text;
                P.Email = txtemail.Text;
                P.Debtor = intdebtor.Value;
                P.Creditor = intcreditor.Value;
                P.Address = txtaddress.Text;
                P.Description = txtdesc.Text;
                string date = DateTime.Now.ToString("yyyy/MM/dd");
                string time = DateTime.Now.ToString("HH : mm : ss");
                string DT = date +" " + time;
                P.Regdate = DT;

                if (btnsave.Text == "Save")
                {
                    msg.MyMessagebox("Create New Person", bll.Create(P), 0, 0);
                    Clear();
                }
                else if(btnsave.Text == "Edit")
                {
                    int id = ((FrmShowPeople)Application.OpenForms["FrmShowPeople"]).id;
                    msg.MyMessagebox("Edit Person", bll.Update(id, P), 0, 0);
                    btnsave.Text = "Save";
                    
                }
                var frmshowpeople = Application.OpenForms["FrmShowPeople"] as FrmShowPeople;
                if (frmshowpeople != null)
                {
                    frmshowpeople.FillPeople();
                }
                var frmaddfactor = Application.OpenForms["FrmAddFactor"] as FrmAddFactor;
                if (frmaddfactor != null)
                {
                    frmaddfactor.txtPersonFilter_TextChanged(null, null);
                }
                var frmaddtask = Application.OpenForms["FrmAddTask"] as FrmAddTask;
                if (frmaddtask != null)
                {
                    frmaddtask.FrmAddTask_Load(null, null);
                }
                Clear();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
