namespace Pemkot.OnlineMonitoringApp.ChildForm
{
    partial class frmGetDataTransaction
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipeRequest = new System.Windows.Forms.ComboBox();
            this.tbJenisPajak = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRepoType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbParameter = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSend = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbJenisRepository = new System.Windows.Forms.TextBox();
            this.gbParameter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(106, 7);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.ReadOnly = true;
            this.tbUsername.Size = new System.Drawing.Size(175, 20);
            this.tbUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipe Request";
            // 
            // cbTipeRequest
            // 
            this.cbTipeRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipeRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipeRequest.FormattingEnabled = true;
            this.cbTipeRequest.Location = new System.Drawing.Point(106, 103);
            this.cbTipeRequest.Margin = new System.Windows.Forms.Padding(2);
            this.cbTipeRequest.Name = "cbTipeRequest";
            this.cbTipeRequest.Size = new System.Drawing.Size(416, 21);
            this.cbTipeRequest.TabIndex = 2;
            this.cbTipeRequest.SelectedIndexChanged += new System.EventHandler(this.cbTipeRequest_SelectedIndexChanged);
            // 
            // tbJenisPajak
            // 
            this.tbJenisPajak.Location = new System.Drawing.Point(106, 38);
            this.tbJenisPajak.Name = "tbJenisPajak";
            this.tbJenisPajak.ReadOnly = true;
            this.tbJenisPajak.Size = new System.Drawing.Size(175, 20);
            this.tbJenisPajak.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Jenis Pajak";
            // 
            // tbRepoType
            // 
            this.tbRepoType.Location = new System.Drawing.Point(106, 68);
            this.tbRepoType.Name = "tbRepoType";
            this.tbRepoType.ReadOnly = true;
            this.tbRepoType.Size = new System.Drawing.Size(175, 20);
            this.tbRepoType.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tipe Repository";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbParameter
            // 
            this.gbParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbParameter.Controls.Add(this.panel1);
            this.gbParameter.Location = new System.Drawing.Point(15, 136);
            this.gbParameter.Margin = new System.Windows.Forms.Padding(2);
            this.gbParameter.Name = "gbParameter";
            this.gbParameter.Padding = new System.Windows.Forms.Padding(2);
            this.gbParameter.Size = new System.Drawing.Size(507, 145);
            this.gbParameter.TabIndex = 7;
            this.gbParameter.TabStop = false;
            this.gbParameter.Text = "Parameter";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(5, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 122);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(493, 118);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(420, 284);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(102, 22);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Kirim Request";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Jenis";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbJenisRepository
            // 
            this.tbJenisRepository.Location = new System.Drawing.Point(346, 69);
            this.tbJenisRepository.Name = "tbJenisRepository";
            this.tbJenisRepository.ReadOnly = true;
            this.tbJenisRepository.Size = new System.Drawing.Size(176, 20);
            this.tbJenisRepository.TabIndex = 6;
            // 
            // frmGetDataTransaction
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 314);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.gbParameter);
            this.Controls.Add(this.tbJenisRepository);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRepoType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbJenisPajak);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTipeRequest);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetDataTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Request";
            this.gbParameter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUsername;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbTipeRequest;
    private System.Windows.Forms.TextBox tbJenisPajak;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbRepoType;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.GroupBox gbParameter;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbJenisRepository;
        private System.Windows.Forms.Panel panel1;
    }
}