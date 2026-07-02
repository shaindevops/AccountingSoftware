namespace SSG
{
    partial class FrmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplash));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.T1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblwhatsapp = new System.Windows.Forms.Label();
            this.lblwebsite = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // T1
            // 
            this.T1.Interval = 3000;
            this.T1.Tick += new System.EventHandler(this.T1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(29, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Design and development by Devpars software collection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(29, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contact us :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(209, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Website :";
            // 
            // lblwhatsapp
            // 
            this.lblwhatsapp.AutoSize = true;
            this.lblwhatsapp.BackColor = System.Drawing.Color.Transparent;
            this.lblwhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblwhatsapp.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblwhatsapp.ForeColor = System.Drawing.Color.Blue;
            this.lblwhatsapp.Location = new System.Drawing.Point(101, 383);
            this.lblwhatsapp.Name = "lblwhatsapp";
            this.lblwhatsapp.Size = new System.Drawing.Size(99, 13);
            this.lblwhatsapp.TabIndex = 4;
            this.lblwhatsapp.Text = "+98-990-282-7506";
            this.lblwhatsapp.Click += new System.EventHandler(this.lblwhatsapp_Click);
            // 
            // lblwebsite
            // 
            this.lblwebsite.AutoSize = true;
            this.lblwebsite.BackColor = System.Drawing.Color.Transparent;
            this.lblwebsite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblwebsite.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblwebsite.ForeColor = System.Drawing.Color.Blue;
            this.lblwebsite.Location = new System.Drawing.Point(265, 384);
            this.lblwebsite.Name = "lblwebsite";
            this.lblwebsite.Size = new System.Drawing.Size(84, 13);
            this.lblwebsite.TabIndex = 5;
            this.lblwebsite.Text = "www.devpars.ir";
            this.lblwebsite.Click += new System.EventHandler(this.lblwebsite_Click);
            // 
            // FrmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(373, 406);
            this.ControlBox = false;
            this.Controls.Add(this.lblwebsite);
            this.Controls.Add(this.lblwhatsapp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.FrmSplash_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer T1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblwhatsapp;
        private System.Windows.Forms.Label lblwebsite;
    }
}