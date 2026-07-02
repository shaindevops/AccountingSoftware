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
    public partial class FrmShowPanels : Form
    {
        public FrmShowPanels()
        {
            InitializeComponent();
        }

        SmsPanel sp = new SmsPanel();
        BLLSmsPanel bll = new BLLSmsPanel();

        msgclass msg = new msgclass();


        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Settings", 3) && bllu.AccessTo(LoggedUser, "Settings", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = true;
            }
            else if (bllu.AccessTo(LoggedUser, "Settings", 3) && !bllu.AccessTo(LoggedUser, "Settings", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = false;
            }
            else if (!bllu.AccessTo(LoggedUser, "Settings", 3) && bllu.AccessTo(LoggedUser, "Settings", 4))
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
        public void FrmShowPanels_Load(object sender, EventArgs e)
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
            dgvpanels.DataSource = null;
            dgvpanels.DataSource = bll.FillSmsPanel();
            dgvpanels.Columns["id"].Visible = false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            new FrmAddSmsPanel().ShowDialog();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            sp = bll.ReadId((int)dgvpanels.CurrentRow.Cells[0].Value);
            if(sp != null )
            {
                FrmAddSmsPanel addp = new FrmAddSmsPanel();
                addp.PanelId = sp.id;

                addp.txtpanelname.Text = sp.PanelName;
                addp.txtsid.Text = sp.PanelSID;
                addp.txtkey.Text = sp.PanelAuthKey;
                addp.txtphone.Text = sp.PanelNumber;
                addp.btnsave.Text = "Edit";
                addp.ShowDialog();
            }
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            sp = bll.ReadId((int)dgvpanels.CurrentRow.Cells[0].Value);
            if (sp != null)
            {
               if(msg.MyMessagebox("", "", 1, 1) == DialogResult.Yes)
                {
                    bll.Delete(sp.id);
                }
            }

            FrmShowPanels_Load(null, null);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnbalance_Click(object sender, EventArgs e)
        {

        }
    }
}
