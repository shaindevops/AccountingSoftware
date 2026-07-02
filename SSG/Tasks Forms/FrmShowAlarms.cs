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
    public partial class FrmShowAlarms : Form
    {
        public FrmShowAlarms()
        {
            InitializeComponent();
        }
        Tasks T = new Tasks();
        BLLTasks bll = new BLLTasks();

        DateTime strToday;

        Users LoggedUser = new Users();

        private void FrmShowAlarms_Load(object sender, EventArgs e)
        {
            if (bll.ExistTask())
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
                strToday = Convert.ToDateTime(DateTime.Now.ToString("MM/d/yyyy"));
                dgvtaskalrams.DataSource = null;
                dgvtaskalrams.DataSource = bll.FillTaskAlarmToday(LoggedUser.id , strToday);
                dgvtaskalrams.Columns["id"].Visible = false;
                dgvtaskalrams.Columns["TaskGroup_id"].Visible = false;
                dgvtaskalrams.Columns["Users_id"].Visible = false;
            }
            


        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
