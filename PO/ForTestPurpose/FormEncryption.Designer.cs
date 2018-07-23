namespace ForTestPurpose
{
    partial class FormEncryption
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
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tbResultEncrypted = new System.Windows.Forms.RichTextBox();
      this.lblStringLength = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.btnEncrypt = new System.Windows.Forms.Button();
      this.tbEncryptedPassword = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tbPlainText = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tbResultDecrypted = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btnDecrypt = new System.Windows.Forms.Button();
      this.tbDecryptPassword = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.tbEncryptedText = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.lblFileEncMessage = new System.Windows.Forms.Label();
      this.btnEncryptFile = new System.Windows.Forms.Button();
      this.tbFileEncResult = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.btnBrowseEnc = new System.Windows.Forms.Button();
      this.tbFileEncSource = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.tabPage4 = new System.Windows.Forms.TabPage();
      this.lblFileDecMessage = new System.Windows.Forms.Label();
      this.btnDecryptFile = new System.Windows.Forms.Button();
      this.tbFileDecResult = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.btnBrowseDec = new System.Windows.Forms.Button();
      this.tbFileDecSource = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.tabPage5 = new System.Windows.Forms.TabPage();
      this.btnReadXML = new System.Windows.Forms.Button();
      this.tbResultXML = new System.Windows.Forms.TextBox();
      this.button2 = new System.Windows.Forms.Button();
      this.tbPathXML = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.ofdXML = new System.Windows.Forms.OpenFileDialog();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.tabPage4.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Controls.Add(this.tabPage4);
      this.tabControl1.Controls.Add(this.tabPage5);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(783, 314);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.tbResultEncrypted);
      this.tabPage1.Controls.Add(this.lblStringLength);
      this.tabPage1.Controls.Add(this.label6);
      this.tabPage1.Controls.Add(this.btnEncrypt);
      this.tabPage1.Controls.Add(this.tbEncryptedPassword);
      this.tabPage1.Controls.Add(this.label2);
      this.tabPage1.Controls.Add(this.tbPlainText);
      this.tabPage1.Controls.Add(this.label1);
      this.tabPage1.Location = new System.Drawing.Point(4, 29);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
      this.tabPage1.Size = new System.Drawing.Size(775, 281);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Encrypt Data";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tbResultEncrypted
      // 
      this.tbResultEncrypted.Location = new System.Drawing.Point(105, 95);
      this.tbResultEncrypted.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tbResultEncrypted.Name = "tbResultEncrypted";
      this.tbResultEncrypted.Size = new System.Drawing.Size(661, 135);
      this.tbResultEncrypted.TabIndex = 7;
      this.tbResultEncrypted.Text = "";
      // 
      // lblStringLength
      // 
      this.lblStringLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblStringLength.AutoSize = true;
      this.lblStringLength.Location = new System.Drawing.Point(100, 246);
      this.lblStringLength.Name = "lblStringLength";
      this.lblStringLength.Size = new System.Drawing.Size(90, 20);
      this.lblStringLength.TabIndex = 6;
      this.lblStringLength.Text = "Length : {0}";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(8, 95);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(81, 20);
      this.label6.TabIndex = 6;
      this.label6.Text = "Encrypted";
      // 
      // btnEncrypt
      // 
      this.btnEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnEncrypt.Location = new System.Drawing.Point(632, 240);
      this.btnEncrypt.Name = "btnEncrypt";
      this.btnEncrypt.Size = new System.Drawing.Size(135, 32);
      this.btnEncrypt.TabIndex = 5;
      this.btnEncrypt.Text = "Encrypt";
      this.btnEncrypt.UseVisualStyleBackColor = true;
      this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
      // 
      // tbEncryptedPassword
      // 
      this.tbEncryptedPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbEncryptedPassword.Location = new System.Drawing.Point(104, 55);
      this.tbEncryptedPassword.Name = "tbEncryptedPassword";
      this.tbEncryptedPassword.Size = new System.Drawing.Size(662, 26);
      this.tbEncryptedPassword.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(8, 58);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(78, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Password";
      // 
      // tbPlainText
      // 
      this.tbPlainText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbPlainText.Location = new System.Drawing.Point(104, 17);
      this.tbPlainText.Name = "tbPlainText";
      this.tbPlainText.Size = new System.Drawing.Size(662, 26);
      this.tbPlainText.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(77, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Plain Text";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.tbResultDecrypted);
      this.tabPage2.Controls.Add(this.label5);
      this.tabPage2.Controls.Add(this.btnDecrypt);
      this.tabPage2.Controls.Add(this.tbDecryptPassword);
      this.tabPage2.Controls.Add(this.label3);
      this.tabPage2.Controls.Add(this.tbEncryptedText);
      this.tabPage2.Controls.Add(this.label4);
      this.tabPage2.Location = new System.Drawing.Point(4, 29);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
      this.tabPage2.Size = new System.Drawing.Size(775, 281);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Decrypt Data";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // tbResultDecrypted
      // 
      this.tbResultDecrypted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbResultDecrypted.Location = new System.Drawing.Point(104, 95);
      this.tbResultDecrypted.Multiline = true;
      this.tbResultDecrypted.Name = "tbResultDecrypted";
      this.tbResultDecrypted.Size = new System.Drawing.Size(662, 139);
      this.tbResultDecrypted.TabIndex = 10;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(8, 98);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(77, 20);
      this.label5.TabIndex = 9;
      this.label5.Text = "Plain Text";
      // 
      // btnDecrypt
      // 
      this.btnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDecrypt.Location = new System.Drawing.Point(632, 240);
      this.btnDecrypt.Name = "btnDecrypt";
      this.btnDecrypt.Size = new System.Drawing.Size(135, 32);
      this.btnDecrypt.TabIndex = 8;
      this.btnDecrypt.Text = "Decrypt";
      this.btnDecrypt.UseVisualStyleBackColor = true;
      this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
      // 
      // tbDecryptPassword
      // 
      this.tbDecryptPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbDecryptPassword.Location = new System.Drawing.Point(104, 54);
      this.tbDecryptPassword.Name = "tbDecryptPassword";
      this.tbDecryptPassword.Size = new System.Drawing.Size(662, 26);
      this.tbDecryptPassword.TabIndex = 7;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(8, 57);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(78, 20);
      this.label3.TabIndex = 6;
      this.label3.Text = "Password";
      // 
      // tbEncryptedText
      // 
      this.tbEncryptedText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbEncryptedText.Location = new System.Drawing.Point(104, 15);
      this.tbEncryptedText.Name = "tbEncryptedText";
      this.tbEncryptedText.Size = new System.Drawing.Size(662, 26);
      this.tbEncryptedText.TabIndex = 5;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(8, 18);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(81, 20);
      this.label4.TabIndex = 4;
      this.label4.Text = "Encrypted";
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.lblFileEncMessage);
      this.tabPage3.Controls.Add(this.btnEncryptFile);
      this.tabPage3.Controls.Add(this.tbFileEncResult);
      this.tabPage3.Controls.Add(this.label8);
      this.tabPage3.Controls.Add(this.btnBrowseEnc);
      this.tabPage3.Controls.Add(this.tbFileEncSource);
      this.tabPage3.Controls.Add(this.label7);
      this.tabPage3.Location = new System.Drawing.Point(4, 29);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
      this.tabPage3.Size = new System.Drawing.Size(775, 281);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Encrypt File";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // lblFileEncMessage
      // 
      this.lblFileEncMessage.AutoSize = true;
      this.lblFileEncMessage.Location = new System.Drawing.Point(128, 152);
      this.lblFileEncMessage.Name = "lblFileEncMessage";
      this.lblFileEncMessage.Size = new System.Drawing.Size(82, 20);
      this.lblFileEncMessage.TabIndex = 6;
      this.lblFileEncMessage.Text = "[Message]";
      this.lblFileEncMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnEncryptFile
      // 
      this.btnEncryptFile.Location = new System.Drawing.Point(132, 100);
      this.btnEncryptFile.Name = "btnEncryptFile";
      this.btnEncryptFile.Size = new System.Drawing.Size(176, 42);
      this.btnEncryptFile.TabIndex = 5;
      this.btnEncryptFile.Text = "Start Encrypt File";
      this.btnEncryptFile.UseVisualStyleBackColor = true;
      this.btnEncryptFile.Click += new System.EventHandler(this.btnEncryptFile_Click);
      // 
      // tbFileEncResult
      // 
      this.tbFileEncResult.Location = new System.Drawing.Point(132, 58);
      this.tbFileEncResult.Name = "tbFileEncResult";
      this.tbFileEncResult.Size = new System.Drawing.Size(494, 26);
      this.tbFileEncResult.TabIndex = 4;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(8, 62);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(110, 20);
      this.label8.TabIndex = 3;
      this.label8.Text = "Encrypted File";
      // 
      // btnBrowseEnc
      // 
      this.btnBrowseEnc.Location = new System.Drawing.Point(633, 12);
      this.btnBrowseEnc.Name = "btnBrowseEnc";
      this.btnBrowseEnc.Size = new System.Drawing.Size(36, 26);
      this.btnBrowseEnc.TabIndex = 2;
      this.btnBrowseEnc.Text = ". . .";
      this.btnBrowseEnc.UseVisualStyleBackColor = true;
      this.btnBrowseEnc.Click += new System.EventHandler(this.btnBrowseEnc_Click);
      // 
      // tbFileEncSource
      // 
      this.tbFileEncSource.Location = new System.Drawing.Point(132, 12);
      this.tbFileEncSource.Name = "tbFileEncSource";
      this.tbFileEncSource.ReadOnly = true;
      this.tbFileEncSource.Size = new System.Drawing.Size(494, 26);
      this.tbFileEncSource.TabIndex = 1;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(8, 15);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(89, 20);
      this.label7.TabIndex = 0;
      this.label7.Text = "File Source";
      // 
      // tabPage4
      // 
      this.tabPage4.Controls.Add(this.lblFileDecMessage);
      this.tabPage4.Controls.Add(this.btnDecryptFile);
      this.tabPage4.Controls.Add(this.tbFileDecResult);
      this.tabPage4.Controls.Add(this.label10);
      this.tabPage4.Controls.Add(this.btnBrowseDec);
      this.tabPage4.Controls.Add(this.tbFileDecSource);
      this.tabPage4.Controls.Add(this.label11);
      this.tabPage4.Location = new System.Drawing.Point(4, 29);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Size = new System.Drawing.Size(775, 281);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "Decrypt File";
      this.tabPage4.UseVisualStyleBackColor = true;
      // 
      // lblFileDecMessage
      // 
      this.lblFileDecMessage.AutoSize = true;
      this.lblFileDecMessage.Location = new System.Drawing.Point(128, 152);
      this.lblFileDecMessage.Name = "lblFileDecMessage";
      this.lblFileDecMessage.Size = new System.Drawing.Size(82, 20);
      this.lblFileDecMessage.TabIndex = 13;
      this.lblFileDecMessage.Text = "[Message]";
      this.lblFileDecMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnDecryptFile
      // 
      this.btnDecryptFile.Location = new System.Drawing.Point(132, 100);
      this.btnDecryptFile.Name = "btnDecryptFile";
      this.btnDecryptFile.Size = new System.Drawing.Size(176, 40);
      this.btnDecryptFile.TabIndex = 12;
      this.btnDecryptFile.Text = "Start Decrypt File";
      this.btnDecryptFile.UseVisualStyleBackColor = true;
      this.btnDecryptFile.Click += new System.EventHandler(this.btnDecryptFile_Click);
      // 
      // tbFileDecResult
      // 
      this.tbFileDecResult.Location = new System.Drawing.Point(132, 58);
      this.tbFileDecResult.Name = "tbFileDecResult";
      this.tbFileDecResult.Size = new System.Drawing.Size(494, 26);
      this.tbFileDecResult.TabIndex = 11;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(8, 62);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(111, 20);
      this.label10.TabIndex = 10;
      this.label10.Text = "Decrypted File";
      // 
      // btnBrowseDec
      // 
      this.btnBrowseDec.Location = new System.Drawing.Point(633, 12);
      this.btnBrowseDec.Name = "btnBrowseDec";
      this.btnBrowseDec.Size = new System.Drawing.Size(36, 26);
      this.btnBrowseDec.TabIndex = 9;
      this.btnBrowseDec.Text = ". . .";
      this.btnBrowseDec.UseVisualStyleBackColor = true;
      this.btnBrowseDec.Click += new System.EventHandler(this.btnBrowseDec_Click);
      // 
      // tbFileDecSource
      // 
      this.tbFileDecSource.Location = new System.Drawing.Point(132, 12);
      this.tbFileDecSource.Name = "tbFileDecSource";
      this.tbFileDecSource.ReadOnly = true;
      this.tbFileDecSource.Size = new System.Drawing.Size(494, 26);
      this.tbFileDecSource.TabIndex = 8;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(8, 15);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(89, 20);
      this.label11.TabIndex = 7;
      this.label11.Text = "File Source";
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // tabPage5
      // 
      this.tabPage5.Controls.Add(this.btnReadXML);
      this.tabPage5.Controls.Add(this.tbResultXML);
      this.tabPage5.Controls.Add(this.button2);
      this.tabPage5.Controls.Add(this.tbPathXML);
      this.tabPage5.Controls.Add(this.label13);
      this.tabPage5.Location = new System.Drawing.Point(4, 29);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage5.Size = new System.Drawing.Size(775, 281);
      this.tabPage5.TabIndex = 4;
      this.tabPage5.Text = "Read XML";
      this.tabPage5.UseVisualStyleBackColor = true;
      // 
      // btnReadXML
      // 
      this.btnReadXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnReadXML.Location = new System.Drawing.Point(136, 211);
      this.btnReadXML.Name = "btnReadXML";
      this.btnReadXML.Size = new System.Drawing.Size(176, 40);
      this.btnReadXML.TabIndex = 19;
      this.btnReadXML.Text = "Read XML";
      this.btnReadXML.UseVisualStyleBackColor = true;
      this.btnReadXML.Click += new System.EventHandler(this.btnReadXML_Click);
      // 
      // tbResultXML
      // 
      this.tbResultXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbResultXML.Location = new System.Drawing.Point(136, 62);
      this.tbResultXML.Multiline = true;
      this.tbResultXML.Name = "tbResultXML";
      this.tbResultXML.Size = new System.Drawing.Size(618, 126);
      this.tbResultXML.TabIndex = 18;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(637, 16);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(36, 26);
      this.button2.TabIndex = 16;
      this.button2.Text = ". . .";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // tbPathXML
      // 
      this.tbPathXML.Location = new System.Drawing.Point(136, 16);
      this.tbPathXML.Name = "tbPathXML";
      this.tbPathXML.ReadOnly = true;
      this.tbPathXML.Size = new System.Drawing.Size(494, 26);
      this.tbPathXML.TabIndex = 15;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(12, 19);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(89, 20);
      this.label13.TabIndex = 14;
      this.label13.Text = "File Source";
      // 
      // ofdXML
      // 
      this.ofdXML.FileName = "openFileDialog2";
      // 
      // FormEncryption
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(783, 314);
      this.Controls.Add(this.tabControl1);
      this.Name = "FormEncryption";
      this.Text = "Form Encrypt - Decrypt";
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.tabPage4.ResumeLayout(false);
      this.tabPage4.PerformLayout();
      this.tabPage5.ResumeLayout(false);
      this.tabPage5.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox tbEncryptedPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPlainText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox tbDecryptPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEncryptedText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbResultDecrypted;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblFileEncMessage;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.TextBox tbFileEncResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBrowseEnc;
        private System.Windows.Forms.TextBox tbFileEncSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblFileDecMessage;
        private System.Windows.Forms.Button btnDecryptFile;
        private System.Windows.Forms.TextBox tbFileDecResult;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBrowseDec;
        private System.Windows.Forms.TextBox tbFileDecSource;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Label lblStringLength;
        private System.Windows.Forms.RichTextBox tbResultEncrypted;
    private System.Windows.Forms.TabPage tabPage5;
    private System.Windows.Forms.Button btnReadXML;
    private System.Windows.Forms.TextBox tbResultXML;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox tbPathXML;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.OpenFileDialog ofdXML;
  }
}