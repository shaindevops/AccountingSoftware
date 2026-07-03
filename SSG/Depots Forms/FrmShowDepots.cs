using BE;
using BE.Logging;
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

namespace SSG.Depots_Forms
{
    public partial class FrmShowDepots : Form
    {
        public FrmShowDepots()
        {
            InitializeComponent();
        }
        Depots D = new Depots();
        BLLDepot bll = new BLLDepot();
        msgclass msg = new msgclass();
        public int id;

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Depots", 3) && bllu.AccessTo(LoggedUser, "Depots", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = true;
            }
            else if (bllu.AccessTo(LoggedUser, "Depots", 3) && !bllu.AccessTo(LoggedUser, "Depots", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = false;
            }
            else if (!bllu.AccessTo(LoggedUser, "Depots", 3) && bllu.AccessTo(LoggedUser, "Depots", 4))
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
        public void FrmShowDepots_Load(object sender, EventArgs e)
        {

            Permisions();
            if(btnedit.Enabled == false && btndelete.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Edit and Delete this section!!!", 2, 2);
            }
            else if (btnedit.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Edit this section!!!", 2, 2);
            }
            if (btndelete.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Delete this section!!!", 2, 2);
            }
            dgvdepots.DataSource = null;
            dgvdepots.DataSource = bll.ReadFillGrid();
            dgvdepots.Columns["id"].Visible = false;
            btncount.Text = bll.CountDepot();
            if(dgvdepots.Rows.Count == 0)
            {
                btnedit.Enabled = false;
                btndelete.Enabled = false;
            }
            else
            {
                btnedit.Enabled = true;
                btndelete.Enabled = true;
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            new FrmAddDepot().ShowDialog();
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            D = bll.ReadId(id);
            if(D != null)
            {
                FrmAddDepot fd = new FrmAddDepot();
                fd.lbldepottitle.Text = "Edit Depot Selected";
                fd.txtdepotname.Text = D.Name;
                fd.btnsave.Text = "Edit";
                fd.ShowDialog();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            D = bll.ReadId(id);
            if (D != null)
            {
                if (msg.MyMessagebox("Depot Deletion", "Do you want to delete this Depot?", 1, 1) == DialogResult.Yes)
                {
                    bll.DeleteDepot(id);
                }
                
            }
            FrmShowDepots_Load(null, null);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvdepots_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvdepots.SelectedRows.Count > 0)
                {
                    id = (int)dgvdepots.SelectedRows[0].Cells["id"].Value;
                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError("FrmShowDepots.dgvdepots_SelectionChanged", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
