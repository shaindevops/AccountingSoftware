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
    public partial class FrmShowTaskGroup : Form
    {
        public FrmShowTaskGroup()
        {
            InitializeComponent();
        }
        TaskGroup TG = new TaskGroup();
        BLLTaskGroup bll = new BLLTaskGroup();

        msgclass msg = new msgclass();
        public void FrmShowTaskGroup_Load(object sender, EventArgs e)
        {
            try
            {
                dgvtaskgroup.DataSource = null;
                dgvtaskgroup.DataSource = bll.FillTaskGroup();
                dgvtaskgroup.Columns["id"].Visible = false;
                dgvtaskgroup.Columns["Title"].Width = 150;
                dgvtaskgroup.Columns["Description"].Width = 350;

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmAddTaskGroup().ShowDialog();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                TG = bll.ReadId((int)dgvtaskgroup.CurrentRow.Cells[0].Value);
                if(TG != null)
                {
                    FrmAddTaskGroup addtg = new FrmAddTaskGroup();
                    addtg.GroupId = TG.id;

                    addtg.txtgroupname.Text = TG.Title;
                    addtg.txtdesc.Text = TG.Description;
                    addtg.btnsave.Text = "Edit";

                    addtg.ShowDialog();
                }
                
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
                TG = bll.ReadId((int)dgvtaskgroup.CurrentRow.Cells[0].Value);
                if (TG != null)
                {
                    if(msg.MyMessagebox("Delete Task Group", "Are you sure you want to delete this task group?", 1, 1) == DialogResult.Yes)
                    {
                        bll.Delete(TG.id);
                    }
                }

                FrmShowTaskGroup_Load(null, null);
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
