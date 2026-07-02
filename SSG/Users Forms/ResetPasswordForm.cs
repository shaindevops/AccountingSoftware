using BE;
using BLL;
using System.Diagnostics;
using System.Windows.Forms;

namespace SSG
{
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }
        Users U = new Users();
        BLLUser bll = new BLLUser();
        msgclass msg = new msgclass();

        private void ResetPasswordForm_Load(object sender, System.EventArgs e)
        {
            U = bll.Read(((frmASWS)Application.OpenForms["frmASWS"]).loggeduser.id);
            //((frmASWS)Application.OpenForms["frmASWS"]).loggeduser = U;
            lblusername.Text = U.Username;
            txtusername.Text = U.Username;
        }
        
        private void btnsave_Click_1(object sender, System.EventArgs e)
        {
            if (U != null)
            {
                if (txtconfirmpassword.Text == txtnewpassword.Text)
                {
                    U.password = txtnewpassword.Text;
                    msg.MyMessagebox("Edit password", bll.Update(((frmASWS)Application.OpenForms["frmASWS"]).loggeduser.id, U), 0, 0);
                    Close();
                    
                    Application.Exit();
                }
                else
                {
                    msg.MyMessagebox("Warning", "The passwords do not match", 3, 3);
                }
            }
        }

        private void btnclose_Click_1(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtcurrentpassword_TextChanged(object sender, System.EventArgs e)
        {
            if(txtcurrentpassword.Text == bll.Decode(U.password))
            {
                lblnewpass.Enabled = true;
                lblconfpass.Enabled = true;
                txtnewpassword.Enabled = true;
                txtconfirmpassword.Enabled = true;
                btnsave.Enabled = true;

            }
            else
            {
                lblnewpass.Enabled = false;
                lblconfpass.Enabled = false;
                txtnewpassword.Enabled = false;
                txtconfirmpassword.Enabled = false;
                btnsave.Enabled = false;
            }
        }
    }
}
