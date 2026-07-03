using BE;
using BE.Logging;
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

namespace SSG.Stocks_Forms
{
    public partial class FrmSelectedDepot : Form
    {
        public FrmSelectedDepot()
        {
            InitializeComponent();
        }
        Depots D = new Depots();
        BLLDepot bll = new BLLDepot();

        msgclass msg = new msgclass();

        public int ProductId = 0;
        public int SumStock = 0;

        public string ProductName = "";
        public string DepotName = "";
        public string GroupName = "";
        private void FrmSelectedDepot_Load(object sender, EventArgs e)
        {
            try
            {
                dgvdepots.DataSource = null;
                dgvdepots.DataSource = bll.FillDepotByProducts(ProductId);
                dgvdepots.Columns["id"].Visible = false;
                dgvdepots.Columns["ProductId"].Visible = false;
                dgvdepots.Columns["DepotId"].Visible = false;

                if (dgvdepots.Rows.Count == 0)
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
                AppLogger.LogError("FrmSelectedDepot.<load>", ex);
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost" + "\n" + ex.Message, 2, 2);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnshowdetail_Click(object sender, EventArgs e)
        {
            FrmShowStockDetails ssd = new FrmShowStockDetails();
            ssd.DepotId = (int)dgvdepots.CurrentRow.Cells[2].Value;
            ssd.ProductId = ProductId;
            ssd.SumStock = SumStock;
            ssd.ProductName = ProductName;
            ssd.Depot = dgvdepots.CurrentRow.Cells[4].Value.ToString();
            ssd.GroupName = GroupName;
            ssd.ShowDialog();
        }
    }
}
