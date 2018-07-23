namespace POFtpSender
{
    partial class frmFtpSender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFtpSender));
            this.MyNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.bgwCekFile = new System.ComponentModel.BackgroundWorker();
            this.tmrDir = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbExcel = new System.Windows.Forms.TabPage();
            this.lvwFtp = new System.Windows.Forms.ListView();
            this.tpDB = new System.Windows.Forms.TabPage();
            this.lvwDB = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registeredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.bgwSettingTime = new System.ComponentModel.BackgroundWorker();
            this.lblVers = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbExcel.SuspendLayout();
            this.tpDB.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyNotifyIcon
            // 
            this.MyNotifyIcon.BalloonTipText = "Click here to show again";
            this.MyNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MyNotifyIcon.Icon")));
            this.MyNotifyIcon.Visible = true;
            // 
            // bgwCekFile
            // 
            this.bgwCekFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCekFile_DoWork);
            this.bgwCekFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCekFile_RunWorkerCompleted);
            // 
            // tmrDir
            // 
            this.tmrDir.Interval = 1000;
            this.tmrDir.Tick += new System.EventHandler(this.tmrDir_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbExcel);
            this.tabControl1.Controls.Add(this.tpDB);
            this.tabControl1.Location = new System.Drawing.Point(-1, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 347);
            this.tabControl1.TabIndex = 3;
            // 
            // tbExcel
            // 
            this.tbExcel.Controls.Add(this.lvwFtp);
            this.tbExcel.Location = new System.Drawing.Point(4, 22);
            this.tbExcel.Name = "tbExcel";
            this.tbExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tbExcel.Size = new System.Drawing.Size(614, 321);
            this.tbExcel.TabIndex = 0;
            this.tbExcel.Text = "Excel";
            this.tbExcel.UseVisualStyleBackColor = true;
            // 
            // lvwFtp
            // 
            this.lvwFtp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwFtp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwFtp.Location = new System.Drawing.Point(3, 3);
            this.lvwFtp.Name = "lvwFtp";
            this.lvwFtp.Size = new System.Drawing.Size(608, 315);
            this.lvwFtp.TabIndex = 1;
            this.lvwFtp.UseCompatibleStateImageBehavior = false;
            this.lvwFtp.View = System.Windows.Forms.View.List;
            // 
            // tpDB
            // 
            this.tpDB.Controls.Add(this.lvwDB);
            this.tpDB.Location = new System.Drawing.Point(4, 22);
            this.tpDB.Name = "tpDB";
            this.tpDB.Padding = new System.Windows.Forms.Padding(3);
            this.tpDB.Size = new System.Drawing.Size(614, 321);
            this.tpDB.TabIndex = 1;
            this.tpDB.Text = "Database";
            this.tpDB.UseVisualStyleBackColor = true;
            // 
            // lvwDB
            // 
            this.lvwDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDB.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwDB.Location = new System.Drawing.Point(3, 3);
            this.lvwDB.Name = "lvwDB";
            this.lvwDB.Size = new System.Drawing.Size(608, 315);
            this.lvwDB.TabIndex = 2;
            this.lvwDB.UseCompatibleStateImageBehavior = false;
            this.lvwDB.View = System.Windows.Forms.View.List;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(-1, 21);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(622, 26);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registeredToolStripMenuItem,
            this.appInfoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // registeredToolStripMenuItem
            // 
            this.registeredToolStripMenuItem.Name = "registeredToolStripMenuItem";
            this.registeredToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.registeredToolStripMenuItem.Text = "Register";
            this.registeredToolStripMenuItem.Click += new System.EventHandler(this.registeredToolStripMenuItem_Click);
            // 
            // appInfoToolStripMenuItem
            // 
            this.appInfoToolStripMenuItem.Name = "appInfoToolStripMenuItem";
            this.appInfoToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.appInfoToolStripMenuItem.Text = "App info";
            this.appInfoToolStripMenuItem.Click += new System.EventHandler(this.appInfoToolStripMenuItem_Click);
            // 
            // bgwGetData
            // 
            this.bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetData_DoWork);
            this.bgwGetData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGetData_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::POFtpSender.Properties.Resources.header_form2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 22);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(14, 4);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(80, 14);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name";
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(598, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 18);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "-";
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // bgwSettingTime
            // 
            this.bgwSettingTime.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSettingTime_DoWork);
            this.bgwSettingTime.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSettingTime_RunWorkerCompleted);
            // 
            // lblVers
            // 
            this.lblVers.BackColor = System.Drawing.Color.Transparent;
            this.lblVers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVers.Location = new System.Drawing.Point(460, 402);
            this.lblVers.Name = "lblVers";
            this.lblVers.Size = new System.Drawing.Size(157, 17);
            this.lblVers.TabIndex = 5;
            this.lblVers.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmFtpSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(620, 419);
            this.Controls.Add(this.lblVers);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmFtpSender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ftp Sender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFtpSender_FormClosing);
            this.Load += new System.EventHandler(this.frmFtpSender_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbExcel.ResumeLayout(false);
            this.tpDB.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.NotifyIcon MyNotifyIcon;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker bgwCekFile;
        private System.Windows.Forms.Timer tmrDir;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbExcel;
        private System.Windows.Forms.ListView lvwFtp;
        private System.Windows.Forms.TabPage tpDB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registeredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appInfoToolStripMenuItem;
        private System.Windows.Forms.ListView lvwDB;
        private System.ComponentModel.BackgroundWorker bgwGetData;
        private System.ComponentModel.BackgroundWorker bgwSettingTime;
        private System.Windows.Forms.Label lblVers;
    }
}