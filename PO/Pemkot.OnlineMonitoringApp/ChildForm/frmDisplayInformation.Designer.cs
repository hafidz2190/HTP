namespace Pemkot.OnlineMonitoringApp.ChildForm
{
    partial class frmDisplayInformation
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ucDispMont = new Pemkot.OnlineMonitoringApp.ControlDisplay.UCDisplayMonitor();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 360000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel.BackgroundImage = global::Pemkot.OnlineMonitoringApp.Properties.Resources.Banner_utama2;
            this.flowLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel.Controls.Add(this.ucDispMont);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1151, 718);
            this.flowLayoutPanel.TabIndex = 2;
            // 
            // ucDispMont
            // 
            this.ucDispMont.AutoSize = true;
            this.ucDispMont.BackColor = System.Drawing.Color.Transparent;
            this.ucDispMont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucDispMont.LabelJenisPajak = "-";
            this.ucDispMont.LabelLastActivity = "-";
            this.ucDispMont.LabelNopTerdaftar = "-";
            this.ucDispMont.LabelStatus = "-";
            this.ucDispMont.LabelUsername = "-";
            this.ucDispMont.Location = new System.Drawing.Point(3, 3);
            this.ucDispMont.Name = "ucDispMont";
            this.ucDispMont.Padding = new System.Windows.Forms.Padding(2);
            this.ucDispMont.PictureStatus = null;
            this.ucDispMont.Size = new System.Drawing.Size(235, 221);
            this.ucDispMont.TabIndex = 0;
            // 
            // frmDisplayInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1151, 718);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "frmDisplayInformation";
            this.Text = "Display Informasi Monitoring";
            this.Load += new System.EventHandler(this.frmDisplayInformation_Load);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private ControlDisplay.UCDisplayMonitor ucDispMont;
    }
}