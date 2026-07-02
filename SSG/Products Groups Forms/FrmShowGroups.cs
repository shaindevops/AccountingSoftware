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

namespace SSG.Groups_Forms
{
    public partial class FrmShowGroups : Form
    {
        public FrmShowGroups()
        {
            InitializeComponent();
        }
        Groups G = new Groups();
        BLLGroups bll = new BLLGroups();
        msgclass msg = new msgclass();
        public int id;


        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Factors", 3) && bllu.AccessTo(LoggedUser, "Factors", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = true;
            }
            else if (bllu.AccessTo(LoggedUser, "Factors", 3) && !bllu.AccessTo(LoggedUser, "Factors", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = false;
            }
            else if (!bllu.AccessTo(LoggedUser, "Factors", 3) && bllu.AccessTo(LoggedUser, "Factors", 4))
            {
                btnedit.Enabled = false;
                btndelete.Enabled = true;
            }
            else
            {
                btnedit.Enabled = false;
                btndelete.Enabled = false;
            }
        }
        public void FrmShowGroups_Load(object sender, EventArgs e)
        {
            Permisions();

            if(btnedit.Enabled == false || btndelete.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Edit and Delete this section!!!", 2, 2);
            }
            else if (btnedit.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Edit this section!!!", 2, 2);
            }
            else if (btndelete.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Delete this section!!!", 2, 2);
            }
            dgvgroups.DataSource = null;
            dgvgroups.DataSource = bll.ReadFillGroup();
            dgvgroups.Columns["id"].Visible = false;
            btncount.Text = bll.GroupCount();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            new FrmAddGroups().ShowDialog();
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            G = bll.ReadId(id);
            if(G != null)
            {
                FrmAddGroups fg = new FrmAddGroups();
                fg.lbltitle.Text = "Edit Group Selected";
                fg.txtgroupname.Text = G.Name;
                fg.txtunit1.Text = G.Unit1;
                fg.txtunit2.Text = G.Unit2;
                fg.btnsave.Text = "Edit";
                fg.ShowDialog();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            G = bll.ReadId(id);
            if (G != null)
            {
                if(msg.MyMessagebox("Delete Group", "Do you want to delete the desired group?", 1,1) == DialogResult.Yes)
                {
                    bll.Delete(id);
                }
            }
            FrmShowGroups_Load(null, null);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvgroups_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvgroups.SelectedRows.Count > 0)
                {
                    id = (int)dgvgroups.SelectedRows[0].Cells["id"].Value;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
