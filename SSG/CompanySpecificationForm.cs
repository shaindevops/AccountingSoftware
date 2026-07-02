using BE;
using BLL;
using System.IO;
using System.Security.Cryptography;
using System;
using System.Windows.Forms;
using DevComponents.DotNetBar.Charts;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Data.SqlClient;
using System.Data;

namespace SSG
{
    public partial class CompanySpecificationForm : Form
    {
        public CompanySpecificationForm()
        {
            InitializeComponent();
        }
        Tbl_CompanyBLL bll = new Tbl_CompanyBLL();
        Tbl_Company com = new Tbl_Company();
        msgclass msg = new msgclass();
        OpenFileDialog ofd = new OpenFileDialog();
        Image pic;

        private void DisableControls()
        {
            txtcomcode.Enabled = false;
            txtcompanyname.Enabled = false;
            txtcompanyphone.Enabled = false;
            txteconomiccode.Enabled = false;
            txtemail.Enabled = false;
            txtaddress.Enabled = false;
            txtcity.Enabled = false;
            txtowner.Enabled = false;
            txtprovince.Enabled = false;
            txtregnumber.Enabled = false;
            txtzipcode.Enabled = false;
            cmbcurrency.Enabled = false;
            piclogo.Enabled = false;
            btnsave.Enabled = false;
            btnchoose.Enabled = false;
            foreach (Control control in this.Controls)
            {
                if(control is Label)
                {
                    control.Enabled = false;
                }
            }

        }
        public void LoadData()
        {
            DataTable companyTable = bll.ReadList();
            if (companyTable.Rows.Count > 0)
            {
                // اگر اطلاعات وجود دارد، مقادیر را در تکست‌باکس‌ها قرار می‌دهیم
                DataRow companyInfo = companyTable.Rows[0];
                txtcompanyname.Text = companyInfo["Name"].ToString();
                txtowner.Text = companyInfo["Owner"].ToString();
                cmbcurrency.Text = companyInfo["Currency"].ToString();
                txteconomiccode.Text = companyInfo["Econimi Code"].ToString();
                txtregnumber.Text = companyInfo["Refistartion Number"].ToString();
                txtcompanyphone.Text = companyInfo["Phone"].ToString();
                txtzipcode.Text = companyInfo["Zip Code"].ToString();
                txtprovince.Text = companyInfo["Province"].ToString();
                txtcity.Text = companyInfo["City"].ToString();
                piclogo.Image = Image.FromFile(companyInfo["Logo"].ToString());
                txtaddress.Text = companyInfo["Address"].ToString();
                txtemail.Text = companyInfo["Email"].ToString();

                // غیرفعال کردن تمامی کنترل‌ها
                DisableControls();
            }
            else
            {
                MessageBox.Show("There is no company registered.");
            }
        }
        private void CompanySpecificationForm_Load(object sender, System.EventArgs e)
        {
            txtcompanyname.Focus();
            txtcomcode.Text = bll.GenerateCode(com);
            if (btnclose.Enabled == false)
            {
                btnclose.Enabled = true;
            }
            LoadData();
            
            
        }
            string SavePic(string ComName)
        {

            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\Company-Logo\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string PicName = ComName + ".png";
            try
            {
                string picPath = ofd.FileName;
                File.Copy(picPath, path + PicName, true);
            }
            catch (Exception e)
            {

                MessageBox.Show("The system is unable to save the company logo!!!", e.Message);
            }
            return path + PicName;
        }

        private void btnchoose_Click(object sender, EventArgs e)
        {
            ofd.Filter = "jpg Files |*.jpg|PNG FIles |*.png";
            ofd.Title = "Select the company logo";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                piclogo.Image = new Bitmap(ofd.FileName);
            }
        }
        private void btnsave_Click_1(object sender, EventArgs e)
        {
            try
            {
                com.code = txtcomcode.Text;
                com.Comname = txtcompanyname.Text;
                com.Comowner = txtowner.Text;
                com.Comcurrency = cmbcurrency.Text;
                com.Comeconimiccode = txteconomiccode.Text;
                com.Comregnumber = txtregnumber.Text;
                com.Comphone = txtcompanyphone.Text;
                com.Comemail = txtemail.Text;
                com.Comzipcode = txtzipcode.Text;
                com.Comprovince = txtprovince.Text;
                com.Comcity = txtcity.Text;
                com.Comaddress = txtaddress.Text;
                Bitmap bmp = (Bitmap)piclogo.Image;
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, bmp.RawFormat);
                com.Comlogo = (SavePic(txtcompanyname.Text));
                com.Comsysregdate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                com.Comsysregtime = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));
                msg.MyMessagebox("", bll.Create(com), 0, 0);
                var frmmain = Application.OpenForms["frmASWS"] as frmASWS;
                if(frmmain != null)
                {
                    frmmain.RefreshWin();
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
           
        }
        private void btnclose_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
