using BE;
using BLL;
using SSG.Emails___Panels;
using SSG.People_Forms;
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
    public partial class FrmAddTask : Form
    {
        public FrmAddTask()
        {
            InitializeComponent();
        }
        Tasks T = new Tasks();
        BLLTasks bll = new BLLTasks();

        TaskGroup TG = new TaskGroup();
        BLLTaskGroup blltg = new BLLTaskGroup();
        Users LoggedUser = new Users();
        Users U = new Users();
        BLLUser bllu = new BLLUser();

        People P = new People();
        BLLPeople bllperson = new BLLPeople();

        SendEmail Send = new SendEmail();
        BLLSendEmail bllsend = new BLLSendEmail();

        EmailPanel emailp = new EmailPanel();
        BLLEmailPanel bllep = new BLLEmailPanel();

        Tbl_Company com = new Tbl_Company();
        Tbl_CompanyBLL bllcom = new Tbl_CompanyBLL();

        msgclass msg = new msgclass();

        public int TaskId = 0;

        string MyShopName = "";

        string Userpanel = "";
        string Passpanel = "";

        public bool FrmTaskType = false;

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Tasks", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }

        public void Clear()
        {
            txttasktitle.Text = string.Empty;
            txtdesc.Text = string.Empty;
            dtinputtaskdate.Text = DateTime.Now.ToString("MM/d/yyyy");
            dtinputalarmdate.Text = DateTime.Now.ToString("MM/d/yyyy");
            dtinputtasktime.Text = DateTime.Now.ToString("HH:mm");
            dtiputalarmtime.Text = DateTime.Now.ToString("HH:mm");
            chkalarm.Checked = false;
        }
        
        public void FrmAddTask_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
                if(btnsave.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
                }




                dtinputtaskdate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                dtinputalarmdate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                chkalarm.Checked = true;

                cmbtaskgroup.DataSource = null;
                cmbtaskgroup.DataSource = blltg.FillTaskGroup();
                cmbtaskgroup.DisplayMember = "Title";


                cmbusers.DataSource = null;
                cmbusers.DataSource = bllu.Read();
                cmbusers.DisplayMember = "Full Name";


                if (FrmTaskType == true)
                {
                    lblperson.Visible = true;
                    cmbusers.Visible = true;
                }
                else
                {
                    lblperson.Visible = false;
                    cmbusers.Visible = false;
                }

                MyShopName = bllcom.ReadComName(com);
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnaddtaskgroup_Click(object sender, EventArgs e)
        {
            
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
                if (bllu.AccessTo(LoggedUser, "Tasks", 1))
                {
                    new FrmShowTaskGroup().ShowDialog();
                }
                else
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
            
        }

        private void chkalarm_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtinputalarmdate.Enabled = chkalarm.Checked;
                dtiputalarmtime.Enabled = chkalarm.Checked;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbtaskgroup.Text == string.Empty)
                {
                    ep.SetError(btnaddtaskgroup, "Click On Add Group Button To \n Add Task Group.");
                    btnaddtaskgroup.Focus();
                }
                else if(txttasktitle.Text == string.Empty)
                {
                    ep.Clear();
                    ep.SetError(txttasktitle, "This Filed Is Required");
                    txttasktitle.Focus();
                }
                
                else
                {
                    ep.Clear();

                    TG = blltg.ReadTaskGroupTitle(cmbtaskgroup.Text);
                    T.TaskGroup = TG;

                    T.Title = txttasktitle.Text;
                    T.Description = txtdesc.Text;
                    T.TaskDate = Convert.ToDateTime(dtinputtaskdate.Text);
                    T.TaskTime = Convert.ToDateTime(dtinputtasktime.Text);
                    if (chkalarm.Checked)
                    {
                        T.TaskAlarmDate = Convert.ToDateTime(dtinputalarmdate.Text);
                        T.TaskAlarmTime = Convert.ToDateTime(dtiputalarmtime.Text);
                        T.Alarm = true;
                    }

                    if (FrmTaskType == true)
                    {
                        U = bllu.ReadU(cmbusers.Text);
                        T.Users = U;
                    }
                    else
                    {
                        LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
                        T.Users = LoggedUser;
                    }
                    

                    if(btnsave.Text == "Save")
                    {
                        if(msg.MyMessagebox("Send Email", "Would you like to send an email to the user?", 1, 1) == DialogResult.Yes)
                        {
                            bllep.GetEmailPanel(out Userpanel, out Passpanel);
                            if (FrmTaskType)
                            {
                                bllsend.SendEmail(Userpanel, Passpanel, MyShopName, T.Users.Email, txttasktitle.Text, "Your Task is \n Title : " + txttasktitle.Text + " \n on date : " + dtinputalarmdate.Text + " \n with Description : " + txtdesc.Text + " \n Registered in : " + MyShopName + " System. Please Done This Ontime", "");
                                msg.MyMessagebox("Message", bll.Create(T, T.TaskGroup.id, U.id), 0, 0);
                            }
                            else
                            {
                                bllsend.SendEmail(Userpanel, Passpanel, MyShopName, LoggedUser.Email, txttasktitle.Text, "Your Task is \n Title : " + txttasktitle.Text + " \n on date : " + dtinputalarmdate.Text + " \n with Description : " + txtdesc.Text + " \n Registered in : " + MyShopName + " System. Please Done This Ontime", "");
                                msg.MyMessagebox("Message", bll.Create(T, T.TaskGroup.id, LoggedUser.id), 0, 0);
                            }
                            
                        }
                        
                    }
                    else if(btnsave.Text == "Edit")
                    {
                        msg.MyMessagebox("Edit Message", bll.Update(TaskId, T), 0, 0);
                        btnsave.Text = "Save";
                    }

                    var frmshowtask = Application.OpenForms["FrmShowTasks"] as FrmShowTasks;
                    if (frmshowtask != null)
                    {
                        frmshowtask.FrmShowTasks_Load(null, null);
                    }
                    Clear();
                    
                }
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

        private void btnaddperson_Click(object sender, EventArgs e)
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Persons", 2))
            {
                new FrmAddPeople().ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
        }
    }
}
