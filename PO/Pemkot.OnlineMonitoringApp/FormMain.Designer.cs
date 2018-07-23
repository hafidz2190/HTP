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
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.lblStatusSignalR = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsStatusButton = new System.Windows.Forms.ToolStripSplitButton();
      this.refreshSignalRConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.monitoringToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
      this.menuStrip1.Size = new System.Drawing.Size(1030, 35);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // closeToolStripMenuItem
      // 
      this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
      this.closeToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
      this.closeToolStripMenuItem.Text = "Close";
      // 
      // monitoringToolStripMenuItem
      // 
      this.monitoringToolStripMenuItem.Name = "monitoringToolStripMenuItem";
      this.monitoringToolStripMenuItem.Size = new System.Drawing.Size(113, 29);
      this.monitoringToolStripMenuItem.Text = "Monitoring";
      this.monitoringToolStripMenuItem.Click += new System.EventHandler(this.monitoringToolStripMenuItem_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusSignalR,
            this.tsStatusButton});
      this.statusStrip1.Location = new System.Drawing.Point(0, 493);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
      this.statusStrip1.Size = new System.Drawing.Size(1030, 30);
      this.statusStrip1.TabIndex = 3;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // lblStatusSignalR
      // 
      this.lblStatusSignalR.Name = "lblStatusSignalR";
      this.lblStatusSignalR.Size = new System.Drawing.Size(138, 25);
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
      this.tsStatusButton.Size = new System.Drawing.Size(45, 28);
      this.tsStatusButton.Text = "toolStripSplitButton1";
      // 
      // refreshSignalRConnectionToolStripMenuItem
      // 
      this.refreshSignalRConnectionToolStripMenuItem.Name = "refreshSignalRConnectionToolStripMenuItem";
      this.refreshSignalRConnectionToolStripMenuItem.Size = new System.Drawing.Size(313, 30);
      this.refreshSignalRConnectionToolStripMenuItem.Text = "Refresh SignalR Connection";
      this.refreshSignalRConnectionToolStripMenuItem.Click += new System.EventHandler(this.refreshSignalRConnectionToolStripMenuItem_Click);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1030, 523);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
  }
}

