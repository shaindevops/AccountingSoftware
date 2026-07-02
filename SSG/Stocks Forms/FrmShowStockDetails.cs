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
using static Stimulsoft.Base.Drawing.Win32;
using Stimulsoft.Report;
namespace SSG.Stocks_Forms
{
    public partial class FrmShowStockDetails : Form
    {
        public FrmShowStockDetails()
        {
            InitializeComponent();
        }
        BLLStocks bll = new BLLStocks();

        public int DepotId = 0;
        public int ProductId = 0;
        public int SumStock = 0;

        public string GroupName = "";
        public string ProductName = "";
        public string Depot = "";

        msgclass msg = new msgclass();
        private void FrmShowStockDetails_Load(object sender, EventArgs e)
        {
            try
            {
                lblproductname.Text = ProductName + " - " + GroupName;
                lbldepotname.Text = Depot;
                lblstockcount.Text = SumStock.ToString("N0");

                dgvstockdetails.DataSource = null;
                dgvstockdetails.DataSource = bll.FilterStockByIds(DepotId, ProductId);
                dgvstockdetails.Columns["id"].Visible = false;
                dgvstockdetails.Columns["FactorId"].Visible = false;
                dgvstockdetails.Columns["DepotId"].Visible = false;
                dgvstockdetails.Columns["ProductId"].Visible = false;

            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            try
            {
                StiReport report = new StiReport();
                report.Load("Reports/rptStocksDetails.mrt");
                report.Compile();

                report["DepotId"] = DepotId;
                report["ProductId"] = ProductId;
                report["strName"] = ProductName + " - " + GroupName;
                report["strDepotName"] = Depot;
                report["IntSum"] = SumStock;

                report.ShowWithRibbonGUI();
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
    }
}
