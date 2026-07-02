namespace SSG.Users_Forms
{
    partial class FrmUserlogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserlogs));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnclose = new DevComponents.DotNetBar.ButtonX();
            this.grpshowlogs = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvshowuserlogs = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.grpshowlogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvshowuserlogs)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel2);
            this.panelEx1.Controls.Add(this.grpshowlogs);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(2, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(613, 533);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.White;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnclose);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(12, 485);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(593, 40);
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
            // btnclose
            // 
            this.btnclose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnclose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(498, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btnclose.Size = new System.Drawing.Size(86, 30);
            this.btnclose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnclose.TabIndex = 0;
            this.btnclose.Text = "Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // grpshowlogs
            // 
            this.grpshowlogs.BackColor = System.Drawing.Color.White;
            this.grpshowlogs.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpshowlogs.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpshowlogs.Controls.Add(this.dgvshowuserlogs);
            this.grpshowlogs.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpshowlogs.Location = new System.Drawing.Point(12, 12);
            this.grpshowlogs.Name = "grpshowlogs";
            this.grpshowlogs.Size = new System.Drawing.Size(593, 467);
            // 
            // 
            // 
            this.grpshowlogs.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grpshowlogs.Style.BackColorGradientAngle = 90;
            this.grpshowlogs.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grpshowlogs.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpshowlogs.Style.BorderBottomWidth = 1;
            this.grpshowlogs.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpshowlogs.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpshowlogs.Style.BorderLeftWidth = 1;
            this.grpshowlogs.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpshowlogs.Style.BorderRightWidth = 1;
            this.grpshowlogs.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpshowlogs.Style.BorderTopWidth = 1;
            this.grpshowlogs.Style.CornerDiameter = 4;
            this.grpshowlogs.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpshowlogs.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpshowlogs.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpshowlogs.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpshowlogs.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpshowlogs.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpshowlogs.TabIndex = 0;
            this.grpshowlogs.Text = "Show Entry and Exit";
            // 
            // dgvshowuserlogs
            // 
            this.dgvshowuserlogs.AllowUserToAddRows = false;
            this.dgvshowuserlogs.AllowUserToDeleteRows = false;
            this.dgvshowuserlogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvshowuserlogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvshowuserlogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvshowuserlogs.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvshowuserlogs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvshowuserlogs.Location = new System.Drawing.Point(3, 3);
            this.dgvshowuserlogs.Name = "dgvshowuserlogs";
            this.dgvshowuserlogs.ReadOnly = true;
            this.dgvshowuserlogs.Size = new System.Drawing.Size(581, 439);
            this.dgvshowuserlogs.TabIndex = 0;
            // 
            // FrmUserlogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(66)))), ((int)(((byte)(55)))));
            this.CancelButton = this.btnclose;
            this.ClientSize = new System.Drawing.Size(617, 537);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmUserlogs";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmUserlogs_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.grpshowlogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvshowuserlogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        public DevComponents.DotNetBar.ButtonX btnclose;
        public DevComponents.DotNetBar.Controls.DataGridViewX dgvshowuserlogs;
        public DevComponents.DotNetBar.Controls.GroupPanel grpshowlogs;
    }
}