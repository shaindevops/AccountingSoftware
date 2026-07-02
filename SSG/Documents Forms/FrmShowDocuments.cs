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
    public partial class FrmShowDocuments : Form
    {
        public FrmShowDocuments()
        {
            InitializeComponent();
        }
        Documents D = new Documents();
        BLLDocuments bll = new BLLDocuments();

        public CostGroup CG = new CostGroup();
        BLLCostGroup bllcg = new BLLCostGroup();

        Accounts A = new Accounts();
        BLLAccounts blla = new BLLAccounts();

        People P = new People();
        BLLPeople bllp = new BLLPeople();

        AccountBook AB = new AccountBook();
        BLLAccountBook bllab = new BLLAccountBook();

        msgclass msg = new msgclass();

        public int DocId = 0;
        public int CostId = 0;
        public int AccountId = 0;
        public int PersonId = 0;

        int SumBook = 0;

        public string AccountName = "";
        public string PersonName = "";

        bool CostStatus = false;

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

        public void FrmShowDocuments_Load(object sender, EventArgs e)
        {
            try
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

                rdodocreceived.Checked = true;
                rdodocpayment.Checked = false;
                grpdocumentlist.Text = grpdocumentlist.Text + " " + AccountName;
                dgvDocuments.Columns["id"].HeaderText = "Rows No.";
                dgvDocuments.Columns["id"].Width = 80;
                dgvDocuments.Columns["Accounts_id"].Visible = false;
                dgvDocuments.Columns["CostGroup_id"].Visible = false;
                dgvDocuments.Columns["People_id"].Visible = false;
                dgvDocuments.Columns["User_id"].Visible = false;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void rdodocreceived_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(rdodocreceived.Checked)
                {
                    dgvDocuments.DataSource = null;
                    dgvDocuments.DataSource = bll.FilterDocumentIncomeByNumber(txtsearchdocnumber.Text);
                    dgvDocuments.Columns["id"].Visible = false;
                    dgvDocuments.Columns["Accounts_id"].Visible = false;
                    dgvDocuments.Columns["CostGroup_id"].Visible = false;
                    dgvDocuments.Columns["People_id"].Visible = false;
                    dgvDocuments.Columns["User_id"].Visible = false;

                    if (dgvDocuments.Rows.Count == 0)
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

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void rdodocpayment_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdodocpayment.Checked)
                {
                    dgvDocuments.DataSource = null;
                    dgvDocuments.DataSource = bll.FilterDocumentPayByNumber(txtsearchdocnumber.Text);
                    dgvDocuments.Columns["id"].Visible = false;
                    dgvDocuments.Columns["Accounts_id"].Visible = false;
                    dgvDocuments.Columns["CostGroup_id"].Visible = false;
                    dgvDocuments.Columns["People_id"].Visible = false;
                    dgvDocuments.Columns["User_id"].Visible = false;

                    if (dgvDocuments.Rows.Count == 0)
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

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void txtsearchdocnumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdodocpayment.Checked)
                {
                    dgvDocuments.DataSource = null;
                    dgvDocuments.DataSource = bll.FilterDocumentPayByNumber(txtsearchdocnumber.Text);
                    dgvDocuments.Columns["id"].HeaderText = "Rows No.";
                    dgvDocuments.Columns["id"].Width = 80;
                    dgvDocuments.Columns["Accounts_id"].Visible = false;
                    dgvDocuments.Columns["CostGroup_id"].Visible = false;
                    dgvDocuments.Columns["People_id"].Visible = false;
                    dgvDocuments.Columns["User_id"].Visible = false;
                }
                else if (rdodocreceived.Checked)
                {
                    dgvDocuments.DataSource = null;
                    dgvDocuments.DataSource = bll.FilterDocumentIncomeByNumber(txtsearchdocnumber.Text);
                    dgvDocuments.Columns["id"].HeaderText = "Rows No.";
                    dgvDocuments.Columns["id"].Width = 80;
                    dgvDocuments.Columns["Accounts_id"].Visible = false;
                    dgvDocuments.Columns["CostGroup_id"].Visible = false;
                    dgvDocuments.Columns["People_id"].Visible = false;
                    dgvDocuments.Columns["User_id"].Visible = false;
                }
                if (dgvDocuments.Rows.Count == 0)
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
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAddDocument doc = new FrmAddDocument();
                doc.CostGroupType = 0;
                doc.AccounId = AccountId;
                doc.AccountName = AccountName;
                doc.PersonId = PersonId;
                doc.PersonName = PersonName;
                doc.ShowDialog();

                if (rdodocpayment.Checked)
                {
                    dgvDocuments.DataSource = null;
                    dgvDocuments.DataSource = bll.FilterDocumentPayByNumber(txtsearchdocnumber.Text);
                }
                else if (rdodocreceived.Checked)
                {
                    dgvDocuments.DataSource = null;
                    dgvDocuments.DataSource = bll.FilterDocumentIncomeByNumber(txtsearchdocnumber.Text);
                }
                if (dgvDocuments.Rows.Count == 0)
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
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                D = bll.ReadId(DocId);
                if(D != null)
                {
                    FrmAddDocument doc = new FrmAddDocument();
                    if ((int)dgvDocuments.CurrentRow.Cells["CostGroupId_id"].Value == 2030)
                    {
                        doc.CostGroupType = 2030;
                    }
                    else if ((int)dgvDocuments.CurrentRow.Cells["CostGroupId_id"].Value == 2031)
                    {
                        doc.CostGroupType = 2031;
                    }
                    else if ((int)dgvDocuments.CurrentRow.Cells["CostGroupId_id"].Value == 2)
                    {
                        doc.CostGroupType = 2;
                    }
                    else if ((int)dgvDocuments.CurrentRow.Cells["CostGroupId_id"].Value == 5)
                    {
                        doc.CostGroupType = 5;
                    }
                    else
                    {
                        doc.CostGroupType = 0;
                    }
                    doc.AccounId = AccountId;
                    doc.DocId = DocId;
                    doc.lbltitle.Text = "Edit Document Selected";
                    doc.cmbcostgroup.Text = D.CostGroup.Name;
                    doc.CostId = CostId;
                    doc.PersonId = PersonId;
                    doc.PersonName = PersonName;
                    doc.mskdocregdate.Text = D.Date1;
                    doc.mskdocmaturitydate.Text = D.Date2;
                    doc.txtdocnumber.Text = D.Number;
                    doc.intSaleBuy = D.Price;
                    doc.strDesc = D.Description;
                    doc.btnsave.Text = "Edit";
                    doc.ShowDialog();
                }

                if (rdodocpayment.Checked)
                {
                    dgvDocuments.DataSource = null;
                    dgvDocuments.DataSource = bll.FilterDocumentPayByNumber(txtsearchdocnumber.Text);
                }
                else if (rdodocreceived.Checked)
                {
                    dgvDocuments.DataSource = null;
                    dgvDocuments.DataSource = bll.FilterDocumentIncomeByNumber(txtsearchdocnumber.Text);
                }
                if (dgvDocuments.Rows.Count == 0)
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
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void dgvDocuments_SelectionChanged(object sender, EventArgs e)
        {
            DocId = (int)dgvDocuments.Rows[dgvDocuments.CurrentRow.Index].Cells[0].Value;
            CostId = (int)dgvDocuments.Rows[dgvDocuments.CurrentRow.Index].Cells["CostGroup_id"].Value;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                D = bll.ReadId(DocId);
                if (D != null)
                {
                    if(msg.MyMessagebox("Delete Document", "Are you sure you want to delete this document?", 1, 1) == DialogResult.Yes)
                    {
                        bll.Delete(DocId);

                        if (rdodocpayment.Checked)
                        {
                            dgvDocuments.DataSource = null;
                            dgvDocuments.DataSource = bll.FilterDocumentPayByNumber(txtsearchdocnumber.Text);
                        }
                        else if (rdodocreceived.Checked)
                        {
                            dgvDocuments.DataSource = null;
                            dgvDocuments.DataSource = bll.FilterDocumentIncomeByNumber(txtsearchdocnumber.Text);
                        }
                        if (dgvDocuments.Rows.Count == 0)
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
                }
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

        private void btnpassed_Click(object sender, EventArgs e)
        {
            try
            {
                CostStatus = bllcg.GetCostGroupStatus((int)dgvDocuments.CurrentRow.Cells[9].Value);
                if(CostStatus == true)
                {
                    D = bll.ReadId(DocId);
                    if (D != null)
                    {
                        FrmPassDocument pass = new FrmPassDocument();
                        pass.DocId = (int)dgvDocuments.CurrentRow.Cells[0].Value;
                        pass.CostId = (int)dgvDocuments.CurrentRow.Cells["CostGroup_id"].Value;
                        pass.CostGroupName = dgvDocuments.CurrentRow.Cells["Cost Group Name"].Value.ToString();
                        pass.PeronId = (int)dgvDocuments.CurrentRow.Cells["People_id"].Value;
                        pass.PersonName = PersonName;
                        pass.Bookdesc = dgvDocuments.CurrentRow.Cells["Description"].Value.ToString();
                        pass.grppass.Text = pass.grppass.Text + " " + dgvDocuments.CurrentRow.Cells["Document Number"].Value.ToString();
                        pass.lbltitle.Text = pass.lbltitle.Text + " For This " + dgvDocuments.CurrentRow.Cells["Document Number"].Value.ToString() + " Document Number";
                        pass.ShowDialog();
                    }
                }
                else
                {
                    SumBook = bllab.GetSumAccountBook((int)dgvDocuments.CurrentRow.Cells[8].Value);
                    if ((int)dgvDocuments.CurrentRow.Cells[5].Value > SumBook)
                    {
                        msg.MyMessagebox("Warning", "The account balance is not enough to settle this document!!!", 3, 3);
                    }
                    else
                    {
                        bll.UpdateDocPass((int)dgvDocuments.CurrentRow.Cells[0].Value);
                        

                        AB.Date = dgvDocuments.CurrentRow.Cells[1].Value.ToString();
                        AB.Time = DateTime.Now.ToShortTimeString();
                        AB.Description = dgvDocuments.CurrentRow.Cells[4].Value.ToString();
                        AB.Price = (int)dgvDocuments.CurrentRow.Cells[5].Value;

                        CG = bllcg.ReadN(dgvDocuments.CurrentRow.Cells[7].Value.ToString());
                        AB.CostGroupId = CG;
                        AB.CostGroupName = CG.Name;

                        CostStatus = bllcg.GetCostGroupStatus(CG.id);

                        A = blla.ReadN(AccountName);
                        AB.AccountName = A.AccountName;
                        AB.AccountId = A;

                        P = bllp.ReadN(PersonName);
                        AB.PersonName = PersonName;
                        AB.PeopleId = P;
                        bllab.Create(AB, A.id, CG.id, P.id);

                        msg.MyMessagebox("Message", "The document was successfully settled", 0, 0);

                        var frmshowbook = Application.OpenForms["FrmShowAccountBook"] as FrmShowAccountBook;
                        if(frmshowbook != null)
                        {
                            frmshowbook.FillAccountBook();
                        }
                        FrmShowDocuments_Load(null, null);
                    }
                }

                
                if (rdodocpayment.Checked)
                {
                    dgvDocuments.DataSource = null;
                    dgvDocuments.DataSource = bll.FilterDocumentPayByNumber(txtsearchdocnumber.Text);
                }
                else if (rdodocreceived.Checked)
                {
                    dgvDocuments.DataSource = null;
                    dgvDocuments.DataSource = bll.FilterDocumentIncomeByNumber(txtsearchdocnumber.Text);
                }
                if (dgvDocuments.Rows.Count == 0)
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
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
