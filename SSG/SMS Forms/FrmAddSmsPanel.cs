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

namespace SSG.SMS_Forms
{
    public partial class FrmAddSmsPanel : Form
    {
        public FrmAddSmsPanel()
        {
            InitializeComponent();
        }


        SmsPanel panel = new SmsPanel();
        BLLSmsPanel bll = new BLLSmsPanel();

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        msgclass msg = new msgclass();

        public int PanelId = 0;

        public void Clear()
        {
            txtpanelname.Text = string.Empty;
            txtsid.Text = string.Empty;
            txtkey.Text = string.Empty;
            txtphone.Text = string.Empty;
            txtpanelname.Focus();
        }
        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if(bllu.AccessTo(LoggedUser, "Settings", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }
        private void FrmAddSmsPanel_Load(object sender, EventArgs e)
        {
            Permisions();
            if (btnsave.Enabled ==false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtpanelname.Text == string.Empty)
            {
                ep.SetError(txtpanelname, "Enter Name Of Sms Panel");
                txtpanelname.Focus();
            }
            else if(txtsid.Text == string.Empty)
            {
                ep.Clear();
                ep.SetError(txtsid, "Enter Account SID");
                txtsid.Focus();
            }
            else if (txtkey.Text == string.Empty)
            {
                ep.Clear();
                ep.SetError(txtkey, "Enter Account Auth Key");
                txtkey.Focus();
            }
            else if (txtphone.Text == string.Empty)
            {
                ep.Clear();
                ep.SetError(txtphone, "Enter Sneder Phone Number");
                txtphone.Focus();
            }
            else
            {
                ep.Clear();
                panel.PanelName = txtpanelname.Text;
                panel.PanelSID = txtsid.Text;
                panel.PanelAuthKey = txtkey.Text;
                panel.PanelNumber = txtphone.Text;

                if(btnsave.Text == "Save")
                {
                    msg.MyMessagebox("Success Message", bll.Create(panel), 0, 0);
                }
                else if(btnsave.Text == "Edit")
                {
                    msg.MyMessagebox("Success Message", bll.Update(PanelId, panel), 0, 0);
                    btnsave.Text = "Save";
                }

                Clear();

                var frmshowsmspanel = Application.OpenForms[""] as FrmShowPanels;
                if (frmshowsmspanel != null)
                {
                    frmshowsmspanel.FrmShowPanels_Load(null, null);
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
