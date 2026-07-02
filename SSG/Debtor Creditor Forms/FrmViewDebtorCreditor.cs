using BE;
using BLL;
using SSG.Accounts_Book_Forms;
using SSG.Documents_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.Debtor_Creditor_Forms
{
    public partial class FrmViewDebtorCreditor : Form
    {
        public FrmViewDebtorCreditor()
        {
            InitializeComponent();
        }
        
        CostGroup CG = new CostGroup();
        BLLCostGroup bllcg = new BLLCostGroup();

        msgclass msg = new msgclass();

        public int PersonId = 0;
        public int PersonDebt = 0;
        public int PersonCredit = 0;

        public string PersonName = "";

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        private void FrmViewDebtorCreditor_Load(object sender, EventArgs e)
        {
            try
            {
                grpdetail.Text = grpdetail.Text + " " + PersonName;
                lbltitle.Text = grpdetail.Text;
                txtdebtoramount.Text = PersonDebt.ToString("n0");
                txtcreditoramount.Text = PersonCredit.ToString("n0");
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void btncach_Click(object sender, EventArgs e)
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Accounts", 1))
            {
                FrmAddAccountBook book = new FrmAddAccountBook();
                book.PersonId = PersonId;
                book.PersonName = PersonName;
                if (PersonDebt != 0)
                {
                    book.CostGroupType = 2030;
                }
                else
                {
                    book.CostGroupType = 2031;
                }
                book.ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnasdoc_Click(object sender, EventArgs e)
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Accounts", 1))
            {
                FrmAddDocument Doc = new FrmAddDocument();
                Doc.PersonId = PersonId;
                Doc.PersonName = PersonName;
                if (PersonDebt != 0)
                {
                    Doc.CostGroupType = 2030;
                }
                else
                {
                    Doc.CostGroupType = 2031;
                }
                Doc.ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
            
        }
    }
}
