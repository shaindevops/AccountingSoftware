using BE;
using BLL;
using DevComponents.DotNetBar;

using SSG.Accounts_Book_Forms;
using SSG.Documents_Forms;
using SSG.People_Forms;
using SSG.Products_Forms;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Globalization;
using Font = iTextSharp.text.Font;
using Rectangle = iTextSharp.text.Rectangle;
using System.Windows;
using DevComponents.WinForms.Drawing;

namespace SSG.Factors_Forms
{
    public partial class FrmAddFactor : Form
    {
        public FrmAddFactor()
        {
            InitializeComponent();
        }

        Products P = new Products();
        BLLProducts bllpro = new BLLProducts();

        People Person = new People();
        BLLPeople bllPer = new BLLPeople();

        Factors F = new Factors();
        BLLFactors bllf = new BLLFactors();

        Details D = new Details();
        BLLDetails bllD = new BLLDetails();

        Depots De = new Depots();
        BLLDepot bllde = new BLLDepot();

        Stocks S = new Stocks();
        BLLStocks blls = new BLLStocks();

        Tax T = new Tax();
        BLLTaxs bllt = new BLLTaxs();

        SendEmail send = new SendEmail();
        BLLSendEmail bllsend = new BLLSendEmail();

        BLLsetting bllset = new BLLsetting();

        BLLMessages bllmsg = new BLLMessages();

        Tbl_Company com = new Tbl_Company();
        Tbl_CompanyBLL bllcom = new Tbl_CompanyBLL();

        msgclass msg = new msgclass();



        public bool FrmType = false;
        bool IsFactorSent = false;
        bool ExistMessage = false;

        double SaleTax = 0;
        double BuyTax = 0;

        string RandomMessage = "";


        string strToday = "";
        string MyShopName = "";
        string FactorAddress = "";
        string FactorTel = "";
        string DepotAddress = "";
        string DepotTel = "";


        string Userpanel = "";
        string Passpanel = "";


        int LastFactorId = 0;
        int TaxPrice = 0;
        int FactorPrice = 0;
        int SumPrice = 0;
        int DefaulDepot = 0;


        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Factors", 3))
            {
                btnSaveFactor.Enabled = true;
            }
            else
            {
                btnSaveFactor.Enabled = false;
            }
        }
        private void FrmAddFactor_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();

                if (btnSaveFactor.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Save this section!!!", 2, 2);
                }

                btnnext.Enabled = true;
                btnprev.Enabled = false;

                btnPrintFactor.Enabled = false;
                btnPrintRemittance.Enabled = false;
                btnbook.Enabled = false;
                btndoc.Enabled = false;

                superTabControl1.SelectedTab = superTabItem1;
                strToday = DateTime.Now.ToString("MM/dd/yyyy");
                mskdate.Text = strToday;

                string strYear = strToday.Substring(8, 2);



                bllt.GetDefaultTax(out SaleTax, out BuyTax);

                IsFactorSent = bllset.GetSettingFactorSend();

                bllset.GetFactorDetails(out FactorAddress, out FactorTel, out DepotAddress, out DepotTel, out MyShopName);

                if (FrmType)
                {
                    intBuyPrice.Visible = true;
                    intSalePrice.Visible = false;
                    txtFactNumber.ReadOnly = false;
                    dblTax.Value = BuyTax;
                    lbltitle.Text = "Add New Buy Factor";
                    DefaulDepot = bllde.GetDefaultDepotId();
                }
                else
                {
                    dblTax.Value = SaleTax;
                    intBuyPrice.Visible = false;
                    intSalePrice.Visible = true;
                    txtFactNumber.ReadOnly = true;
                    lbltitle.Text = "Add New Sale Factor";
                    //Factor-Number Pattern 00-0000 
                    if (!bllf.ExistSaleNumber(F))
                    {
                        string LastSaleNumber = bllf.GetMaxSaleNumber();
                        string strLast = LastSaleNumber.Substring(3, 4);
                        if (strYear == LastSaleNumber.Substring(0, 2))
                        {
                            txtFactNumber.Text = strYear + "-" + (Convert.ToInt32(strLast) + 1).ToString("0000");
                        }
                        else
                        {
                            txtFactNumber.Text = strYear + "-" + "0001";
                        }
                    }
                    else
                    {
                        txtFactNumber.Text = strYear + "-" + "0001";
                    }
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        public void txtPersonFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmbPerson.DataSource = null;
                cmbPerson.DataSource = bllPer.FillPerson1(txtPersonFilter.Text);
                cmbPerson.DisplayMember = "Name";
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void cmbPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPerson.SelectedItem is DataRowView selectedPerson)
                {
                    // بررسی فیلد فیلتر
                    if (txtPersonFilter.Text.Length != 0)
                    {
                        txtMobile.Text = selectedPerson["Mobile"]?.ToString() ?? "";
                        txtpersonemail.Text = selectedPerson["Email"]?.ToString() ?? "";
                    }
                    else
                    {
                        txtMobile.Text = string.Empty;
                        txtpersonemail.Text = string.Empty;
                    }
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        public void txtProductFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtProductFilter.Text.Length != 0)
                {
                    cmbProduct.DataSource = null;
                    cmbProduct.DataSource = blls.FilterStock(txtProductFilter.Text);
                    cmbProduct.DisplayMember = "Name";
                    if (FrmType == false)
                    {
                        intValue2.MaxValue = Convert.ToInt32(lblStock.Text);
                    }
                }
                else
                {
                    cmbProduct.DataSource = null;
                }

            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProduct.SelectedItem is DataRowView selectedPerson)
                {
                    // بررسی فیلد فیلتر
                    if (txtProductFilter.Text.Length != 0)
                    {
                        lblStock.Text = ((DataRowView)cmbProduct.SelectedItem)["Total"].ToString();
                        intSalePrice.Value = (int)((DataRowView)cmbProduct.SelectedItem)["DefaultPrice"];
                        txtsize.Text = ((DataRowView)cmbProduct.SelectedItem)["Size"].ToString();
                        txtUnit1.Text = ((DataRowView)cmbProduct.SelectedItem)["Unit1"].ToString();
                        txtUnit2.Text = ((DataRowView)cmbProduct.SelectedItem)["Unit2"].ToString();
                    }
                    else
                    {
                        lblStock.Text = string.Empty;
                        intSalePrice.Value = 0;
                        txtsize.Text = string.Empty;
                        txtUnit1.Text = string.Empty;
                        txtUnit2.Text = string.Empty;
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

        private void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                if (superTabControl1.SelectedTab == superTabItem1)
                {
                    if (cmbPerson.Text == string.Empty)
                    {
                        ep.SetError(txtPersonFilter, "Select Person Here \n If there is no person in the list,\n click on the opposite button\n and add the person you want to the program.");
                        txtPersonFilter.Focus();
                    }
                    else
                    {
                        ep.Clear();
                        superTabControl1.SelectedTab = superTabItem2;
                        btnprev.Enabled = true;
                    }
                }
                else if (superTabControl1.SelectedTab == superTabItem2)
                {
                    if (dgvFactor.Rows.Count == 0)
                    {
                        ep.SetError(cmbProduct, "Select Product Here");
                        cmbProduct.Focus();
                    }
                    else
                    {
                        for (int i = 0; i < dgvFactor.Rows.Count; i++)
                        {
                            FactorPrice = FactorPrice + (Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[4].Value)) * Convert.ToInt32(dgvFactor.Rows[i].Cells[1].Value);
                        }

                        chkTax.Checked = true;


                        intTotalProduct.Value = FactorPrice;

                        SumPrice = (FactorPrice + TaxPrice + intServicePrice.Value) - intDiscountPrice.Value;

                        intSumPrice.Value = SumPrice;

                        ep.Clear();
                        superTabControl1.SelectedTab = superTabItem3;
                        btnnext.Enabled = false;
                    }
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnprev_Click(object sender, EventArgs e)
        {
            try
            {
                if (superTabControl1.SelectedTab == superTabItem3)
                {
                    FactorPrice = 0;
                    superTabControl1.SelectedTab = superTabItem2;
                    btnnext.Enabled = true;

                }
                else if (superTabControl1.SelectedTab == superTabItem2)
                {
                    superTabControl1.SelectedTab = superTabItem1;
                    btnprev.Enabled = false;
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void intValue2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtValue1.Text = (Convert.ToInt32(txtsize.Text) * intValue2.Value).ToString();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            try
            {
                int ProductId = (int)((DataRowView)cmbProduct.SelectedItem)["id"];

                if (FrmType)
                {
                    dgvFactor.Rows.Add(cmbProduct.Text, intBuyPrice.Text, intValue2.Text, txtUnit2.Text, txtsize.Text, ProductId);
                }
                else
                {
                    dgvFactor.Rows.Add(cmbProduct.Text, intSalePrice.Text, intValue2.Text, txtUnit2.Text, txtsize.Text, ProductId);
                }
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvFactor.Rows.RemoveAt(dgvFactor.CurrentRow.Index);
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void chkTax_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTax.Checked)
                {
                    TaxPrice = Convert.ToInt32(FactorPrice * dblTax.Value);
                }
                else
                {
                    TaxPrice = 0;
                }
                SumPrice = (FactorPrice + TaxPrice + intServicePrice.Value) - intDiscountPrice.Value;

                intTax.Value = TaxPrice;
                intSumPrice.Value = SumPrice;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void intServicePrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SumPrice = (FactorPrice + TaxPrice + intServicePrice.Value) - intDiscountPrice.Value;

                intSumPrice.Value = SumPrice;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }

        }

        private void intDiscountPrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SumPrice = (FactorPrice + TaxPrice + intServicePrice.Value) - intDiscountPrice.Value;

                intSumPrice.Value = SumPrice;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }



        private void btnSaveFactor_Click(object sender, EventArgs e)
        {
            try
            {
                // تنظیمات اولیه فاکتور
                F.FactorDate = mskdate.Text;
                F.FactorNumber = txtFactNumber.Text;

                Person = bllPer.ReadN(cmbPerson.Text);
                F.Person = Person;
                F.PersonId = Person.id;

                F.FactorPrice = FactorPrice;
                F.FactorDefaultTax = dblTax.Value;
                F.FactorTaxPrice = TaxPrice;
                F.FactorServicePrice = intServicePrice.Value;
                F.FactorDiscountPrice = intDiscountPrice.Value;
                F.FactorType = FrmType;
                F.FactorSumPrice = SumPrice;


                bllf.Create(F, Person.id);

                LastFactorId = bllf.GetFactorId();

                // ایجاد جزئیات فاکتور
                for (int i = 0; i < dgvFactor.Rows.Count; i++)
                {
                    D.DetailValue1 = Convert.ToDouble(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToDouble(dgvFactor.Rows[i].Cells[4].Value);
                    D.DetailValue2 = Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value);
                    D.DefaultPrice = Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[4].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[1].Value);
                    D.DetailPrice = Convert.ToInt32(dgvFactor.Rows[i].Cells[1].Value);
                    D.DetailExit = false;
                    D.DepotId = 0;
                    D.FactorId = LastFactorId;
                    P = bllpro.ProductName(dgvFactor.Rows[i].Cells[0].Value.ToString());
                    D.Product = P;
                    D.ProductId = P.id;

                    bllD.Create(D, LastFactorId, 0, P.id);
                }


                msg.MyMessagebox("Factor Creation Message", "The invoice for the customer named :  "+cmbPerson.Text+" was created successfully.", 0, 0);

                // ثبت در انبار برای نوع خرید
                if (FrmType)
                {
                    RegisterStockIn();
                }
                else
                {
                    // اگر فاکتور ارسال شده باشد، ایجاد فایل PDF و ارسال ایمیل
                    if (IsFactorSent == true)
                    {
                        if(msg.MyMessagebox("Send Factor", "Would you like to send the factor to the customer?", 1, 1) == DialogResult.Yes)
                        {
                            invoiceFilePath = CreateInvoicePDF();
                            SendEmailWithInvoice(invoiceFilePath);
                        }
                        else
                        {
                            Close();
                        }
                       
                    }
                }

                // بروزرسانی فرم فاکتورها و فعال‌سازی دکمه‌ها
                UpdateFormAndButtons();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        // ثبت ورود کالا به انبار
        private void RegisterStockIn()
        {
            for (int i = 0; i < dgvFactor.Rows.Count; i++)
            {
                S.RegDate = mskdate.Text;
                S.Description = "Purchase by number " + txtFactNumber.Text;
                S.StockIn = Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value);
                S.StockOut = 0;
                S.FactorId = LastFactorId;
                S.DepotId = DefaulDepot;
                P = bllpro.ProductName(dgvFactor.Rows[i].Cells[0].Value.ToString());
                S.Product = P;
                S.ProductId = P.id;

                msg.MyMessagebox("Purchase Factor Message", blls.Create(S, LastFactorId, DefaulDepot, P.id), 0, 0);
            }
        }


        #region عملیات ساخت فایل پی دی اف و جزییات آن


        string invoiceFilePath = "";
        // ایجاد فایل PDF فاکتور
        private string CreateInvoicePDF()
        {
            try
            {
                // افزودن فونت Tahoma به فایل PDF
                BaseFont bfTahoma = BaseFont.CreateFont(@"C:\Windows\Fonts\tahoma.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font tahomaBold = new Font(bfTahoma, 12, Convert.ToInt32(Font.Bold));
                Font tahomaminBold = new Font(bfTahoma, 9, Convert.ToInt32(Font.Bold));
                Font tahomaNormal = new Font(bfTahoma, 8);

                invoiceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Factor.pdf");
                string directoryPath = Path.GetDirectoryName(invoiceFilePath);

                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                using (FileStream fs = new FileStream(invoiceFilePath, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4, 20, 20, 20, 20);
                    document.SetMargins(80f, 80f, 50f, 50f);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);

                    document.Open();

                    // واترمارک
                    AddWatermark(writer, bllcom.ReadComName(com), bfTahoma);

                    // هدر فاکتور
                    PdfPTable headerTable = new PdfPTable(3)
                    {
                        WidthPercentage = 100
                    };
                    headerTable.SetWidths(new float[] { 3, 6, 1 });

                    headerTable.AddCell(new PdfPCell(new Phrase($"Factor Date: {DateTime.Now:yyyy/MM/dd}\nFactor Number: {txtFactNumber.Text}", tahomaminBold))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });

                    headerTable.AddCell(new PdfPCell(new Phrase("Sale Factor", tahomaBold))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Border = Rectangle.NO_BORDER
                    });

                    string piclogo = bllcom.ReadComLogo(com);
                    if (File.Exists(piclogo))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(piclogo);
                        logo.ScaleToFit(50f, 50f);
                        headerTable.AddCell(new PdfPCell(logo, true)
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            Border = Rectangle.NO_BORDER
                        });
                    }
                    else
                    {
                        headerTable.AddCell(new PdfPCell(new Phrase("Logo not found", tahomaNormal))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            Border = Rectangle.NO_BORDER
                        });
                    }

                    document.Add(headerTable);

                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);


                    // اطلاعات مشتری
                    PdfPTable custInfoTable = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };
                    custInfoTable.SetWidths(new float[] { 3, 3 });

                    custInfoTable.AddCell(new PdfPCell(new Phrase("Customer Name: " + cmbPerson.Text, tahomaNormal)) { Border = Rectangle.NO_BORDER });
                    custInfoTable.AddCell(new PdfPCell(new Phrase("Customer Phone Number: " + txtMobile.Text, tahomaNormal)) { Border = Rectangle.NO_BORDER });

                    document.Add(custInfoTable);

                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);

                    // جدول محصولات
                    PdfPTable productTable = new PdfPTable(5)
                    {
                        WidthPercentage = 100
                    };
                    productTable.SetWidths(new float[] { 1, 5, 2, 2, 2 });

                    string[] headers = { "Rows", "Product's Name", "Unit Price", "Number", "Unit" };
                    foreach (string header in headers)
                    {
                        productTable.AddCell(new PdfPCell(new Phrase(header, tahomaminBold)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    }

                    decimal totalAmount = 0;
                    int rowIndex = 1;

                    foreach (DataGridViewRow row in dgvFactor.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string productName = row.Cells[0].Value.ToString();
                            double unitPrice = Convert.ToDouble(row.Cells[1].Value);
                            int number = Convert.ToInt32(row.Cells[2].Value);
                            string unit = row.Cells[3].Value.ToString();

                            productTable.AddCell(new PdfPCell(new Phrase(rowIndex.ToString(), tahomaNormal)) { HorizontalAlignment = Element.ALIGN_LEFT });
                            productTable.AddCell(new PdfPCell(new Phrase(productName, tahomaNormal)) { HorizontalAlignment = Element.ALIGN_LEFT });
                            productTable.AddCell(new PdfPCell(new Phrase(unitPrice.ToString("N0"), tahomaNormal)) { HorizontalAlignment = Element.ALIGN_LEFT });
                            productTable.AddCell(new PdfPCell(new Phrase(number.ToString(), tahomaNormal)) { HorizontalAlignment = Element.ALIGN_LEFT });
                            productTable.AddCell(new PdfPCell(new Phrase(unit, tahomaNormal)) { HorizontalAlignment = Element.ALIGN_LEFT });

                            totalAmount = SumPrice;
                            rowIndex++;
                        }
                    }



                    document.Add(productTable);

                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);
                    // جدول فوتر
                    PdfPTable footerTable = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };
                    footerTable.SetWidths(new float[] { 4, 2 });

                    AddFooterRow(footerTable, "Total Products:", intTotalProduct.Value.ToString(), tahomaminBold);
                    // فاصله
                    AddEmptyLine(document);

                    AddFooterRow(footerTable, "Tax Price:", intTax.Value.ToString("N0"), tahomaNormal);
                    // فاصله
                    AddEmptyLine(document);

                    AddFooterRow(footerTable, "Service Cost:", intServicePrice.Value.ToString("N0"), tahomaNormal);
                    // فاصله
                    AddEmptyLine(document);
                    AddFooterRow(footerTable, "Discount Price:", intDiscountPrice.Value.ToString("N0"), tahomaNormal);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);

                    footerTable.AddCell(new PdfPCell(new Phrase("Total Price:", tahomaminBold)) { Border = Rectangle.TOP_BORDER });
                    footerTable.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("N0"), tahomaminBold)) { Border = Rectangle.TOP_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                    // فاصله
                    AddEmptyLine(document);

                    

                    document.Add(footerTable);

                    Paragraph total = new Paragraph(ConvertAmountToWords(totalAmount), tahomaNormal)
                    {
                        Alignment = Element.ALIGN_RIGHT
                        
                    };
                    document.Add(total);
                    // فاصله
                    AddEmptyLine(document);
                    // فاصله
                    AddEmptyLine(document);


                    Paragraph address = new Paragraph("Address: " + FactorAddress, tahomaNormal)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    Paragraph Tel = new Paragraph("Contact: " + FactorTel, tahomaNormal)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };

                    // افزودن پاراگراف‌ها به سند
                    document.Add(address);
                    document.Add(Tel);

                    

                    document.Close();
                }

                MessageBox.Show("Invoice PDF created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PDF: " + ex.Message);
            }
            return invoiceFilePath;
        }

        private void AddWatermark(PdfWriter writer, string watermarkText, BaseFont baseFont)
        {
            PdfContentByte canvas = writer.DirectContentUnder;
            canvas.BeginText();
            canvas.SetFontAndSize(baseFont, 40);
            canvas.SetColorFill(BaseColor.LIGHT_GRAY);
            canvas.ShowTextAligned(Element.ALIGN_CENTER, watermarkText, 300, 400, 45);
            canvas.EndText();
        }

        private void AddEmptyLine(Document document)
        {
            document.Add(new Paragraph(" "));
        }

        private void AddFooterRow(PdfPTable table, string label, string value, Font font)
        {
            table.AddCell(new PdfPCell(new Phrase(label, font)) { Border = Rectangle.NO_BORDER });
            table.AddCell(new PdfPCell(new Phrase(value, font)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
        }

        // متد تبدیل عدد به حروف
        private string ConvertAmountToWords(decimal amount)
        {
            if (amount == 0) return "Zero";

            string words = "";
            int[] numParts = SplitNumber((long)amount);

            for (int i = 0; i < numParts.Length; i++)
            {
                int n = numParts[i];
                if (n == 0) continue;

                string prefix = ThreeDigitToWords(n);
                string suffix = ThousandsGroups[i];
                words = $"{prefix} {suffix} {words}".Trim();
            }

            int decimalPart = (int)((amount - (long)amount) * 100); // برای دو رقم اعشار
            if (decimalPart > 0)
            {
                words += $" and {ThreeDigitToWords(decimalPart)} Cents";
            }

            return words.Trim();
        }

        private int[] SplitNumber(long number)
        {
            var parts = new int[ThousandsGroups.Length];
            int i = 0;

            while (number > 0)
            {
                parts[i++] = (int)(number % 1000);
                number /= 1000;
            }

            return parts;
        }

        private string ThreeDigitToWords(int number)
        {
            string words = "";

            if (number >= 100)
            {
                words += Units[number / 100] + " Hundred ";
                number %= 100;
            }

            if (number >= 10 && number < 20)
            {
                words += Teens[number - 10] + " ";
            }
            else
            {
                if (number >= 20)
                {
                    words += Tens[number / 10] + " ";
                    number %= 10;
                }

                if (number > 0)
                {
                    words += Units[number] + " ";
                }
            }

            return words.Trim();
        }

        private static readonly string[] Units = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static readonly string[] Teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static readonly string[] ThousandsGroups = { "", "Thousand", "Million", "Billion", "Trillion" };
        #endregion



        // ارسال ایمیل با فایل PDF پیوست
        private void SendEmailWithInvoice(string invoiceFilePath)
        {
            BLLEmailPanel bllep = new BLLEmailPanel();
            bllep.GetEmailPanel( out Userpanel, out Passpanel);

            send.From = Userpanel;
            send.Password = Passpanel;
            send.DisplayName = MyShopName;
            send.To = txtpersonemail.Text;
            send.Subject = "Sale Factor";
            send.Body = $"Dear customer :"+ cmbPerson.Text + "\n" + "Factor with the number : " + txtFactNumber.Text + "\n on date : " + mskdate.Text + "It has been sent to you. \n Click on the attached file to view your invoice.";
            send.File = invoiceFilePath;

            msg.MyMessagebox("", bllsend.SendEmail(Userpanel, Passpanel, MyShopName, txtpersonemail.Text, "Sale Factor", $"Factor number : {txtFactNumber.Text} on date : {mskdate.Text}", invoiceFilePath), 0, 0);
            bllsend.Create(send);
        }

        // بروزرسانی فرم فاکتورها و فعال‌سازی دکمه‌ها
        private void UpdateFormAndButtons()
        {
            var frmshowfactors = Application.OpenForms["FrmShowFactors"] as FrmShowFactors;
            if (frmshowfactors != null)
            {
                frmshowfactors.FrmShowFactors_Load(null, null);
            }
            btnPrintFactor.Enabled = true;
            btnPrintRemittance.Enabled = true;
            btnbook.Enabled = true;
            btndoc.Enabled = true;
        }


        private void btnPrintFactor_Click(object sender, EventArgs e)
        {
            try
            {
                
                ExistMessage = bllmsg.ExistMessage();
                StiReport report = new StiReport();
                report.Load("Reports/rptFactor.mrt");

                report.Compile();

                report["intFactorId"] = LastFactorId;
                report["strPersonName"] = cmbPerson.Text;
                report["strMobile"] = txtMobile.Text;
                report["strAddress"] = FactorAddress;
                report["strTel"] = FactorTel;

                if (ExistMessage)
                {
                    bllmsg.GetRandomMessage(out RandomMessage);

                    report["strMessage"] = RandomMessage;
                }
                else
                {
                    report["strMessage"] = "";
                }

                if (FrmType)
                {
                    report["strType"] = "Buy Factor";
                }
                else
                {
                    report["strType"] = "Sale Factor";
                }
                report.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + ex.Message, 2, 2);
            }
        }

        private void btnPrintRemittance_Click(object sender, EventArgs e)
        {
            try
            {
                StiReport report = new StiReport();
                report.Load("Reports/rptFactorDepot.mrt");
                report.Compile();
                report["FactorId"] = LastFactorId;
                report["strFullName"] = cmbPerson.Text;
                report["strMobile"] = txtMobile.Text;
                report["strAddress"] = DepotAddress;
                report["strTel"] = DepotTel;
                
                report.ShowWithRibbonGUI();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnaddperson_Click(object sender, EventArgs e)
        {
            Users LoggedUser = new Users();
            BLLUser bllu = new BLLUser();
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

        private void btnaddproduct_Click(object sender, EventArgs e)
        {
            Users LoggedUser = new Users();
            BLLUser bllu = new BLLUser();
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Factors", 1))
            {
                new FrmAddProduct().ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
        }

        private void btnbook_Click(object sender, EventArgs e)
        {
            Users LoggedUser = new Users();
            BLLUser bllu = new BLLUser();
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Accounts", 1))
            {
                FrmAddAccountBook book = new FrmAddAccountBook();
                if (FrmType)
                {
                    book.CostGroupType = 5;
                    book.strDesc = "buy from " + cmbPerson.Text + " With Factor Number" + " \n" + txtFactNumber.Text;

                }
                else
                {
                    book.CostGroupType = 2;
                    book.strDesc = "sell to " + cmbPerson.Text + " With Factor Number" + " \n" + txtFactNumber.Text;

                }
                Person = bllPer.ReadN(cmbPerson.Text);
                book.PersonId = Person.id;
                book.PersonName = cmbPerson.Text;
                book.intSaleBuy = SumPrice;
                book.ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
            
        }

        private void btndoc_Click(object sender, EventArgs e)
        {
            Users LoggedUser = new Users();
            BLLUser bllu = new BLLUser();
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Accounts", 1))
            {
                FrmAddDocument doc = new FrmAddDocument();
                if (FrmType)
                {
                    doc.CostGroupType = 5;
                    doc.strDesc = "buy from " + cmbPerson.Text + " With Factor Number" + " \n" + txtFactNumber.Text;

                }
                else
                {
                    doc.CostGroupType = 2;
                    doc.strDesc = "sell to " + cmbPerson.Text + " With Factor Number" + " \n" + txtFactNumber.Text;

                }
                Person = bllPer.ReadN(cmbPerson.Text);
                doc.PersonId = Person.id;
                doc.PersonName = cmbPerson.Text;
                doc.intSaleBuy = SumPrice;
                doc.ShowDialog();
            }
            else
            {
                msg.MyMessagebox("Limit Access", "You are not authorized to enter this section!!!", 2, 2);
            }
            
        }
    }
}
