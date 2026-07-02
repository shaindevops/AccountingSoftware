using BE;
using BLL;
using SSG.Accounts_Book_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.Accounts_Forms
{
    public partial class FrmShowAccounts : Form
    {
        public FrmShowAccounts()
        {
            InitializeComponent();
        }
        Accounts A = new Accounts();
        BLLAccounts bll = new BLLAccounts();

        msgclass msg = new msgclass();

        public bool AccountType = false;

        public int id;

        public void FrmShowAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                
                if(AccountType)
                {
                    dgvaccounts.DataSource = null;
                    dgvaccounts.DataSource = bll.FillAccountsBYType1();
                    dgvaccounts.Columns["id"].Visible = false;
                    dgvaccounts.Columns["People_id"].Visible = false;
                    dgvaccounts.Columns["User_id"].Visible = false;
                }
                else
                {
                    dgvaccounts.DataSource = null;
                    dgvaccounts.DataSource = bll.FillAccountsBYType0();
                    dgvaccounts.Columns["id"].Visible = false;
                    dgvaccounts.Columns["People_id"].Visible = false;
                }
                if(dgvaccounts.Rows.Count == 0)
                {
                    btnedit.Enabled = false;
                    btndelete.Enabled = false;
                    btnviewaccountbook.Enabled = false;
                }
                else
                {
                    btnedit.Enabled = true;
                    btndelete.Enabled = true;
                    btnviewaccountbook.Enabled = true;
                }
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
                FrmAddAccount fa = new FrmAddAccount();
                fa.AccountType = AccountType;
                fa.ShowDialog();
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
                A = bll.ReadId(id);
                if (A != null)
                {
                    FrmAddAccount fa = new FrmAddAccount();
                    fa.lbltitle.Text = "Edit Account Selected";
                    fa.txtaccountname.Text = A.AccountName;
                    fa.txtaccountnumber.Text = A.AccountNumber;
                    fa.txtaccounperson.Text = A.AccountPerson;
                    fa.AccountType = A.AccountType;
                    fa.btnsave.Text = "Edit";
                    fa.ShowDialog();
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
                A = bll.ReadId(id);
                if (A != null)
                {
                    if(msg.MyMessagebox("Delete Account", "Are you sure to delete this financial account?", 1, 1) == DialogResult.Yes)
                    {
                        bll.Delete(id);
                    }
                }
                FrmShowAccounts_Load(null, null);
                
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

        private void btnviewaccountbook_Click(object sender, EventArgs e)
        {
            try
            {
                FrmShowAccountBook book = new FrmShowAccountBook();
                book.AId = (int)dgvaccounts.SelectedRows[0].Cells[0].Value;
                book.AccountName = dgvaccounts.Rows[dgvaccounts.CurrentRow.Index].Cells["Account Name"].Value.ToString();
                book.PersonName = dgvaccounts.Rows[dgvaccounts.CurrentRow.Index].Cells["Account Person"].Value.ToString();
                book.ShowDialog();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
            
        }

        private void dgvaccounts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvaccounts.SelectedRows.Count > 0)
                {
                    id = (int)dgvaccounts.SelectedRows[0].Cells["id"].Value;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
            
        }
    }
}
