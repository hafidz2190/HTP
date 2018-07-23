namespace POFtpSender
{
    partial class frmRegister
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnApply = new System.Windows.Forms.Button();
            this.tbKeterangan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSerialNo = new System.Windows.Forms.TextBox();
            this.lblIdentity = new System.Windows.Forms.Label();
            this.tbIDMachine = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbKeteranganAktivasi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReAktivasi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbKodeLama = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(11, 233);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(385, 21);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Tutup Form";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(407, 229);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnApply);
            this.tabPage1.Controls.Add(this.tbKeterangan);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbSerialNo);
            this.tabPage1.Controls.Add(this.lblIdentity);
            this.tabPage1.Controls.Add(this.tbIDMachine);
            this.tabPage1.Controls.Add(this.tbUsername);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(399, 203);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Aktivasi Baru";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(93, 168);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(300, 31);
            this.btnApply.TabIndex = 18;
            this.btnApply.Text = "Pasang Kode Registrasi";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tbKeterangan
            // 
            this.tbKeterangan.Location = new System.Drawing.Point(93, 110);
            this.tbKeterangan.Margin = new System.Windows.Forms.Padding(2);
            this.tbKeterangan.Multiline = true;
            this.tbKeterangan.Name = "tbKeterangan";
            this.tbKeterangan.ReadOnly = true;
            this.tbKeterangan.Size = new System.Drawing.Size(301, 46);
            this.tbKeterangan.TabIndex = 17;
            this.tbKeterangan.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Keterangan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kode Serial";
            // 
            // tbSerialNo
            // 
            this.tbSerialNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSerialNo.Location = new System.Drawing.Point(93, 77);
            this.tbSerialNo.Margin = new System.Windows.Forms.Padding(2);
            this.tbSerialNo.Name = "tbSerialNo";
            this.tbSerialNo.Size = new System.Drawing.Size(301, 21);
            this.tbSerialNo.TabIndex = 14;
            // 
            // lblIdentity
            // 
            this.lblIdentity.AutoSize = true;
            this.lblIdentity.Location = new System.Drawing.Point(5, 47);
            this.lblIdentity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdentity.Name = "lblIdentity";
            this.lblIdentity.Size = new System.Drawing.Size(67, 13);
            this.lblIdentity.TabIndex = 13;
            this.lblIdentity.Text = "ID Registrasi";
            // 
            // tbIDMachine
            // 
            this.tbIDMachine.BackColor = System.Drawing.Color.White;
            this.tbIDMachine.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIDMachine.Location = new System.Drawing.Point(93, 46);
            this.tbIDMachine.Margin = new System.Windows.Forms.Padding(2);
            this.tbIDMachine.Name = "tbIDMachine";
            this.tbIDMachine.ReadOnly = true;
            this.tbIDMachine.Size = new System.Drawing.Size(301, 21);
            this.tbIDMachine.TabIndex = 12;
            this.tbIDMachine.TabStop = false;
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.Color.White;
            this.tbUsername.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(93, 15);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(2);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.ReadOnly = true;
            this.tbUsername.Size = new System.Drawing.Size(301, 21);
            this.tbUsername.TabIndex = 11;
            this.tbUsername.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Username";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbKeteranganAktivasi);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnReAktivasi);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbKodeLama);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(399, 203);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Aktivasi Ulang";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbKeteranganAktivasi
            // 
            this.tbKeteranganAktivasi.Location = new System.Drawing.Point(93, 41);
            this.tbKeteranganAktivasi.Margin = new System.Windows.Forms.Padding(2);
            this.tbKeteranganAktivasi.Multiline = true;
            this.tbKeteranganAktivasi.Name = "tbKeteranganAktivasi";
            this.tbKeteranganAktivasi.ReadOnly = true;
            this.tbKeteranganAktivasi.Size = new System.Drawing.Size(301, 46);
            this.tbKeteranganAktivasi.TabIndex = 20;
            this.tbKeteranganAktivasi.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Keterangan";
            // 
            // btnReAktivasi
            // 
            this.btnReAktivasi.Location = new System.Drawing.Point(93, 98);
            this.btnReAktivasi.Margin = new System.Windows.Forms.Padding(2);
            this.btnReAktivasi.Name = "btnReAktivasi";
            this.btnReAktivasi.Size = new System.Drawing.Size(300, 27);
            this.btnReAktivasi.TabIndex = 18;
            this.btnReAktivasi.Text = "Aktifkan";
            this.btnReAktivasi.UseVisualStyleBackColor = true;
            this.btnReAktivasi.Click += new System.EventHandler(this.btnReAktivasi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Kode Serial";
            // 
            // tbKodeLama
            // 
            this.tbKodeLama.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKodeLama.Location = new System.Drawing.Point(93, 13);
            this.tbKodeLama.Margin = new System.Windows.Forms.Padding(2);
            this.tbKodeLama.Name = "tbKodeLama";
            this.tbKodeLama.Size = new System.Drawing.Size(301, 21);
            this.tbKodeLama.TabIndex = 16;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(407, 265);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegister";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrasi Aplikasi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegister_FormClosing);
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

    #endregion
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.Button btnApply;
    private System.Windows.Forms.TextBox tbKeterangan;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbSerialNo;
    private System.Windows.Forms.Label lblIdentity;
    private System.Windows.Forms.TextBox tbIDMachine;
    private System.Windows.Forms.TextBox tbUsername;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Button btnReAktivasi;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbKodeLama;
    private System.Windows.Forms.TextBox tbKeteranganAktivasi;
    private System.Windows.Forms.Label label5;
  }
}