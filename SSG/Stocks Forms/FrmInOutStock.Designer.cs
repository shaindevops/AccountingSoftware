namespace SSG.Stocks_Forms
{
    partial class FrmInOutStock
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInOutStock));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnclose = new DevComponents.DotNetBar.ButtonX();
            this.btnsave = new DevComponents.DotNetBar.ButtonX();
            this.grpinoutstock = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnadddepot = new DevComponents.DotNetBar.ButtonX();
            this.btnaddgroup = new DevComponents.DotNetBar.ButtonX();
            this.intcount = new DevComponents.Editors.IntegerInput();
            this.cmbdepot = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbproduct = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.mskregdate = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtdesc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtsearchproduct = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbltitle = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelEx1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.grpinoutstock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intcount)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel3);
            this.panelEx1.Controls.Add(this.grpinoutstock);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(2, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Padding = new System.Windows.Forms.Padding(10);
            this.panelEx1.Size = new System.Drawing.Size(467, 420);
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
            this.groupPanel3.Controls.Add(this.btnclose);
            this.groupPanel3.Controls.Add(this.btnsave);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(13, 367);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(441, 40);
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
            this.groupPanel3.TabIndex = 1;
            // 
            // btnclose
            // 
            this.btnclose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnclose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnclose.FocusCuesEnabled = false;
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(348, 2);
            this.btnclose.Name = "btnclose";
            this.btnclose.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnclose.Size = new System.Drawing.Size(84, 30);
            this.btnclose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnclose.TabIndex = 1;
            this.btnclose.Text = "  Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnsave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FocusCuesEnabled = false;
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.Location = new System.Drawing.Point(9, 2);
            this.btnsave.Name = "btnsave";
            this.btnsave.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnsave.Size = new System.Drawing.Size(86, 30);
            this.btnsave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "Save";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // grpinoutstock
            // 
            this.grpinoutstock.BackColor = System.Drawing.Color.White;
            this.grpinoutstock.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpinoutstock.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpinoutstock.Controls.Add(this.btnadddepot);
            this.grpinoutstock.Controls.Add(this.btnaddgroup);
            this.grpinoutstock.Controls.Add(this.intcount);
            this.grpinoutstock.Controls.Add(this.cmbdepot);
            this.grpinoutstock.Controls.Add(this.cmbproduct);
            this.grpinoutstock.Controls.Add(this.mskregdate);
            this.grpinoutstock.Controls.Add(this.txtdesc);
            this.grpinoutstock.Controls.Add(this.txtsearchproduct);
            this.grpinoutstock.Controls.Add(this.labelX2);
            this.grpinoutstock.Controls.Add(this.labelX4);
            this.grpinoutstock.Controls.Add(this.labelX5);
            this.grpinoutstock.Controls.Add(this.labelX3);
            this.grpinoutstock.Controls.Add(this.labelX1);
            this.grpinoutstock.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpinoutstock.Location = new System.Drawing.Point(13, 98);
            this.grpinoutstock.Name = "grpinoutstock";
            this.grpinoutstock.Size = new System.Drawing.Size(441, 263);
            // 
            // 
            // 
            this.grpinoutstock.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grpinoutstock.Style.BackColorGradientAngle = 90;
            this.grpinoutstock.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grpinoutstock.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpinoutstock.Style.BorderBottomWidth = 1;
            this.grpinoutstock.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpinoutstock.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpinoutstock.Style.BorderLeftWidth = 1;
            this.grpinoutstock.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpinoutstock.Style.BorderRightWidth = 1;
            this.grpinoutstock.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpinoutstock.Style.BorderTopWidth = 1;
            this.grpinoutstock.Style.CornerDiameter = 4;
            this.grpinoutstock.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpinoutstock.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpinoutstock.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpinoutstock.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpinoutstock.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpinoutstock.TabIndex = 0;
            this.grpinoutstock.Text = "Enter Product To Depot";
            // 
            // btnadddepot
            // 
            this.btnadddepot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnadddepot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnadddepot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadddepot.Image = ((System.Drawing.Image)(resources.GetObject("btnadddepot.Image")));
            this.btnadddepot.Location = new System.Drawing.Point(390, 105);
            this.btnadddepot.Name = "btnadddepot";
            this.btnadddepot.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnadddepot.Size = new System.Drawing.Size(22, 22);
            this.btnadddepot.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnadddepot.TabIndex = 58;
            this.btnadddepot.Tooltip = "Click to Depot";
            this.btnadddepot.Click += new System.EventHandler(this.btnadddepot_Click);
            // 
            // btnaddgroup
            // 
            this.btnaddgroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnaddgroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnaddgroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaddgroup.Image = ((System.Drawing.Image)(resources.GetObject("btnaddgroup.Image")));
            this.btnaddgroup.Location = new System.Drawing.Point(390, 50);
            this.btnaddgroup.Name = "btnaddgroup";
            this.btnaddgroup.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnaddgroup.Size = new System.Drawing.Size(22, 22);
            this.btnaddgroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnaddgroup.TabIndex = 58;
            this.btnaddgroup.Tooltip = "Click to Add Product";
            this.btnaddgroup.Click += new System.EventHandler(this.btnaddgroup_Click);
            // 
            // intcount
            // 
            this.intcount.AllowEmptyState = false;
            // 
            // 
            // 
            this.intcount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intcount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intcount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intcount.FocusHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.intcount.FocusHighlightEnabled = true;
            this.intcount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.intcount.Location = new System.Drawing.Point(130, 133);
            this.intcount.MinValue = 0;
            this.intcount.Name = "intcount";
            this.intcount.ShowUpDown = true;
            this.intcount.Size = new System.Drawing.Size(103, 21);
            this.intcount.TabIndex = 4;
            // 
            // cmbdepot
            // 
            this.cmbdepot.DisplayMember = "Text";
            this.cmbdepot.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbdepot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdepot.FocusHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbdepot.FocusHighlightEnabled = true;
            this.cmbdepot.ForeColor = System.Drawing.Color.Black;
            this.cmbdepot.FormattingEnabled = true;
            this.cmbdepot.ItemHeight = 16;
            this.cmbdepot.Location = new System.Drawing.Point(130, 105);
            this.cmbdepot.Name = "cmbdepot";
            this.cmbdepot.Size = new System.Drawing.Size(254, 22);
            this.cmbdepot.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbdepot.TabIndex = 3;
            // 
            // cmbproduct
            // 
            this.cmbproduct.DisplayMember = "Text";
            this.cmbproduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbproduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbproduct.FocusHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbproduct.FocusHighlightEnabled = true;
            this.cmbproduct.ForeColor = System.Drawing.Color.Black;
            this.cmbproduct.FormattingEnabled = true;
            this.cmbproduct.ItemHeight = 16;
            this.cmbproduct.Location = new System.Drawing.Point(130, 50);
            this.cmbproduct.Name = "cmbproduct";
            this.cmbproduct.Size = new System.Drawing.Size(254, 22);
            this.cmbproduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbproduct.TabIndex = 1;
            // 
            // mskregdate
            // 
            // 
            // 
            // 
            this.mskregdate.BackgroundStyle.Class = "TextBoxBorder";
            this.mskregdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mskregdate.ButtonClear.Visible = true;
            this.mskregdate.FocusHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mskregdate.FocusHighlightEnabled = true;
            this.mskregdate.Location = new System.Drawing.Point(130, 23);
            this.mskregdate.Name = "mskregdate";
            this.mskregdate.Size = new System.Drawing.Size(174, 20);
            this.mskregdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.mskregdate.TabIndex = 0;
            this.mskregdate.Text = "";
            this.mskregdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtdesc
            // 
            this.txtdesc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtdesc.Border.Class = "TextBoxBorder";
            this.txtdesc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtdesc.DisabledBackColor = System.Drawing.Color.White;
            this.txtdesc.ForeColor = System.Drawing.Color.Black;
            this.txtdesc.Location = new System.Drawing.Point(130, 165);
            this.txtdesc.MaxLength = 500;
            this.txtdesc.Multiline = true;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.PreventEnterBeep = true;
            this.txtdesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtdesc.Size = new System.Drawing.Size(302, 69);
            this.txtdesc.TabIndex = 5;
            // 
            // txtsearchproduct
            // 
            this.txtsearchproduct.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtsearchproduct.Border.Class = "TextBoxBorder";
            this.txtsearchproduct.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtsearchproduct.DisabledBackColor = System.Drawing.Color.White;
            this.txtsearchproduct.ForeColor = System.Drawing.Color.Black;
            this.txtsearchproduct.Location = new System.Drawing.Point(130, 78);
            this.txtsearchproduct.Name = "txtsearchproduct";
            this.txtsearchproduct.PreventEnterBeep = true;
            this.txtsearchproduct.Size = new System.Drawing.Size(254, 21);
            this.txtsearchproduct.TabIndex = 2;
            this.txtsearchproduct.WatermarkText = "Search Product....";
            this.txtsearchproduct.TextChanged += new System.EventHandler(this.txtsearchproduct_TextChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(9, 165);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(115, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Description :";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(9, 136);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(115, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Stock Count";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(9, 106);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(115, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Select Depot :";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(9, 49);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(115, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Select Product :";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(9, 20);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(115, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Date :";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.pictureBox2);
            this.groupPanel1.Controls.Add(this.lbltitle);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(13, 13);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(441, 79);
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
            this.groupPanel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "All items are nessesaty.";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(373, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.Location = new System.Drawing.Point(6, 9);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(154, 14);
            this.lbltitle.TabIndex = 46;
            this.lbltitle.Text = "Enter Product To Depot";
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // FrmInOutStock
            // 
            this.AcceptButton = this.btnsave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(66)))), ((int)(((byte)(55)))));
            this.CancelButton = this.btnclose;
            this.ClientSize = new System.Drawing.Size(471, 424);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmInOutStock";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmInOutStock_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.grpinoutstock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.intcount)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public DevComponents.DotNetBar.ButtonX btnclose;
        public DevComponents.DotNetBar.ButtonX btnsave;
        public DevComponents.DotNetBar.Controls.GroupPanel grpinoutstock;
        public DevComponents.DotNetBar.Controls.TextBoxX txtdesc;
        public DevComponents.DotNetBar.Controls.TextBoxX txtsearchproduct;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label lbltitle;
        public DevComponents.DotNetBar.Controls.MaskedTextBoxAdv mskregdate;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbproduct;
        public DevComponents.Editors.IntegerInput intcount;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbdepot;
        public DevComponents.DotNetBar.PanelEx panelEx1;
        public DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        public DevComponents.DotNetBar.LabelX labelX2;
        public DevComponents.DotNetBar.LabelX labelX1;
        public DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        public DevComponents.DotNetBar.LabelX labelX4;
        public DevComponents.DotNetBar.LabelX labelX5;
        public DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.ErrorProvider ep;
        public DevComponents.DotNetBar.ButtonX btnadddepot;
        public DevComponents.DotNetBar.ButtonX btnaddgroup;
    }
}