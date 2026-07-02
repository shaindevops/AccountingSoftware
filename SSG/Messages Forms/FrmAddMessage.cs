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

namespace SSG.Messages_Forms
{
    public partial class FrmAddMessage : Form
    {
        public FrmAddMessage()
        {
            InitializeComponent();
        }
        Messages M = new Messages();
        BLLMessages bll = new BLLMessages();

        msgclass msg = new msgclass();

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtmsg.Text == string.Empty)
            {
                ErrorProvider ep = new ErrorProvider();

                ep.SetError(lblmsg, "This field is required");
                txtmsg.Focus();
            }
            else
            {
                M.MessageText = txtmsg.Text;


                msg.MyMessagebox("Message", bll.Create(M), 0, 0);
                txtmsg.Text = string.Empty;

                var frmshowmessage = Application.OpenForms["FrmShowMessages"] as FrmShowMessages;
                if (frmshowmessage != null)
                {
                    frmshowmessage.FrmShowMessages_Load(null, null);
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
