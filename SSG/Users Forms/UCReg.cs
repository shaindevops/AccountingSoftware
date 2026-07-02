using BE;
using BLL;
using DevComponents.DotNetBar.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.Users_Forms
{
    public partial class UCReg : UserControl
    {
        public UCReg()
        {
            InitializeComponent();
        }
        BLLUser bllu = new BLLUser();
        BLLUsergroup bllug = new BLLUsergroup();
        OpenFileDialog ofd = new OpenFileDialog();
        msgclass msg = new msgclass();
        Image pic;

        public void Clear()
        {
            txtfullname.Text = string.Empty;
            txtphone.Text = string.Empty;
            txtnationalid.Text = string.Empty;
            txtusername.Text = string.Empty;
            txtpass.Text = string.Empty;
            txtrepass.Text = string.Empty;
            pictureBox1.Image = null;
        }
        public string Savepic(string UserName)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\userpic\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string picname = UserName + ".JPG";
            try
            {
                string picpath = ofd.FileName;
                if (!Directory.Exists(path + picname))
                {
                    File.Copy(picpath, path + picname, true);
                }
                return path + picname;
            }
            catch (Exception e)
            {
                MessageBox.Show("The system is not able to save the picture!!!" + e.Message);
            }
            return null;

        }

        private void btnselectpic_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG(*.JPG) | *.JPG";
            ofd.Title = "تصویر مورد نظر را انتخاب کنید";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic = Image.FromFile(ofd.FileName);
                picuser.Image = pic;
            }
        }

        Userroles Fillroles(string section, bool canenter, bool cancreate, bool canedit, bool candelete)
        {
            Userroles ur = new Userroles();
            ur.section = section;
            ur.canenter = canenter;
            ur.cancreate = cancreate;
            ur.canedit = canedit;
            ur.candelete = candelete;
            return ur;
        }
        void Createadmingroup()
        {
            Usergroup ug = new Usergroup();
            ug.Title = "General Administrator";
            ug.Roles.Add(Fillroles("Depots", true, true, true, true));
            ug.Roles.Add(Fillroles("Accounts", true, true, true, true));
            ug.Roles.Add(Fillroles("Persons", true, true, true, true));
            ug.Roles.Add(Fillroles("Orders", true, true, true, true));
            ug.Roles.Add(Fillroles("Factors", true, true, true, true));
            ug.Roles.Add(Fillroles("Settings", true, true, true, true));
            ug.Roles.Add(Fillroles("Users", true, true, true, true));
            ug.Roles.Add(Fillroles("Tasks", true, true, true, true));
            bllug.Create(ug);
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            if(txtfullname.Text == string.Empty && txtphone.Text == string.Empty && txtnationalid.Text == string.Empty && txtusername.Text == string.Empty && txtpass.Text == string.Empty)
            {
                ErrorProvider ep = new ErrorProvider();
                ep.SetError(txtfullname, "This field is required");
                ErrorProvider ep1 = new ErrorProvider();
                ep1.SetError(txtphone, "This field is required");
                ErrorProvider ep2 = new ErrorProvider();
                ep2.SetError(txtnationalid, "This field is required");
                ErrorProvider ep3 = new ErrorProvider();
                ep3.SetError(txtusername, "This field is required");
                ErrorProvider ep4 = new ErrorProvider();
                ep4.SetError(txtpass, "This field is required");
                ErrorProvider ep5 = new ErrorProvider();
                ep5.SetError(txtrepass, "This field is required");
            }
            else
            {
                Users u = new Users();
                Createadmingroup();
                u.Fullname = txtfullname.Text;
                u.PhoneNo = txtphone.Text;
                u.NationalID = txtnationalid.Text;
                u.Email = txtemail.Text;
                u.Username = txtusername.Text;
                if (txtrepass.Text == txtpass.Text)
                {
                    u.password = txtpass.Text;
                }
                else
                {
                    ErrorProvider ep = new ErrorProvider();
                    ErrorProvider ep1 = new ErrorProvider();
                    ep.SetError(txtpass, "Passwords do not match");
                    ep1.SetError(txtrepass, "Passwords do not match");
                }
                u.Regdate = DateTime.Now;
                u.pic = Savepic(txtusername.Text);
                u.IsActive = true;
                MessageBox.Show(bllu.Create(u, bllug.ReadN("General Administrator")), "User account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                this.Visible = false;
                ((FrmLogin)Application.OpenForms["FrmLogin"]).LoadLoginForm();
            }
            
        }

        private void picuser_Click(object sender, EventArgs e)
        {

        }
    }
}
