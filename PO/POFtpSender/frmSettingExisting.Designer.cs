namespace POFtpSender
{
    partial class frmSettingExisting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettingExisting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbGuid = new System.Windows.Forms.TextBox();
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.btnTesUpload = new System.Windows.Forms.Button();
            this.pbProccess = new System.Windows.Forms.ProgressBar();
            this.bgwLoad = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbGuid);
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Controls.Add(this.tbUrl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Validasi User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "URL Web API";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Username";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbUrl
            // 
            this.tbUrl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUrl.Location = new System.Drawing.Point(121, 24);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(258, 22);
            this.tbUrl.TabIndex = 18;
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(121, 50);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(258, 22);
            this.tbUsername.TabIndex = 19;
            // 
            // tbGuid
            // 
            this.tbGuid.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGuid.Location = new System.Drawing.Point(121, 76);
            this.tbGuid.Multiline = true;
            this.tbGuid.Name = "tbGuid";
            this.tbGuid.Size = new System.Drawing.Size(258, 53);
            this.tbGuid.TabIndex = 20;
            // 
            // imgSmall
            // 
            this.imgSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSmall.ImageStream")));
            this.imgSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSmall.Images.SetKeyName(0, "83825-200.png");
            this.imgSmall.Images.SetKeyName(1, "9308.png");
            this.imgSmall.Images.SetKeyName(2, "save-icon-png--4.png");
            this.imgSmall.Images.SetKeyName(3, "532.png");
            this.imgSmall.Images.SetKeyName(4, "ms_excel1600.png");
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.ImageKey = "9308.png";
            this.btnOk.ImageList = this.imgSmall;
            this.btnOk.Location = new System.Drawing.Point(328, 156);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 30);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "Batal";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnTesUpload
            // 
            this.btnTesUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTesUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTesUpload.ImageKey = "532.png";
            this.btnTesUpload.ImageList = this.imgSmall;
            this.btnTesUpload.Location = new System.Drawing.Point(241, 156);
            this.btnTesUpload.Name = "btnTesUpload";
            this.btnTesUpload.Size = new System.Drawing.Size(81, 30);
            this.btnTesUpload.TabIndex = 17;
            this.btnTesUpload.Text = "Buat XML";
            this.btnTesUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTesUpload.UseVisualStyleBackColor = true;
            this.btnTesUpload.Click += new System.EventHandler(this.btnTesUpload_Click);
            // 
            // pbProccess
            // 
            this.pbProccess.Location = new System.Drawing.Point(12, 168);
            this.pbProccess.Name = "pbProccess";
            this.pbProccess.Size = new System.Drawing.Size(200, 18);
            this.pbProccess.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbProccess.TabIndex = 19;
            // 
            // bgwLoad
            // 
            this.bgwLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoad_DoWork);
            this.bgwLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoad_RunWorkerCompleted);
            // 
            // frmSettingExisting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 198);
            this.Controls.Add(this.pbProccess);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnTesUpload);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSettingExisting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Ulang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGuid;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.ImageList imgSmall;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnTesUpload;
        private System.Windows.Forms.ProgressBar pbProccess;
        private System.ComponentModel.BackgroundWorker bgwLoad;
    }
}