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
    public partial class FrmAddCompanyEmail : Form
    {
        public FrmAddCompanyEmail()
        {
            InitializeComponent();
        }

        EmailPanel EP = new EmailPanel();
        BLLEmailPanel bll = new BLLEmailPanel();

        msgclass msg = new msgclass();

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Settings", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }

        private void FrmAddCompanyEmail_Load(object sender, EventArgs e)
        {
            Permisions();
            if(btnsave.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtemail.Text == string.Empty)
            {
                errorProvider1.SetError(txtemail, "Enter Company Address Email....");
                txtemail.Focus();
            }
            else if(txtpasword.Text == string.Empty)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtpasword, "Enter Password Of Email....");
                txtpasword.Focus();
            }
            else
            {
                errorProvider1.Clear();

                EP.EmailSender = txtemail.Text;
                EP.Password = txtpasword.Text;
                EP.Regdate = DateTime.Now.ToShortDateString();


                msg.MyMessagebox("Register Message", bll.Create(EP), 0, 0);

                var frmshowpanel = Application.OpenForms["FrmShowEmailPanel"] as FrmShowEmailPanel;
                if(frmshowpanel != null)
                {
                    frmshowpanel.FrmShowEmailPanel_Load(null, null);
                }

                txtemail.Text = string.Empty;
                txtpasword.Text = string.Empty;
                txtemail.Focus();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
