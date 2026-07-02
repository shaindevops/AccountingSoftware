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

namespace SSG.Tasks_Forms
{
    public partial class FrmAddTaskGroup : Form
    {
        public FrmAddTaskGroup()
        {
            InitializeComponent();
        }

        TaskGroup TG = new TaskGroup();
        BLLTaskGroup bll = new BLLTaskGroup();

        msgclass msg = new msgclass();

        Users LoggedUser = new Users();

        public int GroupId = 0;

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtgroupname.Text == string.Empty)
            {
                ep.SetError(txtgroupname, "This filed is required");
                txtgroupname.Focus();
            }
            else
            {
                ep.Clear();
                TG.Title = txtgroupname.Text;
                TG.Description = txtdesc.Text;


                if (btnsave.Text == "Save")
                {
                    msg.MyMessagebox("Message", bll.Create(TG), 0, 0);
                }
                else if (btnsave.Text == "Edit")
                {
                    msg.MyMessagebox("Message", bll.Update(GroupId, TG), 0, 0);
                    btnsave.Text = "Save";
                }

                var frmshowtaskgroup = Application.OpenForms["FrmShowTaskGroup"] as FrmShowTaskGroup;
                if(frmshowtaskgroup != null)
                {
                    frmshowtaskgroup.FrmShowTaskGroup_Load(null, null);
                }

                var frmaddtask = Application.OpenForms["FrmAddTask"] as FrmAddTask;
                if(frmaddtask != null)
                {
                    frmaddtask.FrmAddTask_Load(null, null);
                }
                txtgroupname.Text = string.Empty;
                txtdesc.Text = string.Empty;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
