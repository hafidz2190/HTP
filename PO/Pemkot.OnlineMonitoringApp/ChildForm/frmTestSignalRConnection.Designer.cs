namespace Pemkot.OnlineMonitoringApp.ChildForm
{
  partial class frmTestSignalRConnection
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if(disposing && (components != null))
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
      this.tbText = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.tbClientID = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.tbMessage = new System.Windows.Forms.TextBox();
      this.btnSend = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // tbText
      // 
      this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.tbText.Location = new System.Drawing.Point(16, 32);
      this.tbText.Multiline = true;
      this.tbText.Name = "tbText";
      this.tbText.Size = new System.Drawing.Size(414, 311);
      this.tbText.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(131, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "Connected Client";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(443, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(116, 20);
      this.label2.TabIndex = 1;
      this.label2.Text = "Send Message";
      // 
      // tbClientID
      // 
      this.tbClientID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbClientID.Location = new System.Drawing.Point(536, 38);
      this.tbClientID.Name = "tbClientID";
      this.tbClientID.Size = new System.Drawing.Size(297, 26);
      this.tbClientID.TabIndex = 2;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(443, 41);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(70, 20);
      this.label3.TabIndex = 1;
      this.label3.Text = "Client ID";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(443, 88);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(74, 20);
      this.label4.TabIndex = 1;
      this.label4.Text = "Message";
      // 
      // tbMessage
      // 
      this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbMessage.Location = new System.Drawing.Point(536, 85);
      this.tbMessage.Multiline = true;
      this.tbMessage.Name = "tbMessage";
      this.tbMessage.Size = new System.Drawing.Size(297, 149);
      this.tbMessage.TabIndex = 4;
      // 
      // btnSend
      // 
      this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnSend.Location = new System.Drawing.Point(536, 256);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new System.Drawing.Size(128, 38);
      this.btnSend.TabIndex = 5;
      this.btnSend.Text = "Send Message";
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // frmTestSignalRConnection
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(845, 361);
      this.Controls.Add(this.btnSend);
      this.Controls.Add(this.tbClientID);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbMessage);
      this.Controls.Add(this.tbText);
      this.Name = "frmTestSignalRConnection";
      this.Text = "frmTestSignalRConnection";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbText;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbClientID;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbMessage;
    private System.Windows.Forms.Button btnSend;
  }
}