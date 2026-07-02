namespace SSG.Users_Forms
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lblloading = new System.Windows.Forms.Label();
            this.lblwellcome = new System.Windows.Forms.Label();
            this.btncnacel = new DevComponents.DotNetBar.ButtonX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panel1);
            this.panelEx1.Controls.Add(this.progressBarX1);
            this.panelEx1.Controls.Add(this.lblloading);
            this.panelEx1.Controls.Add(this.lblwellcome);
            this.panelEx1.Controls.Add(this.btncnacel);
            this.panelEx1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(2, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Padding = new System.Windows.Forms.Padding(10);
            this.panelEx1.Size = new System.Drawing.Size(684, 467);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(125, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 314);
            this.panel1.TabIndex = 16;
            this.panel1.Visible = false;
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Location = new System.Drawing.Point(125, 385);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(434, 33);
            this.progressBarX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.progressBarX1.TabIndex = 15;
            this.progressBarX1.Text = "progressBarX1";
            // 
            // lblloading
            // 
            this.lblloading.AutoSize = true;
            this.lblloading.Location = new System.Drawing.Point(294, 198);
            this.lblloading.Name = "lblloading";
            this.lblloading.Size = new System.Drawing.Size(123, 13);
            this.lblloading.TabIndex = 13;
            this.lblloading.Text = "Application Is Loading...";
            // 
            // lblwellcome
            // 
            this.lblwellcome.AutoSize = true;
            this.lblwellcome.Location = new System.Drawing.Point(236, 198);
            this.lblwellcome.Name = "lblwellcome";
            this.lblwellcome.Size = new System.Drawing.Size(235, 13);
            this.lblwellcome.TabIndex = 14;
            this.lblwellcome.Text = "Wellcome To Accounting Management Software";
            this.lblwellcome.Visible = false;
            // 
            // btncnacel
            // 
            this.btncnacel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncnacel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncnacel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncnacel.FocusCuesEnabled = false;
            this.btncnacel.Image = ((System.Drawing.Image)(resources.GetObject("btncnacel.Image")));
            this.btncnacel.Location = new System.Drawing.Point(259, 424);
            this.btncnacel.Name = "btncnacel";
            this.btncnacel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 3, 3, 10);
            this.btncnacel.Size = new System.Drawing.Size(174, 30);
            this.btncnacel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncnacel.TabIndex = 12;
            this.btncnacel.Text = "Cancel program opening";
            this.btncnacel.Visible = false;
            this.btncnacel.Click += new System.EventHandler(this.btncnacel_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.OfficeMobile2014;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(71)))), ((int)(((byte)(42))))));
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(66)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(688, 471);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseDown);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        public DevComponents.DotNetBar.ButtonX btncnacel;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private System.Windows.Forms.Label lblloading;
        private System.Windows.Forms.Label lblwellcome;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}