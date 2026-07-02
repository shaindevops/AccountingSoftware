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
using System.Windows.Forms.Design;
using Stimulsoft.Report;
namespace SSG.Accounts_Book_Forms
{
    public partial class FrmShowAccountBook : Form
    {
        public FrmShowAccountBook()
        {
            InitializeComponent();
        }

        AccountBook AB = new AccountBook();
        BLLAccountBook bll = new BLLAccountBook();
        CostGroup CG = new CostGroup();
        BLLCostGroup bllCG = new BLLCostGroup();
        Accounts A = new Accounts();
        BLLAccounts bllA = new BLLAccounts();
        People P = new People();
        BLLPeople bllP = new BLLPeople();
        msgclass msg = new msgclass();

        public int ABId = 0;
        public int CGId = 0;
        public int AId = 0;
        public int Pid = 0;

        public int total = 0;

        string strToday = "";

        public string AccountName = "";
        public string PersonName = "";

        public void FillAccountBook()
        {
            try
            {
                grpaccountbooklist.Text = "Show Financial Account Book For " + "" + AccountName;

                strToday = DateTime.Now.ToString("MM/dd/yyyy");

                mskdate1.Text = strToday;
                mskdate2.Text = strToday;

                dgvaccountbooks.DataSource = null;
                dgvaccountbooks.DataSource = bll.FilterAccountBookByDate(AId, mskdate1.Text, mskdate2.Text);
                dgvaccountbooks.Columns["id"].Visible = false;
                dgvaccountbooks.Columns["AccountId_id"].Visible = false;
                dgvaccountbooks.Columns["CostGroupId_id"].Visible = false;
                dgvaccountbooks.Columns["PeopleId_id"].Visible = false;
                dgvaccountbooks.Columns["Account Name"].Visible = false;
                dgvaccountbooks.Columns["Cost Group Name"].Visible = false;
                dgvaccountbooks.Columns["Person Name"].Visible = false;
                dgvaccountbooks.Columns["PeopleId_id"].Visible = false;
                dgvaccountbooks.Columns["PeopleId_id"].Visible = false;



                txtaccountbalance.Text = bll.GetSumAccountBook(AId).ToString();

                if (dgvaccountbooks.Rows.Count == 0)
                {

                    btnedit.Enabled = false;
                    btndelete.Enabled = false;
                }
                else
                {
                    btnedit.Enabled = true;
                    btndelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Accounts", 3) && bllu.AccessTo(LoggedUser, "Accounts", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = true;
            }
            else if (bllu.AccessTo(LoggedUser, "Accounts", 3) && !bllu.AccessTo(LoggedUser, "Accounts", 4))
            {
                btnedit.Enabled = true;
                btndelete.Enabled = false;
            }
            else if (!bllu.AccessTo(LoggedUser, "Accounts", 3) && bllu.AccessTo(LoggedUser, "Accounts", 4))
            {
                btnedit.Enabled = false;
                btndelete.Enabled = true;
            }
            else
            {
                btnedit.Enabled = false;
                btndelete.Enabled = false;
            }
        }

        public void FrmShowAccountBook_Load(object sender, EventArgs e)
        {
            Permisions();
            if(btnedit.Enabled == false && btndelete.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Edit and Delete this section!!!", 2, 2);
            }
            else if (btnedit.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Edit this section!!!", 2, 2);
            }
            else if (btndelete.Enabled == false)
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to Delete this section!!!", 2, 2);
            }


            FillAccountBook();
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAddAccountBook book = new FrmAddAccountBook();
                book.CostGroupType = 0;
                book.AccountId = AId;
                book.AccountName = AccountName;
                book.PersonId = Pid;
                book.PersonName = PersonName;
                book.lbltitle.Text = book.lbltitle.Text+ " For" + " " + AccountName;
                book.grpaddaccountbook.Text = "Account Book" + " "+ book.grpaddaccountbook.Text + " For " + AccountName;

                book.ShowDialog();

                txtaccountbalance.Text = bll.GetSumAccountBook(AId).ToString();

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
                AB = bll.ReadId(ABId);
                if(AB != null)
                {
                    FrmAddAccountBook book = new FrmAddAccountBook();
                    book.lbltitle.Text = "Edit Account Book";
                    book.grpaddaccountbook.Text = "Account Book" + " " + book.grpaddaccountbook.Text + " For " + AccountName;


                    if ((int)dgvaccountbooks.CurrentRow.Cells["CostGroupId_id"].Value == 2030)
                    {
                        book.CostGroupType = 2030;
                    }
                    else if ((int)dgvaccountbooks.CurrentRow.Cells["CostGroupId_id"].Value == 2031)
                    {
                        book.CostGroupType = 2031;
                    }
                    else if ((int)dgvaccountbooks.CurrentRow.Cells["CostGroupId_id"].Value == 2)
                    {
                        book.CostGroupType = 2;
                        
                    }
                    else if ((int)dgvaccountbooks.CurrentRow.Cells["CostGroupId_id"].Value == 5)
                    {
                        book.CostGroupType = 5;
                    }
                    else
                    {
                        book.CostGroupType = 0;
                    }
                    A = bllA.ReadId(AId);

                    CG = bllCG.ReadId(CGId);
                   
                    book.cmbcostgroup.Text = AB.CostGroupName;
                    book.PersonId = Pid;

                    book.mskdate.Text = AB.Date;
                    book.strDesc = AB.Description; 
                    book.intSaleBuy = AB.Price;
                    book.btnsave.Text = "Edit";
                    book.ShowDialog();
                }
                txtaccountbalance.Text = bll.GetSumAccountBook(AId).ToString();

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
                if(msg.MyMessagebox("Delete Account Book", "Are you sure to delete the information of this account book?", 1,1) == DialogResult.Yes)
                {
                    bll.Delete(ABId);
                }
                FrmShowAccountBook_Load(null, null);
                

            }
            catch (Exception m)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + m.Message, 2, 2);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvaccountbooks_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvaccountbooks.SelectedRows.Count > 0)
                {
                    ABId = (int)dgvaccountbooks.SelectedRows[0].Cells["id"].Value;
                    Pid = (int)dgvaccountbooks.SelectedRows[11].Cells["PeopleId_id"].Value;
                    PersonName = dgvaccountbooks.SelectedRows[3].Cells["Person Name"].Value.ToString();
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            try
            {
                StiReport report = new StiReport();
                report.Load("Reports/rptShowAccountBook.mrt");

                report.Compile();

                report["strDate1"] = mskdate1.Text;
                report["strDate2"] = mskdate2.Text;
                report["intAccountId"] = AId;
                report["strAccountName"] = AccountName;
                report["intSumAccountBook"] = bll.GetSumAccountBook(AId);

                report.ShowWithRibbonGUI();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }

        }

        private void dtpfromdate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvaccountbooks.DataSource = null;
                dgvaccountbooks.DataSource = bll.FilterAccountBookByDate(AId, mskdate1.Text, mskdate2.Text);
                dgvaccountbooks.Columns["id"].Visible = false;
                dgvaccountbooks.Columns["AccountId_id"].Visible = false;
                dgvaccountbooks.Columns["CostGroupId_id"].Visible = false;
                dgvaccountbooks.Columns["PeopleId_id"].Visible = false;
                dgvaccountbooks.Columns["User_id"].Visible = false;

                txtaccountbalance.Text = bll.GetSumAccountBook(AId).ToString();

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void dtptodate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvaccountbooks.DataSource = null;
                dgvaccountbooks.DataSource = bll.FilterAccountBookByDate(AId, mskdate1.Text, mskdate2.Text);
                dgvaccountbooks.Columns["id"].Visible = false;
                dgvaccountbooks.Columns["AccountId_id"].Visible = false;
                dgvaccountbooks.Columns["CostGroupId_id"].Visible = false;
                dgvaccountbooks.Columns["PeopleId_id"].Visible = false;

                txtaccountbalance.Text = bll.GetSumAccountBook(AId).ToString();

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
