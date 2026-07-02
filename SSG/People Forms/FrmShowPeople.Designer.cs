namespace SSG.People_Forms
{
    partial class FrmShowPeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowPeople));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btndelete = new DevComponents.DotNetBar.ButtonX();
            this.btnedit = new DevComponents.DotNetBar.ButtonX();
            this.btnclose = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvpersonlist = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rdoallperson = new System.Windows.Forms.RadioButton();
            this.chkmobile = new System.Windows.Forms.CheckBox();
            this.chktel = new System.Windows.Forms.CheckBox();
            this.chkname = new System.Windows.Forms.CheckBox();
            this.btncount = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtserch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rdosuppliers = new System.Windows.Forms.RadioButton();
            this.rdocustomers = new System.Windows.Forms.RadioButton();
            this.btnadd = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpersonlist)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel3);
            this.panelEx1.Controls.Add(this.groupPanel2);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(2, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Padding = new System.Windows.Forms.Padding(10);
            this.panelEx1.Size = new System.Drawing.Size(1180, 587);
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
            this.groupPanel3.Controls.Add(this.btnedit);
            this.groupPanel3.Controls.Add(this.btnclose);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel3.Location = new System.Drawing.Point(10, 537);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1160, 40);
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
            this.btndelete.Location = new System.Drawing.Point(97, 2);
            this.btndelete.Name = "btndelete";
            this.btndelete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btndelete.Size = new System.Drawing.Size(131, 30);
            this.btndelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btndelete.TabIndex = 1;
            this.btndelete.Text = "Delete Product";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnedit
            // 
            this.btnedit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnedit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnedit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.Location = new System.Drawing.Point(1043, 2);
            this.btnedit.Name = "btnedit";
            this.btnedit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnedit.Size = new System.Drawing.Size(106, 30);
            this.btnedit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnedit.TabIndex = 0;
            this.btnedit.Text = "Edit User";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnclose
            // 
            this.btnclose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnclose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(5, 2);
            this.btnclose.Name = "btnclose";
            this.btnclose.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnclose.Size = new System.Drawing.Size(86, 30);
            this.btnclose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnclose.TabIndex = 2;
            this.btnclose.Text = "  Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.White;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgvpersonlist);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(10, 83);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.groupPanel2.Size = new System.Drawing.Size(1160, 448);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            // 
            // dgvpersonlist
            // 
            this.dgvpersonlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvpersonlist.BackgroundColor = System.Drawing.Color.White;
            this.dgvpersonlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvpersonlist.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvpersonlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvpersonlist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvpersonlist.Location = new System.Drawing.Point(5, 5);
            this.dgvpersonlist.MultiSelect = false;
            this.dgvpersonlist.Name = "dgvpersonlist";
            this.dgvpersonlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvpersonlist.Size = new System.Drawing.Size(1144, 432);
            this.dgvpersonlist.TabIndex = 0;
            this.dgvpersonlist.SelectionChanged += new System.EventHandler(this.dgvpersonlist_SelectionChanged);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.rdoallperson);
            this.groupPanel1.Controls.Add(this.chkmobile);
            this.groupPanel1.Controls.Add(this.chktel);
            this.groupPanel1.Controls.Add(this.chkname);
            this.groupPanel1.Controls.Add(this.btncount);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.txtserch);
            this.groupPanel1.Controls.Add(this.rdosuppliers);
            this.groupPanel1.Controls.Add(this.rdocustomers);
            this.groupPanel1.Controls.Add(this.btnadd);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(10, 10);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1160, 73);
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
            // rdoallperson
            // 
            this.rdoallperson.AutoSize = true;
            this.rdoallperson.Location = new System.Drawing.Point(5, 16);
            this.rdoallperson.Name = "rdoallperson";
            this.rdoallperson.Size = new System.Drawing.Size(72, 17);
            this.rdoallperson.TabIndex = 62;
            this.rdoallperson.Text = "All Person";
            this.rdoallperson.UseVisualStyleBackColor = true;
            this.rdoallperson.CheckedChanged += new System.EventHandler(this.rdoallperson_CheckedChanged);
            // 
            // chkmobile
            // 
            this.chkmobile.AutoSize = true;
            this.chkmobile.Location = new System.Drawing.Point(631, 39);
            this.chkmobile.Name = "chkmobile";
            this.chkmobile.Size = new System.Drawing.Size(98, 17);
            this.chkmobile.TabIndex = 61;
            this.chkmobile.Text = "Filter By Mobile";
            this.chkmobile.UseVisualStyleBackColor = true;
            // 
            // chktel
            // 
            this.chktel.AutoSize = true;
            this.chktel.Location = new System.Drawing.Point(480, 39);
            this.chktel.Name = "chktel";
            this.chktel.Size = new System.Drawing.Size(82, 17);
            this.chktel.TabIndex = 60;
            this.chktel.Text = "Filter By Tel";
            this.chktel.UseVisualStyleBackColor = true;
            // 
            // chkname
            // 
            this.chkname.AutoSize = true;
            this.chkname.Location = new System.Drawing.Point(316, 39);
            this.chkname.Name = "chkname";
            this.chkname.Size = new System.Drawing.Size(95, 17);
            this.chkname.TabIndex = 59;
            this.chkname.Text = "Filter By Name";
            this.chkname.UseVisualStyleBackColor = true;
            // 
            // btncount
            // 
            this.btncount.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncount.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncount.Location = new System.Drawing.Point(824, 3);
            this.btncount.Name = "btncount";
            this.btncount.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btncount.Size = new System.Drawing.Size(35, 35);
            this.btncount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncount.TabIndex = 58;
            this.btncount.Text = "0";
            this.btncount.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(735, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Person Count :";
            // 
            // txtserch
            // 
            this.txtserch.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtserch.Border.Class = "TextBoxBorder";
            this.txtserch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtserch.DisabledBackColor = System.Drawing.Color.White;
            this.txtserch.ForeColor = System.Drawing.Color.Black;
            this.txtserch.Location = new System.Drawing.Point(316, 12);
            this.txtserch.Name = "txtserch";
            this.txtserch.PreventEnterBeep = true;
            this.txtserch.Size = new System.Drawing.Size(413, 21);
            this.txtserch.TabIndex = 3;
            this.txtserch.WatermarkText = "Search Name and Family of Person...";
            this.txtserch.TextChanged += new System.EventHandler(this.txtserch_TextChanged);
            // 
            // rdosuppliers
            // 
            this.rdosuppliers.AutoSize = true;
            this.rdosuppliers.Location = new System.Drawing.Point(224, 16);
            this.rdosuppliers.Name = "rdosuppliers";
            this.rdosuppliers.Size = new System.Drawing.Size(68, 17);
            this.rdosuppliers.TabIndex = 2;
            this.rdosuppliers.Text = "Suppliers";
            this.rdosuppliers.UseVisualStyleBackColor = true;
            // 
            // rdocustomers
            // 
            this.rdocustomers.AutoSize = true;
            this.rdocustomers.Location = new System.Drawing.Point(110, 16);
            this.rdocustomers.Name = "rdocustomers";
            this.rdocustomers.Size = new System.Drawing.Size(76, 17);
            this.rdocustomers.TabIndex = 1;
            this.rdocustomers.Text = "Customers";
            this.rdocustomers.UseVisualStyleBackColor = true;
            // 
            // btnadd
            // 
            this.btnadd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnadd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.Image")));
            this.btnadd.Location = new System.Drawing.Point(1043, 12);
            this.btnadd.Name = "btnadd";
            this.btnadd.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnadd.Size = new System.Drawing.Size(106, 30);
            this.btnadd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnadd.TabIndex = 1;
            this.btnadd.Text = "Add Product";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // FrmShowPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(66)))), ((int)(((byte)(55)))));
            this.CancelButton = this.btnclose;
            this.ClientSize = new System.Drawing.Size(1184, 591);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmShowPeople";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmShowPeople_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpersonlist)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvpersonlist;
        public DevComponents.DotNetBar.ButtonX btnadd;
        private System.Windows.Forms.RadioButton rdosuppliers;
        private System.Windows.Forms.RadioButton rdocustomers;
        private DevComponents.DotNetBar.Controls.TextBoxX txtserch;
        public DevComponents.DotNetBar.ButtonX btndelete;
        public DevComponents.DotNetBar.ButtonX btnedit;
        public DevComponents.DotNetBar.ButtonX btnclose;
        public DevComponents.DotNetBar.ButtonX btncount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkmobile;
        private System.Windows.Forms.CheckBox chktel;
        private System.Windows.Forms.CheckBox chkname;
        private System.Windows.Forms.RadioButton rdoallperson;
    }
}