namespace SSG.Documents_Forms
{
    partial class FrmShowDocuments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowDocuments));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnpassed = new DevComponents.DotNetBar.ButtonX();
            this.btndelete = new DevComponents.DotNetBar.ButtonX();
            this.btnedit = new DevComponents.DotNetBar.ButtonX();
            this.btnclose = new DevComponents.DotNetBar.ButtonX();
            this.grpdocumentlist = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvDocuments = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtsearchdocnumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rdodocpayment = new System.Windows.Forms.RadioButton();
            this.rdodocreceived = new System.Windows.Forms.RadioButton();
            this.btnadd = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.grpdocumentlist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel3);
            this.panelEx1.Controls.Add(this.grpdocumentlist);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(2, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1194, 624);
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
            this.groupPanel3.Controls.Add(this.btnpassed);
            this.groupPanel3.Controls.Add(this.btndelete);
            this.groupPanel3.Controls.Add(this.btnedit);
            this.groupPanel3.Controls.Add(this.btnclose);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel3.Location = new System.Drawing.Point(0, 584);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1194, 40);
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
            // btnpassed
            // 
            this.btnpassed.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnpassed.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnpassed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpassed.FocusCuesEnabled = false;
            this.btnpassed.Image = ((System.Drawing.Image)(resources.GetObject("btnpassed.Image")));
            this.btnpassed.Location = new System.Drawing.Point(955, 1);
            this.btnpassed.Name = "btnpassed";
            this.btnpassed.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnpassed.Size = new System.Drawing.Size(93, 30);
            this.btnpassed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnpassed.TabIndex = 1;
            this.btnpassed.Text = "Passed";
            this.btnpassed.Click += new System.EventHandler(this.btnpassed_Click);
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
            this.btndelete.Size = new System.Drawing.Size(138, 30);
            this.btndelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btndelete.TabIndex = 2;
            this.btndelete.Text = "Delete Document";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnedit
            // 
            this.btnedit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnedit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnedit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.Location = new System.Drawing.Point(1054, 1);
            this.btnedit.Name = "btnedit";
            this.btnedit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnedit.Size = new System.Drawing.Size(124, 30);
            this.btnedit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnedit.TabIndex = 0;
            this.btnedit.Text = "Edit Document";
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
            // grpdocumentlist
            // 
            this.grpdocumentlist.BackColor = System.Drawing.Color.White;
            this.grpdocumentlist.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpdocumentlist.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpdocumentlist.Controls.Add(this.dgvDocuments);
            this.grpdocumentlist.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpdocumentlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpdocumentlist.Location = new System.Drawing.Point(0, 47);
            this.grpdocumentlist.Name = "grpdocumentlist";
            this.grpdocumentlist.Padding = new System.Windows.Forms.Padding(10);
            this.grpdocumentlist.Size = new System.Drawing.Size(1194, 531);
            // 
            // 
            // 
            this.grpdocumentlist.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grpdocumentlist.Style.BackColorGradientAngle = 90;
            this.grpdocumentlist.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grpdocumentlist.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpdocumentlist.Style.BorderBottomWidth = 1;
            this.grpdocumentlist.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpdocumentlist.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpdocumentlist.Style.BorderLeftWidth = 1;
            this.grpdocumentlist.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpdocumentlist.Style.BorderRightWidth = 1;
            this.grpdocumentlist.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpdocumentlist.Style.BorderTopWidth = 1;
            this.grpdocumentlist.Style.CornerDiameter = 4;
            this.grpdocumentlist.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpdocumentlist.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpdocumentlist.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpdocumentlist.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpdocumentlist.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpdocumentlist.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpdocumentlist.TabIndex = 1;
            this.grpdocumentlist.Text = "Show Documents List";
            // 
            // dgvDocuments
            // 
            this.dgvDocuments.AllowUserToAddRows = false;
            this.dgvDocuments.AllowUserToDeleteRows = false;
            this.dgvDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocuments.BackgroundColor = System.Drawing.Color.White;
            this.dgvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocuments.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocuments.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDocuments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvDocuments.Location = new System.Drawing.Point(10, 10);
            this.dgvDocuments.MultiSelect = false;
            this.dgvDocuments.Name = "dgvDocuments";
            this.dgvDocuments.ReadOnly = true;
            this.dgvDocuments.Size = new System.Drawing.Size(1168, 441);
            this.dgvDocuments.TabIndex = 0;
            this.dgvDocuments.SelectionChanged += new System.EventHandler(this.dgvDocuments_SelectionChanged);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtsearchdocnumber);
            this.groupPanel1.Controls.Add(this.rdodocpayment);
            this.groupPanel1.Controls.Add(this.rdodocreceived);
            this.groupPanel1.Controls.Add(this.btnadd);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1194, 47);
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
            // txtsearchdocnumber
            // 
            this.txtsearchdocnumber.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtsearchdocnumber.Border.Class = "TextBoxBorder";
            this.txtsearchdocnumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtsearchdocnumber.DisabledBackColor = System.Drawing.Color.White;
            this.txtsearchdocnumber.ForeColor = System.Drawing.Color.Black;
            this.txtsearchdocnumber.Location = new System.Drawing.Point(288, 10);
            this.txtsearchdocnumber.Name = "txtsearchdocnumber";
            this.txtsearchdocnumber.PreventEnterBeep = true;
            this.txtsearchdocnumber.Size = new System.Drawing.Size(244, 21);
            this.txtsearchdocnumber.TabIndex = 2;
            this.txtsearchdocnumber.WatermarkText = "Search document number...";
            this.txtsearchdocnumber.TextChanged += new System.EventHandler(this.txtsearchdocnumber_TextChanged);
            // 
            // rdodocpayment
            // 
            this.rdodocpayment.AutoSize = true;
            this.rdodocpayment.Location = new System.Drawing.Point(149, 14);
            this.rdodocpayment.Name = "rdodocpayment";
            this.rdodocpayment.Size = new System.Drawing.Size(123, 17);
            this.rdodocpayment.TabIndex = 1;
            this.rdodocpayment.TabStop = true;
            this.rdodocpayment.Text = "Payment Documents";
            this.rdodocpayment.UseVisualStyleBackColor = true;
            this.rdodocpayment.CheckedChanged += new System.EventHandler(this.rdodocpayment_CheckedChanged);
            // 
            // rdodocreceived
            // 
            this.rdodocreceived.AutoSize = true;
            this.rdodocreceived.Location = new System.Drawing.Point(10, 14);
            this.rdodocreceived.Name = "rdodocreceived";
            this.rdodocreceived.Size = new System.Drawing.Size(125, 17);
            this.rdodocreceived.TabIndex = 0;
            this.rdodocreceived.TabStop = true;
            this.rdodocreceived.Text = "Documents Received";
            this.rdodocreceived.UseVisualStyleBackColor = true;
            this.rdodocreceived.CheckedChanged += new System.EventHandler(this.rdodocreceived_CheckedChanged);
            // 
            // btnadd
            // 
            this.btnadd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnadd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.Image")));
            this.btnadd.Location = new System.Drawing.Point(1054, 3);
            this.btnadd.Name = "btnadd";
            this.btnadd.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnadd.Size = new System.Drawing.Size(124, 30);
            this.btnadd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "Add Document";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // FrmShowDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(66)))), ((int)(((byte)(55)))));
            this.CancelButton = this.btnclose;
            this.ClientSize = new System.Drawing.Size(1198, 628);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmShowDocuments";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmShowDocuments_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.grpdocumentlist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        public DevComponents.DotNetBar.ButtonX btndelete;
        public DevComponents.DotNetBar.ButtonX btnedit;
        public DevComponents.DotNetBar.ButtonX btnclose;
        private DevComponents.DotNetBar.Controls.GroupPanel grpdocumentlist;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDocuments;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtsearchdocnumber;
        private System.Windows.Forms.RadioButton rdodocpayment;
        private System.Windows.Forms.RadioButton rdodocreceived;
        public DevComponents.DotNetBar.ButtonX btnadd;
        public DevComponents.DotNetBar.ButtonX btnpassed;
    }
}