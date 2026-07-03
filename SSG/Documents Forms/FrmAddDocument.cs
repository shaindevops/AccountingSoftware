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
    public partial class FrmAddDocument : Form
    {
        public FrmAddDocument()
        {
            InitializeComponent();
        }
        Documents D = new Documents();
        BLLDocuments bll = new BLLDocuments();
        CostGroup CG = new CostGroup();
        BLLCostGroup bllcg = new BLLCostGroup();
        Accounts A = new Accounts();
        BLLAccounts blla = new BLLAccounts();
        People P = new People();
        BLLPeople bllp = new BLLPeople();

        msgclass msg = new msgclass();

        public int DocId = 0;
        public int CostId = 0;
        public int AccounId = 0;
        public int PersonId = 0;
        public int CostGroupType = 0;
        public int intSaleBuy = 0;

        int OldPrice = 0;

        public bool DocExist = false;

        public string AccountName = "";
        public string PersonName = "";
        public string strDesc = "";

        string strtoday = "";

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Accounts", 2))
            {
                btnsave.Enabled = true;
            }
            else
            {
                btnsave.Enabled = false;
            }
        }
        private void FrmAddDocument_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
                if(btnsave.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
                }
                strtoday = DateTime.Now.ToShortDateString();
                mskdocmaturitydate.Text = strtoday;
                mskdocregdate.Text = strtoday;

                grpadddoc.Text = grpadddoc.Text + " " + PersonName;
                lbltitle.Text = grpadddoc.Text;

                if (CostGroupType != 0)
                {
                    lblaccountname.Visible = true;
                    cmbaccount.Visible = true;

                    lblcostincome.Visible = false;
                    cmbcostgroup.Visible = false;
                    if (CostGroupType == 2030)
                    {
                        cmbaccount.DataSource = blla.FillAccountsBYType0();
                        cmbaccount.DisplayMember = "Account Name";
                    }
                    else if (CostGroupType == 2031)
                    {
                        cmbaccount.DataSource = blla.FillAccountsBYType1();
                        cmbaccount.DisplayMember = "Account Name";
                    }
                    else if (CostGroupType == 5)
                    {
                        cmbaccount.DataSource = blla.FillAccountsBYType1();
                        cmbaccount.DisplayMember = "Account Name";
                    }
                    else if (CostGroupType == 2)
                    {
                        cmbaccount.DataSource = blla.FillAccountsBYType0();
                        cmbaccount.DisplayMember = "Account Name";
                    }

                    
                    
                    if(CostGroupType == 2 || CostGroupType == 5)
                    {
                        intprice.Value = intSaleBuy;
                        txtdesc.Text = strDesc;
                    }
                    else
                    {
                        OldPrice = intprice.Value;
                    }
                    
                }
                else
                {
                    lblcostincome.Visible = true;
                    cmbcostgroup.Visible = true;

                    lblaccountname.Visible = false;
                    cmbaccount.Visible = false;

                    cmbcostgroup.DataSource = null;
                    cmbcostgroup.DataSource = bllcg.FillCostGroup();
                    cmbcostgroup.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost \n" +ex.Message , 2, 2);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CostGroupType != 0)
                {
                    A = blla.ReadN(cmbaccount.Text);
                    D.Accounts = A;

                    D.Date1 = mskdocregdate.Text;
                    D.Date2 = mskdocmaturitydate.Text;
                    D.Description = txtdesc.Text;
                    D.Price = intprice.Value;
                    CG = bllcg.ReadId(CostGroupType);
                    D.CostGroup = CG;
                    P = bllp.ReadN(PersonName);
                    D.People = P;
                    if (btnsave.Text == "Save")
                    {

                        msg.MyMessagebox("Create Document", bll.Create(D, A.id, CG.id), 0, 0);
                        var frmshowaccountbook = Application.OpenForms["FrmShowAccountBook"] as FrmShowAccountBook;
                        if(frmshowaccountbook != null)
                        {
                            frmshowaccountbook.FrmShowAccountBook_Load(null, null);
                        }
                        mskdocregdate.Text = strtoday;
                        mskdocregdate.Text = strtoday;
                        txtdesc.Text = string.Empty;
                        intprice.Value = 0;
                    }
                    else if (btnsave.Text == "Edit")
                    {
                        int idAB = ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).ABId;
                        msg.MyMessagebox("Update Document", bll.Update(DocId, D), 0, 0);
                        //int NewPrice = 0;
                        //NewPrice = intprice.Value - OldPrice;
                        //if (CostGroupType == 28)
                        //{
                        //    bllp.UpdateDebtor(PersonId, NewPrice);
                        //}
                        //else if (CostGroupType == 29)
                        //{
                        //    bllp.UpdateCreditor(PersonId, NewPrice);
                        //}
                        btnsave.Text = "Save";
                        var frmshowwaccountbook = Application.OpenForms["FrmShowAccountBook"] as FrmShowAccountBook;
                        if(frmshowwaccountbook != null)
                        {
                            frmshowwaccountbook.FrmShowAccountBook_Load(null, null);
                        }
                    }
                }
                else
                {
                    ErrorProvider ep = new ErrorProvider();
                    if (txtdocnumber.Text == string.Empty)
                    {
                        ep.SetError(txtdocnumber, "This filed is required");
                        txtdocnumber.Focus();
                    }
                    else
                    {
                        ep.Clear();

                        D.Date1 = mskdocregdate.Text;
                        D.Date2 = mskdocmaturitydate.Text;
                        D.Number = txtdocnumber.Text;
                        D.Price = intprice.Value;
                        D.Description = txtdesc.Text;
                        if (btnsave.Text == "Save")
                        {
                            CG = bllcg.ReadN(cmbcostgroup.Text);
                            D.CostGroup = CG;
                            A = blla.ReadN(AccountName);
                            D.Accounts = A;
                            P = bllp.ReadN(PersonName);
                            D.People = P;
                            msg.MyMessagebox("Create Document", bll.Create(D, A.id, CG.id), 0, 0);
                            ((FrmShowDocuments)Application.OpenForms["FrmShowDocuments"]).FrmShowDocuments_Load(null, null);

                            mskdocregdate.Text = strtoday;
                            mskdocmaturitydate.Text = strtoday;
                            txtdocnumber.Text = string.Empty;
                            intprice.Value = 0;
                            txtdesc.Text = string.Empty;
                        }
                        else if (btnsave.Text == "Edit")
                        {
                            msg.MyMessagebox("Edit Document", bll.Update(DocId, D), 0, 0);
                            ((FrmShowDocuments)Application.OpenForms["FrmShowDocuments"]).FrmShowDocuments_Load(null, null);
                            btnsave.Text = "Save";
                        }
                    }
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }
    }
}
