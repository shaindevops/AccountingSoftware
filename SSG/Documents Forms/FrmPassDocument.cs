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

namespace SSG.Documents_Forms
{
    public partial class FrmPassDocument : Form
    {
        public FrmPassDocument()
        {
            InitializeComponent();
        }
        Documents D = new Documents();
        BLLDocuments blld = new BLLDocuments();
        Accounts A = new Accounts();
        BLLAccounts bll = new BLLAccounts();

        AccountBook book = new AccountBook();
        BLLAccountBook bllab = new BLLAccountBook();

        People P = new People();
        BLLPeople bllp = new BLLPeople();

        CostGroup CG = new CostGroup();
        BLLCostGroup bllcg = new BLLCostGroup();

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        msgclass msg = new msgclass();

        public int CostId = 0;
        public int PeronId = 0;
        public int DocId = 0;

        string strToday = "";
        public string Bookdesc = "";
        public string Docnumber = "";

        public string CostGroupName = "";
        public string PersonName = "";

        

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Accounts", 2))
            {
                btnpassed.Enabled = true;
            }
            else
            {
                btnpassed.Enabled = false;
            }
        }

        private void FrmPassDocument_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
                if(btnpassed.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
                }


                grppass.Text = grppass.Text + " " + Docnumber;

                lbltitle.Text = lbltitle.Text + " For This " + Docnumber + " Document Number";

                strToday = DateTime.Now.ToShortDateString();
                mskpassdate.Text = strToday;

                txttransactiondesc.Text = Bookdesc;

                cmbselectaccount.DataSource = null;
                cmbselectaccount.DataSource = bll.FillAccountsBYType0();
                cmbselectaccount.DisplayMember = "Account Name";
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btndeposited_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;
                if (bllu.AccessTo(LoggedUser, "Accounts", 2))
                {
                    book.Date = mskpassdate.Text;
                    book.Time = DateTime.Now.ToShortTimeString();
                    book.Description = txttransactiondesc.Text;
                    book.Price = intprice.Value;
                    A = bll.ReadN(cmbselectaccount.Text);
                    book.AccountName = cmbselectaccount.Text;
                    book.AccountId = A;

                    CG = bllcg.ReadN(CostGroupName);
                    book.CostGroupId = CG;

                    P = bllp.ReadN(PersonName);
                    book.PeopleId = P;

                    bllab.Create(book, A.id, CG.id, P.id);
                    if (msg.MyMessagebox("Confirm Passed", "Will the document be passed by depositing this amount?", 1, 1) == DialogResult.Yes)
                    {
                        blld.UpdateDocPass(DocId);
                        msg.MyMessagebox("Confirmation", "The deposit and passed operations have been successfully completed", 0, 0);

                    }
                    else
                    {
                        msg.MyMessagebox("Confirmation", "Part of the amount of the document was deposited into the account", 0, 0);
                    }
                    intprice.Value = 0;
                }
                else
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Deposit this section!!!", 2, 2);
                }

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnpassed_Click(object sender, EventArgs e)
        {
            try
            {
                msg.MyMessagebox("Deposited Account Book", blld.UpdateDocPass(DocId), 0, 0);
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
    }
}
