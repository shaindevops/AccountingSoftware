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

namespace SSG.People_Forms
{
    public partial class FrmShowPeople : Form
    {
        public FrmShowPeople()
        {
            InitializeComponent();
        }
        People P = new People();
        BLLPeople bll = new BLLPeople();
        msgclass msg = new msgclass();
        public int id;
        int index;
        public void FillPeople()
        {
            dgvpersonlist.DataSource = null;
            dgvpersonlist.DataSource = bll.ReadFillPeople();
            dgvpersonlist.Columns["id"].Visible = false;

            btncount.Text = bll.PeopleCount();

            rdoallperson.Checked = true;

            if(dgvpersonlist.Rows.Count == 0 )
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

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Persons", 3) && bllu.AccessTo(LoggedUser, "Persons", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = true;
            }
            else if (bllu.AccessTo(LoggedUser, "Persons", 3) && !bllu.AccessTo(LoggedUser, "Persons", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = false;
            }
            else if (!bllu.AccessTo(LoggedUser, "Persons", 3) && bllu.AccessTo(LoggedUser, "Persons", 4))
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
        private void FrmShowPeople_Load(object sender, EventArgs e)
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
            else if (btndelete.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Delete this section!!!", 2, 2);
            }
            FillPeople();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            new FrmAddPeople().ShowDialog();
        }


        private void btnedit_Click(object sender, EventArgs e)
        {
            P = bll.ReadId(id);
            if(P != null)
            {
                FrmAddPeople per = new FrmAddPeople();
                per.lbltitle.Text = "Edit Person Selected";
                if(P.Type == "Person")
                {
                    per.rdoperson.Checked = true;
                }
                else
                {
                    per.rdocompany.Checked = true;
                }
                per.txtname.Text = P.Name;
                per.txtmobile.Text = P.Mobile;
                per.txttel.Text = P.Tel;
                per.txtemail.Text = P.Email;
                per.intdebtor.Value = P.Debtor;
                per.intcreditor.Value = P.Creditor;
                per.txtaddress.Text = P.Address;
                per.txtdesc.Text = P.Description;
                per.btnsave.Text = "Edit";
                per.ShowDialog();

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            P = bll.ReadId(id);
            if (P != null)
            {
                if(msg.MyMessagebox("Delete person", "Are you sure you want to delete the person?", 1,1) == DialogResult.Yes)
                {
                    bll.Delete(id);
                }
            }
            FillPeople();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        void FilterBY()
        {
            if (chkname.Checked && chktel.Checked && chkmobile.Checked || !chkname.Checked && !chktel.Checked && chkmobile.Checked)
            {
                index = 0;
            }
            else if (chkname.Checked && !chktel.Checked && !chkmobile.Checked)
            {
                index = 1;
            }
            else if (!chkname.Checked && chktel.Checked && !chkmobile.Checked)
            {
                index = 2;
            }
            else if (!chkname.Checked && !chktel.Checked && chkmobile.Checked)
            {
                index = 3;
            }
            dgvpersonlist.DataSource = null;
            dgvpersonlist.DataSource = bll.SearchPeople(txtserch.Text, index);
            dgvpersonlist.Columns["id"].Visible = false;
        }

        private void txtserch_TextChanged(object sender, EventArgs e)
        {
            if (rdoallperson.Checked)
            {
                FilterBY();
            }
            else if (rdocustomers.Checked)
            {
                FilterBY();
            }
            else if (rdosuppliers.Checked)
            {
                FilterBY();
            }
            
        }

        private void rdoallperson_CheckedChanged(object sender, EventArgs e)
        {
            dgvpersonlist.DataSource = null;
            dgvpersonlist.DataSource = bll.ReadFillPeople();
            dgvpersonlist.Columns["id"].Visible = false;
            btncount.Text = bll.PeopleCount();
        }

        private void dgvpersonlist_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvpersonlist.SelectedRows.Count > 0)
                {
                    id = (int)dgvpersonlist.SelectedRows[0].Cells["id"].Value;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

    }
}
