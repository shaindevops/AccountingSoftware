using BE;
using BLL;
using SSG.Accounts_Book_Forms;
using SSG.Documents_Forms;
using Stimulsoft.Report;
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
    public partial class FrmShowMoneyFactures : Form
    {
        public FrmShowMoneyFactures()
        {
            InitializeComponent();
        }
        BLLAccountBook bllb = new BLLAccountBook();
        BLLDocuments blld = new BLLDocuments();

        msgclass msg = new msgclass();

        public int PersonId = 0;

        public string PersonName = "";

        public int SumSaleBook = 0;
        public int SumBuyBook = 0;
        public int SumSaleDoc = 0;
        public int SumBuyDoc = 0;
        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        private void FrmShowMoneyFactures_Load(object sender, EventArgs e)
        {
            try
            {
                dgvbook.DataSource = null;
                dgvbook.DataSource = bllb.FillBookByPerson(PersonId);

                dgvbook.Columns["id"].Visible = false;
                dgvbook.Columns["PeopleId_id"].Visible = false;
                dgvbook.Columns["AccountName"].Visible = false;
                dgvbook.Columns["User_id"].Visible = false;

                dgvdocument.DataSource = null;
                dgvdocument.DataSource = blld.FillDocumentsByPerson(PersonId);
                dgvdocument.Columns["id"].Visible = false;
                dgvdocument.Columns["People_id"].Visible = false;
                dgvdocument.Columns["User_id"].Visible = false;
                txtbookbuy.Text = SumBuyBook.ToString("N0");
                txtbooksale.Text = SumSaleBook.ToString("N0");

                txtdocbuy.Text = SumBuyDoc.ToString("N0");
                txtdocsale.Text = SumSaleDoc.ToString("N0");
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void btnbook1_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

                if (bllu.AccessTo(LoggedUser, "Accounts", 1))
                {
                    FrmAddAccountBook book = new FrmAddAccountBook();
                    book.CostGroupType = 2;
                    book.PersonId = PersonId;
                    book.PersonName = PersonName;
                    book.ShowDialog();
                }
                else
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);

                }

            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
            
        }

        private void btnbook2_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

                if (bllu.AccessTo(LoggedUser, "Accounts", 1))
                {
                    FrmAddAccountBook book = new FrmAddAccountBook();
                    book.CostGroupType = 5;
                    book.PersonId = PersonId;
                    book.PersonName = PersonName;
                    book.ShowDialog();
                }
                else
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);

                }
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void btndoc1_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

                if (bllu.AccessTo(LoggedUser, "Accounts", 1))
                {
                    FrmAddDocument doc = new FrmAddDocument();
                    doc.CostGroupType = 2;
                    doc.PersonId = PersonId;
                    doc.PersonName = PersonName;
                    doc.ShowDialog();
                }
                else
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);

                }
                
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
            
        }

        private void btndoc2_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

                if (bllu.AccessTo(LoggedUser, "Accounts", 1))
                {
                    FrmAddDocument doc = new FrmAddDocument();
                    doc.CostGroupType = 5;
                    doc.PersonId = PersonId;
                    doc.PersonName = PersonName;
                    doc.ShowDialog();
                }
                else
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);

                }
                
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

                if (bllu.AccessTo(LoggedUser, "Accounts", 2))
                {
                    StiReport report = new StiReport();

                    report.Compile();

                    report.Load("Reports/rptFactureMoney.mrt");

                    report["PersonId"] = PersonId;
                    report["strPersonName"] = PersonName;

                    report.ShowWithRibbonGUI();
                }
                else
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);

                }
                
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }
    }
}
