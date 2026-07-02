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

namespace SSG
{
    public partial class FrmShowPosDevice : Form
    {
        public FrmShowPosDevice()
        {
            InitializeComponent();
        }
        PosDevice PD = new PosDevice();
        BLLPosDevice bll = new BLLPosDevice();

        msgclass msg = new msgclass();


        public void FrmShowPosDevice_Load(object sender, EventArgs e)
        {
            try
            {
                dgvpos.DataSource = null;
                dgvpos.DataSource = bll.FillDevices();
                dgvpos.Columns["id"].Visible = false;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void dgvpos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtdevicename.Text = dgvpos.CurrentRow.Cells[1].Value.ToString();
                txtdevictype.Text = dgvpos.CurrentRow.Cells[2].Value.ToString();
                txtportname.Text = dgvpos.CurrentRow.Cells[3].Value.ToString();
                txtbaudrate.Text = dgvpos.CurrentRow.Cells[4].Value.ToString();
                chkisdefault.Checked = (bool)dgvpos.CurrentRow.Cells[5].Value;
                lblstatus.Text = dgvpos.CurrentRow.Cells[6].Value.ToString();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                PD = bll.ReadId((int)dgvpos.CurrentRow.Cells[0].Value);
                if (PD != null)
                {
                    if (msg.MyMessagebox("Delete Device", "Are you sure you want to delete this device?", 1, 1) == DialogResult.Yes)
                    {
                        bll.Delete(PD.id);
                    }
                }
                FrmShowPosDevice_Load(null, null);
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
