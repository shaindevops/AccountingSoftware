using BE;
using BLL;
using SSG.Accounts_Book_Forms;
using SSG.Accounts_Forms;
using SSG.CostGroup_Forms;
using SSG.Depots_Forms;
using SSG.Documents_Forms;
using SSG.Factors_Forms;
using SSG.Groups_Forms;
using SSG.Messages_Forms;
using SSG.People_Forms;
using SSG.Products_Forms;
using SSG.Stocks_Forms;
using SSG.Users_Forms;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using SSG.Orders_Forms;
using SSG.Emails___Panels;
using SSG.SMS_Forms;
using System.Management;
using SSG.Pos_Forms;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using SSG.Tasks_Forms;
namespace SSG
{
    public partial class frmASWS : Form
    {
        private Dictionary<string, bool> connectedDevices = new Dictionary<string, bool>();

        private ManagementEventWatcher usbWatcher;
        private Timer comTimer;
        private FrmDeviceId deviceForm;

        public frmASWS()
        {
            InitializeComponent();
            deviceForm = new FrmDeviceId();
            InitializeUSBWatcher();
            InitializeCOMWatcher();
            InitializeNetworkWatcher();
        }

        private void InitializeUSBWatcher()
        {
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");
            usbWatcher = new ManagementEventWatcher(query);
            usbWatcher.EventArrived += new EventArrivedEventHandler(UsbEventArrived);
            usbWatcher.Start();
        }

        private async void UsbEventArrived(object sender, EventArrivedEventArgs e)
        {
            var eventType = e.NewEvent.Properties["EventType"].Value;
            if (eventType != null && Convert.ToInt32(eventType) == 2) // دستگاه جدید متصل شد
            {
                await Task.Run(() =>
                {
                    try
                    {
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity WHERE DeviceID LIKE 'USB%'");
                        foreach (ManagementObject device in searcher.Get())
                        {
                            string deviceName = device["Name"]?.ToString() ?? "Unspecified";
                            if (!connectedDevices.ContainsKey(deviceName)) // اگر دستگاه قبلا اضافه نشده باشد
                            {
                                connectedDevices[deviceName] = true;

                                this.Invoke((MethodInvoker)delegate
                                {
                                    // بروزرسانی فرم شناسایی
                                    deviceForm.cmbdevicename.Items.Clear();
                                    deviceForm.cmbdevicename.Items.Add(deviceName);
                                    deviceForm.cmbdevicename.SelectedIndex = 0;

                                    deviceForm.txtportname.Text = device["Caption"]?.ToString() ?? "Unspecified";
                                    deviceForm.txtbaudrate.Text = "9600";

                                    deviceForm.lblstatus.Text = "USB Connected";
                                    deviceForm.lblstatus.ForeColor = Color.Green;

                                    if (!deviceForm.Visible) deviceForm.ShowDialog();
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error getting device information: " + ex.Message);
                    }
                });
            }
        }

        private void InitializeCOMWatcher()
        {
            comTimer = new Timer();
            comTimer.Interval = 5000;
            comTimer.Tick += (s, e) => CheckCOMDevices();
            comTimer.Start();
        }

        private void CheckCOMDevices()
        {
            string[] portNames = SerialPort.GetPortNames();
            foreach (string port in portNames)
            {
                if (!connectedDevices.ContainsKey(port)) // اگر پورت قبلا شناسایی نشده باشد
                {
                    connectedDevices[port] = true;

                    this.Invoke((MethodInvoker)delegate
                    {
                        deviceForm.cmbdevicename.Items.Clear();
                        deviceForm.cmbdevicename.Items.Add("COM Device: " + port);
                        deviceForm.cmbdevicename.SelectedIndex = 0;

                        deviceForm.txtportname.Text = port;
                        deviceForm.lblstatus.Text = "COM Connected";
                        deviceForm.lblstatus.ForeColor = Color.Blue;

                        if (!deviceForm.Visible) deviceForm.ShowDialog();
                    });
                }
            }
        }

        private void InitializeNetworkWatcher()
        {
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(NetworkChanged);
        }

        private async void NetworkChanged(object sender, EventArgs e)
        {
            await CheckNetworkDevices();
        }

        private async Task CheckNetworkDevices()
        {
            string baseIP = "192.168.1.";
            for (int i = 1; i < 255; i++)
            {
                string ip = baseIP + i;
                await Task.Run(() => PingDevice(ip));
                await Task.Delay(100);
            }
        }

        private void PingDevice(string ipAddress)
        {
            using (Ping ping = new Ping())
            {
                try
                {
                    PingReply reply = ping.Send(ipAddress, 100);
                    if (reply.Status == IPStatus.Success)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (!connectedDevices.ContainsKey(ipAddress))
                            {
                                connectedDevices[ipAddress] = true;

                                deviceForm.cmbdevicename.Items.Clear();
                                deviceForm.cmbdevicename.Items.Add("Network Device: " + ipAddress);
                                deviceForm.cmbdevicename.SelectedIndex = 0;

                                deviceForm.txtportname.Text = ipAddress;
                                deviceForm.lblstatus.Text = "Network Connected";
                                deviceForm.lblstatus.ForeColor = Color.Purple;

                                if (!deviceForm.Visible) deviceForm.ShowDialog();
                            }
                        });
                    }
                }
                catch (PingException)
                {
                    // نادیده گرفتن دستگاه‌های بدون پاسخ
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            usbWatcher.Stop();
            usbWatcher.Dispose();
            comTimer.Stop();
            base.OnFormClosed(e);
        }





        public Users loggeduser = new Users();
        msgclass msg = new msgclass();
        BLLsetting blls = new BLLsetting();
        BLLUser bllu = new BLLUser();
        public UserLogs ul = new UserLogs();
        BLLUserlog bllul = new BLLUserlog();
        Setting s = new Setting();
        Tbl_CompanyBLL bllcom = new Tbl_CompanyBLL();
        public Tbl_Company com = new Tbl_Company();

        BLLTaxs blltax = new BLLTaxs();

        BLLTasks blltask = new BLLTasks();

        BLLStocks bllst = new BLLStocks();
        public bool ExistSetting = false;
        int id;
        public int logid;

        int Alarm1 = 0;
        int Alarm2 = 0;

        Timer t1 = new Timer();
        string strToday = DateTime.Now.ToString("MM/dd/yyyy");

        public void HidePanel()
        {
            pnlOrder.Visible = false;
        }
        public void FillDGVStock()
        {
            dgvstockAlarm.DataSource = null;
            dgvstockAlarm.DataSource = bllst.FillStockAlerm();
            dgvstockAlarm.Columns["id"].Visible = false;
            dgvstockAlarm.Columns["Group_id"].Visible = false;
            dgvstockAlarm.Columns["Code"].Visible = false;
            dgvstockAlarm.Columns["DefaultPrice"].Visible = false;
            dgvstockAlarm.Columns["Size"].Visible = false;
            dgvstockAlarm.Columns["Alarm"].Visible = false;
            dgvstockAlarm.Columns["Unit1"].Visible = false;
            dgvstockAlarm.Columns["Total Enter"].Visible = false;
            dgvstockAlarm.Columns["Total Leave"].Visible = false;
            dgvstockAlarm.Columns["Group Name"].Visible = false;
            dgvstockAlarm.Columns["Name"].HeaderText = "Product Name";
            dgvstockAlarm.Columns["Unit2"].HeaderText = "Unit";
            dgvstockAlarm.Columns["Total"].HeaderText = "Sum Stock";
            if (dgvstockAlarm.Rows.Count == 0)
            {
                exPanelStock.Visible = false;
            }
            else
            {
                exPanelStock.Visible = true;
            }
        }
        public void FillDGVAlarm()
        {
            try
            {
                blls.GetAlarmSetting(out Alarm1, out Alarm2);

                dgvduedocs.DataSource = null;
                dgvduedocs.DataSource = blls.AlarmDocuments(strToday, Alarm1, Alarm2);

                if (dgvduedocs.Rows.Count == 0)
                {
                    expaneldocs.Visible = false;
                }
                else
                {
                    expaneldocs.Visible = true;
                }
            }
            catch (Exception m)
            {
                msg.MyMessagebox("Disconnected from the server", "There is a problem communicating with the server" + m.Message, 3, 3);
            }

        }

        public void UpdateTask()
        {
            // تنظیم تایمر برای چک کردن تسک‌ها هر یک ساعت
            Timer timer = new Timer();
            timer.Interval = 3600000; // یک ساعت (۱ ساعت = ۳۶۰۰۰۰۰ میلی‌ثانیه)
            timer.Tick += (s, ev) => blltask.UpdateTaskDueDates();
            timer.Start();
        }

        public void TaskAlarms()
        {
            if (blltask.ExistTask())
            {
                // ایجاد و تنظیمات فرم پاپ‌آپ
                FrmShowAlarms popup = new FrmShowAlarms();

                // موقعیت شروع فرم پاپ‌آپ (پایین صفحه)
                popup.StartPosition = FormStartPosition.Manual;
                popup.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - popup.Width) / 2,
                                           Screen.PrimaryScreen.WorkingArea.Height);

                // اضافه کردن تایمر برای حرکت آرام فرم به بالا
                Timer moveTimer = new Timer();
                moveTimer.Interval = 20; // تنظیم سرعت حرکت
                moveTimer.Tick += (s, ev) =>
                {
                    if (popup.Top > (Screen.PrimaryScreen.WorkingArea.Height - popup.Height) / 2)
                    {
                        popup.Top -= 10; // حرکت آرام به سمت بالا
                    }
                    else
                    {
                        moveTimer.Stop(); // متوقف کردن تایمر وقتی فرم به وسط صفحه رسید
                    }
                };

                popup.Show(); // نمایش فرم پاپ‌آپ
                moveTimer.Start(); // شروع تایمر حرکت
            }
        }
        public void RefreshWin()
        {
            t1.Enabled = true;
            t1.Interval = 4000;
            t1.Tick += Timer1_Tick;
            t1.Start();

            FillDGVStock();

            FillDGVAlarm();

            if(bllcom.ExistCompany() == false)
            {
                new CompanySpecificationForm().ShowDialog();
            }
            if (blls.Exictsetting() == false)
            {
                new Frmsetting().ShowDialog();
            }
            if(blltax.ExistTax() == false)
            {
                new FrmTax().ShowDialog();
            }

            pnlOrder.Visible = false;

            if (bllu.AccessTo(loggeduser, "Users", 1))
            {
                lblusermanage.Enabled = true;
                btnusermanage.Enabled = true;
            }
            else
            {
                lblusermanage.Enabled = false;
                btnusermanage.Enabled = false;
            }
            if(bllu.AccessTo(loggeduser, "Settings", 1))
            {
                lblsetting.Enabled = true;
                btnsetting.Enabled = true;
                btntax.Enabled = true;
                btnemail.Enabled = true;
                btnsmspanel.Enabled = true;
                btnsendsms.Enabled = true;
            }
            else
            {
                lblsetting.Enabled = false;
                btnsetting.Enabled = false;
                btntax.Enabled = false;
                btnemail.Enabled = false;
                btnsmspanel.Enabled = false;
                btnsendsms.Enabled = false;
            }

            if(bllu.AccessTo(loggeduser, "Depots", 1))
            {
                btndepot.Enabled = true;
                btnmanual.Enabled = true;
                btnstock.Enabled = true;
                btnmovment.Enabled = true;
            }
            else
            {
                btndepot.Enabled = false;
                btnmanual.Enabled = false;
                btnstock.Enabled = false;
                btnmovment.Enabled = false;
            }

            if (bllu.AccessTo(loggeduser, "Factors", 1))
            {
                btngroups.Enabled = true;
                btnproducts.Enabled = true;
                btngoods.Enabled = true;
                btnsales.Enabled = true;
                btnSale.Enabled = true;
                btnBuy.Enabled = true;
                btnbuys.Enabled = true;
            }
            else
            {
                btngroups.Enabled = false;
                btnproducts.Enabled = false;
                btngoods.Enabled = false;
                btnsales.Enabled = false;
                btnSale.Enabled = false;
                btnBuy.Enabled = false;
                btnbuys.Enabled = false;
            }
            if(bllu.AccessTo(loggeduser, "Persons", 1))
            {
                btnpersons.Enabled = true;
                btnshowpersons.Enabled = true;
                btnnotbook.Enabled = true;
            }
            else
            {
                btnpersons.Enabled = false;
                btnshowpersons.Enabled = false;
                btnnotbook.Enabled = false;
            }
            if( bllu.AccessTo(loggeduser, "Accounts", 1))
            {
                btncost.Enabled = true;
                btnincome.Enabled = true;
                btnaccount.Enabled = true;
                btndocument.Enabled = true;
                btnaccounts.Enabled = true;
                btnsalerepor.Enabled = true;
                btnbuyreport.Enabled = true;
                btnmoneyreport.Enabled = true;
                btnfacture.Enabled = true;
            }
            else
            {
                btncost.Enabled = false;
                btnincome.Enabled = false;
                btnaccount.Enabled = false;
                btndocument.Enabled = false;
                btnaccounts.Enabled = false;
                btnsalerepor.Enabled = false;
                btnbuyreport.Enabled = false;
                btnmoneyreport.Enabled = false;
                btnfacture.Enabled = false;
            }
            if(bllu.AccessTo(loggeduser, "Orders", 1))
            {
                btnfastorder.Enabled = true;
                btnsendorder.Enabled = true;
            }
            else
            {
                btnfastorder.Enabled = false;
                btnsendorder.Enabled = false;
            }

            if (bllu.AccessTo(loggeduser, "Tasks", 1))
            {
                btnactivity.Enabled = true;
                btnreminders.Enabled = true;
                btntasks.Enabled = true;
            }
            else
            {
                btnactivity.Enabled = false;
                btnreminders.Enabled = false;
                btntasks.Enabled = false;
            }

        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblorganizationame.Text = bllcom.ReadComName(com);
                lblownername.Text = bllcom.ReadComOwner(com);
                piclogo.ImageLocation = bllcom.ReadComLogo(com);

                bllu.UpdateIsActive(loggeduser.id);

                if(loggeduser.IsActive != false )
                {
                    picuser.Image = Image.FromFile(loggeduser.pic);
                    btnnameofuser.Text = loggeduser.Fullname;
                    btnusername.Text = loggeduser.Username;
                    btnusergroup.Text = loggeduser.Usergroup.Title;
                    symbollight.BackColor = Color.LimeGreen;
                    toolTip1.SetToolTip(symbollight, "User Is Actived" +" - " +"Enter at : "+strToday);
                }
                
            }
            catch (Exception m)
            {
                msg.MyMessagebox("Disconnected from the server", "There is a problem communicating with the server" + m.Message, 3, 3);
            }
            
        }
        public void Timer_Tick(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblclock.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void lblsite_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.devpars.ir");
        }
        private void lbltel_Click(object sender, EventArgs e)
        {
            Process.Start("tel:+989902827506");
        }
        private void frmASWS_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();
            

            // ایجاد تایمر برای تأخیر دو ثانیه‌ای
            Timer delayTimer = new Timer();
            delayTimer.Interval = 5000; // دو ثانیه (۲۰۰۰ میلی‌ثانیه)
            delayTimer.Tick += (s, ev) =>
            {
                delayTimer.Stop(); // توقف تایمر پس از فراخوانی TaskAlarms

                if (blltask.ExistTask())
                {
                    blltask.UpdateTaskDueDates();

                    TaskAlarms(); // فراخوانی متد نمایش پاپ‌آپ
                }
                
            };
            delayTimer.Start(); // شروع تایمر

            RefreshWin();

        }
        private void lblusermanage_Click(object sender, EventArgs e)
        {
            UserManagementForm um = new UserManagementForm();
            um.ShowDialog();
        }

        private void lblsetting_Click(object sender, EventArgs e)
        {
            Frmsetting set = new Frmsetting();
            set.ShowDialog();
            
        }

        private void lblorganization_Click(object sender, EventArgs e)
        {
            CompanySpecificationForm cs = new CompanySpecificationForm();
            cs.ShowDialog();
        }

        private void lblbacksup_Click(object sender, EventArgs e)
        {
            BackupForm b = new BackupForm();
            b.ShowDialog();
        }

        private void lblrestoredb_Click(object sender, EventArgs e)
        {
            RestoreForm r = new RestoreForm();
            r.ShowDialog();
        }

        private void lblcalc_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void lblextit_Click(object sender, EventArgs e)
        {
            DialogResult dr = msg.MyMessagebox("Exit Of Application", "Do you want to exit the program?\n\nWant to back up before exiting?", 1, 1);
            if (dr == DialogResult.Yes)
            {
                new BackupForm().ShowDialog();
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnusermanage_Click(object sender, EventArgs e)
        {
            UserManagementForm um = new UserManagementForm();
            um.ShowDialog();
        }

        private void btnorganization_Click(object sender, EventArgs e)
        {
            CompanySpecificationForm cs = new CompanySpecificationForm();
            cs.ShowDialog();
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            BackupForm b = new BackupForm();
            b.ShowDialog();
        }

        private void btnrestore_Click(object sender, EventArgs e)
        {
            RestoreForm r = new RestoreForm();
            r.ShowDialog();
        }

        private void btnexitaccount_Click(object sender, EventArgs e)
        {
            DialogResult dr = msg.MyMessagebox("Sign Out User Account", "Do you intend to log out of your account?", 1, 1);
            if(dr == DialogResult.Yes)
            {
                Hide();
                FrmLogin l = new FrmLogin();
                l.ShowDialog();
            }
        }

        private void btnloginsetting_Click(object sender, EventArgs e)
        {
            new ResetPasswordForm().ShowDialog();
        }
        private void btndepot_Click(object sender, EventArgs e)
        {
            new FrmShowDepots().ShowDialog();
        }

        private void btngroups_Click(object sender, EventArgs e)
        {
            new FrmShowGroups().ShowDialog();
        }

        private void btnproducts_Click(object sender, EventArgs e)
        {
            new FrmShowProducts().ShowDialog();
        }

        private void btnpersons_Click(object sender, EventArgs e)
        {
            new FrmShowPeople().ShowDialog();
        }

        private void btnincome_Click(object sender, EventArgs e)
        {
            FrmShowCostGroup fscg = new FrmShowCostGroup();
            fscg.CostType = true;
            fscg.btnadd.Text = "Add Income Group";
            fscg.btnedit.Text = "Edit Income Group";
            fscg.btndelete.Text = "Delete Income Group";
            fscg.ShowDialog();
        }

        private void btncost_Click(object sender, EventArgs e)
        {
            FrmShowCostGroup fscg = new FrmShowCostGroup();
            fscg.CostType = false;
            fscg.btnadd.Text = "Add Cost Group";
            fscg.btnedit.Text = "Edit Cost Group";
            fscg.btndelete.Text = "Delete Cost Group";
            fscg.ShowDialog();
        }

        private void btnaccount_Click(object sender, EventArgs e)
        {
            FrmShowAccounts fa = new FrmShowAccounts();
            fa.AccountType = false;
            fa.ShowDialog();
        }

        private void btnbankaccount_Click(object sender, EventArgs e)
        {
            FrmShowAccounts fa = new FrmShowAccounts();
            fa.AccountType = true;
            fa.ShowDialog();
        }

        private void btndocument_Click_1(object sender, EventArgs e)
        {
            new FrmShowFinancialAccount().ShowDialog();
        }

        private void btnsetting_Click_1(object sender, EventArgs e)
        {
            Frmsetting set = new Frmsetting();
            set.ShowDialog();
        }

        private void btntax_Click(object sender, EventArgs e)
        {
            new FrmTax().ShowDialog();
        }

        private void btnfacture_Click(object sender, EventArgs e)
        {
            new FrmFactures().ShowDialog();
        }

        private void btnmanual_Click(object sender, EventArgs e)
        {
            new FrmSelectStock().ShowDialog();
        }

        private void btnmovment_Click_1(object sender, EventArgs e)
        {
            new FrmMovmentProductToDepot().ShowDialog();

        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            FrmShowFactors fact = new FrmShowFactors();
            fact.FrmType = true;
            fact.grpfactors.Text = "Show List Of Buy Factors";
            fact.ShowDialog();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            FrmShowFactors fact = new FrmShowFactors();
            fact.FrmType = false;
            fact.grpfactors.Text = "Show List Of Sale Factors";
            fact.ShowDialog();
        }

        private void btnstock_Click_1(object sender, EventArgs e)
        {
            new FrmShowStocks().ShowDialog();
        }

        private void dgvstockAlarm_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // چک می‌کنیم اگر سطر زوج باشد، رنگ پس‌زمینه قرمز روشن شود
            if (e.RowIndex % 2 == 0)
            {
                dgvstockAlarm.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral; // قرمز لایت
                dgvstockAlarm.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else
            {
                dgvstockAlarm.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red; // قرمز
                dgvstockAlarm.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }

        }

        private void btnbuyreport_Click(object sender, EventArgs e)
        {
            FrmFactorReports fact = new FrmFactorReports();
            fact.FrmType = true;
            
            fact.ShowDialog();
        }

        private void btnsalerepor_Click(object sender, EventArgs e)
        {
            FrmFactorReports fact = new FrmFactorReports();
            fact.FrmType = false;
            
            fact.ShowDialog();
        }

        private void btnmoneyreport_Click(object sender, EventArgs e)
        {
            new FrmMoneyReports().ShowDialog();
        }

        private void btnmessage_Click(object sender, EventArgs e)
        {
            new FrmShowMessages().ShowDialog();
        }
        private void btnfastorder_Click(object sender, EventArgs e)
        {
            pnlOrder.Visible = true;
            UCShowOrderFrom ucorder = new UCShowOrderFrom();

            // تنظیم پرنت به فرم اصلی
            ucorder.ParentForm = this;

            pnlOrder.Controls.Clear();
            pnlOrder.Controls.Add(ucorder);
        }

        private void frmASWS_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = msg.MyMessagebox("Exit Of Application", "Do you want to exit the program?\n\nWant to back up before exiting?", 1, 1);
            if (dr == DialogResult.Yes)
            {
                new BackupForm().ShowDialog();
            }
            else
            {
                Application.ExitThread();
            }
        }
        private void btnsmspanel_Click(object sender, EventArgs e)
        {
            new FrmShowPanels().ShowDialog();
        }

        private void btnsendsms_Click(object sender, EventArgs e)
        {
            new FrmShowSendSms().ShowDialog();
        }

        private void btnemail_Click(object sender, EventArgs e)
        {
            new FrmShowEmailPanel().ShowDialog();
        }

        private void btndevices_Click(object sender, EventArgs e)
        {
            new FrmShowPosDevice().ShowDialog();
        }

        private void btnaccounts_Click(object sender, EventArgs e)
        {
            new FrmShowAccounts().ShowDialog();
        }

        private void btngoods_Click(object sender, EventArgs e)
        {
            new FrmShowProducts().ShowDialog();
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            FrmShowFactors fact = new FrmShowFactors();
            fact.FrmType = false;
            fact.grpfactors.Text = "Show List Of Sale Factors";
            fact.ShowDialog();
        }

        private void btnbuys_Click(object sender, EventArgs e)
        {
            FrmShowFactors fact = new FrmShowFactors();
            fact.FrmType = true;
            fact.grpfactors.Text = "Show List Of Buy Factors";
            fact.ShowDialog();
        }

        private void btnshowpersons_Click(object sender, EventArgs e)
        {
            new FrmShowPeople().ShowDialog();
        }

        private void btnreminders_Click(object sender, EventArgs e)
        {
            TaskAlarms();
        }

        private void btnactivity_Click(object sender, EventArgs e)
        {
            new FrmShowTasks().ShowDialog();
        }

        private void btntasks_Click(object sender, EventArgs e)
        {
            new FrmShowTasks().ShowDialog();
        }
    }
}
