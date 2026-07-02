using BE;
using BLL;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace SSG.Orders_Forms
{
    public partial class UCShowOrderFrom : UserControl
    {
        public Form ParentForm { get; set; }
        public UCShowOrderFrom()
        {
            
            InitializeComponent();
        }

        Orders O = new Orders();
        BLLOrders bll = new BLLOrders();

        OrderDetails OD = new OrderDetails();
        BLLOrderDetails bllod = new BLLOrderDetails();

        msgclass msg = new msgclass();

        private void btnadd_Click(object sender, EventArgs e)
        {
            new FrmAddOrder().ShowDialog();
        }

        public void FillGrid()
        {
            try
            {
                dgvorders.DataSource = null;
                dgvorders.DataSource = bll.FilterOrderByDate(mskdate1.Text, mskdate2.Text);

                dgvorders.Columns["id"].Visible = false;
                dgvorders.Columns["Product_id"].Visible = false;
                dgvorders.Columns["OrderId"].Visible = false;
                dgvorders.Columns["Group_id"].Visible = false;
                dgvorders.Columns["Product Group Name"].Visible = false;
                dgvorders.Columns["People_id"].Visible = false;
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        Users LoggedUser = new Users();
        BLLUser bllu = new BLLUser();

        public void Permisions()
        {
            LoggedUser = ((frmASWS)Application.OpenForms["frmASWS"]).loggeduser;

            if (bllu.AccessTo(LoggedUser, "Settings", 3) && bllu.AccessTo(LoggedUser, "Settings", 4))
            {
                btnupdate.Enabled = true;
                btncancelorder.Enabled = true;
            }
            else if (bllu.AccessTo(LoggedUser, "Settings", 3) && !bllu.AccessTo(LoggedUser, "Settings", 4))
            {
                btnupdate.Enabled = true;
                btncancelorder.Enabled = false;
            }
            else if (!bllu.AccessTo(LoggedUser, "Settings", 3) && bllu.AccessTo(LoggedUser, "Settings", 4))
            {
                btnupdate.Enabled = false;
                btncancelorder.Enabled = true;
            }
            else
            {
                btnupdate.Enabled = false;
                btncancelorder.Enabled = false;
            }
        }
        public void UCShowOrderFrom_Load(object sender, EventArgs e)
        {
            try
            {
                Permisions();

                if (btnupdate.Enabled == false && btncancelorder.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Update and Cancel this section!!!", 2, 2);
                }
                else if (btnupdate.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Update this section!!!", 2, 2);
                }
                else if (btncancelorder.Enabled == false)
                {
                    msg.MyMessagebox("Limit Access", "You are not authorized to Cancel this section!!!", 2, 2);
                }

                mskdate1.Text = DateTime.Now.ToString("MM/dd/yyyy");
                mskdate2.Text = DateTime.Now.ToString("MM/dd/yyyy");

                FillGrid();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            O = bll.ReadId((int)dgvorders.CurrentRow.Cells[0].Value);
            if(O != null)
            {
                O.StatusType = "Send Order";
                bll.UpdateStatus((int)dgvorders.CurrentRow.Cells[0].Value, O);

            }
            UCShowOrderFrom_Load(null,null);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                ((Panel)this.Parent).Visible = false; // پنهان کردن پنل
            }
            this.Dispose(); // حذف یوزر کنترل
        }

        private void mskdate1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillGrid();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void mskdate2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillGrid();
            }
            catch
            {
                msg.MyMessagebox("Server Connection", "Connection to the server has been lost", 2, 2);
            }
        }

        private void btncancelorder_Click(object sender, EventArgs e)
        {
            if (msg.MyMessagebox("Cancel Message", "Do you want to cancel this order?", 1, 1) == DialogResult.Yes)
            {
                bll.DeleteOrder((int)dgvorders.CurrentRow.Cells[0].Value);
            }
            UCShowOrderFrom_Load(null, null);
        }
    }
}
