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
    public partial class FrmLogin : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public FrmLogin()
        {
            this.Controls.Add(r);
            this.Controls["UCReg"].Location = new Point(125, 480);
            this.Controls.Add(l);
            this.Controls["Uclogin"].Location = new Point(125, 480);
            InitializeComponent();
        }
        Timer t1 = new Timer();
        Timer t2 = new Timer();
        Timer t3 = new Timer();
        BLLUser ubll = new BLLUser();
        UCReg r = new UCReg();
        UClogin l = new UClogin();
        bool _Isregistered;
        public void LoadLoginForm()
        {
            t3.Enabled = true;
            t3.Interval = 15;
            t3.Tick += Timer3_Tick;
            t3.Start();
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblloading.Text = "Connecting To Database...";
            lblloading.Visible = true;
            t1.Enabled = true;
            t1.Interval = 15;
            t1.Tick += Timer_Tick;
            t1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBarX1.Value >= 100)
            {
                t1.Stop();
                progressBarX1.Visible = false;
                lblloading.Visible = false;
                lblwellcome.Visible = true;
                btncnacel.Visible = true;
                t2.Enabled = true;
                t2.Interval = 1;
                t2.Tick += Timer2_Tick;
                t2.Start();
            }
            else if (progressBarX1.Value == 50)
            {
                _Isregistered = ubll.IsRegistered();
                progressBarX1.Value++;
            }
            else
            {
                progressBarX1.Value++;
            }
        }
        int y = 250;
        int y2 = 525;
        int y3 = 525;
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (lblwellcome.Location.Y >= 15)
            {
                y = y - 15;
                y2 = y2 - 30;
                lblwellcome.Location = new Point(226, y);
                if (_Isregistered == true)
                {
                    this.Controls["UClogin"].Location = new Point(127, y2);
                }
                else
                {
                    this.Controls["UCReg"].Location = new Point(127, y2);
                }
            }
            else
            {
                t2.Stop();
            }
        }
        private void Timer3_Tick(object sender, EventArgs e)
        {
            if (this.Controls["UClogin"].Location.Y >= 65)
            {
                y3 = y3 - 30;
                this.Controls["UClogin"].Location = new Point(127, y3);
            }
            else
            {
                t3.Stop();
            }
        }

        private void btncnacel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
