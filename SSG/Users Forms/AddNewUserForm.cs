using BE;
using BLL;
using DevComponents.DotNetBar.Charts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SSG
{
    public partial class AddNewUserForm : Form
    {
        public AddNewUserForm()
        {
            InitializeComponent();
        }
        Users U = new Users();
        BLLUser bll = new BLLUser();
        BLLUsergroup bllug = new BLLUsergroup();
        Usergroup ug = new Usergroup();
        msgclass msg = new msgclass();
        OpenFileDialog ofd = new OpenFileDialog();
        Image pic;
        
        public void permisions()
        {
            U = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
            if (bll.AccessTo(U, "Users", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }

        private void btnclose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        public void FillGridCMB()
        {
            cmbusertype.DataSource = null;
            cmbusertype.DataSource = bllug.ReadUGNames();
        }
        private void AddNewUserForm_Load(object sender, System.EventArgs e)
        {
            permisions();
            if(btnsave.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
            }
            FillGridCMB();
            
        }

        private void btnusertype_Click(object sender, System.EventArgs e)
        {
            Users LoggedUser = new Users();
            BLLUser bllu = new BLLUser();

            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Users", 1))
            {
                new FrmUsergroup().ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
        }

        string SavePic(string Username)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\userpic\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string PicName = Username + ".JPG";
            try
            {
                string picPath = ofd.FileName;
                File.Copy(picPath, path + PicName, true);
            }
            catch (Exception e)
            {
                msg.MyMessagebox("Warning", "The system cannot save the user's photo!!!" + e.Message, 3, 3);
            }
            return path + PicName;
        }
        private void btnupload_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG(*.JPG)|*.JPG";
            ofd.Title = "Select user image";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic = Image.FromFile(ofd.FileName);
                picofuser.Image = pic;
            }
        }
        
        private void btnsave_Click(object sender, System.EventArgs e)
        {
            
            if (txtfullname.Text == string.Empty)
            {
                ep.SetError(txtfullname, "This field is required");
                txtfullname.Focus();
            }
            else if(txtphone.Text == string.Empty)
            {
                ep.SetError(txtphone, "This field is required");
                txtphone.Focus();
            }
            else if (txtemail.Text == string.Empty)
            {
                ep.SetError(txtemail, "This field is required");
                txtemail.Focus();
            }
            else if (txtusername.Text == string.Empty)
            {
                ep.SetError(txtusername, "This field is required");
                txtusername.Focus();
            }
            else if (txtpassword.Text == string.Empty)
            {
                ep.SetError(txtpassword, "This field is required");
                txtpassword.Focus();
            }
            else if (txtconfirmpassword.Text == string.Empty)
            {
                ep.SetError(txtconfirmpassword, "This field is required");
                txtconfirmpassword.Focus();
            }
            else if (picofuser.Image == null)
            {
                ep.SetError(picofuser, "This field is required");
                btnupload.Focus();
            }
            else
            {
                ep.Clear();
                U.Fullname = txtfullname.Text;
                U.PhoneNo = txtphone.Text;
                U.NationalID = txtnationalid.Text;
                U.Username = txtusername.Text;
                if(txtconfirmpassword.Text != txtpassword.Text)
                {
                    ep.SetError(txtpassword, "The passwords do not match");
                    ep.SetError(txtconfirmpassword, "The passwords do not match");
                }
                else
                {
                    ep.Clear();
                    U.password = txtpassword.Text;
                }
                
                if(rdoactiv.Checked)
                {
                    U.IsActive = true;
                }
                else
                {
                    U.IsActive = false;
                }
                
                U.Regdate = DateTime.Now;
                if(btnsave.Text == "Save")
                {
                    U.pic = SavePic(txtusername.Text);
                    ug = bllug.ReadN(cmbusertype.Text);
                    U.Usergroup = ug;
                    msg.MyMessagebox("User Registration", bll.Create(U, ug), 0, 0);
                    ((UserManagementForm)Application.OpenForms["UserManagementForm"]).FillGrid();
                }
                else if(btnsave.Text == "Edit")
                {
                    msg.MyMessagebox("User Registration", bll.Update(((UserManagementForm)Application.OpenForms["UserManagementForm"]).id, U), 0, 0);
                    ((UserManagementForm)Application.OpenForms["UserManagementForm"]).FillGrid();
                    btnsave.Text = "Save";
                }
            }
        }
    }
}
