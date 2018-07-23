namespace POFtpSender
{
    partial class frmTestConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestConnection));
            this.btnTes = new System.Windows.Forms.Button();
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.tbAPI = new System.Windows.Forms.TextBox();
            this.bgwTesKoneksi = new System.ComponentModel.BackgroundWorker();
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnTes
            // 
            this.btnTes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTes.ImageIndex = 6;
            this.btnTes.ImageList = this.imgSmall;
            this.btnTes.Location = new System.Drawing.Point(22, 39);
            this.btnTes.Name = "btnTes";
            this.btnTes.Size = new System.Drawing.Size(97, 31);
            this.btnTes.TabIndex = 0;
            this.btnTes.Text = "Tes Koneksi";
            this.btnTes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTes.UseVisualStyleBackColor = true;
            this.btnTes.Click += new System.EventHandler(this.btnTes_Click);
            // 
            // imgSmall
            // 
            this.imgSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSmall.ImageStream")));
            this.imgSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSmall.Images.SetKeyName(0, "9308.png");
            this.imgSmall.Images.SetKeyName(1, "save-icon-png--4.png");
            this.imgSmall.Images.SetKeyName(2, "532.png");
            this.imgSmall.Images.SetKeyName(3, "ms_excel1600.png");
            this.imgSmall.Images.SetKeyName(4, "Minus.png");
            this.imgSmall.Images.SetKeyName(5, "Plus.png");
            this.imgSmall.Images.SetKeyName(6, "sharingIcon-e1364762257551.png");
            this.imgSmall.Images.SetKeyName(7, "open.png");
            // 
            // tbAPI
            // 
            this.tbAPI.Location = new System.Drawing.Point(22, 13);
            this.tbAPI.Name = "tbAPI";
            this.tbAPI.ReadOnly = true;
            this.tbAPI.Size = new System.Drawing.Size(392, 20);
            this.tbAPI.TabIndex = 1;
            // 
            // bgwTesKoneksi
            // 
            this.bgwTesKoneksi.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTesKoneksi_DoWork);
            this.bgwTesKoneksi.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTesKoneksi_RunWorkerCompleted);
            // 
            // pbLoading
            // 
            this.pbLoading.Location = new System.Drawing.Point(270, 50);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(144, 16);
            this.pbLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbLoading.TabIndex = 2;
            // 
            // frmTestConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 78);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.tbAPI);
            this.Controls.Add(this.btnTes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTestConnection";
            this.Text = "Koneksi Server BPKPD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTestConnection_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTes;
        private System.Windows.Forms.TextBox tbAPI;
        private System.Windows.Forms.ImageList imgSmall;
        private System.ComponentModel.BackgroundWorker bgwTesKoneksi;
        private System.Windows.Forms.ProgressBar pbLoading;
    }
}