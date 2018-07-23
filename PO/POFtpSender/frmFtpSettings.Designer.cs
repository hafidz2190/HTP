namespace POFtpSender
{
    partial class frmFtpSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFtpSettings));
            this.gbUrlApi = new System.Windows.Forms.GroupBox();
            this.tbUrlApi = new System.Windows.Forms.TextBox();
            this.btnTesApi = new System.Windows.Forms.Button();
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            this.lblCountNop = new System.Windows.Forms.Label();
            this.btnDelNop = new System.Windows.Forms.Button();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.btnAddNop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.dgvOP = new System.Windows.Forms.DataGridView();
            this.JENISPAJAK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JML_OP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETAIL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.HAPUS = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbJenisPajak = new System.Windows.Forms.ComboBox();
            this.btnCekVersion = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnTesUpload = new System.Windows.Forms.Button();
            this.numJmlNop = new System.Windows.Forms.NumericUpDown();
            this.dgvNop = new System.Windows.Forms.DataGridView();
            this.CHECK_NOP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNamaColumn = new System.Windows.Forms.DataGridView();
            this.COLUMN_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLUMN_TEXT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.rbExist = new System.Windows.Forms.RadioButton();
            this.bgwCekExcel = new System.ComponentModel.BackgroundWorker();
            this.bgwSendData = new System.ComponentModel.BackgroundWorker();
            this.bgwXml = new System.ComponentModel.BackgroundWorker();
            this.tCtlSetting = new System.Windows.Forms.TabControl();
            this.tpExc = new System.Windows.Forms.TabPage();
            this.tpDb = new System.Windows.Forms.TabPage();
            this.btnAddDB = new System.Windows.Forms.Button();
            this.dgvSettingDB = new System.Windows.Forms.DataGridView();
            this.JENPAJAK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JML_NOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUERYPAJAK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUERYDETAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bgwSendDB = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.bgwTxt = new System.ComponentModel.BackgroundWorker();
            this.gbUrlApi.SuspendLayout();
            this.gbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJmlNop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNamaColumn)).BeginInit();
            this.tCtlSetting.SuspendLayout();
            this.tpExc.SuspendLayout();
            this.tpDb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettingDB)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUrlApi
            // 
            this.gbUrlApi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUrlApi.Controls.Add(this.tbUrlApi);
            this.gbUrlApi.Controls.Add(this.btnTesApi);
            this.gbUrlApi.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUrlApi.Location = new System.Drawing.Point(12, 12);
            this.gbUrlApi.Name = "gbUrlApi";
            this.gbUrlApi.Size = new System.Drawing.Size(847, 64);
            this.gbUrlApi.TabIndex = 0;
            this.gbUrlApi.TabStop = false;
            this.gbUrlApi.Text = "Url Web API";
            // 
            // tbUrlApi
            // 
            this.tbUrlApi.Location = new System.Drawing.Point(16, 25);
            this.tbUrlApi.Name = "tbUrlApi";
            this.tbUrlApi.Size = new System.Drawing.Size(699, 20);
            this.tbUrlApi.TabIndex = 1;
            // 
            // btnTesApi
            // 
            this.btnTesApi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTesApi.ImageKey = "sharingIcon-e1364762257551.png";
            this.btnTesApi.ImageList = this.imgSmall;
            this.btnTesApi.Location = new System.Drawing.Point(734, 19);
            this.btnTesApi.Name = "btnTesApi";
            this.btnTesApi.Size = new System.Drawing.Size(97, 30);
            this.btnTesApi.TabIndex = 0;
            this.btnTesApi.Text = "Tes Koneksi";
            this.btnTesApi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTesApi.UseVisualStyleBackColor = true;
            this.btnTesApi.Click += new System.EventHandler(this.btnTesApi_Click);
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
            this.imgSmall.Images.SetKeyName(7, "open.png");
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.pbLoading);
            this.gbSetting.Controls.Add(this.lblCountNop);
            this.gbSetting.Controls.Add(this.btnDelNop);
            this.gbSetting.Controls.Add(this.cbAll);
            this.gbSetting.Controls.Add(this.btnAddNop);
            this.gbSetting.Controls.Add(this.label2);
            this.gbSetting.Controls.Add(this.btnOk);
            this.gbSetting.Controls.Add(this.dgvOP);
            this.gbSetting.Controls.Add(this.label1);
            this.gbSetting.Controls.Add(this.cbJenisPajak);
            this.gbSetting.Controls.Add(this.btnCekVersion);
            this.gbSetting.Controls.Add(this.lblVersion);
            this.gbSetting.Controls.Add(this.btnTesUpload);
            this.gbSetting.Controls.Add(this.numJmlNop);
            this.gbSetting.Controls.Add(this.dgvNop);
            this.gbSetting.Controls.Add(this.dgvNamaColumn);
            this.gbSetting.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSetting.Location = new System.Drawing.Point(6, 6);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(826, 452);
            this.gbSetting.TabIndex = 1;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Setting Kolom";
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbLoading.Location = new System.Drawing.Point(16, 324);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(212, 14);
            this.pbLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbLoading.TabIndex = 10;
            // 
            // lblCountNop
            // 
            this.lblCountNop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountNop.AutoSize = true;
            this.lblCountNop.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountNop.Location = new System.Drawing.Point(13, 321);
            this.lblCountNop.Name = "lblCountNop";
            this.lblCountNop.Size = new System.Drawing.Size(74, 13);
            this.lblCountNop.TabIndex = 33;
            this.lblCountNop.Text = "Query Pajak";
            this.lblCountNop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelNop
            // 
            this.btnDelNop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelNop.ImageKey = "Minus.png";
            this.btnDelNop.ImageList = this.imgSmall;
            this.btnDelNop.Location = new System.Drawing.Point(792, 270);
            this.btnDelNop.Name = "btnDelNop";
            this.btnDelNop.Size = new System.Drawing.Size(28, 28);
            this.btnDelNop.TabIndex = 20;
            this.btnDelNop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelNop.UseVisualStyleBackColor = true;
            this.btnDelNop.Click += new System.EventHandler(this.btnDelNop_Click);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(20, 230);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(15, 14);
            this.cbAll.TabIndex = 19;
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.CheckedChanged += new System.EventHandler(this.cbAll_CheckedChanged);
            // 
            // btnAddNop
            // 
            this.btnAddNop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNop.ImageKey = "Plus.png";
            this.btnAddNop.ImageList = this.imgSmall;
            this.btnAddNop.Location = new System.Drawing.Point(792, 236);
            this.btnAddNop.Name = "btnAddNop";
            this.btnAddNop.Size = new System.Drawing.Size(28, 28);
            this.btnAddNop.TabIndex = 18;
            this.btnAddNop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNop.UseVisualStyleBackColor = true;
            this.btnAddNop.Click += new System.EventHandler(this.btnAddNop_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "List Setting Kolom";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.ImageKey = "save-icon-png--4.png";
            this.btnOk.ImageList = this.imgSmall;
            this.btnOk.Location = new System.Drawing.Point(739, 321);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 30);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dgvOP
            // 
            this.dgvOP.AllowUserToAddRows = false;
            this.dgvOP.AllowUserToDeleteRows = false;
            this.dgvOP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JENISPAJAK,
            this.JML_OP,
            this.DETAIL,
            this.HAPUS});
            this.dgvOP.Location = new System.Drawing.Point(16, 357);
            this.dgvOP.Name = "dgvOP";
            this.dgvOP.ReadOnly = true;
            this.dgvOP.RowHeadersVisible = false;
            this.dgvOP.Size = new System.Drawing.Size(804, 85);
            this.dgvOP.TabIndex = 15;
            this.dgvOP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOP_CellClick);
            // 
            // JENISPAJAK
            // 
            this.JENISPAJAK.DataPropertyName = "JENISPAJAK";
            this.JENISPAJAK.HeaderText = "JENIS PAJAK";
            this.JENISPAJAK.Name = "JENISPAJAK";
            this.JENISPAJAK.ReadOnly = true;
            // 
            // JML_OP
            // 
            this.JML_OP.DataPropertyName = "JML_OP";
            this.JML_OP.HeaderText = "JML OP";
            this.JML_OP.Name = "JML_OP";
            this.JML_OP.ReadOnly = true;
            // 
            // DETAIL
            // 
            this.DETAIL.HeaderText = "DETAIL";
            this.DETAIL.Name = "DETAIL";
            this.DETAIL.ReadOnly = true;
            this.DETAIL.Text = "DETAIL";
            this.DETAIL.UseColumnTextForButtonValue = true;
            // 
            // HAPUS
            // 
            this.HAPUS.HeaderText = "HAPUS";
            this.HAPUS.Name = "HAPUS";
            this.HAPUS.ReadOnly = true;
            this.HAPUS.Text = "HAPUS";
            this.HAPUS.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Jenis Pajak";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbJenisPajak
            // 
            this.cbJenisPajak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJenisPajak.FormattingEnabled = true;
            this.cbJenisPajak.Location = new System.Drawing.Point(89, 24);
            this.cbJenisPajak.Name = "cbJenisPajak";
            this.cbJenisPajak.Size = new System.Drawing.Size(121, 21);
            this.cbJenisPajak.TabIndex = 13;
            this.cbJenisPajak.SelectedIndexChanged += new System.EventHandler(this.cbJenisPajak_SelectedIndexChanged);
            this.cbJenisPajak.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbJenisPajak_MouseClick);
            // 
            // btnCekVersion
            // 
            this.btnCekVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCekVersion.ImageKey = "532.png";
            this.btnCekVersion.ImageList = this.imgSmall;
            this.btnCekVersion.Location = new System.Drawing.Point(732, 19);
            this.btnCekVersion.Name = "btnCekVersion";
            this.btnCekVersion.Size = new System.Drawing.Size(88, 29);
            this.btnCekVersion.TabIndex = 12;
            this.btnCekVersion.Text = "Cek Vers";
            this.btnCekVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCekVersion.UseVisualStyleBackColor = true;
            this.btnCekVersion.Visible = false;
            this.btnCekVersion.Click += new System.EventHandler(this.btnCekVersion_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(707, 27);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(113, 13);
            this.lblVersion.TabIndex = 11;
            this.lblVersion.Text = "Versi";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTesUpload
            // 
            this.btnTesUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTesUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTesUpload.ImageKey = "ms_excel1600.png";
            this.btnTesUpload.ImageList = this.imgSmall;
            this.btnTesUpload.Location = new System.Drawing.Point(616, 321);
            this.btnTesUpload.Name = "btnTesUpload";
            this.btnTesUpload.Size = new System.Drawing.Size(117, 30);
            this.btnTesUpload.TabIndex = 9;
            this.btnTesUpload.Text = "Komparasi File";
            this.btnTesUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTesUpload.UseVisualStyleBackColor = true;
            this.btnTesUpload.Click += new System.EventHandler(this.btnTesUpload_Click);
            // 
            // numJmlNop
            // 
            this.numJmlNop.Location = new System.Drawing.Point(216, 25);
            this.numJmlNop.Name = "numJmlNop";
            this.numJmlNop.Size = new System.Drawing.Size(65, 20);
            this.numJmlNop.TabIndex = 6;
            this.numJmlNop.Visible = false;
            this.numJmlNop.ValueChanged += new System.EventHandler(this.numJmlNop_ValueChanged);
            // 
            // dgvNop
            // 
            this.dgvNop.AllowUserToAddRows = false;
            this.dgvNop.AllowUserToDeleteRows = false;
            this.dgvNop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHECK_NOP,
            this.NOP});
            this.dgvNop.Location = new System.Drawing.Point(16, 227);
            this.dgvNop.Name = "dgvNop";
            this.dgvNop.RowHeadersVisible = false;
            this.dgvNop.Size = new System.Drawing.Size(770, 91);
            this.dgvNop.TabIndex = 5;
            // 
            // CHECK_NOP
            // 
            this.CHECK_NOP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CHECK_NOP.HeaderText = "";
            this.CHECK_NOP.Name = "CHECK_NOP";
            this.CHECK_NOP.Width = 20;
            // 
            // NOP
            // 
            this.NOP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NOP.DataPropertyName = "NOP";
            this.NOP.FillWeight = 109.7508F;
            this.NOP.HeaderText = "NOP";
            this.NOP.Name = "NOP";
            // 
            // dgvNamaColumn
            // 
            this.dgvNamaColumn.AllowUserToAddRows = false;
            this.dgvNamaColumn.AllowUserToDeleteRows = false;
            this.dgvNamaColumn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNamaColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNamaColumn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COLUMN_NAME,
            this.COLUMN_TEXT});
            this.dgvNamaColumn.Location = new System.Drawing.Point(16, 51);
            this.dgvNamaColumn.Name = "dgvNamaColumn";
            this.dgvNamaColumn.RowHeadersVisible = false;
            this.dgvNamaColumn.Size = new System.Drawing.Size(804, 170);
            this.dgvNamaColumn.TabIndex = 2;
            // 
            // COLUMN_NAME
            // 
            this.COLUMN_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.COLUMN_NAME.DataPropertyName = "COLUMN_NAME";
            this.COLUMN_NAME.FillWeight = 152.2843F;
            this.COLUMN_NAME.HeaderText = "NAMA KOLOM";
            this.COLUMN_NAME.Name = "COLUMN_NAME";
            this.COLUMN_NAME.ReadOnly = true;
            this.COLUMN_NAME.Width = 102;
            // 
            // COLUMN_TEXT
            // 
            this.COLUMN_TEXT.DataPropertyName = "COLUMN_TEXT";
            this.COLUMN_TEXT.FillWeight = 47.71573F;
            this.COLUMN_TEXT.HeaderText = "TEKS KOLOM";
            this.COLUMN_TEXT.Name = "COLUMN_TEXT";
            // 
            // btnBatal
            // 
            this.btnBatal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatal.ImageKey = "9308.png";
            this.btnBatal.ImageList = this.imgSmall;
            this.btnBatal.Location = new System.Drawing.Point(772, 578);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(81, 30);
            this.btnBatal.TabIndex = 4;
            this.btnBatal.Text = "Keluar";
            this.btnBatal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSimpan.ImageKey = "save-icon-png--4.png";
            this.btnSimpan.ImageList = this.imgSmall;
            this.btnSimpan.Location = new System.Drawing.Point(685, 578);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(81, 30);
            this.btnSimpan.TabIndex = 3;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNew.Location = new System.Drawing.Point(13, 13);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(93, 17);
            this.rbNew.TabIndex = 2;
            this.rbNew.TabStop = true;
            this.rbNew.Text = "New Settings";
            this.rbNew.UseVisualStyleBackColor = true;
            // 
            // rbExist
            // 
            this.rbExist.AutoSize = true;
            this.rbExist.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExist.Location = new System.Drawing.Point(13, 36);
            this.rbExist.Name = "rbExist";
            this.rbExist.Size = new System.Drawing.Size(113, 17);
            this.rbExist.TabIndex = 3;
            this.rbExist.TabStop = true;
            this.rbExist.Text = "Existing Settings";
            this.rbExist.UseVisualStyleBackColor = true;
            this.rbExist.Click += new System.EventHandler(this.rbExist_Click);
            // 
            // bgwCekExcel
            // 
            this.bgwCekExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCekExcel_DoWork);
            this.bgwCekExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCekExcel_RunWorkerCompleted);
            // 
            // bgwSendData
            // 
            this.bgwSendData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSendData_DoWork);
            this.bgwSendData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSendData_RunWorkerCompleted);
            // 
            // tCtlSetting
            // 
            this.tCtlSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tCtlSetting.Controls.Add(this.tpExc);
            this.tCtlSetting.Controls.Add(this.tpDb);
            this.tCtlSetting.Location = new System.Drawing.Point(13, 82);
            this.tCtlSetting.Name = "tCtlSetting";
            this.tCtlSetting.SelectedIndex = 0;
            this.tCtlSetting.Size = new System.Drawing.Size(846, 490);
            this.tCtlSetting.TabIndex = 5;
            this.tCtlSetting.Selected += new System.Windows.Forms.TabControlEventHandler(this.tCtlSetting_Selected);
            // 
            // tpExc
            // 
            this.tpExc.AutoScroll = true;
            this.tpExc.Controls.Add(this.gbSetting);
            this.tpExc.Location = new System.Drawing.Point(4, 22);
            this.tpExc.Name = "tpExc";
            this.tpExc.Padding = new System.Windows.Forms.Padding(3);
            this.tpExc.Size = new System.Drawing.Size(838, 464);
            this.tpExc.TabIndex = 0;
            this.tpExc.Text = "File";
            this.tpExc.UseVisualStyleBackColor = true;
            // 
            // tpDb
            // 
            this.tpDb.AutoScroll = true;
            this.tpDb.Controls.Add(this.btnAddDB);
            this.tpDb.Controls.Add(this.dgvSettingDB);
            this.tpDb.Location = new System.Drawing.Point(4, 22);
            this.tpDb.Name = "tpDb";
            this.tpDb.Padding = new System.Windows.Forms.Padding(3);
            this.tpDb.Size = new System.Drawing.Size(838, 464);
            this.tpDb.TabIndex = 1;
            this.tpDb.Text = "Database";
            this.tpDb.UseVisualStyleBackColor = true;
            // 
            // btnAddDB
            // 
            this.btnAddDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDB.ImageKey = "Plus.png";
            this.btnAddDB.ImageList = this.imgSmall;
            this.btnAddDB.Location = new System.Drawing.Point(6, 6);
            this.btnAddDB.Name = "btnAddDB";
            this.btnAddDB.Size = new System.Drawing.Size(94, 28);
            this.btnAddDB.TabIndex = 19;
            this.btnAddDB.Text = "Add Setting";
            this.btnAddDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddDB.UseVisualStyleBackColor = true;
            this.btnAddDB.Click += new System.EventHandler(this.btnAddDB_Click);
            // 
            // dgvSettingDB
            // 
            this.dgvSettingDB.AllowUserToAddRows = false;
            this.dgvSettingDB.AllowUserToDeleteRows = false;
            this.dgvSettingDB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSettingDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSettingDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSettingDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JENPAJAK,
            this.JML_NOP,
            this.QUERYPAJAK,
            this.QUERYDETAIL,
            this.DELETE});
            this.dgvSettingDB.Location = new System.Drawing.Point(6, 40);
            this.dgvSettingDB.Name = "dgvSettingDB";
            this.dgvSettingDB.ReadOnly = true;
            this.dgvSettingDB.RowHeadersVisible = false;
            this.dgvSettingDB.Size = new System.Drawing.Size(826, 370);
            this.dgvSettingDB.TabIndex = 0;
            this.dgvSettingDB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSettingDB_CellClick);
            // 
            // JENPAJAK
            // 
            this.JENPAJAK.DataPropertyName = "JENISPAJAK";
            this.JENPAJAK.HeaderText = "JENIS PAJAK";
            this.JENPAJAK.Name = "JENPAJAK";
            this.JENPAJAK.ReadOnly = true;
            // 
            // JML_NOP
            // 
            this.JML_NOP.DataPropertyName = "JML_NOP";
            this.JML_NOP.HeaderText = "JML NOP";
            this.JML_NOP.Name = "JML_NOP";
            this.JML_NOP.ReadOnly = true;
            // 
            // QUERYPAJAK
            // 
            this.QUERYPAJAK.DataPropertyName = "QUERYPAJAK";
            this.QUERYPAJAK.HeaderText = "QUERY PAJAK";
            this.QUERYPAJAK.Name = "QUERYPAJAK";
            this.QUERYPAJAK.ReadOnly = true;
            // 
            // QUERYDETAIL
            // 
            this.QUERYDETAIL.DataPropertyName = "QUERYDETAIL";
            this.QUERYDETAIL.HeaderText = "QUERY DETAIL";
            this.QUERYDETAIL.Name = "QUERYDETAIL";
            this.QUERYDETAIL.ReadOnly = true;
            // 
            // DELETE
            // 
            this.DELETE.HeaderText = "ACTION";
            this.DELETE.Name = "DELETE";
            this.DELETE.ReadOnly = true;
            this.DELETE.Text = "DELETE";
            this.DELETE.UseColumnTextForButtonValue = true;
            // 
            // bgwSendDB
            // 
            this.bgwSendDB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSendDB_DoWork);
            this.bgwSendDB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSendDB_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.btnOpenPort);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(573, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 64);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Client";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(16, 25);
            this.tbPort.MaxLength = 5;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(122, 20);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "2502";
            this.tbPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPort_KeyPress);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenPort.ImageKey = "open.png";
            this.btnOpenPort.ImageList = this.imgSmall;
            this.btnOpenPort.Location = new System.Drawing.Point(173, 18);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(88, 30);
            this.btnOpenPort.TabIndex = 0;
            this.btnOpenPort.Text = "Open Port";
            this.btnOpenPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // bgwTxt
            // 
            this.bgwTxt.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTxt_DoWork);
            this.bgwTxt.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTxt_RunWorkerCompleted);
            // 
            // frmFtpSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(868, 619);
            this.Controls.Add(this.gbUrlApi);
            this.Controls.Add(this.rbExist);
            this.Controls.Add(this.rbNew);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.tCtlSetting);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFtpSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APP Settings";
            this.Load += new System.EventHandler(this.frmFtpSettings_Load);
            this.gbUrlApi.ResumeLayout(false);
            this.gbUrlApi.PerformLayout();
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJmlNop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNamaColumn)).EndInit();
            this.tCtlSetting.ResumeLayout(false);
            this.tpExc.ResumeLayout(false);
            this.tpDb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettingDB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUrlApi;
        private System.Windows.Forms.TextBox tbUrlApi;
        private System.Windows.Forms.Button btnTesApi;
        private System.Windows.Forms.ImageList imgSmall;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.DataGridView dgvNamaColumn;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLUMN_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLUMN_TEXT;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.RadioButton rbExist;
        private System.Windows.Forms.NumericUpDown numJmlNop;
        private System.Windows.Forms.DataGridView dgvNop;
        private System.ComponentModel.BackgroundWorker bgwCekExcel;
        private System.Windows.Forms.Button btnTesUpload;
        private System.Windows.Forms.ProgressBar pbLoading;
        private System.ComponentModel.BackgroundWorker bgwSendData;
        private System.ComponentModel.BackgroundWorker bgwXml;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnCekVersion;
        private System.Windows.Forms.TabControl tCtlSetting;
        private System.Windows.Forms.TabPage tpExc;
        private System.Windows.Forms.TabPage tpDb;
        private System.Windows.Forms.ComboBox cbJenisPajak;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOP;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn JENISPAJAK;
        private System.Windows.Forms.DataGridViewTextBoxColumn JML_OP;
        private System.Windows.Forms.DataGridViewButtonColumn DETAIL;
        private System.Windows.Forms.DataGridViewButtonColumn HAPUS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelNop;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.Button btnAddNop;
        private System.Windows.Forms.Label lblCountNop;
        private System.Windows.Forms.DataGridView dgvSettingDB;
        private System.Windows.Forms.Button btnAddDB;
        private System.ComponentModel.BackgroundWorker bgwSendDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn JENPAJAK;
        private System.Windows.Forms.DataGridViewTextBoxColumn JML_NOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUERYPAJAK;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUERYDETAIL;
        private System.Windows.Forms.DataGridViewButtonColumn DELETE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHECK_NOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOP;
        private System.ComponentModel.BackgroundWorker bgwTxt;
    }
}