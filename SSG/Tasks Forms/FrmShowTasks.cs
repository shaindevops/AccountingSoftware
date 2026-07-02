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
using System.Xml.Linq;

namespace SSG.Tasks_Forms
{
    public partial class FrmShowTasks : Form
    {
        public FrmShowTasks()
        {
            InitializeComponent();
        }

        Tasks T = new Tasks();
        BLLTasks bll = new BLLTasks();

        TaskGroup TG = new TaskGroup();
        BLLTaskGroup blltg = new BLLTaskGroup();

        msgclass msg = new msgclass();

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();
        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Tasks", 3) && bllu.AccessTo(LoggedUser, "Tasks", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = true;
                btnisdone.Enabled = true;
            }
            else if (bllu.AccessTo(LoggedUser, "Tasks", 3) && !bllu.AccessTo(LoggedUser, "Tasks", 4))
            {
                btnedit.Enabled = true;
                btnisdone.Enabled = true;
                btndelete.Enabled = false;
            }
            else if (!bllu.AccessTo(LoggedUser, "Tasks", 3) && bllu.AccessTo(LoggedUser, "Tasks", 4))
            {
                btnedit.Enabled = false;
                btnisdone.Enabled = false;
                btndelete.Enabled = true;
            }
            else
            {
                btnedit.Enabled = false;
                btnisdone.Enabled = false;
                btndelete.Enabled = false;
            }
        }

        public void FrmShowTasks_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + ex.Message, 2, 2);
            }
        }

        

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                T = bll.ReadId((int)dgvtasks.CurrentRow.Cells[0].Value);
                if (T != null) 
                { 
                    FrmAddTask addt = new FrmAddTask();
                    addt.TaskId = T.id;
                    addt.txttasktitle.Text = T.Title;
                    addt.dtinputtaskdate.Text = T.TaskDate.ToString();
                    addt.dtinputtasktime.Text = T.TaskTime.ToString();
                    addt.txtdesc.Text = T.Description;
                    addt.chkalarm.Checked = true;
                    addt.dtinputalarmdate.Text = T.TaskAlarmDate.ToString();
                    addt.dtiputalarmtime.Text = T.TaskAlarmTime.ToString();
                    addt.btnsave.Text = "Edit";
                    addt.ShowDialog();
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnisdone_Click(object sender, EventArgs e)
        {
            try
            {
                T = bll.ReadId((int)dgvtasks.CurrentRow.Cells[0].Value);
                if (T != null)
                {
                    bll.UpdateIsDone(T.id);

                    if (dgvtasks.Rows.Count > 0) // بررسی اینکه DataGridView خالی نیست
                    {
                        int lastRowIndex = dgvtasks.Rows.Count - 1; // اندیس آخرین ردیف
                        var cellValue = dgvtasks.Rows[lastRowIndex].Cells[6].Value;

                        if (cellValue != null && cellValue is bool isChecked && isChecked)
                        {
                            dgvtasks.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                        }
                    }
                }

                FrmShowTasks_Load(null, null);
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
                T = bll.ReadId((int)dgvtasks.CurrentRow.Cells[0].Value);
                if (T != null)
                {
                    bll.Delete(T.id);
                }

                FrmShowTasks_Load(null, null);
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

        private void btnadd_Click(object sender, EventArgs e)
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
            FrmAddTask addt = new FrmAddTask();
            if(LoggedUser.Usergroup.Title == "General Administrator")
            {
                addt.FrmTaskType = true;
            }
            else
            {
                addt.FrmTaskType = false;
            }

            addt.ShowDialog();
        }

        private void chkIsdone_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
                dgvtasks.DataSource = null;
                dgvtasks.DataSource = bll.FillIsDoneTaskByUser(LoggedUser.id);
                dgvtasks.Columns["id"].Visible = false;
                dgvtasks.Columns["Users_id"].Visible = false;
                dgvtasks.Columns["IsDone"].Visible = false;
                

                if (dgvtasks.Rows.Count > 0) // بررسی اینکه DataGridView خالی نیست
                {
                    int lastRowIndex = dgvtasks.Rows.Count - 1; // اندیس آخرین ردیف
                    var cellValue = dgvtasks.Rows[lastRowIndex].Cells[6].Value;

                    if (cellValue != null && cellValue is bool isChecked && isChecked)
                    {
                        dgvtasks.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    }
                }


                btnallcount.Text = bll.TasksCount();
                btnisdonecount.Text = bll.TasksCountIsDone();
                btnnotdonecount.Text = bll.TasksCountNotDone();
                btntaskstodaycount.Text = bll.TasksCountToday();
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + ex.Message, 2, 2);
            }

        }

        private void chkinproccess_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
                dgvtasks.DataSource = null;
                dgvtasks.DataSource = bll.FillNonDoneTaskByUser(LoggedUser.id);
                dgvtasks.Columns["IsDone"].Visible = false;
                dgvtasks.Columns["id"].Visible = false;
                dgvtasks.Columns["Users_id"].Visible = false;

                if (dgvtasks.Rows.Count > 0) // بررسی اینکه DataGridView خالی نیست
                {
                    int lastRowIndex = dgvtasks.Rows.Count - 1; // اندیس آخرین ردیف
                    var cellValue = dgvtasks.Rows[lastRowIndex].Cells[6].Value;

                    if (cellValue != null && cellValue is bool isChecked && isChecked)
                    {
                        dgvtasks.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    }
                }

                btnallcount.Text = bll.TasksCount();
                btnisdonecount.Text = bll.TasksCountIsDone();
                btnnotdonecount.Text = bll.TasksCountNotDone();
                btntaskstodaycount.Text = bll.TasksCountToday();
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost\n" + ex.Message, 2, 2);
            }
        }

        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
                dgvtasks.DataSource = null;
                dgvtasks.DataSource = bll.FillTaskByUser(LoggedUser.id);
                dgvtasks.Columns["IsDone"].Visible = false;
                dgvtasks.Columns["id"].Visible = false;
                dgvtasks.Columns["Users_id"].Visible = false;


                if (dgvtasks.Rows.Count > 0) // بررسی اینکه DataGridView خالی نیست
                {
                    int lastRowIndex = dgvtasks.Rows.Count - 1; // اندیس آخرین ردیف
                    var cellValue = dgvtasks.Rows[lastRowIndex].Cells[6].Value;

                    if (cellValue != null && cellValue is bool isChecked && isChecked)
                    {
                        dgvtasks.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    }
                }
                btnallcount.Text = bll.TasksCount();
                btnisdonecount.Text = bll.TasksCountIsDone();
                btnnotdonecount.Text = bll.TasksCountNotDone();
                btntaskstodaycount.Text = bll.TasksCountToday();
            }
            catch(Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost\n"+ ex.Message, 2, 2);
            }
        }
    }
}
