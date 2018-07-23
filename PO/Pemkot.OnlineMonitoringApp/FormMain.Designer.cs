namespace Pemkot.OnlineMonitoringApp
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jadwalKegiatanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertJadwalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusSignalR = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusButton = new System.Windows.Forms.ToolStripSplitButton();
            this.refreshSignalRConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitoringToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hasilPerekamanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.monitoringToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(687, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // monitoringToolStripMenuItem
            // 
            this.monitoringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.monitoringToolStripMenuItem.Name = "monitoringToolStripMenuItem";
            this.monitoringToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.monitoringToolStripMenuItem.Text = "Monitoring";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jadwalKegiatanToolStripMenuItem,
            this.insertJadwalToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // jadwalKegiatanToolStripMenuItem
            // 
            this.jadwalKegiatanToolStripMenuItem.Name = "jadwalKegiatanToolStripMenuItem";
            this.jadwalKegiatanToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.jadwalKegiatanToolStripMenuItem.Text = "Jadwal Kegiatan";
            this.jadwalKegiatanToolStripMenuItem.Click += new System.EventHandler(this.jadwalKegiatanToolStripMenuItem_Click);
            // 
            // insertJadwalToolStripMenuItem
            // 
            this.insertJadwalToolStripMenuItem.Name = "insertJadwalToolStripMenuItem";
            this.insertJadwalToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.insertJadwalToolStripMenuItem.Text = "Insert Jadwal";
            this.insertJadwalToolStripMenuItem.Click += new System.EventHandler(this.insertJadwalToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitoringToolStripMenuItem1,
            this.hasilPerekamanToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.testToolStripMenuItem.Text = "Display";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusSignalR,
            this.tsStatusButton});
            this.statusStrip1.Location = new System.Drawing.Point(0, 310);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(687, 30);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusSignalR
            // 
            this.lblStatusSignalR.Name = "lblStatusSignalR";
            this.lblStatusSignalR.Size = new System.Drawing.Size(90, 25);
            this.lblStatusSignalR.Text = "SignalR Status : ";
            // 
            // tsStatusButton
            // 
            this.tsStatusButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsStatusButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshSignalRConnectionToolStripMenuItem});
            this.tsStatusButton.Image = global::Pemkot.OnlineMonitoringApp.Properties.Resources.settings_icon;
            this.tsStatusButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsStatusButton.Name = "tsStatusButton";
            this.tsStatusButton.Size = new System.Drawing.Size(40, 28);
            this.tsStatusButton.Text = "toolStripSplitButton1";
            // 
            // refreshSignalRConnectionToolStripMenuItem
            // 
            this.refreshSignalRConnectionToolStripMenuItem.Name = "refreshSignalRConnectionToolStripMenuItem";
            this.refreshSignalRConnectionToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.refreshSignalRConnectionToolStripMenuItem.Text = "Refresh SignalR Connection";
            this.refreshSignalRConnectionToolStripMenuItem.Click += new System.EventHandler(this.refreshSignalRConnectionToolStripMenuItem_Click);
            // 
            // monitoringToolStripMenuItem1
            // 
            this.monitoringToolStripMenuItem1.Name = "monitoringToolStripMenuItem1";
            this.monitoringToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.monitoringToolStripMenuItem1.Text = "Monitoring";
            this.monitoringToolStripMenuItem1.Click += new System.EventHandler(this.monitoringToolStripMenuItem1_Click);
            // 
            // hasilPerekamanToolStripMenuItem
            // 
            this.hasilPerekamanToolStripMenuItem.Name = "hasilPerekamanToolStripMenuItem";
            this.hasilPerekamanToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.hasilPerekamanToolStripMenuItem.Text = "Hasil Perekaman";
            this.hasilPerekamanToolStripMenuItem.Click += new System.EventHandler(this.hasilPerekamanToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 340);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitoring Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitoringToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusSignalR;
    private System.Windows.Forms.ToolStripSplitButton tsStatusButton;
    private System.Windows.Forms.ToolStripMenuItem refreshSignalRConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jadwalKegiatanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertJadwalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitoringToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hasilPerekamanToolStripMenuItem;
    }
}

