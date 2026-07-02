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
    public partial class FrmUserlogs : Form
    {
        public FrmUserlogs()
        {
            InitializeComponent();
        }
        BLLUserlog bll = new BLLUserlog();
        public int userid;
        public string username;
        private void FrmUserlogs_Load(object sender, EventArgs e)
        {

            grpshowlogs.Text = grpshowlogs.Text + " " + username;
            dgvshowuserlogs.DataSource = null;
            dgvshowuserlogs.DataSource = bll.Read(userid);
            dgvshowuserlogs.Columns["id"].Visible = false;
            dgvshowuserlogs.Columns["User_id"].Visible = false;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
