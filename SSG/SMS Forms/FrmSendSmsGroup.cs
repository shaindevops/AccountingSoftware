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
using static Stimulsoft.Base.Drawing.Win32;

namespace SSG.SMS_Forms
{
    public partial class FrmSendSmsGroup : Form
    {
        public FrmSendSmsGroup()
        {
            InitializeComponent();
        }
        public bool Resault = false;
        public ListBox lstnums = new ListBox();

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        msgclass msg = new msgclass();
        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Settings", 2))
            {
                btnsendsms.Enabled = true;
            }
            else
            {
                btnsendsms.Enabled = false;
            }
        }
        private void FrmSendSmsGroup_Load(object sender, EventArgs e)
        {
            Permisions();
            if(btnsendsms.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Send Sms this section!!!", 2, 2);
            }
        }
       
        private void txtmessage_TextChanged(object sender, EventArgs e)
        {
            lblcount.Text = txtmessage.Text.Length.ToString();
        }

        private void btnsendsms_Click(object sender, EventArgs e)
        {
            msg.MyMessagebox("Coming Soon...", "Sending group SMS will be launched soon.", 3, 3);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            FrmListNumbers list = new FrmListNumbers();
            list.IsGroup = true;
            list.ShowDialog();
            if (list.Resault == true)
            {
                for (int i = 0; i < list.lstnums.Items.Count; i++)
                {
                    listnumber.Items.Add(list.lstnums.Items[i].ToString());
                }
            }

        }

        
    }
}
