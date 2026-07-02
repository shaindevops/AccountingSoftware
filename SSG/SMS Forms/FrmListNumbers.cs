using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.SMS_Forms
{
    public partial class FrmListNumbers : Form
    {
        public FrmListNumbers()
        {
            InitializeComponent();
        }
        BLLPeople bll = new BLLPeople();
        public bool Resault = false;
        public bool IsGroup = false;
        public string SelectedNum = "";

        public ListBox lstnums = new ListBox();

        private void FrmListNumbers_Load(object sender, EventArgs e)
        {
            dgvpersons.DataSource = null;
            dgvpersons.DataSource = bll.ReadFillNameAndMobile();
            if (IsGroup)
            {
                btnselect.Visible = true;
            }
            else
            {
                btnselect.Visible = false;
            }
           
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvpersons_DoubleClick(object sender, EventArgs e)
        {
            SelectedNum = dgvpersons.CurrentRow.Cells["Mobile"].Value.ToString();
            Close();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            lstnums.Items.Clear();
            for (int i = 0; i < dgvpersons.Rows.Count; i++)
            {
                if (dgvpersons.Rows[i].Selected == true)
                {
                    lstnums.Items.Add(dgvpersons.Rows[i].Cells["Mobile"].Value.ToString());
                }
            }
            Resault = true;
            this.Close();
        }
    }
}
