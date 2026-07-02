using BE;
using BLL;
using SSG.People_Forms;
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
    public partial class FrmAddAccount : Form
    {
        public FrmAddAccount()
        {
            InitializeComponent();
        }

        Accounts A = new Accounts();
        BLLAccounts bll = new BLLAccounts();
        People P = new People();
        BLLPeople bllp = new BLLPeople();
        msgclass msg = new msgclass();

        public bool AccountType = false;

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
        public void FrmAddAccount_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();
                if(btnsave.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
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
                ErrorProvider ep = new ErrorProvider();
                if (txtaccountname.Text == string.Empty)
                {
                    ep.SetError(txtaccountname, "This field is required");
                    txtaccountname.Focus();
                }
                else if(txtaccounperson.Text == string.Empty)
                {
                    ep.Clear();
                    ep.SetError(txtaccounperson, "This field is required");
                    txtaccounperson.Focus();
                }
                else
                {
                    A.AccountName = txtaccountname.Text;
                    A.AccountNumber = txtaccountnumber.Text;
                    A.AccountPerson = txtaccounperson.Text;
                    A.AccountType = AccountType;
                    string date = DateTime.Now.ToString("yyyy/MM/dd");
                    string time = DateTime.Now.ToString("HH : mm : ss");
                    string DT = date + " " + time;

                    A.Regdate = DT;

                    P = bllp.ReadN(txtaccounperson.Text);
                    A.People = P;
                    A.AccountPerson = P.Name;
                    if (btnsave.Text == "Save")
                    {
                        msg.MyMessagebox("Create New Acconut", bll.Create(A, P.id), 0, 0);
                        
                        
                    }
                    else if(btnsave.Text == "Edit")
                    {
                        int id = ((FrmShowAccounts)Application.OpenForms["FrmShowAccounts"]).id;
                        msg.MyMessagebox("Edit Acconut", bll.Update(id, A), 0, 0);
                        
                        btnsave.Text = "Save";
                        
                    }
                    var frmshowaccount = Application.OpenForms["FrmShowAccounts"] as FrmShowAccounts;
                    if (frmshowaccount != null)
                    {
                        frmshowaccount.FrmShowAccounts_Load(null, null);
                    }
                    txtaccountname.Text = string.Empty;
                    txtaccountnumber.Text = string.Empty;
                    txtaccounperson.Text = string.Empty;
                    txtaccountname.Focus();
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

        private void txtaccounperson_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteStringCollection person = new AutoCompleteStringCollection();
                foreach (var item in bllp.SelectPersonName())
                {
                    person.Add(item);
                }
                txtaccounperson.AutoCompleteCustomSource = person;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }

        }

        private void btnaddperson_Click(object sender, EventArgs e)
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Persons", 1))
            {
                new FrmAddPeople().ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
        }
    }
}
