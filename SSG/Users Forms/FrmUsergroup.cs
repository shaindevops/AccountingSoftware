using BE;
using BLL;
using System.Windows.Forms;

namespace SSG
{
    public partial class FrmUsergroup : Form
    {
        public FrmUsergroup()
        {
            InitializeComponent();
        }
        Usergroup ug = new Usergroup();
        BLLUsergroup bll = new BLLUsergroup();
       
        msgclass msg = new msgclass();
        bool check = false;

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();
        public void permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
            if (bllu.AccessTo(LoggedUser, "Users", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }
        private void chkWall_CheckedChanged(object sender, System.EventArgs e)
        {
            if(chkWall.Checked)
            {
                chkwenter.Checked = true;
                chkwadd.Checked = true;
                chkwedit.Checked = true;
                chkwdelete.Checked = true;
            }
            else
            {
                chkwenter.Checked = false;
                chkwadd.Checked = false;
                chkwedit.Checked = false;
                chkwdelete.Checked = false;
            }
        }

        private void chkAall_CheckedChanged(object sender, System.EventArgs e)
        {
            if(chkAall.Checked)
            {
                chkAenter.Checked = true;
                chkaadd.Checked = true;
                chkaedit.Checked = true;
                chkadelete.Checked = true;
            }
            else
            {
                chkAenter.Checked = false;
                chkaadd.Checked = false;
                chkaedit.Checked = false;
                chkadelete.Checked = false;
            }
        }

        private void chkPall_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkPall.Checked)
            {
                chkpenter.Checked = true;
                chkpadd.Checked = true;
                chkpedit.Checked = true;
                chkpdelete.Checked = true;
            }
            else
            {
                chkpenter.Checked= false;
                chkpadd.Checked= false;
                chkpedit.Checked= false;
                chkpdelete.Checked= false;
            }
        }

        private void chkFall_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkFall.Checked)
            {
                chkfenter.Checked = true;
                chkfadd.Checked = true;
                chkfedit.Checked = true;
                chkfdelete.Checked = true;
            }
            else
            {
                chkfenter.Checked = false;
                chkfadd.Checked= false;
                chkfedit.Checked= false;
                chkfdelete.Checked= false;
            }
        }

        private void chkSall_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkSall.Checked)
            {
                chksenter.Checked = true;
                chksadd.Checked = true;
                chksedit.Checked = true;
                chksdelete.Checked= true;
            }
            else
            {
                chksenter.Checked = false;
                chksadd.Checked = false;
                chksedit.Checked= false;
                chksdelete.Checked = false;
            }
        }

        private void chkUall_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkUall.Checked)
            {
                chkuenter.Checked = true;
                chkuadd.Checked = true;
                chkuedit.Checked = true;
                chkudelete.Checked = true;
            }
            else
            {
                chkuenter.Checked = false;
                chkuadd.Checked = false;
                chkuedit.Checked = false;
                chkudelete.Checked = false;
            }
        }

        
        private void CheckAllCheckBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = check;
                }
            }
        }
        void Clear()
        {
            txtusertypetitle.Text = string.Empty;
            CheckAllCheckBoxes();
        }
        Userroles Filluserroles(string Section, bool Canenter, bool Cancreate, bool Canedit, bool Candelete)
        {
            Userroles ur = new Userroles();
            ur.section = Section;
            ur.canenter = Canenter;
            ur.cancreate = Cancreate;
            ur.canedit = Canedit;
            ur.candelete = Candelete;
            return ur;
        }

        private void btnsave_Click(object sender, System.EventArgs e)
        {
            if(txtusertypetitle.Text == string.Empty)
            {
                ErrorProvider ep = new ErrorProvider();
                ep.SetError(txtusertypetitle, "The title of the type of user is necessary");
            }
            else
            {
                ug.Title = txtusertypetitle.Text;
                ug.Roles.Add(Filluserroles(grpwarehouse.Text, chkwenter.Checked, chkwadd.Checked, chkwedit.Checked, chkwdelete.Checked));
                ug.Roles.Add(Filluserroles(grpaccount.Text, chkAenter.Checked, chkaadd.Checked, chkaedit.Checked, chkadelete.Checked));
                ug.Roles.Add(Filluserroles(grpperson.Text, chkpenter.Checked, chkpadd.Checked, chkpedit.Checked, chkpdelete.Checked));
                ug.Roles.Add(Filluserroles(grpOrders.Text, chkoenter.Checked, chkoadd.Checked, chkoedit.Checked, chkodelete.Checked));
                ug.Roles.Add(Filluserroles(grpfactor.Text, chkfenter.Checked, chkfadd.Checked, chkfedit.Checked, chkfdelete.Checked));
                ug.Roles.Add(Filluserroles(grpsetting.Text, chksenter.Checked, chksadd.Checked, chksedit.Checked, chksdelete.Checked));
                ug.Roles.Add(Filluserroles(grpusers.Text, chkuenter.Checked, chkuadd.Checked, chkuedit.Checked, chkudelete.Checked));
                ug.Roles.Add(Filluserroles(grpTasks.Text, chktenter.Checked, chktadd.Checked, chktedit.Checked, chktdelete.Checked));
                msg.MyMessagebox("User Type", bll.Create(ug), 0, 0);
                var usermanageform = Application.OpenForms["UserManagementForm"] as UserManagementForm;
                if (usermanageform != null)
                {
                    usermanageform.FillGrid();
                }

                var addnewuserform = Application.OpenForms["AddNewUserForm"] as AddNewUserForm;
                if (addnewuserform != null)
                {
                    addnewuserform.FillGridCMB();
                }
                Clear();
            }
        }

        private void btnsaveclose_Click(object sender, System.EventArgs e)
        {
            if (txtusertypetitle.Text == string.Empty)
            {
                ErrorProvider ep = new ErrorProvider();
                ep.SetError(txtusertypetitle, "The title of the type of user is necessary");
            }
            else
            {
                ug.Title = txtusertypetitle.Text;
                ug.Roles.Add(Filluserroles(grpwarehouse.Text, chkwenter.Checked, chkwadd.Checked, chkwedit.Checked, chkwdelete.Checked));
                ug.Roles.Add(Filluserroles(grpaccount.Text, chkAenter.Checked, chkaadd.Checked, chkaedit.Checked, chkadelete.Checked));
                ug.Roles.Add(Filluserroles(grpperson.Text, chkpenter.Checked, chkpadd.Checked, chkpedit.Checked, chkpdelete.Checked));
                ug.Roles.Add(Filluserroles(grpOrders.Text, chkoenter.Checked, chkoadd.Checked, chkoedit.Checked, chkodelete.Checked));
                ug.Roles.Add(Filluserroles(grpfactor.Text, chkfenter.Checked, chkfadd.Checked, chkfedit.Checked, chkfdelete.Checked));
                ug.Roles.Add(Filluserroles(grpsetting.Text, chksenter.Checked, chksadd.Checked, chksedit.Checked, chksdelete.Checked));
                ug.Roles.Add(Filluserroles(grpusers.Text, chkuenter.Checked, chkuadd.Checked, chkuedit.Checked, chkudelete.Checked));
                ug.Roles.Add(Filluserroles(grpTasks.Text, chktenter.Checked, chktadd.Checked, chktedit.Checked, chktdelete.Checked));
                msg.MyMessagebox("User Type", bll.Create(ug), 0, 0);

                var usermanageform = Application.OpenForms["UserManagementForm"] as UserManagementForm;
                if (usermanageform != null)
                {
                    usermanageform.FillGrid();
                }

                var addnewuserform = Application.OpenForms["AddNewUserForm"] as AddNewUserForm;
                if (addnewuserform != null)
                {
                    addnewuserform.FillGridCMB();
                }
               
                Clear();
                Close();
            }
        }

        private void btnclose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void chkoall_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkoall.Checked)
            {
                chkoenter.Checked = true;
                chkoadd.Checked = true;
                chkoedit.Checked = true;
                chkodelete.Checked = true;
            }
            else
            {
                chkoenter.Checked = false;
                chkoadd.Checked = false;
                chkoedit.Checked = false;
                chkodelete.Checked = false;
            }
        }

        private void FrmUsergroup_Load(object sender, System.EventArgs e)
        {
            permisions();
            if(btnsave.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
            }
        }

        private void chkTall_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkTall.Checked)
            {
                chktenter.Checked = true;
                chktadd.Checked = true;
                chktedit.Checked = true;
                chktdelete.Checked = true;
            }
            else
            {
                chktenter.Checked = false;
                chktadd.Checked = false;
                chktedit.Checked = false;
                chktdelete.Checked = false;
            }
        }
    }
}
