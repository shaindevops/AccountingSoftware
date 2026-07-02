namespace SSG.Tasks_Forms
{
    partial class FrmShowTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowTasks));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btndelete = new DevComponents.DotNetBar.ButtonX();
            this.btnclose = new DevComponents.DotNetBar.ButtonX();
            this.btnisdone = new DevComponents.DotNetBar.ButtonX();
            this.btnedit = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btntaskstodaycount = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.btnnotdonecount = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.btnisdonecount = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.btnallcount = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvtasks = new System.Windows.Forms.DataGridView();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnadd = new DevComponents.DotNetBar.ButtonX();
            this.chkIsdone = new System.Windows.Forms.RadioButton();
            this.chkinproccess = new System.Windows.Forms.RadioButton();
            this.chkall = new System.Windows.Forms.RadioButton();
            this.panelEx1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtasks)).BeginInit();
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
            this.panelEx1.Size = new System.Drawing.Size(1077, 598);
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
            this.groupPanel3.Controls.Add(this.btnclose);
            this.groupPanel3.Controls.Add(this.btnisdone);
            this.groupPanel3.Controls.Add(this.btnedit);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(13, 545);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1051, 40);
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
            this.groupPanel3.TabIndex = 0;
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
            this.btndelete.Size = new System.Drawing.Size(106, 30);
            this.btndelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btndelete.TabIndex = 5;
            this.btndelete.Text = "Delete Task";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
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
            this.btnclose.TabIndex = 6;
            this.btnclose.Text = "  Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnisdone
            // 
            this.btnisdone.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnisdone.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnisdone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnisdone.Image = ((System.Drawing.Image)(resources.GetObject("btnisdone.Image")));
            this.btnisdone.Location = new System.Drawing.Point(809, 1);
            this.btnisdone.Name = "btnisdone";
            this.btnisdone.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnisdone.Size = new System.Drawing.Size(114, 30);
            this.btnisdone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnisdone.TabIndex = 4;
            this.btnisdone.Text = "Is Done";
            this.btnisdone.Click += new System.EventHandler(this.btnisdone_Click);
            // 
            // btnedit
            // 
            this.btnedit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnedit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnedit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.Location = new System.Drawing.Point(929, 1);
            this.btnedit.Name = "btnedit";
            this.btnedit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnedit.Size = new System.Drawing.Size(106, 30);
            this.btnedit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnedit.TabIndex = 4;
            this.btnedit.Text = "Edit Task";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.White;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btntaskstodaycount);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.btnnotdonecount);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.btnisdonecount);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.btnallcount);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.dgvtasks);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(13, 70);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.groupPanel2.Size = new System.Drawing.Size(1051, 469);
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
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Text = "Show All Tasks";
            // 
            // btntaskstodaycount
            // 
            this.btntaskstodaycount.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btntaskstodaycount.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btntaskstodaycount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntaskstodaycount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntaskstodaycount.Location = new System.Drawing.Point(1000, 407);
            this.btntaskstodaycount.Name = "btntaskstodaycount";
            this.btntaskstodaycount.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btntaskstodaycount.Size = new System.Drawing.Size(35, 35);
            this.btntaskstodaycount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btntaskstodaycount.TabIndex = 60;
            this.btntaskstodaycount.Text = "0";
            this.btntaskstodaycount.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(872, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "All Tasks Today Count :";
            // 
            // btnnotdonecount
            // 
            this.btnnotdonecount.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnnotdonecount.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnnotdonecount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnnotdonecount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnotdonecount.Location = new System.Drawing.Point(700, 407);
            this.btnnotdonecount.Name = "btnnotdonecount";
            this.btnnotdonecount.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnnotdonecount.Size = new System.Drawing.Size(35, 35);
            this.btnnotdonecount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnnotdonecount.TabIndex = 60;
            this.btnnotdonecount.Text = "0";
            this.btnnotdonecount.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(565, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "All Not Done Tasks Count :";
            // 
            // btnisdonecount
            // 
            this.btnisdonecount.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnisdonecount.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnisdonecount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnisdonecount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnisdonecount.Location = new System.Drawing.Point(400, 407);
            this.btnisdonecount.Name = "btnisdonecount";
            this.btnisdonecount.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnisdonecount.Size = new System.Drawing.Size(35, 35);
            this.btnisdonecount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnisdonecount.TabIndex = 60;
            this.btnisdonecount.Text = "0";
            this.btnisdonecount.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "All Is Done Tasks Count :";
            // 
            // btnallcount
            // 
            this.btnallcount.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnallcount.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnallcount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnallcount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnallcount.Location = new System.Drawing.Point(100, 407);
            this.btnallcount.Name = "btnallcount";
            this.btnallcount.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnallcount.Size = new System.Drawing.Size(35, 35);
            this.btnallcount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnallcount.TabIndex = 60;
            this.btnallcount.Text = "0";
            this.btnallcount.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "All Tasks Count :";
            // 
            // dgvtasks
            // 
            this.dgvtasks.AllowUserToAddRows = false;
            this.dgvtasks.AllowUserToDeleteRows = false;
            this.dgvtasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvtasks.BackgroundColor = System.Drawing.Color.White;
            this.dgvtasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvtasks.Location = new System.Drawing.Point(10, 10);
            this.dgvtasks.Name = "dgvtasks";
            this.dgvtasks.ReadOnly = true;
            this.dgvtasks.Size = new System.Drawing.Size(1025, 391);
            this.dgvtasks.TabIndex = 0;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.chkinproccess);
            this.groupPanel1.Controls.Add(this.chkall);
            this.groupPanel1.Controls.Add(this.chkIsdone);
            this.groupPanel1.Controls.Add(this.btnadd);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(13, 13);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1051, 51);
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
            this.btnadd.Location = new System.Drawing.Point(929, 7);
            this.btnadd.Name = "btnadd";
            this.btnadd.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnadd.Size = new System.Drawing.Size(106, 30);
            this.btnadd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnadd.TabIndex = 2;
            this.btnadd.Text = "Add Task";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // chkIsdone
            // 
            this.chkIsdone.AutoSize = true;
            this.chkIsdone.Location = new System.Drawing.Point(126, 20);
            this.chkIsdone.Name = "chkIsdone";
            this.chkIsdone.Size = new System.Drawing.Size(92, 17);
            this.chkIsdone.TabIndex = 3;
            this.chkIsdone.TabStop = true;
            this.chkIsdone.Text = "Is Done Tasks";
            this.chkIsdone.UseVisualStyleBackColor = true;
            this.chkIsdone.CheckedChanged += new System.EventHandler(this.chkIsdone_CheckedChanged_1);
            // 
            // chkinproccess
            // 
            this.chkinproccess.AutoSize = true;
            this.chkinproccess.Location = new System.Drawing.Point(268, 20);
            this.chkinproccess.Name = "chkinproccess";
            this.chkinproccess.Size = new System.Drawing.Size(105, 17);
            this.chkinproccess.TabIndex = 3;
            this.chkinproccess.TabStop = true;
            this.chkinproccess.Text = "In Process Tasks";
            this.chkinproccess.UseVisualStyleBackColor = true;
            this.chkinproccess.CheckedChanged += new System.EventHandler(this.chkinproccess_CheckedChanged);
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Location = new System.Drawing.Point(10, 20);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(66, 17);
            this.chkall.TabIndex = 3;
            this.chkall.TabStop = true;
            this.chkall.Text = "All Tasks";
            this.chkall.UseVisualStyleBackColor = true;
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // FrmShowTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(66)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(1081, 602);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmShowTasks";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmShowTasks_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtasks)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.DataGridView dgvtasks;
        public DevComponents.DotNetBar.ButtonX btnadd;
        public DevComponents.DotNetBar.ButtonX btndelete;
        public DevComponents.DotNetBar.ButtonX btnclose;
        public DevComponents.DotNetBar.ButtonX btnedit;
        public DevComponents.DotNetBar.ButtonX btnisdone;
        public DevComponents.DotNetBar.ButtonX btntaskstodaycount;
        private System.Windows.Forms.Label label4;
        public DevComponents.DotNetBar.ButtonX btnnotdonecount;
        private System.Windows.Forms.Label label3;
        public DevComponents.DotNetBar.ButtonX btnisdonecount;
        private System.Windows.Forms.Label label2;
        public DevComponents.DotNetBar.ButtonX btnallcount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton chkinproccess;
        private System.Windows.Forms.RadioButton chkIsdone;
        private System.Windows.Forms.RadioButton chkall;
    }
}