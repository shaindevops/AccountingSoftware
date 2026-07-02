using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Stimulsoft.Base.Drawing.Win32;

namespace SSG.Products_Forms
{
    public partial class FrmShowWhenPayFactor : Form
    {
        public FrmShowWhenPayFactor()
        {
            InitializeComponent();
        }
        BLLPosDevice bll = new BLLPosDevice();

        msgclass msg = new msgclass();
        private void FrmShowWhenPayFactor_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    cmbselectpos.Items.Clear();
                    cmbselectpos.DataSource = bll.FillEFTPOS();
                    cmbselectpos.DisplayMember = "DeviceName";
                    cmbselectpos.SelectedIndex = 0;
                    cmbselectpos.Focus();
                }
                catch
                {
                    msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
                }
                try
                {
                    cmbselectprinter.Items.Clear();
                    cmbselectprinter.DataSource = bll.FillPrinter();
                    cmbselectprinter.DisplayMember = "DeviceName";
                    cmbselectprinter.SelectedIndex = 0;
                    cmbselectprinter.Focus();
                }
                catch
                {
                    msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }

        }
        private bool IsDeviceConnected(string deviceName)
        {
            try
            {
                // جستجوی دستگاه در سیستم (برای مثال در حال جستجو برای پرینتر یا کارتخوان)
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity WHERE Name = '" + deviceName + "'");
                foreach (ManagementObject device in searcher.Get())
                {
                    // اگر دستگاه پیدا شد، آن به سیستم متصل است
                    return true;
                }
            }
            catch (Exception)
            {
                // اگر خطا در جستجو اتفاق افتاد، دستگاه متصل نیست
                return false;
            }
            return false;
        }

        private void cmbselectpos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedCardReader = cmbselectpos.SelectedItem.ToString();

                if (IsDeviceConnected(selectedCardReader))
                {
                    // اگر دستگاه متصل است، رنگ سیمبل را سبز کنید
                    connetposok.ForeColor = Color.Green;
                }
                else
                {
                    // اگر دستگاه متصل نیست، رنگ سیمبل را قرمز کنید
                    connetposok.ForeColor = Color.Red;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
            
        }

        private void cmbselectprinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedCardReader = cmbselectprinter.SelectedItem.ToString();

                if (IsDeviceConnected(selectedCardReader))
                {
                    // اگر دستگاه متصل است، رنگ سیمبل را سبز کنید
                    connectprinterok.ForeColor = Color.Green;
                }
                else
                {
                    // اگر دستگاه متصل نیست، رنگ سیمبل را قرمز کنید
                    connectprinterok.ForeColor = Color.Red;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void ExecuteTransaction()
        {
            // بررسی اینکه آیا دستگاه کارتخوان و پرینتر از پیش‌فرض‌ها تغییر کرده‌اند
            string selectedCardReader = cmbselectpos.SelectedItem?.ToString() ?? bll.GetDefaultPos();
            string selectedPrinter = cmbselectprinter.SelectedItem?.ToString() ?? bll.GetDefaultPrinter();

            // اگر دستگاه انتخاب شده به درستی متصل است، عملیات را انجام دهید
            if (IsDeviceConnected(selectedCardReader) && IsDeviceConnected(selectedPrinter))
            {
                // عملیات کشیدن کارت (کارتخوان) و چاپ فاکتور (پرینتر) انجام می‌شود
                ProcessCardReaderTransaction(selectedCardReader);
                PrintInvoice(selectedPrinter);
            }
            else
            {
                MessageBox.Show("دستگاه‌های انتخاب شده به درستی متصل نیستند.");
            }
        }

        private void ProcessCardReaderTransaction(string cardReader)
        {
            // کد مربوط به کشیدن کارت با دستگاه کارتخوان
            MessageBox.Show("پرداخت با دستگاه کارتخوان: " + cardReader);
        }

        private void PrintInvoice(string printer)
        {
            // کد مربوط به چاپ فاکتور با پرینتر
            MessageBox.Show("چاپ فاکتور با پرینتر: " + printer);
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            ExecuteTransaction();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
