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

namespace SSG.Accounts_Book_Forms
{
    public partial class FrmAddAccountBook : Form
    {
        public FrmAddAccountBook()
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


        public int AccountId = 0;
        public int PersonId = 0;
        public int CostGroupType = 0;
        int OldPrice = 0;
        public int intSaleBuy = 0;

        int SumBook = 0;

        public string PersonName = "";
        public string AccountName = "";
        public string strDesc = "";
        string strtoday = "";

        bool CostStatus = false;

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

        private void FrmAddAccountBook_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
                if(btnsave.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
                }

               
                if(CostGroupType != 0)
                {
                    lblaccountname.Visible = true;
                    cmbaccount.Visible = true;

                    lblcostincome.Visible = false;
                    cmbcostgroup.Visible = false;

                    
                    grpaddaccountbook.Text = grpaddaccountbook.Text;

                    cmbaccount.DataSource = bllA.FillAccountsBYType0();
                    cmbaccount.DisplayMember = "Account Name";
                    cmbaccount.SelectedIndex = 0;

                    strtoday = DateTime.Now.ToShortDateString();
                    mskdate.Text = strtoday;
                    txtdesc.Text = strDesc;
                    if(CostGroupType == 2 || CostGroupType == 5)
                    {
                        intprice.Value = intSaleBuy;
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
                    cmbcostgroup.DataSource = bllCG.FillCostGroup();
                    cmbcostgroup.DisplayMember = "Name";
                    strtoday = DateTime.Now.ToShortDateString();
                    mskdate.Text = strtoday;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                AB.Date = mskdate.Text;
                AB.Time = DateTime.Now.ToShortTimeString();
                AB.Description = txtdesc.Text;
                AB.Price = intprice.Value;

                CG = bllCG.ReadN(cmbcostgroup.Text);
                CostStatus = bllCG.GetCostGroupStatus(CG.id);

                A = bllA.ReadN(AccountName);
                AB.AccountName = AccountName;
                AB.AccountId = A;


                P = bllP.ReadN(PersonName);
                AB.PersonName = PersonName;
                AB.PeopleId = P;

                
                ErrorProvider ep = new ErrorProvider();
                if(CostStatus == false)
                {
                    SumBook = bll.GetSumAccountBook(A.id);
                    if(intprice.Value > SumBook)
                    {
                        ep.Clear();
                        ep.SetError(intprice, "Account balance is not enough!!!");
                        intprice.Focus();
                    }
                    else
                    {
                        ep.Clear();
                        if (CostGroupType != 0)
                        {
                            if (btnsave.Text == "Save")
                            {
                                msg.MyMessagebox("Create Account Book", bll.Create(AB, A.id, CG.id, P.id), 0, 0);
                                if (CostGroupType == 2030)
                                {
                                    bllP.UpdateDebtor(PersonId, intprice.Value);
                                }
                                else if (CostGroupType == 2031)
                                {
                                    bllP.UpdateCreditor(PersonId, intprice.Value);
                                }
                                var frmaccountbook = Application.OpenForms["FrmShowAccountBook"] as FrmShowAccountBook;
                                if (frmaccountbook != null)
                                {
                                    frmaccountbook.FillAccountBook();
                                }

                                mskdate.Text = strtoday;
                                txtdesc.Text = string.Empty;
                                intprice.Value = 0;
                            }
                            else if (btnsave.Text == "Edit")
                            {
                                int idAB = ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).ABId;
                                msg.MyMessagebox("Update Account Book", bll.Update(idAB, AB), 0, 0);
                                int NewPrice = 0;
                                NewPrice = intprice.Value - OldPrice;
                                if (CostGroupType == 2030)
                                {
                                    bllP.UpdateDebtor(PersonId, NewPrice);
                                }
                                else if (CostGroupType == 2031)
                                {
                                    bllP.UpdateCreditor(PersonId, NewPrice);
                                }
                                btnsave.Text = "Save";
                                ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).FrmShowAccountBook_Load(null, null);
                            }
                        }
                    }
                }
                else if (CostStatus == true)
                {
                    if (CostGroupType != 0)
                    {
                        if (btnsave.Text == "Save")
                        {
                            msg.MyMessagebox("Create Account Book", bll.Create(AB, A.id, CG.id, P.id), 0, 0);
                            if (CostGroupType == 2030)
                            {
                                bllP.UpdateDebtor(PersonId, intprice.Value);
                            }
                            else if (CostGroupType == 2031)
                            {
                                bllP.UpdateCreditor(PersonId, intprice.Value);
                            }
                            var frmaccountbook = Application.OpenForms["FrmShowAccountBook"] as FrmShowAccountBook;
                            if (frmaccountbook != null)
                            {
                                frmaccountbook.FillAccountBook();
                            }

                            mskdate.Text = strtoday;
                            txtdesc.Text = string.Empty;
                            intprice.Value = 0;
                        }
                        else if (btnsave.Text == "Edit")
                        {
                            int idAB = ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).ABId;
                            msg.MyMessagebox("Update Account Book", bll.Update(idAB, AB), 0, 0);
                            int NewPrice = 0;
                            NewPrice = intprice.Value - OldPrice;
                            if (CostGroupType == 2030)
                            {
                                bllP.UpdateDebtor(PersonId, NewPrice);
                            }
                            else if (CostGroupType == 2031)
                            {
                                bllP.UpdateCreditor(PersonId, NewPrice);
                            }
                            btnsave.Text = "Save";
                            ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).FrmShowAccountBook_Load(null, null);
                        }
                    }
                    else
                    {

                        if (cmbcostgroup.Text == string.Empty)
                        {
                            ep.SetError(cmbcostgroup, "This field is required");
                            cmbcostgroup.Focus();
                        }
                        else
                        {
                            if (CostStatus == false)
                            {
                                SumBook = bll.GetSumAccountBook(AccountId);
                                if (intprice.Value > SumBook)
                                {
                                    ep.Clear();
                                    ep.SetError(intprice, "Account balance is not enough!!!");
                                    intprice.Focus();
                                }
                                else
                                {
                                    ep.Clear();

                                    if (btnsave.Text == "Save")
                                    {
                                        msg.MyMessagebox("Create Account Book", bll.Create(AB, A.id, CG.id, P.id), 0, 0);
                                        ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).FrmShowAccountBook_Load(null, null);
                                        mskdate.Text = strtoday;
                                        txtdesc.Text = string.Empty;
                                        intprice.Value = 0;
                                    }
                                    else if (btnsave.Text == "Edit")
                                    {
                                        int idAB = ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).ABId;
                                        msg.MyMessagebox("Update Account Book", bll.Update(idAB, AB), 0, 0);
                                        btnsave.Text = "Save";
                                        ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).FrmShowAccountBook_Load(null, null);
                                    }
                                }
                            }
                            else
                            {
                                if (btnsave.Text == "Save")
                                {
                                    msg.MyMessagebox("Create Account Book", bll.Create(AB, A.id, CG.id, P.id), 0, 0);
                                    ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).FrmShowAccountBook_Load(null, null);
                                    mskdate.Text = strtoday;
                                    txtdesc.Text = string.Empty;
                                    intprice.Value = 0;
                                }
                                else if (btnsave.Text == "Edit")
                                {
                                    int idAB = ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).ABId;
                                    msg.MyMessagebox("Update Account Book", bll.Update(idAB, AB), 0, 0);
                                    btnsave.Text = "Save";
                                    ((FrmShowAccountBook)Application.OpenForms["FrmShowAccountBook"]).FrmShowAccountBook_Load(null, null);
                                }
                            }

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
    }
}
