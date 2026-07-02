using BE;
using BLL;
using SSG.Users_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG
{
    public partial class UserManagementForm : Form
    {
        public UserManagementForm()
        {
            InitializeComponent();
        }
        Users U = new Users();
        BLLUser bll = new BLLUser();
        Usergroup ug = new Usergroup();
        BLLUsergroup bllug = new BLLUsergroup();
        UserLogs ul = new UserLogs();
        BLLUserlog bllul = new BLLUserlog();
        msgclass msg = new msgclass();
        public int idul;
        public int id;
        int idug;
        int index;

        public void permisions()
        {
            U = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
            if (bll.AccessTo(U, "Users", 3) && bll.AccessTo(U, "Users", 4))
            {
                btnedituser.Enabled = true;
                btndeleteuser.Enabled = true;
            }
            else if(bll.AccessTo(U, "Users", 3) && !bll.AccessTo(U, "Users", 4))
            {
                btnedituser.Enabled = true;
                btndeleteuser.Enabled = false;
            }

            else if(!bll.AccessTo(U, "Users", 3) && bll.AccessTo(U, "Users", 4))
            {
                btnedituser.Enabled = false;
                btndeleteuser.Enabled = true;
            }
            else
            {
                btnedituser.Enabled = false;
                btndeleteuser.Enabled = false;
            }
        }
        public void FillGrid()
        {
            dgvuserlist.DataSource = null;
            dgvuserlist.DataSource = bll.Read();
            dgvuserlist.Columns["id"].HeaderText = "Rows No.";
            dgvuserlist.Columns["id"].Width = 80;
            dgvusergrouplist.DataSource = null;
            dgvusergrouplist.DataSource = bllug.Read();
            dgvusergrouplist.Columns["id"].HeaderText = "Rows No.";
            dgvusergrouplist.Columns["id"].Width = 80;
            btncount.Text = bll.Usercount();

            
        }
        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            permisions();

            if(btnedituser.Enabled == false && btndeleteuser.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Edit and Delete this section!!!", 2, 2);
            }
            if (btnedituser.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Edit this section!!!", 2, 2);
            }
            if (btndeleteuser.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Delete this section!!!", 2, 2);
            }

            FillGrid();
        }

        private void btnadduser_Click(object sender, EventArgs e)
        {
            new AddNewUserForm().ShowDialog();
        }

        private void btnaddusergroup_Click(object sender, EventArgs e)
        {
            new FrmUsergroup().ShowDialog();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnedituser_Click(object sender, EventArgs e)
        {
            U = bll.Read(id);
            if(U != null)
            {
                if(dgvuserlist.Rows.Count == 0)
                {
                    btnedituser.Enabled = false;
                    btndeleteuser.Enabled = false;
                }
                else 
                {
                    AddNewUserForm nu = new AddNewUserForm();
                    nu.txtusername.Text = U.Username;
                    // Password fields are intentionally left blank: passwords are
                    // now hashed (PBKDF2) and cannot be decoded back to plaintext.
                    // Leaving them blank means "keep the current password" - see
                    // AddNewUserForm.btnsave_Click and BLLUser.Update.
                    nu.txtfullname.Text = U.Fullname;
                    nu.txtphone.Text = U.PhoneNo;
                    nu.txtnationalid.Text = U.NationalID;
                    nu.txtemail.Text = U.Email;
                    nu.picofuser.Image = Image.FromFile(U.pic);
                    nu.btnsave.Text = "Edit";
                    nu.ShowDialog();
                }
                
            }
            
        }

        private void btndeleteuser_Click(object sender, EventArgs e)
        {
            U = bll.Read(id);
            if(U != null)
            {
                DialogResult dr = msg.MyMessagebox("Delete user", "Are you sure you want to delete the user?", 1, 1);
                if (dr == DialogResult.Yes)
                {
                    msg.MyMessagebox("Delete user", bll.Delete(id), 1, 1);
                }
            }
            FillGrid();
            
        }
        private void dgvuserlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dgvuserlist.Rows[dgvuserlist.CurrentRow.Index].Cells[0].Value.ToString());
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if(cmbsearchby.Text == "")
            {
                index = 0;
            }
            else if (cmbsearchby.Text == "Name's User")
            {
                index = 1;
            }
            else if(cmbsearchby.Text == "Phone")
            {
                index = 2; 
            }
            else if(cmbsearchby.Text == "National Id")
            {
                index = 3;
            }
            else if (cmbsearchby.Text == "User Group")
            {
                index = 4;
            }
            dgvuserlist.DataSource = null;
            dgvuserlist.DataSource = bll.Read(txtsearch.Text, index);
        }

        private void btnshowuserlogs_Click(object sender, EventArgs e)
        {
            FrmUserlogs f = new FrmUserlogs();
            f.userid = Convert.ToInt32(dgvuserlist.Rows[dgvuserlist.CurrentRow.Index].Cells[0].Value);
            f.username = dgvuserlist.Rows[dgvuserlist.CurrentRow.Index].Cells[4].Value.ToString();
            f.ShowDialog();


        }

        private void dgvuserlist_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvuserlist.SelectedRows.Count > 0)
                {
                    id = (int)dgvuserlist.SelectedRows[0].Cells["id"].Value;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
