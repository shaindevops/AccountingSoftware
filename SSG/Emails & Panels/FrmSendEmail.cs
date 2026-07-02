using BE;
using BLL;
using DevComponents.DotNetBar.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.Emails___Panels
{
    public partial class FrmSendEmail : Form
    {
        public FrmSendEmail()
        {
            InitializeComponent();
        }


        SendEmail SE = new SendEmail();
        BLLSendEmail bll = new BLLSendEmail();

        BLLPeople bllper = new BLLPeople();
        BLLEmailPanel bllep = new BLLEmailPanel();

        Tbl_Company com = new Tbl_Company();
        Tbl_CompanyBLL bllcom = new Tbl_CompanyBLL();

        OpenFileDialog ofd = new OpenFileDialog();

        msgclass msg = new msgclass();

        public int EmailPanelId = 0;

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Settings", 2))
            {
                btnsend.Enabled = true;
            }
            else
            {
                btnsend.Enabled = false;
            }
        }


        private void FrmSendEmail_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
                if(btnsend.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Send Email this section!!!", 2, 2);
                }
                cmbpersons.DataSource = null;
                cmbpersons.DataSource = bllper.ReadFillPeople();
                cmbpersons.DisplayMember = "Name";

                cmbcompany.DataSource = null;
                cmbcompany.DataSource = bllep.FillEmailPanel();
                cmbcompany.DisplayMember = "Email Sender";

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void cmbpersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               txtpersonemail.Text = ((DataRowView)cmbpersons.SelectedItem)["Email"].ToString();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void cmbcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtsenderPass.Text = ((DataRowView)cmbcompany.SelectedItem)["Password"].ToString();
                txtcomname.Text = bllcom.ReadComName(com);
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {

                if(txtpersonemail.Text == string.Empty)
                {
                    ep.SetError(txtpersonemail, "Enter Recipient Email....");
                    txtpersonemail.Focus();
                }
                else if(txtsenderPass.Text == string.Empty)
                {
                    ep.Clear();
                    ep.SetError(cmbcompany, "Select Email....");
                    cmbcompany.Focus();
                }
                else if(txtsubject.Text == string.Empty)
                {
                    ep.Clear();
                    ep.SetError(txtsubject, "Enter Subject For Your Email");
                    txtsubject.Focus();
                }
                else
                {
                    SE.From = cmbcompany.Text;
                    SE.Password = txtsenderPass.Text;
                    SE.DisplayName = txtcomname.Text;
                    SE.To = txtpersonemail.Text;
                    SE.Subject = txtsubject.Text;
                    SE.File = txtattachment.Text;
                    SE.Body = txtmessage.Text;
                    SE.Regdate = DateTime.Now.ToString("MM/dd/yyyy");

                    msg.MyMessagebox("Message", bll.SendEmail(SE.From, SE.Password, SE.DisplayName, SE.To, SE.Subject, SE.Body,  SE.File), 0, 0);
                    bll.Create(SE);
                }

            }
            catch(Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + ex.Message, 2, 2);
            }
        }

        private void btnattach_Click(object sender, EventArgs e)
        {
            try
            {
                ofd.Filter = "All Supported Files|*.jpg;*.png;*.pdf;*.docx;*.xlsx|JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|PDF Files (*.pdf)|*.pdf|Word Documents (*.docx)|*.docx|Excel Files (*.xlsx)|*.xlsx";
                ofd.Title = "Select a file";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtattachment.Text = ofd.FileName;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
