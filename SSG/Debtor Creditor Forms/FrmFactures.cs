using BE;
using BLL;
using SSG.Debtor_Creditor_Forms;
using SSG.Factors_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSG.People_Forms
{
    public partial class FrmFactures : Form
    {
        public FrmFactures()
        {
            InitializeComponent();
        }
        People P = new People();
        BLLPeople bll = new BLLPeople();
        BLLAccountBook bllb = new BLLAccountBook();
        BLLDocuments blld = new BLLDocuments();
        BLLFactors bllf = new BLLFactors();
        msgclass msg = new msgclass();

        int debtorAmount = 0;
        int creditorAmount = 0;

        int SumSaleBook = 0;
        int SumBuyBook = 0;

        int SumSaleFactor = 0;
        int SumBuyFactor = 0;

        int SumSaleDoc = 0;
        int SumBuyDoc = 0;

        int PersonId = 0;

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();


        private void SetButtonsEnabled(bool enabled)
        {
            btnviewremindbefore.Enabled = enabled;
            btnfactors.Enabled = enabled;
            btnmoney.Enabled = enabled;
        }

        private void CalculateSums(int personId)
        {
            bllb.GetSumBookByPerson(personId, out SumBuyBook, out SumSaleBook);
            bllf.GetSumFactorsByPerson(personId, out SumBuyFactor, out SumSaleFactor);
            blld.GetSumDocumentByPerson(personId, out SumBuyDoc, out SumSaleDoc);

            int SumSaleStatus = SumSaleFactor - SumBuyBook;
            int SumBuyStatus = SumSaleStatus - SumBuyBook;

            txtdebtoramount.Text = SumSaleStatus.ToString("N0");
            txtcreditoramount.Text = SumBuyStatus.ToString("N0");

            // Validate debtor and creditor amounts
            debtorAmount = ParseOrDefault(txtdebtoramount.Text);
            creditorAmount = ParseOrDefault(txtcreditoramount.Text);

            txtdebtoramount.Text = debtorAmount.ToString("N0");
            txtcreditoramount.Text = creditorAmount.ToString("N0");

            // Calculate reminder using valid values
            int sum = debtorAmount - creditorAmount;
            txtremindbefor.Text = sum.ToString("N0");
        }

        private int ParseOrDefault(string text)
        {
            return int.TryParse(text.Replace(",", ""), out int value) ? value : 0;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                dgvpersons.DataSource = null;
                dgvpersons.DataSource = bll.FillPerson1(txtsearch.Text);
                dgvpersons.Columns["id"].Visible = false;

                if (dgvpersons.Rows.Count == 0)
                {
                    btnviewremindbefore.Enabled = false;
                    btnfactors.Enabled = false;
                    btnmoney.Enabled = false;
                }
                else
                {
                    btnviewremindbefore.Enabled = true;
                    btnfactors.Enabled = true;
                    btnmoney.Enabled = true;

                    PersonId = (int)dgvpersons.CurrentRow.Cells[0].Value;


                    bllb.GetSumBookByPerson(PersonId, out SumBuyBook, out SumSaleBook);
                    bllf.GetSumFactorsByPerson(PersonId, out SumBuyFactor, out SumSaleFactor);
                    blld.GetSumDocumentByPerson(PersonId, out SumBuyDoc, out SumSaleDoc);

                    int SumSaleStatus = 0;
                    int SumBuyStatus = 0;

                    SumSaleStatus = SumSaleFactor - SumBuyBook;
                    SumBuyStatus = SumBuyFactor - SumBuyBook;

                    txtdebtoramount.Text = SumSaleStatus.ToString("N0");
                    txtcreditoramount.Text = SumBuyStatus.ToString("N0");

                    if (P != null)
                    {
                        // اعتبارسنجی مقادیر
                        debtorAmount = bll.GetDebtor((int)dgvpersons.CurrentRow.Cells[0].Value);
                        creditorAmount = bll.GetCreditor((int)dgvpersons.CurrentRow.Cells[0].Value);
                        txtdebtoramount.Text = debtorAmount.ToString("N0");
                        txtcreditoramount.Text = creditorAmount.ToString("N0");
                        // بررسی اینکه آیا مقدار بدهکاری معتبر است یا خیر
                        if (int.TryParse(txtdebtoramount.Text.Replace(",", ""), out debtorAmount))
                        {
                            txtdebtoramount.Text = debtorAmount.ToString("N0");
                        }
                        else
                        {
                            debtorAmount = 0;
                        }

                        // بررسی اینکه آیا مقدار بستانکاری معتبر است یا خیر
                        if (int.TryParse(txtcreditoramount.Text.Replace(",", ""), out creditorAmount))
                        {
                            txtcreditoramount.Text = creditorAmount.ToString("N0");
                        }
                        else
                        {
                            creditorAmount = 0;
                        }

                        // محاسبه با استفاده از مقادیر معتبر
                        int sum = debtorAmount - creditorAmount;
                        txtremindbefor.Text = sum.ToString("N0");
                    }
                }
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void btnviewremindbefore_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtsearch.Text))
                {
                    dgvpersons.DataSource = null;
                    return;
                }
                else
                {
                    if(dgvpersons.DataSource == null)
                    {
                        dgvpersons.DataSource = null;
                        dgvpersons.DataSource = bll.FillPerson1(txtsearch.Text);
                        dgvpersons.Columns["id"].Visible = false;
                        dgvpersons.Columns["User_id"].Visible = false;
                    }
                   

                    if (dgvpersons.Rows.Count == 0)
                    {
                        btnviewremindbefore.Enabled = false;
                    }
                    else
                    {
                        FrmViewDebtorCreditor DC = new FrmViewDebtorCreditor();
                        DC.PersonId = (int)dgvpersons.CurrentRow.Cells[0].Value;
                        DC.PersonName = dgvpersons.CurrentRow.Cells["Name"].Value.ToString();
                        DC.PersonDebt = debtorAmount;
                        DC.PersonCredit = creditorAmount;
                        DC.ShowDialog();

                        btnviewremindbefore.Enabled = true;
                        PersonId = (int)dgvpersons.CurrentRow.Cells[0].Value;
                        if (PersonId != null)
                        {
                            // اعتبارسنجی مقادیر
                            debtorAmount = bll.GetDebtor(PersonId);
                            creditorAmount = bll.GetCreditor(PersonId);
                            txtdebtoramount.Text = debtorAmount.ToString("N0");
                            txtcreditoramount.Text = creditorAmount.ToString("N0");
                            // بررسی اینکه آیا مقدار بدهکاری معتبر است یا خیر
                            if (int.TryParse(txtdebtoramount.Text.Replace(",", ""), out debtorAmount))
                            {
                                txtdebtoramount.Text = debtorAmount.ToString("N0");
                            }
                            else
                            {
                                debtorAmount = 0;
                            }

                            // بررسی اینکه آیا مقدار بستانکاری معتبر است یا خیر
                            if (int.TryParse(txtcreditoramount.Text.Replace(",", ""), out creditorAmount))
                            {
                                txtcreditoramount.Text = creditorAmount.ToString("N0");
                            }
                            else
                            {
                                creditorAmount = 0;
                            }

                            // محاسبه با استفاده از مقادیر معتبر
                            int sum = debtorAmount - creditorAmount;
                            txtremindbefor.Text = sum.ToString("N0");
                        }
                    }
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

        private void btnfactors_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

                if (bllu.AccessTo(LoggedUser, "Factors", 1))
                {
                    FrmShowFactorFactures ff = new FrmShowFactorFactures();
                    ff.PersonId = (int)dgvpersons.CurrentRow.Cells[0].Value;
                    ff.PersonName = dgvpersons.CurrentRow.Cells[3].Value.ToString();
                    ff.SumBuyFactor = (int)SumBuyFactor;
                    ff.SumSaleFactor = (int)SumSaleFactor;
                    ff.grpperson.Text = ff.grpperson.Text + "Of " + dgvpersons.CurrentRow.Cells[3].Value.ToString();
                    ff.ShowDialog();
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

        private void btnmoney_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

                if (bllu.AccessTo(LoggedUser, "Factors", 1))
                {
                    FrmShowMoneyFactures mf = new FrmShowMoneyFactures();
                    mf.PersonId = (int)dgvpersons.CurrentRow.Cells[0].Value;
                    mf.PersonName = dgvpersons.CurrentRow.Cells[2].Value.ToString();
                    mf.SumBuyBook = (int)SumBuyBook;
                    mf.SumSaleBook = (int)SumSaleBook;
                    mf.SumBuyDoc = (int)SumBuyDoc;
                    mf.SumSaleDoc = (int)SumSaleDoc;
                    mf.grpcash.Text = mf.grpcash.Text + " " + dgvpersons.CurrentRow.Cells[2].Value.ToString();
                    mf.grpdoc.Text = mf.grpdoc.Text + " " + dgvpersons.CurrentRow.Cells[2].Value.ToString();

                    mf.ShowDialog();
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

        private void dgvpersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtsearch.Text))
                {
                    dgvpersons.DataSource = null;
                    return;
                }

                // اگر منبع داده قبلاً تنظیم شده باشد، آن را دوباره تنظیم نکنید
                if (dgvpersons.DataSource == null)
                {
                    dgvpersons.DataSource = bll.FillPerson1(txtsearch.Text);
                    dgvpersons.Columns["id"].Visible = false;
                    dgvpersons.Columns["User_id"].Visible = false;
                }

                if (dgvpersons.Rows.Count == 0)
                {
                    SetButtonsEnabled(false);
                    return;
                }

                SetButtonsEnabled(true);

                // انتخاب آیدی از سطر انتخاب شده فعلی
                PersonId = (int)dgvpersons.CurrentRow.Cells[0].Value;

                // محاسبات مالی و به‌روزرسانی مقادیر
                CalculateSums(PersonId);
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost\n" + ex.Message, 2, 2);
            }
        }
    }
}
