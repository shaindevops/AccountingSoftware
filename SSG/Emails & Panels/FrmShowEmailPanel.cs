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
    public partial class FrmShowEmailPanel : Form
    {
        public FrmShowEmailPanel()
        {
            InitializeComponent();
        }

        EmailPanel EP = new EmailPanel();
        BLLEmailPanel bllep = new BLLEmailPanel();

        msgclass msg = new msgclass();



        public void FrmShowEmailPanel_Load(object sender, EventArgs e)
        {
            try
            {
                dgvpanels.DataSource = null;
                dgvpanels.DataSource = bllep.FillEmailPanel();
                dgvpanels.Columns["id"].Visible = false;
                dgvpanels.Columns["Password"].Visible = false;
                btncount.Text = bllep.EmailPanelCount();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
            

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            new FrmAddCompanyEmail().ShowDialog();
        }

        private void btnshowemails_Click(object sender, EventArgs e)
        {
            try
            {
                FrmShowSendEmails ss = new FrmShowSendEmails();
                ss.Sender = dgvpanels.CurrentRow.Cells["Email Sender"].Value.ToString();
                ss.ShowDialog();
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
    }
}
