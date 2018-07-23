namespace ForTestPurpose
{
  partial class frmGenerateKey
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
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
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
      this.btnGenerate = new System.Windows.Forms.Button();
      this.tbSerialKey = new System.Windows.Forms.TextBox();
      this.tbKey = new System.Windows.Forms.TextBox();
      this.tbUsername = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.lblValResult = new System.Windows.Forms.Label();
      this.btnValidate = new System.Windows.Forms.Button();
      this.tbValSerialKey = new System.Windows.Forms.TextBox();
      this.tbValKey = new System.Windows.Forms.TextBox();
      this.tbValUsername = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(756, 260);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.btnGenerate);
      this.tabPage1.Controls.Add(this.tbSerialKey);
      this.tabPage1.Controls.Add(this.tbKey);
      this.tabPage1.Controls.Add(this.tbUsername);
      this.tabPage1.Controls.Add(this.label3);
      this.tabPage1.Controls.Add(this.label2);
      this.tabPage1.Controls.Add(this.label1);
      this.tabPage1.Location = new System.Drawing.Point(4, 29);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(748, 227);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Generate Serial";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // btnGenerate
      // 
      this.btnGenerate.Location = new System.Drawing.Point(582, 177);
      this.btnGenerate.Name = "btnGenerate";
      this.btnGenerate.Size = new System.Drawing.Size(158, 33);
      this.btnGenerate.TabIndex = 6;
      this.btnGenerate.Text = "Generate";
      this.btnGenerate.UseVisualStyleBackColor = true;
      this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
      // 
      // tbSerialKey
      // 
      this.tbSerialKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbSerialKey.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbSerialKey.Location = new System.Drawing.Point(109, 127);
      this.tbSerialKey.Name = "tbSerialKey";
      this.tbSerialKey.ReadOnly = true;
      this.tbSerialKey.Size = new System.Drawing.Size(631, 27);
      this.tbSerialKey.TabIndex = 5;
      // 
      // tbKey
      // 
      this.tbKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbKey.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbKey.Location = new System.Drawing.Point(109, 69);
      this.tbKey.Name = "tbKey";
      this.tbKey.Size = new System.Drawing.Size(631, 27);
      this.tbKey.TabIndex = 4;
      // 
      // tbUsername
      // 
      this.tbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbUsername.Location = new System.Drawing.Point(109, 17);
      this.tbUsername.Name = "tbUsername";
      this.tbUsername.Size = new System.Drawing.Size(363, 26);
      this.tbUsername.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(8, 130);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(79, 20);
      this.label3.TabIndex = 2;
      this.label3.Text = "Serial Key";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(8, 72);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 20);
      this.label2.TabIndex = 1;
      this.label2.Text = "Key";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(83, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Username";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.lblValResult);
      this.tabPage2.Controls.Add(this.btnValidate);
      this.tabPage2.Controls.Add(this.tbValSerialKey);
      this.tabPage2.Controls.Add(this.tbValKey);
      this.tabPage2.Controls.Add(this.tbValUsername);
      this.tabPage2.Controls.Add(this.label4);
      this.tabPage2.Controls.Add(this.label5);
      this.tabPage2.Controls.Add(this.label6);
      this.tabPage2.Location = new System.Drawing.Point(4, 29);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(748, 227);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Validate Serial";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // lblValResult
      // 
      this.lblValResult.AutoSize = true;
      this.lblValResult.Location = new System.Drawing.Point(105, 183);
      this.lblValResult.Name = "lblValResult";
      this.lblValResult.Size = new System.Drawing.Size(86, 20);
      this.lblValResult.TabIndex = 14;
      this.lblValResult.Text = "Result : {0}";
      // 
      // btnValidate
      // 
      this.btnValidate.Location = new System.Drawing.Point(582, 177);
      this.btnValidate.Name = "btnValidate";
      this.btnValidate.Size = new System.Drawing.Size(158, 33);
      this.btnValidate.TabIndex = 13;
      this.btnValidate.Text = "Validate";
      this.btnValidate.UseVisualStyleBackColor = true;
      this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
      // 
      // tbValSerialKey
      // 
      this.tbValSerialKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbValSerialKey.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbValSerialKey.Location = new System.Drawing.Point(109, 127);
      this.tbValSerialKey.Name = "tbValSerialKey";
      this.tbValSerialKey.Size = new System.Drawing.Size(631, 27);
      this.tbValSerialKey.TabIndex = 12;
      // 
      // tbValKey
      // 
      this.tbValKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbValKey.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbValKey.Location = new System.Drawing.Point(109, 69);
      this.tbValKey.Name = "tbValKey";
      this.tbValKey.Size = new System.Drawing.Size(631, 27);
      this.tbValKey.TabIndex = 11;
      // 
      // tbValUsername
      // 
      this.tbValUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbValUsername.Location = new System.Drawing.Point(109, 17);
      this.tbValUsername.Name = "tbValUsername";
      this.tbValUsername.Size = new System.Drawing.Size(363, 26);
      this.tbValUsername.TabIndex = 10;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(8, 130);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(79, 20);
      this.label4.TabIndex = 9;
      this.label4.Text = "Serial Key";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(8, 72);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(35, 20);
      this.label5.TabIndex = 8;
      this.label5.Text = "Key";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(8, 20);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(83, 20);
      this.label6.TabIndex = 7;
      this.label6.Text = "Username";
      // 
      // frmGenerateKey
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(756, 260);
      this.Controls.Add(this.tabControl1);
      this.Name = "frmGenerateKey";
      this.Text = "frmGenerateKey";
      this.Load += new System.EventHandler(this.frmGenerateKey_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TextBox tbSerialKey;
    private System.Windows.Forms.TextBox tbKey;
    private System.Windows.Forms.TextBox tbUsername;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Button btnGenerate;
    private System.Windows.Forms.Button btnValidate;
    private System.Windows.Forms.TextBox tbValSerialKey;
    private System.Windows.Forms.TextBox tbValKey;
    private System.Windows.Forms.TextBox tbValUsername;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label lblValResult;
  }
}