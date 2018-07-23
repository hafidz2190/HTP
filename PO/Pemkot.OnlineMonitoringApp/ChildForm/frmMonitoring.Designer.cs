namespace Pemkot.OnlineMonitoringApp.ChildForm
{
    partial class frmMonitoring
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitoring));
      this.scMain = new System.Windows.Forms.SplitContainer();
      this.scLeft = new System.Windows.Forms.SplitContainer();
      this.dgvNOP = new System.Windows.Forms.DataGridView();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.label3 = new System.Windows.Forms.Label();
      this.dgvUser = new System.Windows.Forms.DataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Webusername = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IP_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Status_Perangkat_Image = new System.Windows.Forms.DataGridViewImageColumn();
      this.Status_Perangkat = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.RefreshApp = new System.Windows.Forms.DataGridViewButtonColumn();
      ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
      this.scMain.Panel1.SuspendLayout();
      this.scMain.Panel2.SuspendLayout();
      this.scMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scLeft)).BeginInit();
      this.scLeft.Panel1.SuspendLayout();
      this.scLeft.Panel2.SuspendLayout();
      this.scLeft.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvNOP)).BeginInit();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // scMain
      // 
      this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.scMain.IsSplitterFixed = true;
      this.scMain.Location = new System.Drawing.Point(0, 0);
      this.scMain.Name = "scMain";
      // 
      // scMain.Panel1
      // 
      this.scMain.Panel1.Controls.Add(this.scLeft);
      // 
      // scMain.Panel2
      // 
      this.scMain.Panel2.Controls.Add(this.dgvUser);
      this.scMain.Panel2.Controls.Add(this.panel1);
      this.scMain.Size = new System.Drawing.Size(1221, 634);
      this.scMain.SplitterDistance = 302;
      this.scMain.SplitterWidth = 3;
      this.scMain.TabIndex = 0;
      // 
      // scLeft
      // 
      this.scLeft.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scLeft.Location = new System.Drawing.Point(0, 0);
      this.scLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.scLeft.Name = "scLeft";
      this.scLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // scLeft.Panel1
      // 
      this.scLeft.Panel1.Controls.Add(this.dgvNOP);
      this.scLeft.Panel1.Controls.Add(this.panel2);
      // 
      // scLeft.Panel2
      // 
      this.scLeft.Panel2.Controls.Add(this.panel3);
      this.scLeft.Size = new System.Drawing.Size(300, 632);
      this.scLeft.SplitterDistance = 459;
      this.scLeft.SplitterWidth = 5;
      this.scLeft.TabIndex = 0;
      // 
      // dgvNOP
      // 
      this.dgvNOP.BackgroundColor = System.Drawing.Color.SeaShell;
      this.dgvNOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvNOP.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvNOP.Location = new System.Drawing.Point(0, 45);
      this.dgvNOP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dgvNOP.Name = "dgvNOP";
      this.dgvNOP.Size = new System.Drawing.Size(300, 414);
      this.dgvNOP.TabIndex = 2;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.panel2.Controls.Add(this.label2);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(300, 45);
      this.panel2.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label2.Location = new System.Drawing.Point(4, 12);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(150, 20);
      this.label2.TabIndex = 0;
      this.label2.Text = "Detail NOP User";
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.panel3.Controls.Add(this.label3);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(300, 45);
      this.panel3.TabIndex = 2;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label3.Location = new System.Drawing.Point(4, 12);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(63, 20);
      this.label3.TabIndex = 0;
      this.label3.Text = "Status";
      // 
      // dgvUser
      // 
      this.dgvUser.AllowUserToAddRows = false;
      this.dgvUser.AllowUserToDeleteRows = false;
      this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvUser.BackgroundColor = System.Drawing.Color.Ivory;
      this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username,
            this.Webusername,
            this.IP_Address,
            this.Port,
            this.Status_Perangkat_Image,
            this.Status_Perangkat,
            this.RefreshApp});
      this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvUser.Location = new System.Drawing.Point(0, 45);
      this.dgvUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dgvUser.Name = "dgvUser";
      this.dgvUser.ReadOnly = true;
      this.dgvUser.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dgvUser.RowTemplate.Height = 35;
      this.dgvUser.Size = new System.Drawing.Size(914, 587);
      this.dgvUser.TabIndex = 1;
      this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellClick);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(914, 45);
      this.panel1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label1.Location = new System.Drawing.Point(4, 12);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(227, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "List Data User Terpasang";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // timer1
      // 
      this.timer1.Interval = 5000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // Username
      // 
      this.Username.DataPropertyName = "Username";
      this.Username.FillWeight = 89.54314F;
      this.Username.HeaderText = "Username";
      this.Username.Name = "Username";
      this.Username.ReadOnly = true;
      // 
      // Webusername
      // 
      this.Webusername.DataPropertyName = "Webusername";
      this.Webusername.FillWeight = 89.54314F;
      this.Webusername.HeaderText = "Web Username";
      this.Webusername.Name = "Webusername";
      this.Webusername.ReadOnly = true;
      // 
      // IP_Address
      // 
      this.IP_Address.DataPropertyName = "IP_Address";
      this.IP_Address.FillWeight = 89.54314F;
      this.IP_Address.HeaderText = "IP Address";
      this.IP_Address.Name = "IP_Address";
      this.IP_Address.ReadOnly = true;
      // 
      // Port
      // 
      this.Port.DataPropertyName = "Port";
      this.Port.FillWeight = 89.54314F;
      this.Port.HeaderText = "Port";
      this.Port.Name = "Port";
      this.Port.ReadOnly = true;
      // 
      // Status_Perangkat_Image
      // 
      this.Status_Perangkat_Image.DataPropertyName = "StatusImage";
      this.Status_Perangkat_Image.FillWeight = 89.54314F;
      this.Status_Perangkat_Image.HeaderText = "Perangkat Aktif ?";
      this.Status_Perangkat_Image.Name = "Status_Perangkat_Image";
      this.Status_Perangkat_Image.ReadOnly = true;
      this.Status_Perangkat_Image.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Status_Perangkat
      // 
      this.Status_Perangkat.DataPropertyName = "Status_Perangkat";
      this.Status_Perangkat.HeaderText = "Status_Perangkat";
      this.Status_Perangkat.Name = "Status_Perangkat";
      this.Status_Perangkat.ReadOnly = true;
      this.Status_Perangkat.Visible = false;
      // 
      // RefreshApp
      // 
      this.RefreshApp.HeaderText = "Kirim Perintah";
      this.RefreshApp.Name = "RefreshApp";
      this.RefreshApp.ReadOnly = true;
      this.RefreshApp.Text = "Request";
      this.RefreshApp.ToolTipText = "Request Data dari Client";
      this.RefreshApp.UseColumnTextForButtonValue = true;
      // 
      // frmMonitoring
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1221, 634);
      this.Controls.Add(this.scMain);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "frmMonitoring";
      this.ShowInTaskbar = false;
      this.Text = "Monitoring";
      this.Load += new System.EventHandler(this.frmMonitoring_Load);
      this.scMain.Panel1.ResumeLayout(false);
      this.scMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
      this.scMain.ResumeLayout(false);
      this.scLeft.Panel1.ResumeLayout(false);
      this.scLeft.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.scLeft)).EndInit();
      this.scLeft.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvNOP)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer scLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.DataGridView dgvNOP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Username;
    private System.Windows.Forms.DataGridViewTextBoxColumn Webusername;
    private System.Windows.Forms.DataGridViewTextBoxColumn IP_Address;
    private System.Windows.Forms.DataGridViewTextBoxColumn Port;
    private System.Windows.Forms.DataGridViewImageColumn Status_Perangkat_Image;
    private System.Windows.Forms.DataGridViewTextBoxColumn Status_Perangkat;
    private System.Windows.Forms.DataGridViewButtonColumn RefreshApp;
  }
}