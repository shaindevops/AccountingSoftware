using SSG.Users_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
        }

        private void T1_Tick(object sender, EventArgs e)
        {
            T1.Stop();
            FrmLogin log = new FrmLogin();
            this.Hide();
            log.ShowDialog();

        }

        private void FrmSplash_Shown(object sender, EventArgs e)
        {
            T1.Start();
        }

        private void lblwhatsapp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://wa.me/+989902827506");
        }

        private void lblwebsite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://devpars.ir");
        }
    }
}
