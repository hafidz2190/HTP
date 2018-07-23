namespace POFtpSender
{
    partial class frmSettingDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettingDB));
            this.label1 = new System.Windows.Forms.Label();
            this.tbParentTable = new System.Windows.Forms.TextBox();
            this.btnAddRelation = new System.Windows.Forms.Button();
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpDynamicControl = new System.Windows.Forms.TableLayoutPanel();
            this.tbHasil = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnRemoveRelation = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbParentAlias = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parent Table";
            // 
            // tbParentTable
            // 
            this.tbParentTable.Location = new System.Drawing.Point(86, 9);
            this.tbParentTable.Name = "tbParentTable";
            this.tbParentTable.Size = new System.Drawing.Size(230, 20);
            this.tbParentTable.TabIndex = 1;
            this.tbParentTable.TextChanged += new System.EventHandler(this.tbParentTable_TextChanged);
            // 
            // btnAddRelation
            // 
            this.btnAddRelation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRelation.ImageKey = "Plus.png";
            this.btnAddRelation.ImageList = this.imgSmall;
            this.btnAddRelation.Location = new System.Drawing.Point(86, 32);
            this.btnAddRelation.Name = "btnAddRelation";
            this.btnAddRelation.Size = new System.Drawing.Size(99, 23);
            this.btnAddRelation.TabIndex = 2;
            this.btnAddRelation.Text = "Add Relation";
            this.btnAddRelation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRelation.UseVisualStyleBackColor = true;
            this.btnAddRelation.Click += new System.EventHandler(this.btnAddRelation_Click);
            // 
            // imgSmall
            // 
            this.imgSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSmall.ImageStream")));
            this.imgSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSmall.Images.SetKeyName(0, "9308.png");
            this.imgSmall.Images.SetKeyName(1, "save-icon-png--4.png");
            this.imgSmall.Images.SetKeyName(2, "532.png");
            this.imgSmall.Images.SetKeyName(3, "ms_excel1600.png");
            this.imgSmall.Images.SetKeyName(4, "Minus.png");
            this.imgSmall.Images.SetKeyName(5, "Plus.png");
            this.imgSmall.Images.SetKeyName(6, "sharingIcon-e1364762257551.png");
            this.imgSmall.Images.SetKeyName(7, "good.png");
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tlpDynamicControl);
            this.panel1.Location = new System.Drawing.Point(18, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 149);
            this.panel1.TabIndex = 3;
            // 
            // tlpDynamicControl
            // 
            this.tlpDynamicControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDynamicControl.AutoSize = true;
            this.tlpDynamicControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpDynamicControl.ColumnCount = 7;
            this.tlpDynamicControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDynamicControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDynamicControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDynamicControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDynamicControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDynamicControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDynamicControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDynamicControl.Location = new System.Drawing.Point(3, 3);
            this.tlpDynamicControl.Name = "tlpDynamicControl";
            this.tlpDynamicControl.RowCount = 1;
            this.tlpDynamicControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDynamicControl.Size = new System.Drawing.Size(0, 0);
            this.tlpDynamicControl.TabIndex = 0;
            // 
            // tbHasil
            // 
            this.tbHasil.Location = new System.Drawing.Point(15, 243);
            this.tbHasil.Multiline = true;
            this.tbHasil.Name = "tbHasil";
            this.tbHasil.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHasil.Size = new System.Drawing.Size(763, 107);
            this.tbHasil.TabIndex = 4;
            // 
            // btnGenerate
            // 
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.ImageKey = "532.png";
            this.btnGenerate.ImageList = this.imgSmall;
            this.btnGenerate.Location = new System.Drawing.Point(15, 214);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(81, 25);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnRemoveRelation
            // 
            this.btnRemoveRelation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveRelation.ImageKey = "Minus.png";
            this.btnRemoveRelation.ImageList = this.imgSmall;
            this.btnRemoveRelation.Location = new System.Drawing.Point(203, 32);
            this.btnRemoveRelation.Name = "btnRemoveRelation";
            this.btnRemoveRelation.Size = new System.Drawing.Size(112, 23);
            this.btnRemoveRelation.TabIndex = 2;
            this.btnRemoveRelation.Text = "Remove Relation";
            this.btnRemoveRelation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveRelation.UseVisualStyleBackColor = true;
            this.btnRemoveRelation.Click += new System.EventHandler(this.btnRemoveRelation_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "alias";
            // 
            // tbParentAlias
            // 
            this.tbParentAlias.Location = new System.Drawing.Point(360, 9);
            this.tbParentAlias.Name = "tbParentAlias";
            this.tbParentAlias.Size = new System.Drawing.Size(230, 20);
            this.tbParentAlias.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(603, 100);
            this.label9.TabIndex = 30;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POFtpSender.Properties.Resources.Relation_Paths_01;
            this.pictureBox1.Location = new System.Drawing.Point(678, 371);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValidate.ImageKey = "good.png";
            this.btnValidate.ImageList = this.imgSmall;
            this.btnValidate.Location = new System.Drawing.Point(694, 214);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(81, 25);
            this.btnValidate.TabIndex = 32;
            this.btnValidate.Text = "Cek Valid";
            this.btnValidate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // frmSettingDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(787, 468);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbParentAlias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbHasil);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnRemoveRelation);
            this.Controls.Add(this.btnAddRelation);
            this.Controls.Add(this.tbParentTable);
            this.Controls.Add(this.label1);
            this.Name = "frmSettingDB";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbParentTable;
        private System.Windows.Forms.Button btnAddRelation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlpDynamicControl;
        private System.Windows.Forms.TextBox tbHasil;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnRemoveRelation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbParentAlias;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imgSmall;
        private System.Windows.Forms.Button btnValidate;
    }
}

