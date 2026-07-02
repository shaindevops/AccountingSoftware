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

namespace SSG.Users_Forms
{
    public partial class UClogin : UserControl
    {
        public UClogin()
        {
            InitializeComponent();
        }
        BLLUser bll = new BLLUser();
        Users U = new Users();
        Setting s = new Setting();
        UserLogs ul = new UserLogs();
        BLLUserlog bllul = new BLLUserlog();
        BLLsetting blls = new BLLsetting();
        msgclass msg = new msgclass();

        private void btnsignin_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorProvider ep = new ErrorProvider();
                U = bll.Login(txtusername.Text, txtpass.Text);
                if (bll.IsRegistered())
                {
                    
                    if (U != null)
                    {
                        
                        msg.MyMessagebox("Login successful", "Click on the Okey button to continue", 0, 0);
                        string strtoday = DateTime.Now.ToString("yyyy/MM/dd");
                        string strtime = DateTime.Now.ToString("HH : mm");
                        string logindatetime = strtoday +"  "+ strtime;
                        ul.LogIn = logindatetime;
                        ul.Username = U.Username;
                        bllul.Create(ul, U.id);
                        ((FrmLogin)Application.OpenForms["FrmLogin"]).Hide();
                        frmASWS f = new frmASWS();
                        f.loggeduser = U;
                        f.RefreshWin();
                        f.ShowDialog();
                    }
                    else
                    {
                        msg.MyMessagebox("Warning", "Username and password are not correct", 3, 3);
                    }

                }
            }
            catch (Exception m)
            {
                msg.MyMessagebox("Warning", "There is a Problem :" + m.Message, 3, 3);
            }
            
        }

        private void UClogin_Load(object sender, EventArgs e)
        {
            txtusername.Text = bll.ReadUsername();
        }
    }
}
