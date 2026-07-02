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
    public partial class FrmShowMessages : Form
    {
        public FrmShowMessages()
        {
            InitializeComponent();
        }
        Messages M = new Messages();
        BLLMessages bll = new BLLMessages();

        msgclass msg = new msgclass();
        public void FrmShowMessages_Load(object sender, EventArgs e)
        {
            dgvmessages.DataSource = null;
            dgvmessages.DataSource = bll.FillMessage();
            dgvmessages.Columns["id"].Visible = false;

            btncount.Text = bll.MessageCount();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            new FrmAddMessage().ShowDialog();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            M = bll.ReadId((int)dgvmessages.CurrentRow.Cells[0].Value);
            if(M != null)
            {
                if(msg.MyMessagebox("Delete Message", "Are you sure you want to delete the prepared message text?", 1, 1) == DialogResult.Yes)
                {
                    bll.DeleteMessage(M.id);
                }
            }
            FrmShowMessages_Load(null, null);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
