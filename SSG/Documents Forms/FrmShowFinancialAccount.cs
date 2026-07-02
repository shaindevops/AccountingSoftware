using BE;
using BLL;
using SSG.Accounts_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.Documents_Forms
{
    public partial class FrmShowFinancialAccount : Form
    {
        public FrmShowFinancialAccount()
        {
            InitializeComponent();
        }
        Accounts A = new Accounts();
        BLLAccounts bll = new BLLAccounts();

        msgclass msg = new msgclass();

        private void FrmShowFinancialAccount_Load(object sender, EventArgs e)
        {
            try
            {
                rdosoftwareaccount.Checked = true;
                rdopersonaccount.Checked = false;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void rdosoftwareaccount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdosoftwareaccount.Checked)
                {
                    dgvselectaccounts.DataSource = null;
                    dgvselectaccounts.DataSource = bll.FillAccountsBYType0();
                    dgvselectaccounts.Columns["id"].Visible = false;
                    dgvselectaccounts.Columns["People_id"].Visible = false;
                }

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void rdopersonaccount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdopersonaccount.Checked)
                {
                    dgvselectaccounts.DataSource = null;
                    dgvselectaccounts.DataSource = bll.FillAccountsBYType1();
                    dgvselectaccounts.Columns["id"].Visible = false;
                    dgvselectaccounts.Columns["People_id"].Visible = false;
                }

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void dgvselectaccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FrmShowDocuments doc = new FrmShowDocuments();
                doc.AccountId = (int)dgvselectaccounts.CurrentRow.Cells[0].Value;
                doc.AccountName = dgvselectaccounts.CurrentRow.Cells["Account Name"].Value.ToString();

                doc.PersonId = (int)dgvselectaccounts.CurrentRow.Cells["People_id"].Value;
                doc.PersonName = dgvselectaccounts.CurrentRow.Cells["Account Person"].Value.ToString();
                doc.ShowDialog();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
