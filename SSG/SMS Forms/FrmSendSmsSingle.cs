using BE;
using BLL;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace SSG.SMS_Forms
{
    public partial class FrmSendSmsSingle : Form
    {
        public FrmSendSmsSingle()
        {
            InitializeComponent();
        }

        SendSMS sms = new SendSMS();
        BLLSendSms bll = new BLLSendSms();

        SmsPanel sp = new SmsPanel();
        BLLSmsPanel bllsp = new BLLSmsPanel();

        msgclass msg = new msgclass();

        string PanelName = "";
        string SID = "";
        string AuthKey = "";
        string SenderNumber = "";

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

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
        private void FrmSendSmsSingle_Load(object sender, EventArgs e)
        {
            Permisions();
            if(btnsendsms.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Send Sms this section!!!", 2, 2);
            }

            cmbpanel.DataSource = null;
            cmbpanel.DataSource = bllsp.FillSmsPanel();
            cmbpanel.DisplayMember = "Panel Name";
            PanelName = cmbpanel.Text;
        }
        private void cmbpanel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SID = ((DataRowView)cmbpanel.SelectedItem)["API Key"].ToString();
            AuthKey = ((DataRowView)cmbpanel.SelectedItem)["API Token"].ToString();
            SenderNumber = ((DataRowView)cmbpanel.SelectedItem)["Sender Number"].ToString();
        }
        private void txtmessage_TextChanged(object sender, EventArgs e)
        {
            lblcount.Text = txtmessage.Text.Length.ToString();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            FrmListNumbers list = new FrmListNumbers();

            list.IsGroup = false;
            list.ShowDialog();

            txtphone.Text = list.SelectedNum;

        }

        private void btnsendsms_Click(object sender, EventArgs e)
        {
            if(txtphone.Text == string.Empty)
            {
                ep.SetError(txtphone, "Enter Phone Number Or \n Select Phone From List");
                txtphone.Focus();
            }
            else if(txtmessage.Text == string.Empty)
            {
                ep.Clear();
                ep.SetError(txtmessage, "Your Message Enter The Box Message");
                txtmessage.Focus();
            }
            else
            {
                ep.Clear();

                sms.PanelName = PanelName;
                sms.SID = SID;
                sms.AuthKey = AuthKey;
                sms.SenderNumber = SenderNumber;
                sms.Tonumber = txtphone.Text;
                sms.SmsBody = txtmessage.Text;


                //msg.MyMessagebox("Send Successfully", bll.SendSMS(SID, AuthKey, SenderNumber, sms.Tonumber, sms.SmsBody), 0, 0);

                if(sms.Status == "queued")
                {
                    bll.Create(sms);
                }
                else
                {
                    msg.MyMessagebox("Warning!!!", "Feilur Send Sms", 3, 3);
                }
            }

        }

        

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
