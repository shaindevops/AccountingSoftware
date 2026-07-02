namespace SSG.Accounts_Forms
{
    partial class FrmShowAccounts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowAccounts));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btndelete = new DevComponents.DotNetBar.ButtonX();
            this.btnviewaccountbook = new DevComponents.DotNetBar.ButtonX();
            this.btnedit = new DevComponents.DotNetBar.ButtonX();
            this.btnclose = new DevComponents.DotNetBar.ButtonX();
            this.grpshowaccount = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvaccounts = new System.Windows.Forms.DataGridView();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnadd = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.grpshowaccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaccounts)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel3);
            this.panelEx1.Controls.Add(this.grpshowaccount);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(2, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Padding = new System.Windows.Forms.Padding(10);
            this.panelEx1.Size = new System.Drawing.Size(938, 539);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.White;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btndelete);
            this.groupPanel3.Controls.Add(this.btnviewaccountbook);
            this.groupPanel3.Controls.Add(this.btnedit);
            this.groupPanel3.Controls.Add(this.btnclose);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel3.Location = new System.Drawing.Point(10, 489);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(918, 40);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 2;
            // 
            // btndelete
            // 
            this.btndelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btndelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btndelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.Location = new System.Drawing.Point(102, 1);
            this.btndelete.Name = "btndelete";
            this.btndelete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btndelete.Size = new System.Drawing.Size(131, 30);
            this.btndelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btndelete.TabIndex = 2;
            this.btndelete.Text = "Delete Account";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnviewaccountbook
            // 
            this.btnviewaccountbook.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnviewaccountbook.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnviewaccountbook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnviewaccountbook.Image = ((System.Drawing.Image)(resources.GetObject("btnviewaccountbook.Image")));
            this.btnviewaccountbook.Location = new System.Drawing.Point(641, 1);
            this.btnviewaccountbook.Name = "btnviewaccountbook";
            this.btnviewaccountbook.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnviewaccountbook.Size = new System.Drawing.Size(149, 30);
            this.btnviewaccountbook.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnviewaccountbook.TabIndex = 1;
            this.btnviewaccountbook.Text = "View Account Book";
            this.btnviewaccountbook.Click += new System.EventHandler(this.btnviewaccountbook_Click);
            // 
            // btnedit
            // 
            this.btnedit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnedit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnedit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.Location = new System.Drawing.Point(796, 1);
            this.btnedit.Name = "btnedit";
            this.btnedit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnedit.Size = new System.Drawing.Size(106, 30);
            this.btnedit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnedit.TabIndex = 0;
            this.btnedit.Text = "Edit Account";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnclose
            // 
            this.btnclose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnclose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(10, 1);
            this.btnclose.Name = "btnclose";
            this.btnclose.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnclose.Size = new System.Drawing.Size(86, 30);
            this.btnclose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "  Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // grpshowaccount
            // 
            this.grpshowaccount.BackColor = System.Drawing.Color.White;
            this.grpshowaccount.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpshowaccount.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpshowaccount.Controls.Add(this.dgvaccounts);
            this.grpshowaccount.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpshowaccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpshowaccount.Location = new System.Drawing.Point(10, 50);
            this.grpshowaccount.Name = "grpshowaccount";
            this.grpshowaccount.Padding = new System.Windows.Forms.Padding(10);
            this.grpshowaccount.Size = new System.Drawing.Size(918, 433);
            // 
            // 
            // 
            this.grpshowaccount.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grpshowaccount.Style.BackColorGradientAngle = 90;
            this.grpshowaccount.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grpshowaccount.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpshowaccount.Style.BorderBottomWidth = 1;
            this.grpshowaccount.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpshowaccount.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpshowaccount.Style.BorderLeftWidth = 1;
            this.grpshowaccount.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpshowaccount.Style.BorderRightWidth = 1;
            this.grpshowaccount.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpshowaccount.Style.BorderTopWidth = 1;
            this.grpshowaccount.Style.CornerDiameter = 4;
            this.grpshowaccount.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpshowaccount.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpshowaccount.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpshowaccount.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpshowaccount.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpshowaccount.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpshowaccount.TabIndex = 1;
            this.grpshowaccount.Text = "Show Financial Account List";
            // 
            // dgvaccounts
            // 
            this.dgvaccounts.AllowUserToAddRows = false;
            this.dgvaccounts.AllowUserToDeleteRows = false;
            this.dgvaccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvaccounts.BackgroundColor = System.Drawing.Color.White;
            this.dgvaccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvaccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvaccounts.Location = new System.Drawing.Point(10, 10);
            this.dgvaccounts.MultiSelect = false;
            this.dgvaccounts.Name = "dgvaccounts";
            this.dgvaccounts.ReadOnly = true;
            this.dgvaccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvaccounts.Size = new System.Drawing.Size(892, 391);
            this.dgvaccounts.TabIndex = 0;
            this.dgvaccounts.SelectionChanged += new System.EventHandler(this.dgvaccounts_SelectionChanged);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnadd);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(10, 10);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(918, 40);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            // 
            // btnadd
            // 
            this.btnadd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnadd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.Image")));
            this.btnadd.Location = new System.Drawing.Point(796, 2);
            this.btnadd.Name = "btnadd";
            this.btnadd.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnadd.Size = new System.Drawing.Size(106, 30);
            this.btnadd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnadd.TabIndex = 0;
            this.btnadd.Text = "Add Account";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // FrmShowAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(66)))), ((int)(((byte)(55)))));
            this.CancelButton = this.btnclose;
            this.ClientSize = new System.Drawing.Size(942, 543);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmShowAccounts";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmShowAccounts_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.grpshowaccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvaccounts)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public DevComponents.DotNetBar.ButtonX btnadd;
        public DevComponents.DotNetBar.ButtonX btndelete;
        public DevComponents.DotNetBar.ButtonX btnedit;
        public DevComponents.DotNetBar.ButtonX btnclose;
        public DevComponents.DotNetBar.ButtonX btnviewaccountbook;
        public DevComponents.DotNetBar.PanelEx panelEx1;
        public DevComponents.DotNetBar.Controls.GroupPanel grpshowaccount;
        public DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        public DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.DataGridView dgvaccounts;
    }
}