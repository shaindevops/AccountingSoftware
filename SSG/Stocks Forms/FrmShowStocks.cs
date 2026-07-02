using BE;
using BLL;
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
using static Stimulsoft.Base.Drawing.Win32;

namespace SSG.Stocks_Forms
{
    public partial class FrmShowStocks : Form
    {
        public FrmShowStocks()
        {
            InitializeComponent();
        }

        Stocks S = new Stocks();
        BLLStocks bll = new BLLStocks();

        Products p = new Products();
        BLLProducts bllp = new BLLProducts();

        Depots D = new Depots();
        BLLDepot blld = new BLLDepot();

        msgclass msg = new msgclass();
        public void FrmShowStocks_Load(object sender, EventArgs e)
        {
            try
            {
                dgvstocks.DataSource = null;
                dgvstocks.DataSource = bll.FilterStock(txtserch.Text);
                dgvstocks.Columns[0].Visible = false;
                dgvstocks.Columns[1].Visible = false;
                dgvstocks.Columns[2].Visible = false;

                if (dgvstocks.Rows.Count == 0)
                {
                    btnshowdetail.Enabled = false;
                }
                else
                {
                    btnshowdetail.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void txtserch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvstocks.DataSource = null;
                dgvstocks.DataSource = bll.FilterStock(txtserch.Text);
                dgvstocks.Columns[0].Visible = false;
                dgvstocks.Columns[1].Visible = false;

                if (dgvstocks.Rows.Count == 0)
                {
                    btnshowdetail.Enabled = false;
                }
                else
                {
                    btnshowdetail.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }
        private void btnshowdetail_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSelectedDepot sd = new FrmSelectedDepot();
                sd.ProductId = (int)dgvstocks.CurrentRow.Cells[0].Value;
                sd.GroupName = dgvstocks.CurrentRow.Cells[3].Value.ToString();
                sd.DepotName = dgvstocks.CurrentRow.Cells[5].Value.ToString();
                sd.ProductName = dgvstocks.CurrentRow.Cells[6].Value.ToString();
                sd.SumStock = (int)dgvstocks.CurrentRow.Cells[14].Value;
                sd.ShowDialog();
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

        private void btnpreview_Click(object sender, EventArgs e)
        {
            try
            {
                StiReport report = new StiReport();
                report.Load("Reports/rptStocks.mrt");
                report.Compile();

                report["strName"] = txtserch.Text;

                report.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            FrmInOutStock inOutStock = new FrmInOutStock();
            inOutStock.InOut = true;
            inOutStock.ShowDialog();
        }
    }
}
