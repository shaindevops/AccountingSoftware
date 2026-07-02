using BE;
using BLL;
using DevComponents.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG
{
    public partial class Frmsetting : Form
    {
        public Frmsetting()
        {
            InitializeComponent();
        }
        BLLsetting bll = new BLLsetting();
        Setting s = new Setting();
        Tbl_CompanyBLL bllcom = new Tbl_CompanyBLL();
        public Tbl_Company C = new Tbl_Company();
        int id;

        Users Loggeduser = new Users();
        BLLUser bllu = new BLLUser();
       
        private void DisableControls()
        {
            txtcomname.Enabled = false;
            txtfactoraddress.Enabled = false;
            txtdepotaddress.Enabled = false;
            txtfactornum.Enabled = false;
            txtdepotnumber.Enabled = false;
            txtsmspaneluser.Enabled = false;
            txtsmspanelpassword.Enabled = false;
            txtsmssender.Enabled = false;
            intalarm1.Enabled = false;
            intalarm2.Enabled = false;
            chkbanksend.Enabled = false;
            chkfactorsend.Enabled = false;
            btnsave.Enabled = false;
            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    control.Enabled = false;
                }
            }
            
        }
        public void LoadData()
        {
            DataTable SettingTable = bll.Read();
            if (SettingTable.Rows.Count != 0)
            {
                // دریافت اطلاعات تنظیمات از دیتابیس
                DataTable settingsTable = bll.Read();
                if (settingsTable.Rows.Count > 0)
                {
                    // اگر اطلاعات وجود دارد، مقادیر را در تکست‌باکس‌ها قرار می‌دهیم
                    DataRow settingsInfo = settingsTable.Rows[0];
                    txtcomname.Text = settingsInfo["Company Name"].ToString();
                    txtfactoraddress.Text = settingsInfo["Factor Address"].ToString();
                    txtfactornum.Text = settingsInfo["Factor Tel"].ToString();
                    txtdepotaddress.Text = settingsInfo["Depot Address"].ToString();
                    txtdepotnumber.Text = settingsInfo["Depot Tel"].ToString();
                    txtsmspaneluser.Text = settingsInfo["User Sms Panel"].ToString();
                    txtsmspanelpassword.Text = settingsInfo["Sms Panel Password"].ToString();
                    txtsmssender.Text = settingsInfo["Panel Phone Number"].ToString();
                    intalarm1.Value = Convert.ToInt32(settingsInfo["First Alarm"].ToString());
                    intalarm2.Value = Convert.ToInt32(settingsInfo["Second Alarm"].ToString());
                    chkbanksend.Checked = Convert.ToBoolean(settingsInfo["Bank Send"].ToString());
                    chkfactorsend.Checked = Convert.ToBoolean(settingsInfo["Factor Send"].ToString());

                    // غیرفعال کردن تمامی کنترل‌ها برای جلوگیری از ویرایش
                    DisableControls();
                }
                else
                {
                    MessageBox.Show("No settings recorded.");
                }
            }

        }
        private void Frmsetting_Load(object sender, EventArgs e)
        {
            txtcomname.Focus();
            txtcomname.Text = bllcom.ReadComName(C);
            
            LoadData();
            if (btnclose.Enabled == false)
            {
                btnclose.Enabled = true;
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            s.comname = txtcomname.Text;
            s.factoraddress = txtfactoraddress.Text;
            s.depotaddress = txtdepotaddress.Text;
            s.factortel = txtfactornum.Text;
            s.depottel = txtdepotnumber.Text;
            s.SMSpaneluser = txtsmspaneluser.Text;
            s.SMSpanelpassword = txtsmspanelpassword.Text;
            s.Smssendernumber = txtsmssender.Text;
            s.alarm1 = intalarm1.Value;
            s.alarm2 = intalarm2.Value;
            s.Banksend = chkbanksend.Checked;
            s.Factorsend = chkfactorsend.Checked;
            s.regdate = DateTime.Now;
            bool settingsExist = bll.Exictsetting();
            if (!settingsExist)
            {
                C = bllcom.ReadN(txtcomname.Text);
                s.comname = C.Comname;
                s.company = C;

                MessageBox.Show(bll.Create(s), "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (bll.Exictsetting())
                {
                    this.Close();
                }
            }
            else if (settingsExist)
            {

                MessageBox.Show(bll.Update(s.id, s), "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (bll.Exictsetting())
                {
                    this.Close();
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
