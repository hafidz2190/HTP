namespace POFtpSender
{
    partial class frmOpsiFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpsiFile));
            this.rbExcel = new System.Windows.Forms.RadioButton();
            this.imgRadioButton = new System.Windows.Forms.ImageList(this.components);
            this.rbTxtFile = new System.Windows.Forms.RadioButton();
            this.rbCsvFile = new System.Windows.Forms.RadioButton();
            this.tbSeparator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbKeterangan = new System.Windows.Forms.TextBox();
            this.lblOpsi = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbExcel
            // 
            this.rbExcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExcel.ImageIndex = 2;
            this.rbExcel.ImageList = this.imgRadioButton;
            this.rbExcel.Location = new System.Drawing.Point(16, 6);
            this.rbExcel.Name = "rbExcel";
            this.rbExcel.Size = new System.Drawing.Size(82, 53);
            this.rbExcel.TabIndex = 0;
            this.rbExcel.TabStop = true;
            this.rbExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbExcel.UseVisualStyleBackColor = true;
            this.rbExcel.CheckedChanged += new System.EventHandler(this.rbExcel_CheckedChanged);
            // 
            // imgRadioButton
            // 
            this.imgRadioButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgRadioButton.ImageStream")));
            this.imgRadioButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imgRadioButton.Images.SetKeyName(0, "csv.png");
            this.imgRadioButton.Images.SetKeyName(1, "txt.png");
            this.imgRadioButton.Images.SetKeyName(2, "xls-file-format-symbol-30.png");
            // 
            // rbTxtFile
            // 
            this.rbTxtFile.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTxtFile.ImageIndex = 1;
            this.rbTxtFile.ImageList = this.imgRadioButton;
            this.rbTxtFile.Location = new System.Drawing.Point(211, 6);
            this.rbTxtFile.Name = "rbTxtFile";
            this.rbTxtFile.Size = new System.Drawing.Size(76, 53);
            this.rbTxtFile.TabIndex = 1;
            this.rbTxtFile.TabStop = true;
            this.rbTxtFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbTxtFile.UseVisualStyleBackColor = true;
            this.rbTxtFile.CheckedChanged += new System.EventHandler(this.rbTxtFile_CheckedChanged);
            // 
            // rbCsvFile
            // 
            this.rbCsvFile.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCsvFile.ImageIndex = 0;
            this.rbCsvFile.ImageList = this.imgRadioButton;
            this.rbCsvFile.Location = new System.Drawing.Point(117, 6);
            this.rbCsvFile.Name = "rbCsvFile";
            this.rbCsvFile.Size = new System.Drawing.Size(75, 53);
            this.rbCsvFile.TabIndex = 2;
            this.rbCsvFile.TabStop = true;
            this.rbCsvFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbCsvFile.UseVisualStyleBackColor = true;
            this.rbCsvFile.CheckedChanged += new System.EventHandler(this.rbCsvFile_CheckedChanged);
            // 
            // tbSeparator
            // 
            this.tbSeparator.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSeparator.Location = new System.Drawing.Point(109, 68);
            this.tbSeparator.Name = "tbSeparator";
            this.tbSeparator.Size = new System.Drawing.Size(37, 26);
            this.tbSeparator.TabIndex = 3;
            this.tbSeparator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSeparator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSeparator_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Separator";
            // 
            // btnOk
            // 
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.ImageIndex = 1;
            this.btnOk.ImageList = this.imgSmall;
            this.btnOk.Location = new System.Drawing.Point(134, 249);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(74, 31);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImageIndex = 0;
            this.btnCancel.ImageList = this.imgSmall;
            this.btnCancel.Location = new System.Drawing.Point(214, 249);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbKeterangan);
            this.panel1.Controls.Add(this.lblOpsi);
            this.panel1.Location = new System.Drawing.Point(13, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 145);
            this.panel1.TabIndex = 7;
            // 
            // tbKeterangan
            // 
            this.tbKeterangan.BackColor = System.Drawing.Color.White;
            this.tbKeterangan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbKeterangan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKeterangan.Location = new System.Drawing.Point(6, 28);
            this.tbKeterangan.Multiline = true;
            this.tbKeterangan.Name = "tbKeterangan";
            this.tbKeterangan.ReadOnly = true;
            this.tbKeterangan.Size = new System.Drawing.Size(265, 112);
            this.tbKeterangan.TabIndex = 6;
            // 
            // lblOpsi
            // 
            this.lblOpsi.AutoSize = true;
            this.lblOpsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpsi.Location = new System.Drawing.Point(3, 2);
            this.lblOpsi.Name = "lblOpsi";
            this.lblOpsi.Size = new System.Drawing.Size(77, 16);
            this.lblOpsi.TabIndex = 5;
            this.lblOpsi.Text = "Separator";
            // 
            // frmOpsiFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(301, 289);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSeparator);
            this.Controls.Add(this.rbCsvFile);
            this.Controls.Add(this.rbTxtFile);
            this.Controls.Add(this.rbExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmOpsiFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pilihan Data File";
            this.Load += new System.EventHandler(this.frmOpsiFile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbExcel;
        private System.Windows.Forms.RadioButton rbTxtFile;
        private System.Windows.Forms.RadioButton rbCsvFile;
        private System.Windows.Forms.TextBox tbSeparator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbKeterangan;
        private System.Windows.Forms.Label lblOpsi;
        private System.Windows.Forms.ImageList imgSmall;
        private System.Windows.Forms.ImageList imgRadioButton;
    }
}