using FastMember;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using POAdministrationTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace POFtpSender
{
    public partial class frmFtpSettings : Form
    {
        private List<string> _listSuccess;
        private List<USERAPP> _ListUser;
        private List<NOP> _listNOP;
        private List<Setting> _listSetting;
        private AppSettings _appSettings;
        private bool _isApiConnect;
        private string _urlApi;
        private string _portClient;
        private Dictionary<string, bool> _dictColHeader;
        //private bool _IsPortOpen;
        private List<ExceptionPort> _lstPort;

        public frmFtpSettings()
        {
            InitializeComponent();
            _listNOP = new List<NOP>();
            _listSetting = new List<Setting>();
            _listSuccess = new List<string>();

            rbNew.Checked = true;
            pbLoading.Hide();
            lblCountNop.Text = "Jml : 0";
        }

        private void LoadComboJenisPajak()
        {
            Dictionary<string, string> lstPajak = new Dictionary<string, string>();
            if (lst.Count > 0)
            {
                var teksPajak = lst.Select(s => s.JenPajak).Distinct().ToList();
                for (int iList = 0; iList < teksPajak.Count; iList++)
                {
                    lstPajak.Add(teksPajak[iList], teksPajak[iList]);
                }
            }

            cbJenisPajak.DataSource = new BindingSource(lstPajak, null);
            cbJenisPajak.ValueMember = "key";
            cbJenisPajak.DisplayMember = "value";
        }

        List<PajakEntity> lst;
        private void LoadGridPajak(string NamaPajak)
        {
            if (string.IsNullOrEmpty(NamaPajak))
                NamaPajak = "HOTEL";

            DataTable dtNamaKolom = new DataTable();
            dtNamaKolom.Columns.Add("COLUMN_NAME", typeof(string));
            dtNamaKolom.Columns.Add("COLUMN_TEXT", typeof(string));

            var lstPajak = lst.Where(s => s.JenPajak == NamaPajak).ToList();

            for (int iList = 0; iList < lstPajak.Count; iList++)
            {
                DataRow newRow = dtNamaKolom.NewRow();
                newRow["COLUMN_NAME"] = lstPajak[iList].teks;
                newRow["COLUMN_TEXT"] = "";
                dtNamaKolom.Rows.Add(newRow);
            }

            dgvNamaColumn.DataSource = dtNamaKolom;
            dgvNamaColumn.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private List<PajakEntity> ParsingXmlJenisPajak(string pathName)
        {
            List<PajakEntity> lst = new List<PajakEntity>();
            string fileName = pathName;
            string jenisPajak = string.Empty;

            using (XmlReader reader = XmlReader.Create(fileName))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToUpper())
                        {
                            case "SETTING":
                                //string versi = reader["version"];
                                //lblVersion.Text = "setting v." + versi;
                                break;
                            case "JENIS":
                                jenisPajak = reader["nama"];
                                break;
                            default:
                                break;
                        }
                    }

                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        string teks = reader.Value;
                        PajakEntity le = new PajakEntity();
                        //insert into list
                        le.JenPajak = jenisPajak;
                        le.teks = teks;
                        lst.Add(le);
                    }
                }
            }

            return lst;
        }

        private void cbJenisPajak_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isDgvOpKlik)
                LoadGridPajak(cbJenisPajak.SelectedValue.ToString());

        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        DataTable dtNop;
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda ingin menyimpan data setting?", "Peringatan", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            frmValidasiUser frmVal = new frmValidasiUser();
            if (frmVal.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //if (!_IsPortOpen)
            //{
            //    MessageBox.Show("Port belum tersedia. Klik open port dahulu.", "Peringatan");
            //    return;
            //}

            dtNop = new DataTable();
            dtNop.Columns.Add("NOP", typeof(string));
            dtNop.Columns.Add("JENISPAJAK", typeof(string));

            if (_listSuccess.Count >= 2)
            {
                if (_lstColumnName != null && _lstColumnName.Count > 0)
                    SetConfigUploadAndSendAPI();
                else
                {
                    if (ClassHelper.lstDBSettings != null && ClassHelper.lstDBSettings.Count > 0)
                    {
                        if (!bgwSendDB.IsBusy)
                        {
                            pbLoading.Show();
                            bgwSendDB.RunWorkerAsync();
                        }
                    }
                    else
                        MessageBox.Show("Tidak ada data setting yang akan dikirim. Mohon periksa kembali.", "Peringatan");
                }
            }
            else
            {
                if (_listSuccess == null || _listSuccess.Count == 0)
                {
                    MessageBox.Show("Klik Tes Koneksi terlebih dahulu.", "Peringatan");
                }
                else
                {
                    //Check if setting upload is entry
                    if (_listSetting != null && _listSetting.Count > 0)
                    {
                        var lst = _listSuccess.FindAll(s => s.ToUpper().Contains("API"));
                        if (lst.Count > 0)
                        {
                            if (MessageBox.Show("Pastikan semua Kolom sudah valid, jika belum silahkan melakukan Komparasi excel terlebih dahulu", "Peringatan", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                SetConfigUploadAndSendAPI();
                            }
                        }
                        else
                            MessageBox.Show("Klik Tes Koneksi terlebih dahulu.", "Peringatan");
                    }
                    else
                    {
                        if (ClassHelper.lstDBSettings != null && ClassHelper.lstDBSettings.Count > 0)
                        {
                            if (!bgwSendDB.IsBusy)
                            {
                                pbLoading.Show();
                                bgwSendDB.RunWorkerAsync();
                            }
                        }
                        else
                            MessageBox.Show("Tidak ada data setting yang akan dikirim. Mohon periksa kembali.", "Peringatan");
                    }


                }
            }
        }

        private void SetConfigUploadAndSendAPI()
        {
            if (_listSetting.Count <= 0)
            {
                MessageBox.Show("List Nop belum terisi.", "Peringatan");
                return;
            }

            List<string> lstNop = new List<string>();
            lstNop = _listSetting.Select(x => x.nop).Distinct().ToList();

            foreach (var item in lstNop)
            {
                NOP nopEntity = new NOP();
                string nop = item;
                string jenPajak = string.Empty;
                switch (nop.Replace(".", string.Empty).Substring(10, 3))
                {
                    case "901":
                        jenPajak = "HOTEL";
                        break;
                    case "902":
                        jenPajak = "RESTORAN";
                        break;
                    case "903":
                        jenPajak = "HIBURAN";
                        break;
                    case "907":
                        jenPajak = "PARKIR";
                        break;
                    default:
                        break;
                }

                nopEntity.nop = nop;
                nopEntity.jenisPajak = jenPajak;

                _listNOP.Add(nopEntity);
            }

            //Send data to Web API
            if (!bgwSendData.IsBusy)
            {
                //urlApi = tbUrlApi.Text;
                pbLoading.Show();
                bgwSendData.RunWorkerAsync();
            }
        }

        private void rbExist_Click(object sender, EventArgs e)
        {
            frmSettingExisting frmExisting = new frmSettingExisting();
            if (frmExisting.ShowDialog() == DialogResult.Yes)
            {
                DialogResult = DialogResult.Yes;
                Close();
                return;
            }
            rbNew.Checked = true;
        }

        private void frmFtpSettings_Load(object sender, EventArgs e)
        {
            CreateFTPDirectory();
            tCtlSetting.Enabled = false;
            lst = new List<PajakEntity>();
            ClassHelper.lstDBSettings = new List<DBSettings>();
            lst = ParsingXmlJenisPajak("setJenis.xml");
            LoadComboJenisPajak();
            LoadGridPajak(cbJenisPajak.SelectedValue.ToString());
            gbUrlApi.Show();
            rbNew.Checked = true;
            tbUrlApi.Focus();
            _dtOP.Columns.Add("JENISPAJAK", typeof(string));
            _dtOP.Columns.Add("JML_OP", typeof(string));
            //_IsPortOpen = false;
            _isApiConnect = false;
            _lstPort = new List<ExceptionPort>();
            _portClient = string.Empty;
            string vers = ClassHelper.LoadVersion();
            lblVersion.Text = "Ver. " + vers;
            this.Text = "APP Settings Ver." + vers;
            _portClient = tbPort.Text;
            ClassHelper.port = Convert.ToInt32(_portClient);
        }

        private void CreateFTPDirectory()
        {
            string folderName = @"C:\FTPFile";

            DirectoryInfo di = new DirectoryInfo(folderName);
            if (!Directory.Exists(folderName))
            {
                di.Create();
                di.CreateSubdirectory("INBOX");
                di.CreateSubdirectory("SUCCESS");
                di.CreateSubdirectory("FAILED");
                di.CreateSubdirectory("LOGS");
            }

        }

        private void numJmlNop_ValueChanged(object sender, EventArgs e)
        {
            while (dgvNop.Rows.Count < numJmlNop.Value)
            {
                dgvNop.Rows.Add();
            }
            while (dgvNop.Rows.Count > numJmlNop.Value)
            {
                dgvNop.Rows.RemoveAt(dgvNop.Rows.Count - 1);
            }

            dgvNop.Columns["CHECK_NOP"].DisplayIndex = 0;
            dgvNop.Columns["NOP"].DisplayIndex = 1;

            lblCountNop.Text = "Jml : " + numJmlNop.Value;
        }

        List<string> _lstColumnName;
        private void btnTesUpload_Click(object sender, EventArgs e)
        {
            _lstColumnName = new List<string>();
            List<string> lstNop = new List<string>();
            bool isColumnNull = false;
            for (int iRow = 0; iRow < dgvNamaColumn.Rows.Count; iRow++)
            {
                if (string.IsNullOrEmpty(dgvNamaColumn.Rows[iRow].Cells["COLUMN_TEXT"].Value.ToString()))
                {
                    isColumnNull = true;
                    break;
                }
                else
                {
                    _lstColumnName.Add(dgvNamaColumn.Rows[iRow].Cells["COLUMN_TEXT"].Value.ToString());
                }
            }

            if (dgvNop.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < dgvNop.Rows.Count; iRow++)
                {
                    if (dgvNop.Rows[iRow].Cells["NOP"].Value == null)
                    {
                        MessageBox.Show("Kolom Nop tidak boleh kosong.", "Peringatan");
                        return;
                    }
                    else
                        lstNop.Add(dgvNop.Rows[iRow].Cells["NOP"].Value.ToString());
                }
            }
            else
            {
                MessageBox.Show("Kolom Nop tidak boleh kosong.", "Peringatan");
                return;
            }

            if (!isColumnNull)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel 2003 files (*.xls)|*.xls|Excel Files (*.xlsx)|*.xlsx|Text (*.txt*)|*.txt|CSV (*.csv*)|*.csv";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(ofd.SafeFileName);

                    //string[] namaFile = ofd.SafeFileName.Split('.');
                    string namaFile = file.Name.Replace(file.Extension, string.Empty).Replace(".", string.Empty).Replace(",", string.Empty);
                    var nopCount = lstNop.FindAll(s => s.Replace(".", string.Empty).Replace(".", string.Empty) == namaFile);
                    if (nopCount.Count <= 0)
                    {
                        MessageBox.Show("Nop pada nama excel tidak ada pada list.", "Peringatan");
                        return;
                    }

                    try
                    {
                        _pathExcel = ofd.FileName;
                        switch (file.Extension.ToUpper())
                        {
                            case ".TXT":
                            case ".CSV":
                                if (!bgwTxt.IsBusy)
                                {
                                    pbLoading.Show();
                                    bgwTxt.RunWorkerAsync();
                                }
                                break;
                            case ".XLS":
                            case ".XLSX":
                                if (!bgwCekExcel.IsBusy)
                                {
                                    pbLoading.Show();
                                    bgwCekExcel.RunWorkerAsync();
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
                MessageBox.Show("Mohon isi semua kolom teks, gunakan tanda '-' jika kosong", "Peringatan");

        }

        private void btnTesApi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUrlApi.Text))
            {
                MessageBox.Show("Url Web API tidak boleh kosong.", "Peringatan");
                return;
            }

            _urlApi = string.Empty;
            if (tbUrlApi.Text.Contains("http"))
                _urlApi = tbUrlApi.Text;
            else
                _urlApi = "http://" + tbUrlApi.Text;

            ClassHelper.urlAPI = _urlApi;
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(_urlApi + "/testConnection");
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("THE HOSTNAME COULD NOT BE PARSED"))
                    MessageBox.Show("Mohon periksa kembali URL tersebut tidak ditemukan.", "Peringatan");
                else
                    MessageBox.Show("Mohon periksa kembali URL : " + ex.Message, "Peringatan");

                return;
            }


            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(_urlApi + "/testConnection");
                var response = (HttpWebResponse)request.GetResponse();
                string valStatus = string.Empty;
                string pesan = string.Empty;

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                    JToken jVal = jObj["value"];
                    JToken jBody = jObj["body"];

                    if (jVal.ToString().Contains("OK"))
                    {
                        _lstPort = JsonConvert.DeserializeObject<List<ExceptionPort>>(jBody.ToString());
                        ClassHelper.ListNotAllowedPort(ref _lstPort);
                        _isApiConnect = true;
                        var lst = _listSuccess.FindAll(s => s.ToUpper().Contains("API"));
                        if (lst.Count <= 0)
                            _listSuccess.Add("Setting API");

                        MessageBox.Show("Koneksi Berhasil.");
                    }
                    else
                    {
                        MessageBox.Show(jVal.ToString());
                        _isApiConnect = false;
                    }
                }


            }
            catch (Exception ex)
            {
                if (ex.ToString().ToUpper().Contains("UNABLE TO CONNECT TO THE REMOTE SERVER"))
                {
                    MessageBox.Show("Koneksi Gagal : API Tidak terhubung ke server");
                }
                _isApiConnect = false;
            }

            if (_isApiConnect)
            {
                tCtlSetting.Enabled = true;
                new frmOpsiFile().ShowDialog();
                if (string.Compare(ClassHelper.jenisFile, "TXT") == 0 || string.Compare(ClassHelper.jenisFile, "CSV") == 0)
                    gbSetting.Text = "Setting kolom ( " + ClassHelper.jenisFile + " dengan separator '" + ClassHelper.separator + "')";
                else
                    gbSetting.Text = "Setting kolom ( " + ClassHelper.jenisFile + " )";

                if (string.Compare(ClassHelper.jenisFile, "DATABASE") == 0)
                {
                    tCtlSetting.SelectedTab = tpDb;
                }
            }

        }

        string _pathExcel;
        bool _isColumnTrue;
        List<string> _lstKolomTeks;
        bool _isFileOpen;
        StringBuilder getErrorMsg;
        private void bgwCekExcel_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _isFileOpen = false;
            XSSFWorkbook hssfwb = null;
            bool isError = false;

            getErrorMsg = new StringBuilder();
            try
            {   
                using (FileStream file = new FileStream(_pathExcel, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new XSSFWorkbook(file);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("USED BY ANOTHER"))
                {
                    _isFileOpen = true;
                    return;
                }
                else
                {
                    isError = true;
                    getErrorMsg.AppendLine(ex.Message);
                    //return;
                }
            }

            _isColumnTrue = true;
            bool isColumnFound = false;
            _lstKolomTeks = new List<string>();
            ISheet sheet = null;
            IRow headerRow = null;
            _dictColHeader = new Dictionary<string, bool>();
            int iCount = 0;

            //read open office excel
            if (isError)
            {
                try
                {
                    getErrorMsg = new StringBuilder();
                    DataSet ds = ClassHelper.ReadExcelFile(_pathExcel);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];

                    //cek column exist
                    foreach (DataColumn col in dt.Columns)
                    {
                        string teks = col.ColumnName.ToUpper();

                        if (string.Compare(teks, "-") == 0)
                            continue;

                        var lstKolom = _lstColumnName.Where(s => s.ToUpper() == teks).FirstOrDefault();
                        if (lstKolom == null)
                        {
                            //header tidak ditemukan
                            if (iCount == 0)
                                continue;
                            else
                            {
                                _isColumnTrue = false;
                                _lstKolomTeks.Add(teks);
                                //break;
                            }

                        }
                        else
                        {
                            //header kolumn ditemukan
                            _dictColHeader[teks.ToUpper()] = true;
                            isColumnFound = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    getErrorMsg.AppendLine(ex.Message);
                }

                return;
            }

            //read office excel
            try
            {
                sheet = hssfwb.GetSheetAt(0);
                for (int iColName = 0; iColName < _lstColumnName.Count; iColName++)
                {
                    if (string.Compare(_lstColumnName[iColName], "-") != 0)
                        _dictColHeader.Add(_lstColumnName[iColName].ToUpper(), false);
                }

                for (int iRow = 0; iRow < 10; iRow++)
                {
                    if (isColumnFound)
                        break;

                    headerRow = sheet.GetRow(iRow);

                    if (headerRow != null && headerRow.LastCellNum > 0)
                    {
                        //Cek if this row is column name
                        for (int iCol = 0; iCol < headerRow.Cells.Count; iCol++)
                        {
                            string teks = headerRow.Cells[iCol].StringCellValue;
                            if (string.Compare(teks, "-") != 0)
                            {
                                var lstKolom = _lstColumnName.Where(s => s.ToUpper() == teks.ToUpper()).FirstOrDefault();
                                if (lstKolom == null)
                                {
                                    //header tidak ditemukan
                                    if (iCount == 0)
                                        continue;
                                    else
                                    {
                                        _isColumnTrue = false;
                                        _lstKolomTeks.Add(teks);
                                        //break;
                                    }

                                }
                                else
                                {
                                    //header kolumn ditemukan
                                    _dictColHeader[teks.ToUpper()] = true;
                                    isColumnFound = true;
                                }
                            }
                            iCount++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                getErrorMsg.AppendLine(ex.Message);
            }
        }

        private void bgwCekExcel_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_isFileOpen)
            {
                MessageBox.Show("File dalam kondisi terbuka, tutup file terlebih dahulu.", "peringatan");
                pbLoading.Hide();
                return;
            }

            if (getErrorMsg.Length > 0)
            {
                MessageBox.Show(getErrorMsg.ToString(), "peringatan");
                pbLoading.Hide();
                return;
            }

            if (!_isColumnTrue)
            {
                StringBuilder sb = new StringBuilder();
                string kolomTeks = string.Empty;
                var headerNotFound = _dictColHeader.Where(m => !m.Value);
                foreach (var item in headerNotFound)
                {
                    sb.Append(item.Key + ",");
                }

                kolomTeks = "{ ";
                for (int iCol = 0; iCol < _lstKolomTeks.Count; iCol++)
                {
                    kolomTeks += _lstKolomTeks[iCol] + ",";
                }
                kolomTeks += sb.ToString();
                kolomTeks = kolomTeks.Remove(kolomTeks.Length - 1) + " }";

                sb = new StringBuilder();
                sb.AppendLine("Nama Kolom : " + kolomTeks + " di excel, tidak ditemukan pada entri nama kolom tersebut.");
                sb.AppendLine("Silahkan cek kembali nama kolom pada excel.");
                sb.AppendLine("Jika sudah benar, silahkan abaikan dan klik simpan.");
                MessageBox.Show(sb.ToString(), "Peringatan");

            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Cek Kolom berhasil, semua nama kolom yang dientry sudah sesuai.");
                sb.AppendLine("Silahkan simpan setting untuk melakukan proses selanjutnya.");
                MessageBox.Show(sb.ToString(), "Perhatian");
                var lst = _listSuccess.FindAll(s => s.ToUpper().Contains("EXCEL"));
                if (lst.Count <= 0)
                    _listSuccess.Add("Setting Excel");
            }

            pbLoading.Hide();
        }

        private void bgwSendData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pbLoading.Hide();
            if (_isSend)
            {
                if (_isHaveSettingDB)
                {
                    if (!bgwSendDB.IsBusy)
                    {
                        pbLoading.Show();
                        bgwSendDB.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Simpan file berhasil", "Perhatian");
                    DialogResult = DialogResult.Yes;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Simpan file gagal : " + _errMessage, "Peringatan");
            }
        }

        private void btnCekVersion_Click(object sender, EventArgs e)
        {
            if (!_listSuccess.Contains("API"))
            {
                MessageBox.Show("Mohon cek dahulu koneksi ke API", "Peringatan");
            }
            else
            {
                //Get Latest Version from Server
            }
        }

        bool _isSend;
        bool _isHaveSettingDB;
        string _errMessage;
        private void bgwSendData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _isSend = false;
            _errMessage = string.Empty;
            _isHaveSettingDB = false;


            //Create GUID AND USER
            string userName = string.Empty;
            string cpuInfo = string.Empty;
            string guidInfo = string.Empty;
            HttpWebRequest httpWebRequest;
            cpuInfo = GetIdMachine(out userName, out guidInfo, out httpWebRequest);


            //Send data API & Create XML File upload Excel
            #region Upload File
            if (_listSetting != null)
                //Create XML File            
                ClassHelper.WriteXmlFile(_listSetting, _listNOP, _urlApi, _ListUser, out _errMessage);

            //Get Content setUpload.xml to string
            string xmlString = System.IO.File.ReadAllText("setUpload.xml");

            _appSettings = new AppSettings
            {
                list_user = _ListUser,
                list_nop = _listNOP,
                settings = _listSetting,
                xml_content = xmlString,
                jenFile = ClassHelper.jenisFile,
                separator = ClassHelper.separator.ToString()
            };

            if (string.IsNullOrEmpty(_errMessage))
            {
                try
                {
                    if (!string.IsNullOrEmpty(_errMessage))
                    {
                        _isSend = false;
                        return;
                    }

                    //Send Json Request
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(_urlApi + "/dev/postSettingClient");
                    var jsonBody = JsonConvert.SerializeObject(_appSettings);

                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(jsonBody);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    //{
                    //    var result = streamReader.ReadToEnd();
                    //}

                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        _isSend = true;
                    }
                }
                catch (Exception ex)
                {
                    _errMessage = ex.Message;
                    return;
                }
            }
            #endregion

            //Send data API & Create XML File retrieve database
            #region Database
            if (ClassHelper.lstDBSettings != null && ClassHelper.lstDBSettings.Count > 0)
            {
                _isHaveSettingDB = true;
            }
            #endregion
        }

        private string GetIdMachine(out string userName, out string guidInfo, out HttpWebRequest httpWebRequest)
        {
            string cpuInfo = string.Empty;

            cpuInfo = SerialKey.RetrieveIDMachine();

            USERAPP setUser = new USERAPP();
            guidInfo = Guid.NewGuid().ToString();

            //Random character            
            string randomTeks = string.Empty;


            //Find randomteks if exist in lstUserName
            List<string> lstUsr = new List<string>();
            httpWebRequest = (HttpWebRequest)WebRequest.Create(_urlApi + "/dev/getAllUser");
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";

            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(stream, Encoding.UTF8);
            string info = readStream.ReadToEnd();
            JObject jObj = JObject.Parse(info);
            JToken jUser = jObj["body"];

            lstUsr = JsonConvert.DeserializeObject<List<string>>(jUser.ToString()).ToList();

            response.Close();
            readStream.Close();
            randomTeks = SerialKey.GenerateUser(lstUsr);

            userName = randomTeks;

            setUser.userName = userName;
            setUser.idMachine = cpuInfo;
            setUser.guid = guidInfo;
            setUser.phone = ClassHelper.PhoneUser;
            setUser.mail = ClassHelper.MailUser;
            setUser.port = Convert.ToInt32(_portClient);
            _ListUser = new List<USERAPP>();
            _ListUser.Add(setUser);
            return cpuInfo.Replace(" ", string.Empty);
        }

        DataTable _dtOP = new DataTable();
        private void btnOk_Click(object sender, EventArgs e)
        {
            //Check if Nop empty
            if (dgvNop.Rows.Count <= 0)
            {
                MessageBox.Show("Data Nop belum diisi, Mohon isi nop terlebih dahulu.", "Peringatan");
                return;
            }

            foreach (DataGridViewRow dRow in dgvNamaColumn.Rows)
            {
                try
                {
                    if (string.IsNullOrEmpty(dRow.Cells["COLUMN_TEXT"].Value.ToString()))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Isian teks kolom tidak boleh kosong.");
                        sb.AppendLine("Isi dengan tanda (-) minus jika kosong.");
                        MessageBox.Show(sb.ToString(), "Peringatan");
                        return;
                    }
                }
                catch
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Isian teks kolom tidak boleh kosong.");
                    sb.AppendLine("Isi dengan tanda (-) minus jika kosong.");
                    MessageBox.Show(sb.ToString(), "Peringatan");
                    return;
                }
            }

            DataTable dt = new DataTable();

            //Check Nop Validation by JenisPajak
            bool isNopValid = false;
            string jenPjk = cbJenisPajak.Text;
            List<string> lstInvalidNop = new List<string>();
            Task t1 = Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(dgvNop.Rows.Cast<DataGridViewRow>(), (dRow) =>
                {
                    string nopVal = dRow.Cells["NOP"].Value.ToString().Replace(".", string.Empty).Replace(",", string.Empty);
                    switch (jenPjk)
                    {
                        case "HOTEL":
                            if (nopVal.Substring(10, 3) == "901")
                                isNopValid = true;
                            else
                            {
                                lstInvalidNop.Add(dRow.Cells["NOP"].Value.ToString());
                                isNopValid = false;
                            }
                            break;
                        case "RESTORAN":
                            if (nopVal.Substring(10, 3) == "902")
                                isNopValid = true;
                            else
                            {
                                lstInvalidNop.Add(dRow.Cells["NOP"].Value.ToString());
                                isNopValid = false;
                            }
                            break;
                        case "HIBURAN":
                            if (nopVal.Substring(10, 3) == "903")
                                isNopValid = true;
                            else
                            {
                                lstInvalidNop.Add(dRow.Cells["NOP"].Value.ToString());
                                isNopValid = false;
                            }
                            break;
                        case "PARKIR":
                            if (nopVal.Substring(10, 3) == "907")
                                isNopValid = true;
                            else
                            {
                                lstInvalidNop.Add(dRow.Cells["NOP"].Value.ToString());
                                isNopValid = false;
                            }
                            break;
                        default:
                            break;
                    }
                });
            });

            try
            {
                while (t1.Status != TaskStatus.RanToCompletion)
                {
                    Task.Delay(1000);
                }
            }
            catch { }

            if (!isNopValid)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Mohon periksa Nop berikut :");
                for (int iNop = 1; iNop < lstInvalidNop.Count + 1; iNop++)
                {
                    sb.AppendLine(iNop + ". " + lstInvalidNop[iNop - 1]);
                }
                sb.AppendLine("Nop tersebut bukan Nop atas Pajak " + jenPjk);
                MessageBox.Show(sb.ToString(), "Peringatan");
                return;
            }

            //Check if JenisPajak isExists
            if (dgvOP != null && dgvOP.Rows.Count > 0)
            {
                var rowCount = dgvOP.Rows.Cast<DataGridViewRow>()
                    .Count(r => r.Cells["JENISPAJAK"].Value.ToString() == jenPjk);


                if (rowCount > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Jenis Pajak tersebut telah dientry,");
                    sb.AppendLine("Silahkan hapus terlebih dahulu jenis pajak tersebut untuk mengupdate yang baru.");
                    MessageBox.Show(sb.ToString(), "Peringatan");
                    return;
                }
            }


            //insert list nop
            Setting sett = new Setting();

            DataRow newRow = _dtOP.NewRow();
            newRow["JENISPAJAK"] = cbJenisPajak.Text;
            newRow["JML_OP"] = dgvNop.Rows.Count;
            _dtOP.Rows.Add(newRow);

            //insert list setting
            dt = new DataTable();
            dt = (DataTable)(dgvNamaColumn.DataSource);

            foreach (DataGridViewRow item in dgvNop.Rows)
            {
                string nopVal = item.Cells["NOP"].Value == DBNull.Value ? string.Empty : item.Cells["NOP"].Value.ToString().Replace(".", string.Empty).Replace(",", string.Empty);
                Task t2 = Task.Factory.StartNew(() =>
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        sett = new Setting();
                        sett.nop = nopVal;
                        sett.column_name = dRow["COLUMN_NAME"].ToString();
                        sett.column_text = dRow["COLUMN_TEXT"].ToString();

                        _listSetting.Add(sett);
                    }
                });

                while (t2.Status != TaskStatus.RanToCompletion)
                {
                    Task.Delay(1000);
                }
            }


            dgvOP.DataSource = _dtOP;
            ClearAllTeks();
        }

        private void ClearAllTeks()
        {
            cbJenisPajak.SelectedIndex = 0;
            numJmlNop.Value = 0;
            LoadGridPajak(cbJenisPajak.SelectedValue.ToString());
            while (dgvNop.Rows.Count > 0)
            {
                dgvNop.Rows.RemoveAt(0);
            }
        }

        bool isDgvOpKlik;
        private void dgvOP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Yakin ingin menghapus data Pajak tersebut?", "Peringatan", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            isDgvOpKlik = true;

            var distNop = _listSetting.Select(x => x.nop).Distinct();

            string jenPjk = dgvOP.Rows[e.RowIndex].Cells["JENISPAJAK"].Value.ToString();
            switch (jenPjk)
            {
                case "HOTEL":
                    distNop = distNop.Where(x => x.Substring(10, 3) == "901");
                    break;
                case "RESTORAN":
                    distNop = distNop.Where(x => x.Substring(10, 3) == "902").ToList();
                    break;
                case "HIBURAN":
                    distNop = distNop.Where(x => x.Substring(10, 3) == "903").ToList();
                    break;
                case "PARKIR":
                    distNop = distNop.Where(x => x.Substring(10, 3) == "907").ToList();
                    break;
                default:
                    break;
            }

            //view detail
            if (e.ColumnIndex == 0)
            {
                DataTable dt = new DataTable();
                using (var reader = ObjectReader.Create(_listSetting))
                {
                    dt.Load(reader);
                }

                if (dt.Rows.Count > 0)
                {
                    DataView view = new DataView(dt);
                    DataTable distinctViewNop = new DataTable();

                    DataTable ViewColumns = new DataTable();
                    switch (jenPjk)
                    {
                        case "HOTEL":
                            view.RowFilter = "substring(NOP,11,3) = '901'";
                            distinctViewNop = view.ToTable(true, "NOP");
                            ViewColumns = view.ToTable(true, "COLUMN_NAME", "COLUMN_TEXT");
                            break;
                        case "RESTORAN":
                            view.RowFilter = "substring(NOP,11,3) = '902'";
                            distinctViewNop = view.ToTable(true, "NOP");
                            ViewColumns = view.ToTable(true, "COLUMN_NAME", "COLUMN_TEXT");
                            break;
                        case "HIBURAN":
                            break;
                        case "PARKIR":
                            break;
                        default:
                            break;
                    }

                    if ((distinctViewNop != null && distinctViewNop.Rows.Count > 0) &&
                        (ViewColumns != null && ViewColumns.Rows.Count > 0))
                    {
                        dgvNamaColumn.DataSource = ViewColumns;
                        while (dgvNop.Rows.Count > 0)
                        {
                            dgvNop.Rows.RemoveAt(0);
                        }

                        foreach (DataRow item in distinctViewNop.Rows)
                        {
                            int rowIndex = dgvNop.Rows.Add();
                            DataGridViewRow dRow = dgvNop.Rows[rowIndex];
                            dRow.Cells[0].Value = false;
                            dRow.Cells[1].Value = item.ItemArray[0];
                        }

                        numJmlNop.Value = dgvNop.Rows.Count;
                    }

                    cbJenisPajak.Text = jenPjk;
                }
            }

            //hapus
            if (e.ColumnIndex == 1)
            {
                if (distNop.Count() > 0)
                {
                    for (int iRow = 0; iRow < distNop.Count(); iRow++)
                    {
                        string strNop = distNop.ToList()[iRow].ToString();
                        _listSetting.RemoveAll(x => x.nop == strNop);
                    }
                }

                dgvOP.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void cbJenisPajak_MouseClick(object sender, MouseEventArgs e)
        {
            isDgvOpKlik = false;
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            Parallel.ForEach(dgvNop.Rows.Cast<DataGridViewRow>(), dRow =>
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dRow.Cells[0];
                chk.Value = cbAll.Checked;
            });

        }

        private void btnAddNop_Click(object sender, EventArgs e)
        {
            numJmlNop.Value += 1;
        }

        private void btnDelNop_Click(object sender, EventArgs e)
        {
            if (numJmlNop.Value == 0)
            {
                return;
            }

            bool isChecked = false;
            Parallel.ForEach(dgvNop.Rows.Cast<DataGridViewRow>(), dRow =>
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dRow.Cells[0];
                if (chk.Value != null)
                    isChecked = true;

            });

            if (isChecked)
            {
                for (int i = dgvNop.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)dgvNop.Rows[i].Cells[0].FormattedValue)
                    {
                        dgvNop.Rows.RemoveAt(i);
                        numJmlNop.Value -= 1;
                    }
                }
            }
            else
                numJmlNop.Value -= 1;

            if (numJmlNop.Value == 0)
                cbAll.Checked = false;
        }

        private void btnAddDB_Click(object sender, EventArgs e)
        {
            if (_listSuccess.Count == 0)
            {
                MessageBox.Show("Klik Tes Koneksi terlebih dahulu.", "Peringatan");
                return;
            }

            if (MessageBox.Show("Apakah ingin menambahkan setting Database?", "Peringatan", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmWizard newWizard = new frmWizard();
                if (newWizard.ShowDialog() == DialogResult.OK)
                {
                    DataTable dtSetting = new DataTable();
                    dtSetting.Columns.Add("JENISPAJAK", typeof(string));
                    dtSetting.Columns.Add("JML_NOP", typeof(string));
                    dtSetting.Columns.Add("QUERYPAJAK", typeof(string));
                    dtSetting.Columns.Add("QUERYDETAIL", typeof(string));

                    foreach (var item in ClassHelper.lstDBSettings)
                    {
                        DataRow newRow = dtSetting.NewRow();
                        newRow["JENISPAJAK"] = item.LstNop.FirstOrDefault().JenisPajak;
                        newRow["JML_NOP"] = item.LstNop.Count;
                        newRow["QUERYPAJAK"] = item.QueryPajak;
                        newRow["QUERYDETAIL"] = item.QueryDetail;

                        dtSetting.Rows.Add(newRow);
                    }

                    dgvSettingDB.DataSource = dtSetting;
                }
            }
        }

        bool _isSendDBSuccess;
        List<string> _lstErrMsgDB;
        private void bgwSendDB_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _isSendDBSuccess = false;
            _lstErrMsgDB = new List<string>();
            //Create GUID AND USER
            string userName = string.Empty;
            string cpuInfo = string.Empty;
            string guidInfo = string.Empty;
            HttpWebRequest httpWebRequest;
            cpuInfo = GetIdMachine(out userName, out guidInfo, out httpWebRequest);

            //Create Xml Files
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            try
            {
                using (XmlWriter writer = XmlWriter.Create("setDB.xml", settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("settingdatabase");
                    writer.WriteStartElement("jenis");
                    writer.WriteAttributeString("nama", "user");
                    writer.WriteElementString("username", userName);
                    writer.WriteElementString("urlapi", ClassHelper.urlAPI);
                    writer.WriteElementString("port", _portClient);
                    writer.WriteEndElement();

                    foreach (var item in ClassHelper.lstDBSettings)
                    {
                        foreach (var itemSetting in item.LstNop)
                        {
                            writer.WriteStartElement("jenispajak");
                            writer.WriteAttributeString("nama", itemSetting.JenisPajak);
                            writer.WriteElementString("nop", itemSetting.Nop);
                            writer.WriteElementString("alias", itemSetting.Alias);
                            writer.WriteElementString("querypajak", item.QueryPajak);
                            writer.WriteElementString("querylampiran", item.QueryDetail);
                            writer.WriteEndElement();
                        }
                    }

                    writer.WriteEndDocument();
                }
            }
            catch (Exception ex)
            {
                _lstErrMsgDB.Add(ex.Message);
                _isSendDBSuccess = false;
            }

            //Get setDB.xml to string
            string xmlString = System.IO.File.ReadAllText("setDB.xml");
            ClassHelper.lstDBSettings.FirstOrDefault().xml_content = xmlString;

            //Send Json Request
            httpWebRequest = (HttpWebRequest)WebRequest.Create(_urlApi + "/setting/postSettingDBWithParam");
            var jsonBody = JsonConvert.SerializeObject(ClassHelper.lstDBSettings);

            StringBuilder sb = new StringBuilder();
            sb.Append("{\"machineInfo\":[{\"userName\":\"" + userName + "\",\"idMachine\":\"" + cpuInfo + "\",\"guid\":\"" + guidInfo + "\",");
            sb.Append("\"phone\":\"" + ClassHelper.PhoneUser + "\",\"mail\":\"" + ClassHelper.MailUser + "\",\"port\":\"" + _portClient + "\"}],\"body\":" + jsonBody + "}");
            var body = sb.ToString();

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(body);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                //{
                //    var result = streamReader.ReadToEnd();
                //}

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    _isSendDBSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _lstErrMsgDB.Add(ex.Message);
                _isSendDBSuccess = false;
            }

        }

        private void bgwSendDB_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_isSendDBSuccess)
            {
                MessageBox.Show("Simpan dan send data setting berhasil.", "Perhatian");
                DialogResult = DialogResult.Yes;
                Close();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                int iJml = 1;
                sb.AppendLine("Simpan dan send data setting gagal : ");
                foreach (var item in _lstErrMsgDB)
                {
                    sb.AppendLine(iJml.ToString() + ". " + item + ".");
                    iJml++;
                }

                MessageBox.Show(sb.ToString(), "Peringatan");
            }

            pbLoading.Hide();
        }

        private void dgvSettingDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                string pajakDeleted = dgvSettingDB.Rows[e.RowIndex].Cells["JENPAJAK"].Value.ToString();
                if (MessageBox.Show("Yakin anda ingin menghapus seting atas pajak " + pajakDeleted + " ?", "Peringatan", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var element = ClassHelper.lstDBSettings.Select((v, i) => new { v, i }).Where(x => x.v.LstNop.FirstOrDefault().JenisPajak.Equals(pajakDeleted)).Select(x => x.i);
                    int iDelDB = -1;
                    if (element.Count() > 0)
                        iDelDB = element.FirstOrDefault();

                    if (iDelDB >= 0)
                        ClassHelper.lstDBSettings.RemoveAt(iDelDB);
                }

                DataTable dtSetting = new DataTable();
                dtSetting.Columns.Add("JENISPAJAK", typeof(string));
                dtSetting.Columns.Add("JML_NOP", typeof(string));
                dtSetting.Columns.Add("QUERYPAJAK", typeof(string));
                dtSetting.Columns.Add("QUERYDETAIL", typeof(string));

                foreach (var item in ClassHelper.lstDBSettings)
                {
                    DataRow newRow = dtSetting.NewRow();
                    newRow["JENISPAJAK"] = item.LstNop.FirstOrDefault().JenisPajak;
                    newRow["JML_NOP"] = item.LstNop.Count;
                    newRow["QUERYPAJAK"] = item.QueryPajak;
                    newRow["QUERYDETAIL"] = item.QueryDetail;

                    dtSetting.Rows.Add(newRow);
                }

                dgvSettingDB.DataSource = dtSetting;
            }
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            if (!_isApiConnect)
            {
                MessageBox.Show("Koneksi API belum berhasil", "Peringatan");
                return;
            }

            if (Convert.ToInt32(tbPort.Text) < 2000 || Convert.ToInt32(tbPort.Text) > 65536)
            {
                MessageBox.Show("Port tidak boleh kurang dari 2000 dan melebihi 65536", "Peringatan");
                return;
            }

            var isLstPort = _lstPort.Where(m => m.Port == Convert.ToInt32(tbPort.Text)).ToList();
            if (isLstPort != null && isLstPort.Count > 0)
            {
                MessageBox.Show("Port sedang terpakai, silahkan pakai port yang lain.", "Peringatan");
                return;
            }

            string message = string.Empty;
            //if (!ClassHelper.CheckAvailabilityPort(Convert.ToInt32(tbPort.Text), out message))
            //{
            //    MessageBox.Show(message);
            //    return;
            //}

            //_IsPortOpen = true;
            _portClient = tbPort.Text;
            MessageBox.Show("Port tersimpan", "Perhatian");
        }

        private void tbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        StringBuilder _sbTxt;
        private void bgwTxt_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _isColumnTrue = true;
            _sbTxt = new StringBuilder();
            int countColumnTrue = 0;
            string[] lines = System.IO.File.ReadAllLines(_pathExcel);
            string[] rowHeader = lines[0].Split(ClassHelper.separator);
            if (rowHeader.Length <= 1)
            {
                _sbTxt.AppendLine("Mohon cek separator yang digunakan, apakah menggunakan '" + ClassHelper.separator + "' ?");
                _sbTxt.AppendLine("1. Jika Benar, klik yes dan cek kembali header apakah sudah benar.");
                _sbTxt.AppendLine("2. Jika Salah, klik No untuk mengganti separator.");
                _isColumnTrue = false;
                return;
            }

            foreach (string itemHeader in rowHeader)
            {
                var findText = _lstColumnName.Where(m => m.ToUpper().Equals(itemHeader.Replace(" ", string.Empty).ToUpper())).ToList();
                if (findText.Count <= 0)
                {
                    _sbTxt.Append(itemHeader + ",");
                }
                else
                    countColumnTrue++;
            }

            if (countColumnTrue <= 0)
                _isColumnTrue = false;
        }

        private void bgwTxt_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!_isColumnTrue)
            {
                if (_sbTxt.Length > 1)
                {
                    DialogResult result = MessageBox.Show(_sbTxt.ToString(), "Peringatan", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        new frmOpsiFile().ShowDialog();
                        if (string.Compare(ClassHelper.jenisFile, "TXT") == 0 || string.Compare(ClassHelper.jenisFile, "CSV") == 0)
                            gbSetting.Text = "Setting kolom ( " + ClassHelper.jenisFile + " dengan separator '" + ClassHelper.separator + "')";
                        else
                            gbSetting.Text = "Setting kolom ( " + ClassHelper.jenisFile + " )";

                        if (string.Compare(ClassHelper.jenisFile, "DATABASE") == 0)
                        {
                            tCtlSetting.SelectedTab = tpDb;
                        }
                    }

                    pbLoading.Hide();
                    return;
                }

                StringBuilder sbMessage = new StringBuilder();
                sbMessage.AppendLine("Nama kolom header pada file tidak ditemukan,");
                sbMessage.AppendLine("Mohon periksa kembali file tersebut.");

                MessageBox.Show(sbMessage.ToString(), "Peringatan");
            }
            else
            {
                if (_sbTxt.Length > 0)
                {
                    StringBuilder sbMessage = new StringBuilder();
                    sbMessage.AppendLine("Nama Kolom : (" + _sbTxt.Remove(_sbTxt.Length - 1, 1) + ") di text file, tidak ditemukan pada entri nama kolom tersebut.");
                    sbMessage.AppendLine("Silahkan cek kembali nama kolom pada text file.");
                    sbMessage.AppendLine("Jika sudah benar, silahkan abaikan dan klik simpan.");
                    MessageBox.Show(sbMessage.ToString(), "Peringatan");
                }
                else
                {
                    StringBuilder sbMessage = new StringBuilder();
                    sbMessage.AppendLine("Cek Kolom berhasil, semua nama kolom yang dientry sudah sesuai.");
                    sbMessage.AppendLine("Silahkan simpan setting untuk melakukan proses selanjutnya.");
                    MessageBox.Show(sbMessage.ToString(), "Perhatian");
                    var lst = _listSuccess.FindAll(s => s.ToUpper().Contains("EXCEL"));
                    if (lst.Count <= 0)
                        _listSuccess.Add("Setting File");
                }
                pbLoading.Hide();
            }
        }

        private void tCtlSetting_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tpExc)
            {
                if (string.Compare(ClassHelper.jenisFile, "DATABASE") == 0)
                {
                    new frmOpsiFile().ShowDialog();
                    if (string.Compare(ClassHelper.jenisFile, "DATABASE") == 0)
                    {
                        tCtlSetting.SelectedTab = tpDb;
                    }
                }
            }
        }
    }

    class PajakEntity
    {
        public string JenPajak { get; set; }
        public string teks { get; set; }
    }

    internal class ExceptionPort
    {
        public int Port { get; set; }
        //public string Keterangan { get; set; }
    }
}
