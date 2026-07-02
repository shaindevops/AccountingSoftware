using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG
{
    public partial class FrmMsg : Form
    {
        public FrmMsg()
        {
            InitializeComponent();
        }
        msgclass msg = new msgclass();
        private void btnyes_Click(object sender, EventArgs e)
        {
            if (btnyes.Text == "Okey")
            {
                DialogResult = DialogResult.OK;
            }
            else if (btnyes.Text == "Yes")
            {
                this.DialogResult = DialogResult.Yes;
            }
            else if (btnyes.Text == "Okey")
            {
                this.DialogResult = DialogResult.OK;
            }
            else if (btnyes.Text == "Not Okey")
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
