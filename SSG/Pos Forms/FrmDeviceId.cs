using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO.Ports;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using BE;
using BLL;

namespace SSG.Pos_Forms
{
    public partial class FrmDeviceId : Form
    {
        // دیکشنری برای ذخیره اطلاعات دستگاه‌ها
        private Dictionary<string, DeviceInfo> devices = new Dictionary<string, DeviceInfo>();
        public FrmDeviceId()
        {
            InitializeComponent();
        }

        PosDevice PD = new PosDevice();
        BLLPosDevice bll = new BLLPosDevice();

        msgclass msg = new msgclass();

        Users LoggedUser = new Users();

        public void AddDeviceToComboBoxInFrmDeviceId(string deviceName, string portName, string baudRate, string status, Color statusColor)
        {
            AddDeviceToComboBox(deviceName, portName, baudRate, status, statusColor);
        }

        // متدی برای اضافه کردن دستگاه به کمبوباکس و دیکشنری
        private void AddDeviceToComboBox(string deviceName, string portName, string baudRate, string status, Color statusColor)
        {
            // اضافه کردن دستگاه به کمبوباکس و ذخیره اطلاعات آن در دیکشنری
            if (!cmbdevicename.Items.Contains(deviceName))
            {
                cmbdevicename.Items.Add(deviceName);
            }
            devices[deviceName] = new DeviceInfo
            {
                PortName = portName,
                BaudRate = baudRate,
                Status = status,
                StatusColor = statusColor
            };
        }
        // کلاس کمکی برای ذخیره اطلاعات دستگاه‌ها
        private class DeviceInfo
        {
            public string PortName { get; set; }
            public string BaudRate { get; set; }
            public string Status { get; set; }
            public Color StatusColor { get; set; }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbdevicename.Text == string.Empty)
                {
                    ep.SetError(cmbdevicename, "Select Device");
                    cmbdevicename.Focus();
                }
                else
                {
                    ep.Clear();
                    PD.DeviceName = cmbdevicename.Text;
                    if(rdoprinter.Checked)
                    {
                        PD.DeviceType = rdoprinter.Text;
                    }
                    else
                    {
                        PD.DeviceType = rdopos.Text;
                    }
                    PD.PortName = txtportname.Text;
                    PD.BaudRate = Convert.ToInt32(txtbaudrate.Text);

                    if (chkisdefault.Checked)
                    {
                        PD.IsDefault = true;
                    }
                    PD.Status = lblstatus.Text;


                    msg.MyMessagebox("Save Message", bll.Create(PD), 0, 0);

                    var frmshowdevice = Application.OpenForms[""] as FrmShowPosDevice;
                    if (frmshowdevice != null)
                    {
                        frmshowdevice.FrmShowPosDevice_Load(null, null);
                    }
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void cmbdevicename_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbdevicename.SelectedItem != null)
            {
                string selectedDevice = cmbdevicename.SelectedItem.ToString();

                if (devices.ContainsKey(selectedDevice))
                {
                    // اطلاعات دستگاه انتخاب‌شده را از دیکشنری می‌گیریم و نمایش می‌دهیم
                    txtportname.Text = devices[selectedDevice].PortName;
                    txtbaudrate.Text = devices[selectedDevice].BaudRate;
                    lblstatus.Text = devices[selectedDevice].Status;
                    lblstatus.ForeColor = devices[selectedDevice].StatusColor;
                }
                else
                {
                    // اگر دستگاهی با این نام پیدا نشد، فیلدها را خالی کنیم
                    txtportname.Text = string.Empty;
                    txtbaudrate.Text = string.Empty;
                    lblstatus.Text = "Disconnected";
                    lblstatus.ForeColor = Color.Red;
                }
            }
        }
    }
}
