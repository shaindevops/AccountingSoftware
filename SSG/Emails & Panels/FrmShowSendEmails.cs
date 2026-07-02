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

namespace SSG.Emails___Panels
{
    public partial class FrmShowSendEmails : Form
    {
        public FrmShowSendEmails()
        {
            InitializeComponent();
        }

        SendEmail SE = new SendEmail();
        BLLSendEmail bll = new BLLSendEmail();

        EmailPanel EP = new EmailPanel();
        BLLEmailPanel bllep = new BLLEmailPanel();

        msgclass msg = new msgclass();


        public string Sender = "";


        string strToday = "";
        private void FrmShowSendEmails_Load(object sender, EventArgs e)
        {
            try
            {
                strToday = DateTime.Now.ToString("MM/dd/yyyy");

                mskdate1.Text = strToday;
                mskdate2.Text = strToday;


                dgvemailssended.DataSource = null;
                dgvemailssended.DataSource = bll.FillSendEmailsByPanelId(Sender, mskdate1.Text, mskdate2.Text);
                dgvemailssended.Columns["id"].Visible = false;
                dgvemailssended.Columns["Regdate"].Visible = false;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
            

        }

        private void mskdate1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                dgvemailssended.DataSource = null;
                dgvemailssended.DataSource = bll.FillSendEmailsByPanelId(Sender, mskdate1.Text, mskdate2.Text);
                dgvemailssended.Columns["id"].Visible = false;
                dgvemailssended.Columns["Regdate"].Visible = false;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void mskdate2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                dgvemailssended.DataSource = null;
                dgvemailssended.DataSource = bll.FillSendEmailsByPanelId(Sender, mskdate1.Text, mskdate2.Text);
                dgvemailssended.Columns["id"].Visible = false;
                dgvemailssended.Columns["Regdate"].Visible = false;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnsendemail_Click(object sender, EventArgs e)
        {
            new FrmSendEmail().ShowDialog();
        }
    }
}
