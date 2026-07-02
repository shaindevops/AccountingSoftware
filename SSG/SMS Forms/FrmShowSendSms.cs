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
    public partial class FrmShowSendSms : Form
    {
        public FrmShowSendSms()
        {
            InitializeComponent();
        }

        SendSMS sms = new SendSMS();
        BLLSendSms bll = new BLLSendSms();

        SmsPanel Sp = new SmsPanel();
        BLLSmsPanel bllsp = new BLLSmsPanel();

        msgclass msg = new msgclass();


        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Settings", 3))
            {
                btnedit.Enabled = true;
            }
            else
            {
                btnedit.Enabled = false;
            }
        }

            private void btnsendsmsgroup_Click(object sender, EventArgs e)
        {
            FrmSendSmsGroup smsgroup = new FrmSendSmsGroup();
            smsgroup.ShowDialog();
        }

        private void btnsendsmssingle_Click(object sender, EventArgs e)
        {
            new FrmSendSmsSingle().ShowDialog();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            sms = bll.ReadId((int)dgvsendsms.CurrentRow.Cells[0].Value);
            if(sms != null)
            {

            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmShowSendSms_Load(object sender, EventArgs e)
        {
            Permisions();
            if(btnedit.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Update this section!!!", 2, 2);
            }
            dgvsendsms.DataSource = null;
            dgvsendsms.DataSource = bll.FillSendedSms();

            dgvsendsms.Columns["id"].Visible = false;
            dgvsendsms.Columns["SmsPanel_id"].Visible = false;
            dgvsendsms.Columns["SID"].Visible = false;
            dgvsendsms.Columns["AuthKey"].Visible = false;
            dgvsendsms.Columns["Sender Number"].Visible = false;
        }
    }
}
