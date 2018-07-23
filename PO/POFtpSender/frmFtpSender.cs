using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using POAdministrationTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace POFtpSender
{
    public partial class frmFtpSender : Form
    {
        #region private variables
        private List<SettingEntity> _lstColumnName;
        private List<string> _lstNop;
        private bool _mouseIsDown = false;
        private Point _firstPoint;
        private List<string> _lstTeks = new List<string>();
        private List<string> _lstTeksDB = new List<string>();
        private string _urlApi;
        private bool _isFtpValid;
        private bool _isDBValid;
        private List<SettingDBEntity> _lstDB;
        private DateTime _serverDate;
        private DateTime _LastErrDate;
        private List<ResponseSourceDB> _body;
        private bool _isConfigurationValid = false;

        private bool _isMsgBoxShow = false;
        private int _iDirUpload = 0;
        private int _iDirDB = 0;
        private StringBuilder _errGetDataMsg;

        private bool _isBulanTahunSama;
        private StringBuilder _sbErrMessage;

        private int _iTmrSearchUpload = 0;
        private int _iTmrSearchDB = 0;

        private const string GET_TRANSACTION_DATE = "GET_TRANSACTION_DATE";
        private const string RESTART_APPLICATION = "RESTART_APPLICATION";
        #endregion

        public frmFtpSender()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }

        private void frmFtpSender_Load(object sender, System.EventArgs e)
        {
            SetLogFileText("Koneksi Internet tersedia");
            lvwFtp.Items.Add(_lstTeks[0]);
            SetLogFileDB("Koneksi Internet tersedia");
            lvwDB.Items.Add(_lstTeksDB[0]);

            string pesan = string.Empty;
            bool isSetting = ClassHelper.isSetting;
            bool isSettingDB = ClassHelper.isSettingDB;
            string pesanError = string.Empty;
            _serverDate = DateTime.Now;
            _LastErrDate = DateTime.Now;
            ClassHelper.AppStartDate = DateTime.Now;
            ClassHelper.cultureInfos = CultureInfo.CurrentCulture.CompareInfo.Name;

            SetLogFileText("Cek setting Aplikasi");
            lvwFtp.Items.Add(_lstTeks[0]);
            SetLogFileDB("Cek setting Aplikasi");
            lvwDB.Items.Add(_lstTeksDB[0]);

            //Cek setting aplikasi  
            _lstDB = new List<SettingDBEntity>();
            _lstColumnName = new List<SettingEntity>();
            _lstDB = ClassHelper.lstDB;
            _lstColumnName = ClassHelper.lstColumnName;

            _lstNop = new List<string>();
            _urlApi = string.Empty;

            if (isSetting)
            {
                SetLogFileText("Setting FTP berhasil...Load nama kolom");
                lvwFtp.Items.Add(_lstTeks[0]);
                _isFtpValid = true;
            }
            else
            {
                _isFtpValid = false;
            }

            if (isSettingDB)
            {
                SetLogFileDB("Setting Database berhasil....Mulai mengambil data");
                lvwDB.Items.Add(_lstTeksDB[0]);
                _isDBValid = true;
            }
            else
            {
                _isDBValid = false;
                if (!isSetting)
                    return;
            }
            _urlApi = ClassHelper.urlAPI;
            if (_isDBValid)
            {
                //get database setting
                _body = GetSettingDatabase();

                // ambil tanggal error
                SetLogFileDB("Cek Tanggal Terakhir");
                lvwDB.Items.Add(_lstTeks[0]);
                GetLastDate();
                SetLogFileDB("Tanggal transaksi terakhir : " + _LastErrDate.ToString("dd MMM yyyy"));
                lvwDB.Items.Add(_lstTeks[0]);
            }

            _isConfigurationValid = ConfigurationValid(5);
            if (!_isConfigurationValid)
            {
                //show new form to test connection here
                MessageBox.Show("Koneksi ke Server Gagal. Silahkan klik tes koneksi pada halaman tes koneksi Server.", "Informasi");
                frmTestConnection frmConn = new frmTestConnection();
                frmConn.ShowDialog();
            }            

            CekIsRegister();
            tmrDir.Start();
        }

        private void frmFtpSender_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Send Activity App
            string errMsg = string.Empty;

            string ipAddress = string.Empty;
            try
            {
                ipAddress = FunctionHelpers.GetIP();
            }
            catch { }

            SenderTransaction.SendActivity(ClassHelper.userName, _urlApi, 1, "Form Closed", ipAddress, ClassHelper.cultureInfos, out _serverDate, out errMsg);
            #endregion
        }

        private void btnMinimize_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _firstPoint = e.Location;
                _mouseIsDown = true;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseIsDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseIsDown)
            {
                // Get the difference between the two points
                int xDiff = _firstPoint.X - e.Location.X;
                int yDiff = _firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = Location.X - xDiff;
                int y = Location.Y - yDiff;
                Location = new Point(x, y);
            }
        }

        private void tmrDir_Tick(object sender, System.EventArgs e)
        {
            if (_iTmrSearchUpload <= 0 && _iTmrSearchDB <= 0)
            {
                if (!bgwSettingTime.IsBusy)
                    bgwSettingTime.RunWorkerAsync();
            }
            else
            {
                string textRegister = ClassHelper.RuntimeMode;

                if (ClassHelper.QueueMessage.Count > 0)
                {
                    //Thread readConnectionThread = new Thread(DequeueMessage);
                    //readConnectionThread.Start();

                    DequeueMessage();
                }
                else
                {
                    //If upload is valid
                    if (_iDirUpload >= _iTmrSearchUpload)
                    {
                        _iDirUpload = 0;
                        if (_isFtpValid)
                        {
                            if (ClassHelper.AppStartDate.Date != DateTime.Now.Date)
                            {
                                tmrDir.Stop();
                                Application.Restart();
                            }
                            //MessageBox.Show("is upload run");
                            if (!bgwCekFile.IsBusy)
                            {
                                //Cek Is Registered
                                lblUserName.Text = "User : " + ClassHelper.userName + " ( " + textRegister + " )";
                                if (!textRegister.ToUpper().Contains("TRIAL"))
                                    registeredToolStripMenuItem.Enabled = false;
                                else
                                    registeredToolStripMenuItem.Enabled = true;

                                if (textRegister.ToUpper().Contains("TRIAL"))
                                {
                                    if (!_isMsgBoxShow)
                                    {
                                        _isMsgBoxShow = true;
                                        if (MessageBox.Show("Aplikasi belum aktif, silahkan melakukan register terlebih dahulu.", "Peringatan") == DialogResult.OK)
                                        {
                                            _isMsgBoxShow = false;
                                        }
                                    }
                                }
                                else
                                {
                                    bgwCekFile.RunWorkerAsync();
                                }
                            }
                        }
                    }


                    if (_iDirDB >= _iTmrSearchDB)
                    {
                        _iDirDB = 0;
                        if (_isDBValid)
                        {
                            if (ClassHelper.AppStartDate.Date != DateTime.Now.Date)
                            {
                                tmrDir.Stop();
                                Application.Restart();
                            }
                            //MessageBox.Show("is database run");
                            if (!bgwGetData.IsBusy)
                            {
                                //Cek Is Registered
                                lblUserName.Text = "User : " + ClassHelper.userName + " ( " + textRegister + " )";
                                if (!textRegister.ToUpper().Contains("TRIAL"))
                                    registeredToolStripMenuItem.Enabled = false;
                                else
                                    registeredToolStripMenuItem.Enabled = true;

                                if (textRegister.ToUpper().Contains("TRIAL"))
                                {
                                    if (!_isMsgBoxShow)
                                    {
                                        _isMsgBoxShow = true;
                                        if (MessageBox.Show("Aplikasi belum aktif, silahkan melakukan register terlebih dahulu.", "Peringatan") == DialogResult.OK)
                                        {
                                            _isMsgBoxShow = false;
                                        }
                                    }
                                }
                                else
                                {
                                    bgwGetData.RunWorkerAsync();
                                }
                            }
                        }
                    }
                }

                _iDirUpload++;
                _iDirDB++;
            }
        }

        private void bgwCekFile_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _sbErrMessage = new StringBuilder();
            _isBulanTahunSama = true;
            _lstTeks = new List<string>();
            _lstTeksDB = new List<string>();
            int statusCode = 0;
            string pesan = string.Empty;
            string pathDir = @"C:\FTPFile\INBOX";
            var files = Directory.GetFiles(pathDir, "*.*", SearchOption.AllDirectories);

            if (files.Count() <= 0)
            {
                //SetListViewText("File Excel tidak ditemukan.");
                //_sbErrMessage.AppendLine(_lstTeks[0]);
                return;
            }

            try
            {
                foreach (var fileItem in files)
                {
                    string filePath = fileItem;
                    string successPath = @"C:\FTPFile\SUCCESS";
                    string failedPath = @"C:\FTPFile\FAILED";
                    FileInfo fi = new FileInfo(filePath);

                    //Cek file is exist
                    switch (ClassHelper.jenisFile.ToUpper())
                    {
                        case "XLSX":
                        case "XLS":
                            ExcelPackage package = null;
                            try
                            {
                                package = new ExcelPackage(fi);
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.ToUpper().Contains("BEING USED BY ANOTHER PROCESS"))
                                {
                                    SetLogFileText("(" + fi.Name + ")" + " File dalam kondisi terbuka, tutup file terlebih dahulu.");
                                    _sbErrMessage.AppendLine(_lstTeks[0]);
                                    return;
                                }

                                DataSet ds = ClassHelper.ReadExcelFile(fi.FullName);
                                DataTable dt = new DataTable();
                                dt = ds.Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    break;
                                }

                                //Move file to failed directory
                                SetLogFileText("(" + fi.Name + ")" + " ditolak karena file extension format bukan Excel (*.xls, *.xlsx)");
                                _sbErrMessage.AppendLine(_lstTeks[0]);
                                fi.MoveTo(failedPath + @"\" + DateTime.Now.ToString("ddMMyyHH24mmssfff") + "_" + fi.Name);
                                return;
                            }
                            break;
                        case "TXT":
                            if (string.Compare(fi.Extension.ToUpper(), ".TXT") != 0)
                            {
                                SetLogFileText("(" + fi.Name + ")" + " ditolak karena file extension format bukan Text File (*.txt)");
                                _sbErrMessage.AppendLine(_lstTeks[0]);
                                fi.MoveTo(failedPath + @"\" + DateTime.Now.ToString("ddMMyyHH24mmssfff") + "_" + fi.Name);
                                return;
                            }
                            break;
                        case "CSV":
                            if (string.Compare(fi.Extension.ToUpper(), ".CSV") != 0)
                            {
                                SetLogFileText("(" + fi.Name + ")" + " ditolak karena file extension format bukan csv");
                                _sbErrMessage.AppendLine(_lstTeks[0]);
                                fi.MoveTo(failedPath + @"\" + DateTime.Now.ToString("ddMMyyHH24mmssfff") + "_" + fi.Name);
                                return;
                            }
                            break;
                        default:
                            break;
                    }

                    SetLogFileText("File " + ClassHelper.jenisFile + " ditemukan.");
                    //Check nop is valid
                    string nop = fi.Name.Replace(fi.Extension, string.Empty).Replace(".", "").Replace(",", string.Empty);
                    var validNop = _lstColumnName.FindAll(x => x.Nop.Equals(nop)).ToList();
                    if (validNop.Count <= 0)
                    {
                        SetLogFileText("(" + fi.Name + ")" + " ditolak karena nop tidak sesuai");
                        _sbErrMessage.AppendLine(_lstTeks[0]);
                        fi.MoveTo(failedPath + @"\" + DateTime.Now.ToString("ddMMyyHH24mmssfff") + "_" + fi.Name);
                        return;
                    }
                    //Check file is valid                                        
                    DataTable dtPelaporan = new DataTable("Tranksasi");
                    string errMsg = string.Empty;
                    //Get File to datatable
                    switch (ClassHelper.jenisFile.ToUpper())
                    {
                        case "XLS":
                        case "XLSX":
                            try
                            {
                                dtPelaporan = ExcelToDatatable(filePath, out errMsg);
                                if (dtPelaporan == null || dtPelaporan.Rows.Count <= 0)
                                {
                                    errMsg = string.Empty;
                                    DataSet ds = ClassHelper.ReadExcelFile(filePath);
                                    FileInfo fInfo = new FileInfo(filePath);

                                    string extens = fInfo.Extension;
                                    string namaFile = fInfo.Name.Replace(extens, string.Empty).Replace(".", string.Empty);
                                    dtPelaporan = ds.Tables[0];
                                    System.Data.DataColumn newColumn = new System.Data.DataColumn("NOP", typeof(string));
                                    newColumn.DefaultValue = namaFile.Replace(".", string.Empty);
                                    dtPelaporan.Columns.Add(newColumn);
                                }
                            }
                            catch (Exception ex)
                            {
                                SetLogFileText("Read file excel gagal : " + ex.Message);
                                _sbErrMessage.AppendLine(_lstTeks[0]);
                                return;
                            }

                            break;
                        case "TXT":
                            dtPelaporan = TxtToDatatable(filePath, ClassHelper.separator, out errMsg);
                            break;
                        case "CSV":
                            dtPelaporan = CsvToDatatable(filePath, ClassHelper.separator, out errMsg);
                            break;
                        default:
                            break;
                    }


                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        SetLogFileText(errMsg);
                        _sbErrMessage.AppendLine(_lstTeks[0]);
                        return;
                    }

                    #region Checking date
                    //Check bulan dan tahun pada datatable tidak boleh lewat hari
                    string teksTanggal = _lstColumnName.Where(m => m.NamaKolom.ToUpper().Equals("TGL_TRANSAKSI")).Select(m => m.TeksKolom).FirstOrDefault();
                    int iBln = 0;
                    int iThn = 0;

                    foreach (DataRow dRow in dtPelaporan.Rows)
                    {
                        DateTime tgl = DateTime.Now;


                        try
                        {
                            if (string.IsNullOrEmpty(dRow[teksTanggal].ToString()))
                                continue;
                            tgl = Convert.ToDateTime(dRow[teksTanggal]);
                        }
                        catch
                        {
                            tgl = DateTime.ParseExact(dRow[teksTanggal].ToString(), "ddMMyyyy", CultureInfo.CreateSpecificCulture("id-ID"));
                            dRow["TGL_TRANSAKSI"] = tgl;
                        }

                        //cek tanggal tidak boleh > serverDate
                        if (tgl.Date > _serverDate.Date)
                        {
                            SetLogFileText("Silahkan cek kembali, Terdapat tanggal yang melebihi tanggal hari ini.");
                            _sbErrMessage.AppendLine(_lstTeks[0]);
                            fi.MoveTo(failedPath + @"\" + DateTime.Now.ToString("ddMMyyHH24mmssfff") + "_" + fi.Name);
                            SetLogFileText("File dipindahkan ke folder failed.");
                            _sbErrMessage.AppendLine(_lstTeks[0]);
                            return;
                        }
                        //end cek tanggal > datenow

                        //cek bulan tahun harus sama
                        if (iBln == 0 && iThn == 0)
                        {
                            iBln = tgl.Month;
                            iThn = tgl.Year;
                            continue;
                        }
                        //end cek bulan tahun harus sama

                        //validasi bulan tahun
                        if (tgl.Month != iBln || tgl.Year != iThn)
                        {
                            _isBulanTahunSama = false;
                            break;
                        }
                        //end validasi bulan tahun
                    }
                    #endregion

                    if (!_isBulanTahunSama)
                    {
                        SetLogFileText("Terjadi kesalahan, beberapa tanggal tidak pada bulan dan tahun yang sama.");
                        _sbErrMessage.AppendLine(_lstTeks[0]);
                        fi.MoveTo(failedPath + @"\" + DateTime.Now.ToString("ddMMyyHH24mmssfff") + "_" + fi.Name);
                        SetLogFileText("File dipindahkan ke folder failed.");
                        _sbErrMessage.AppendLine(_lstTeks[0]);
                        return;
                    }


                    //Get Url Api Pemkot
                    string apiRealisasi = string.Empty;
                    var httpApi = (HttpWebRequest)WebRequest.Create(_urlApi + "/Dev/GetUrlApi");
                    var httpResApi = (HttpWebResponse)httpApi.GetResponse();
                    statusCode = 0;
                    pesan = string.Empty;
                    using (var streamReader = new StreamReader(httpResApi.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                        Newtonsoft.Json.Linq.JToken jCode = jObj["code"];
                        Newtonsoft.Json.Linq.JToken jMessage = jObj["message"];
                        statusCode = Convert.ToInt32(jCode);
                        pesan = jMessage.ToString();
                        if (statusCode == 200)
                        {
                            Newtonsoft.Json.Linq.JToken jUser = jObj["body"];
                            apiRealisasi = JsonConvert.DeserializeObject(jUser.ToString()).ToString();
                        }
                        else
                        {
                            SetLogFileText("Data gagal diterima : " + pesan);
                            _sbErrMessage.AppendLine(_lstTeks[0]);
                        }
                    }

                    httpResApi.Close();

                    //check if already payed based on transaction month and year
                    #region CheckPayment
                    var httpCP = (HttpWebRequest)WebRequest.Create(apiRealisasi + "/Dev/CheckPayment");
                    RequestCheckPayment cp = new RequestCheckPayment
                    {
                        masapajak = iBln.ToString(),
                        nop = nop,
                        tahunpajak = iThn.ToString(),
                        username = ClassHelper.userName
                    };

                    var jsonCP = JsonConvert.SerializeObject(cp, Newtonsoft.Json.Formatting.Indented);
                    httpCP.ContentType = "application/json";
                    httpCP.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpCP.GetRequestStream()))
                    {
                        streamWriter.Write(jsonCP);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                    var httpResCP = (HttpWebResponse)httpCP.GetResponse();
                    if (httpResCP.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(httpResCP.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                            ResponseCheckPayment response = JsonConvert.DeserializeObject<ResponseCheckPayment>(result);
                            if (response.IsAlreadyPay)
                            {
                                SetLogFileText("Data tidak diterima, Nop dengan masapajak tersebut telah terbayar.");
                                _sbErrMessage.AppendLine(_lstTeks[0]);
                                fi.MoveTo(failedPath + @"\" + DateTime.Now.ToString("ddMMyyHH24mmssfff") + "_" + fi.Name);
                                SetLogFileText("File dipindahkan ke folder failed.");
                                _sbErrMessage.AppendLine(_lstTeks[0]);
                                return;
                            }
                        }
                    }
                    httpResCP.Close();
                    #endregion

                    #region Send Transaction
                    List<string> lstErrMsg = new List<string>();
                    List<string> lstSccMsg = new List<string>();
                    SenderTransaction.SendTransactionFile(_urlApi, dtPelaporan, ClassHelper.userName, iBln, iThn, filePath, successPath,
                        failedPath, ClassHelper.cultureInfos, out lstErrMsg, out lstSccMsg);

                    if (lstErrMsg != null && lstErrMsg.Count > 0)
                    {
                        foreach (var itemErr in lstErrMsg)
                        {
                            SetLogFileText(itemErr);
                            _sbErrMessage.AppendLine(_lstTeks[0]);
                        }
                    }

                    if (lstSccMsg != null && lstSccMsg.Count > 0)
                    {
                        foreach (var itemScc in lstSccMsg)
                        {
                            SetLogFileText(itemScc);
                            _sbErrMessage.AppendLine(_lstTeks[0]);
                        }
                    }
                    #endregion

                }
            }
            catch (Exception ex)
            {
                SetLogFileText("Data gagal terkirim : " + ex.Message);
                _sbErrMessage.AppendLine(_lstTeks[0]);
            }
        }

        private void bgwSettingTime_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            #region Get Setting Time
            SenderTransaction.GetSettingTime(_urlApi, out _iTmrSearchUpload, out _iTmrSearchDB);
            #endregion
        }

        private void bgwSettingTime_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_iTmrSearchUpload <= 0 && _iTmrSearchDB <= 0)
            {
                SetLogFileText("Set timer tidak ditemukan");
                lvwFtp.Items.Add(_lstTeks[0]);
            }

        }

        private void appInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp helpFrm = new frmHelp();
            helpFrm.ShowDialog();
        }

        private void bgwCekFile_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_sbErrMessage != null && _sbErrMessage.Length > 0)
            {
                string[] strLine = _sbErrMessage.ToString().Split(new[] { "\r\n" }, StringSplitOptions.None);

                for (int iLine = 0; iLine < strLine.Count(); iLine++)
                {
                    if (strLine[iLine].Length > 0)
                    {
                        SetLogFileText(strLine[iLine]);
                        lvwFtp.Items.Add(strLine[iLine]);
                    }
                }

                return;
            }
        }

        private void bgwGetData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool eResult = false;
            GetDataFromDB(_LastErrDate, _serverDate, out eResult);
        }
        private void bgwGetData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var success = Convert.ToBoolean(e.Result);
            if (success)
            {
                _LastErrDate = DateTime.Now;
                SetLogFileDB("Tanggal Terakhir dikembalikan ke : " + _LastErrDate.ToString("dd MMM yyyy"));
                lvwDB.Items.Add(_lstTeks[0]);
            }

            if (_errGetDataMsg != null && _errGetDataMsg.Length > 0)
            {
                string[] strLine = _errGetDataMsg.ToString().Split(new[] { "\r\n" }, StringSplitOptions.None);

                for (int iLine = 0; iLine < strLine.Count(); iLine++)
                {
                    if (strLine[iLine].Length > 0)
                    {
                        SetLogFileDB(strLine[iLine]);
                        lvwDB.Items.Add(strLine[iLine]);
                    }
                }
            }
        }

        private void registeredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isMsgBoxShow = true;
            frmRegister regFrm = new frmRegister();
            if (regFrm.ShowDialog() != DialogResult.Yes)
            {
                _isMsgBoxShow = false;
            }
            else
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(_urlApi + "/setting/postSerialKey");
                StringBuilder sb = new StringBuilder();
                sb.Append("{\"serialKey\":\"" + ClassHelper.SerialNo + "\",\"username\":\"" + ClassHelper.userName + "\"}");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(sb.ToString());
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                int statusCode = 0;
                string pesan = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                    Newtonsoft.Json.Linq.JToken jCode = jObj["code"];
                    Newtonsoft.Json.Linq.JToken jMessage = jObj["message"];
                    statusCode = Convert.ToInt32(jCode);
                    pesan = jMessage.ToString();
                }

                SetLogFileText(pesan);
                lvwFtp.Items.Add(_lstTeks[0]);
                SetLogFileDB(pesan);
                lvwDB.Items.Add(_lstTeksDB[0]);

                Application.Restart();

                //string textRegister = ClassHelper.RuntimeMode;
                //lblUserName.Text = "User : " + ClassHelper.userName + " ( " + textRegister + " )";
                //registeredToolStripMenuItem.Enabled = false;
            }
        }

        private void GetDataFromDB(DateTime start, DateTime end, out bool eResult)
        {
            eResult = false;
            //_LastErrDate = DateTime.Now.Date;
            _errGetDataMsg = new StringBuilder();

            var lstDistJenPjk = _lstDB.Select(m => m.jenisPajak).Distinct().ToList();
            foreach (var item in lstDistJenPjk)
            {
                var lstTransByPajak = _lstDB.Where(m => m.jenisPajak.Equals(item)).ToList();
                string namaDb = string.Empty;
                string kodePajak = string.Empty;
                switch (item)
                {
                    case "HOTEL":
                        kodePajak = "901";
                        break;
                    case "RESTORAN":
                        kodePajak = "902";
                        break;
                    case "HIBURAN":
                        kodePajak = "903";
                        break;
                    case "PARKIR":
                        kodePajak = "907";
                        break;
                    default:
                        break;
                }
                DataTable dtSource = new DataTable();
                ResponseSourceDB bodySource = new ResponseSourceDB();
                bodySource = _body.Where(m => m.nop.Substring(10, 3).Equals(kodePajak)).FirstOrDefault();

                if (bodySource != null)
                {
                    namaDb = bodySource.namaDB;
                    string xmlString = bodySource.settingDB;
                    try
                    {
                        StringReader strReader = new StringReader(xmlString);
                        DataSet ds = new DataSet();
                        ds.ReadXml(strReader);

                        dtSource = ds.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        SetLogFileDB(ex.Message);
                        _errGetDataMsg.AppendLine(_lstTeksDB[0]);
                        return;
                    }

                    SetLogFileDB("Proses ambil data dari tanggal " + start.ToString("dd MMM yyyy") + " s/d tanggal " + end.ToString("dd MMM yyyy") + ".");
                    _errGetDataMsg.AppendLine(_lstTeksDB[0]);
                    string queryPajak = lstTransByPajak.FirstOrDefault().queryPajak;
                    string queryLampiran = lstTransByPajak.FirstOrDefault().queryLampiran;
                    DataTable dtPajak = new DataTable();
                    DataTable dtLampiran = new DataTable();
                    DateTime tanggalNow = DateTime.Now.Date;

                    //Get Data from database Client
                    bool success = false;
                    try
                    {
                        switch (namaDb.ToUpper())
                        {
                            case "ORACLE":
                                DataParser.OracleDataParser(dtSource, queryPajak, queryLampiran, start, end, out dtPajak, out dtLampiran);
                                success = true;
                                break;
                            case "MYSQL":
                                DataParser.MySqlDataParser(dtSource, queryPajak, queryLampiran, start, end, out dtPajak, out dtLampiran);
                                success = true;
                                break;
                            case "SQL":
                                DataParser.SQLDataParser(dtSource, queryPajak, queryLampiran, start, end, out dtPajak, out dtLampiran);
                                success = true;
                                break;
                            case "ACCESS":
                                DataParser.AccessDataParser(dtSource, queryPajak, queryLampiran, start, end, out dtPajak, out dtLampiran);
                                success = true;
                                break;
                            default:
                                break;
                        }

                        eResult = success;
                    }
                    catch (Exception ex)
                    {
                        SetLogFileDB("Gagal eksekusi query, " + ex.Message);
                        _errGetDataMsg.AppendLine(_lstTeksDB[0]);
                        string clientIPAddress = string.Empty;
                        try
                        {
                            clientIPAddress = FunctionHelpers.GetIP();
                        }
                        catch { }
                        string pesan = string.Empty;
                        SenderTransaction.SendActivity(ClassHelper.userName, _urlApi, 1, "Gagal eksekusi query", clientIPAddress, ClassHelper.cultureInfos, out _serverDate, out pesan);
                        eResult = false;
                        return;
                    }


                    if (dtPajak == null || dtPajak.Rows.Count <= 0)
                        return;
                    else
                    {
                        SetLogFileDB("Data untuk perhitungan pajak ditemukan.");
                        _errGetDataMsg.AppendLine(_lstTeksDB[0]);
                    }


                    //Change Nop alias   
                    Dictionary<string, string> dictAsNop = new Dictionary<string, string>();
                    bool isNopFound = false;
                    string errNop = string.Empty;
                    foreach (DataRow dRow in dtPajak.Rows)
                    {
                        string value = string.Empty;
                        try
                        {
                            value = lstTransByPajak.Where(m => m.alias.ToUpper().Equals(dRow["NOP"].ToString())).FirstOrDefault().nop;
                            if (dictAsNop.Where(m => m.Key.ToUpper().Equals(dRow["NOP"].ToString())).ToList().Count <= 0)
                                dictAsNop.Add(dRow["NOP"].ToString(), value);

                            dRow.SetField("NOP", value);
                            isNopFound = true;
                        }
                        catch (Exception ex) { errNop = ex.Message; }
                    }

                    if (!isNopFound)
                    {
                        SetLogFileDB(!string.IsNullOrEmpty(errNop) ? "Nop tidak valid, " + errNop : "Nop tidak ditemukan");
                        _errGetDataMsg.AppendLine(_lstTeksDB[0]);
                        return;
                    }

                    //Remove rows if not Nop
                    DataRow[] dDelRows = null;
                    try
                    {
                        dDelRows = dtPajak.Select("NOP not like '3578%'");
                        for (int iRow = dDelRows.Length - 1; iRow >= 0; iRow--)
                        {
                            dtPajak.Rows.Remove(dDelRows[iRow]);
                        }
                    }
                    catch (Exception ex)
                    {
                        SetLogFileDB("Nop : " + dtPajak.Rows[0]["NOP"].ToString() + ", Error like : " + ex.Message + ", jmlRowPajak" + dtPajak.Rows.Count);
                        _sbErrMessage.AppendLine(_lstTeksDB[0]);
                        //lvwDB.Items.Add("Nop : " + dtPajak.Rows[0]["NOP"].ToString() + ", Error like : " + ex.Message + ", jmlRowPajak" + dtPajak.Rows.Count);
                    }

                    dtPajak.AcceptChanges();
                    //cari kolom name yang menjadi alias dari nop pada dtLampiran
                    var namaKolom = "NOP";
                    dtLampiran.Columns.Add("NOP_LAMPIRAN", typeof(string));
                    if (string.IsNullOrEmpty(namaKolom))
                    {
                        foreach (DataRow dRow in dtLampiran.Rows)
                        {
                            string value = dictAsNop.FirstOrDefault().Value.ToString();
                            dRow.SetField("NOP_LAMPIRAN", value);
                        }
                    }
                    else
                    {
                        foreach (DataRow dRow in dtLampiran.Rows)
                        {
                            try
                            {
                                string value = dictAsNop[dRow[namaKolom].ToString()];
                                dRow.SetField("NOP_LAMPIRAN", value);
                            }
                            catch { }

                        }
                    }
                    //End Change Nop Alias

                    //Delete row if nop_lampiran is null
                    DataRow[] dRemRows = dtLampiran.Select("NOP_LAMPIRAN IS NULL");
                    for (int iRow = dRemRows.Length - 1; iRow >= 0; iRow--)
                    {
                        dtLampiran.Rows.Remove(dRemRows[iRow]);
                    }

                    dtLampiran.AcceptChanges();

                    if (dtPajak != null && dtPajak.Rows.Count > 0)
                    {
                        string errMsg = string.Empty;
                        string sccMsg = string.Empty;

                        //Send Transaction into API
                        SenderTransaction.SendTransactionDB(dtPajak, dtLampiran, queryPajak, queryLampiran, _urlApi, ClassHelper.userName,
                            _lstDB, item, ClassHelper.cultureInfos, out errMsg, out sccMsg);

                        if (string.IsNullOrEmpty(errMsg))
                        {
                            SetLogFileDB(sccMsg);
                            _errGetDataMsg.AppendLine(_lstTeksDB[0]);
                        }
                        else
                        {
                            SetLogFileDB(errMsg);
                            _errGetDataMsg.AppendLine(_lstTeksDB[0]);
                        }
                    }
                    else
                    {
                        SetLogFileDB("Tidak ada data yang akan dikirim");
                        _errGetDataMsg.AppendLine(_lstTeksDB[0]);
                    }
                }
            }
        }

        private void DequeueMessage()
        {
            int loopQueue = ClassHelper.QueueMessage.Count;
            SetLogFileDB("Mulai membaca antrian. Jumlah antrian: " + loopQueue);
            //if (_lstTeksDB.Count > 0)
            //    _errGetDataMsg.AppendLine(_lstTeksDB[0]);

            for (int iLoop = 0; iLoop < loopQueue; iLoop++)
            {
                string json = string.Empty;
                foreach (string item in ClassHelper.QueueMessage)
                {
                    json = item;
                    break;
                }

                ClassHelper.QueueMessage.Dequeue();
                SetLogFileDB("json : " + json);
                RequestSignalRSendMessage msg = JsonConvert.DeserializeObject<RequestSignalRSendMessage>(json);
                switch (msg.TipeRequest)
                {
                    case GET_TRANSACTION_DATE:
                        DateTime dtRequest = DateTime.MinValue;
                        string message = string.Empty;
                        foreach (KeyValuePair<string, string> kvp in msg.ParamRequest)
                        {
                            switch (kvp.Key)
                            {
                                case "tanggal":
                                    string valTanggal = kvp.Value;
                                    dtRequest = DateTime.ParseExact(valTanggal, "dd/MM/yyyy", new CultureInfo("id-ID"));
                                    break;
                                case "message":
                                    message = kvp.Value;
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (msg.TipeRepository.Contains("DATABASE"))
                        {
                            bool res = false;
                            SetLogFileDB("Proses ambil data tanggal " + dtRequest.ToString("dd MMM yyyy") + ".");
                            //_errGetDataMsg.AppendLine(_lstTeksDB[0]);
                            GetDataFromDB(dtRequest, dtRequest, out res);
                        }
                        else
                        {
                            //Files
                            frmMessage form = new frmMessage("Informasi", message);
                            form.Show();
                        }
                        break;
                    case RESTART_APPLICATION:
                        break;
                    default:
                        break;
                }
            }
            SetLogFileDB("Selesai membaca antrian.");
            //_errGetDataMsg.AppendLine(_lstTeksDB[0]);
        }

        #region Private Methods
        private DataTable CsvToDatatable(string csvfilePath, char separator, out string errMessage)
        {
            errMessage = string.Empty;
            FileInfo fi = new FileInfo(csvfilePath);
            string nop = fi.Name.ToUpper().Replace(".CSV", string.Empty).Replace(".", string.Empty);
            DataTable csvData = new DataTable();
            try
            {
                using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csvfilePath))
                {
                    csvReader.SetDelimiters(new string[] { separator.ToString() });
                    //csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    //Read columns from CSV file, remove this line if columns not exits  
                    string[] colFields = csvReader.ReadFields();

                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    csvData.Columns.Add("NOP");

                    while (!csvReader.EndOfData)
                    {
                        List<string> fieldData = new List<string>();
                        string[] strArr = csvReader.ReadFields();
                        fieldData.AddRange(strArr);
                        fieldData.Add(nop);

                        //Making empty value as null
                        for (int i = 0; i < fieldData.Count; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }

                        csvData.Rows.Add(fieldData.ToArray());

                    }
                }
            }
            catch (Exception ex)
            {
                errMessage = "Terjadi kesalahan, " + ex.Message;
            }

            return csvData;
        }

        private bool ConfigurationValid(int maximumTryValue)
        {
            var iTryValue = 0;

            #region Send Activity App
            string actMsg = string.Empty;

            string clientIPAddress = string.Empty;
            try
            {
                clientIPAddress = FunctionHelpers.GetIP();
            }
            catch { }
            while (!SenderTransaction.SendActivity(ClassHelper.userName, _urlApi, 0, "Inisialisasi Aplikasi", clientIPAddress, ClassHelper.cultureInfos, out _serverDate, out actMsg))
            {
                iTryValue++;

                if (actMsg.ToUpper().Contains("TIDAK TERHUBUNG DENGAN SERVER"))
                {
                    SetLogFileDB(actMsg);
                    lvwDB.Items.Add(_lstTeksDB[0]);
                    SetLogFileText(actMsg);
                    lvwFtp.Items.Add(_lstTeks[0]);

                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    SetLogFileDB(actMsg);
                    lvwDB.Items.Add(_lstTeksDB[0]);
                    SetLogFileText(actMsg);
                    lvwFtp.Items.Add(_lstTeks[0]);
                }


                if (iTryValue >= maximumTryValue)
                {
                    return false;
                }
            }
            #endregion

            #region Cek Username n machine is found
            string errMsg = string.Empty;

            string serialKey = SerialKey.RetrieveIDMachine();
            if (!SerialKey.IsIdMachine(ClassHelper.userName, _urlApi, out errMsg))
            {
                _isMsgBoxShow = true;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Aplikasi tidak dapat berjalan.");
                sb.AppendLine("Id CPU yang digunakan berbeda, silahkan hubungi Admin BPKPD.'" + ClassHelper.userName + "' ini.");
                MessageBox.Show(sb.ToString(), "Peringatan");

                SenderTransaction.SendActivity(ClassHelper.userName, _urlApi, 1, "Id Cpu tidak sesuai dengan data di database, ID yang digunakan : " + serialKey, clientIPAddress, ClassHelper.cultureInfos, out _serverDate, out actMsg);
                SetLogFileDB(sb.ToString());
                lvwDB.Items.Add(_lstTeksDB[0]);
                SetLogFileText(sb.ToString());
                lvwFtp.Items.Add(_lstTeks[0]);
                return true;
            }

            ClassHelper.urlAPI = _urlApi;
            #endregion

            //Get Timer Time
            if (!bgwSettingTime.IsBusy)
                bgwSettingTime.RunWorkerAsync();

            //CekIsRegister();
            //tmrDir.Start();

            return true;
        }

        private void CekIsRegister()
        {
            //Cek Is Registered
            string textRegister = ClassHelper.RuntimeMode;
            string vers = ClassHelper.LoadVersion();
            lblVers.Text = "App v." + vers;
            lblUserName.Text = "User : " + ClassHelper.userName + " ( " + textRegister + " )";
            if (!textRegister.ToUpper().Contains("TRIAL"))
                registeredToolStripMenuItem.Enabled = false;
            else
                registeredToolStripMenuItem.Enabled = true;
        }

        private bool GetLastDate()
        {
            var isAllowed = false;
            try
            {
                //Get Last Error Date
                var httpWebLastErrorRequest = (HttpWebRequest)WebRequest.Create(_urlApi + "/dev/postLastErrorDate");
                LastErrorRequest req = new LastErrorRequest();
                req.username = ClassHelper.userName;
                var reqBody = JsonConvert.SerializeObject(req.username);
                httpWebLastErrorRequest.ContentType = "application/json";
                httpWebLastErrorRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebLastErrorRequest.GetRequestStream()))
                {
                    streamWriter.Write(reqBody.ToString());
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpLastErrorResponse = (HttpWebResponse)httpWebLastErrorRequest.GetResponse();
                using (var streamReader = new StreamReader(httpLastErrorResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                    Newtonsoft.Json.Linq.JToken jCode = jObj["code"];
                    if (Convert.ToInt32(jCode) == 200)
                    {
                        Newtonsoft.Json.Linq.JToken jBody = jObj["body"];
                        var bodyDate = JsonConvert.DeserializeObject<LastErrorResponse>(jBody.ToString());
                        _LastErrDate = bodyDate.TanggalError;

                        isAllowed = true;
                    }
                    else
                    {
                        SetLogFileDB("getLastDate gagal diterima");
                        _sbErrMessage.AppendLine(_lstTeks[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                SetLogFileDB("getLastDate gagal eksekusi : " + ex.Message);
                _sbErrMessage.AppendLine(_lstTeks[0]);
            }

            return isAllowed;
        }

        private void SetLogFileText(string commandTxt)
        {
            string logPath = @"C:\FTPFile\LOGS\DataFile_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            if (!File.Exists(logPath))
                File.Create(logPath).Close();

            DateTime dateNow = DateTime.Now;
            _lstTeks = new List<string>();
            string timeNow = dateNow.ToString("HH:mm:ss");

            string teks = timeNow + " = " + commandTxt;
            _lstTeks.Add(teks);
            File.AppendAllText(logPath, teks + Environment.NewLine);
        }

        private void SetLogFileDB(string commandTxt)
        {
            string logPath = @"C:\FTPFile\LOGS\DataBase_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            if (!File.Exists(logPath))
                File.Create(logPath).Close();

            DateTime dateNow = DateTime.Now;
            _lstTeksDB = new List<string>();
            string timeNow = dateNow.ToString("HH:mm:ss");

            string teks = timeNow + " = " + commandTxt;
            _lstTeksDB.Add(teks);
            File.AppendAllText(logPath, teks + Environment.NewLine);
        }

        private DataTable ExcelToDatatable(string fileName, out string errMessage)
        {
            errMessage = string.Empty;
            FileInfo inf = new FileInfo(fileName);
            string nop = inf.Name.ToUpper().Replace(".XLSX", string.Empty).Replace(".XLS", string.Empty).Replace(".", string.Empty);
            DataTable dt = new DataTable("Transaksi");
            XSSFWorkbook hssfwb;
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new XSSFWorkbook(file);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("BEING USED BY ANOTHER"))
                {
                    errMessage = "File dalam kondisi terbuka, silahkan tutup terlebih dahulu.";
                }
                else
                {
                    errMessage = ex.Message;
                }

                return new DataTable();
            }


            ISheet sheet = hssfwb.GetSheetAt(0);
            sheet.ForceFormulaRecalculation = true;
            IRow headerRow = null;
            int iRowHeaderFound = 0;
            Dictionary<int, string> lstColumnHeader = new Dictionary<int, string>();

            SetLogFileText("Cek Kolom header");
            bool isHeaderFound = false;
            for (int iRow = 0; iRow < 10; iRow++)
            {
                headerRow = sheet.GetRow(iRow);
                if (headerRow == null)
                    continue;

                if (headerRow.Cells.Count <= 1)
                    continue;

                if (headerRow != null && headerRow.LastCellNum > 0)
                {
                    //Cek if this row is column name
                    if (isHeaderFound)
                        break;

                    //loop each cell row
                    for (int iCol = 0; iCol < headerRow.LastCellNum; iCol++)
                    {
                        string teks = string.Empty;
                        try
                        {
                            teks = headerRow.Cells[iCol].StringCellValue;
                        }
                        catch
                        {
                            continue;
                        }

                        var HeaderName = _lstColumnName.FindAll(s => s.TeksKolom.ToUpper() == teks.ToUpper()).ToList();
                        if (HeaderName.Count > 0)
                        {
                            if (dt.Columns.Count <= 0)
                                dt.Columns.Add("NOP");
                            //Add column name into datatable columns
                            iRowHeaderFound = iRow;
                            if (HeaderName.FirstOrDefault().TeksKolom != "-" || string.IsNullOrEmpty(HeaderName.FirstOrDefault().TeksKolom))
                            {
                                dt.Columns.Add(HeaderName.FirstOrDefault().TeksKolom);
                                lstColumnHeader.Add(iCol, HeaderName.FirstOrDefault().TeksKolom);
                            }

                            isHeaderFound = true;
                        }
                    }
                    // end of loop each cell row
                }
            }

            SetLogFileText("Kolom Header ditemukan.");
            _sbErrMessage.AppendLine(_lstTeks[0]);
            SetLogFileText("copy data dari Excel");
            _sbErrMessage.AppendLine(_lstTeks[0]);
            //Insert data into datatable
            for (int iRow = iRowHeaderFound + 1; iRow <= sheet.LastRowNum; iRow++)
            {
                headerRow = sheet.GetRow(iRow);
                if (headerRow == null)
                    continue;

                if (headerRow.Cells.Count <= 1)
                    continue;

                DataRow newRow = dt.NewRow();
                for (int iCol = 0; iCol < headerRow.LastCellNum; iCol++)
                {
                    try
                    {
                        headerRow.Cells[iCol].ToString();
                    }
                    catch
                    {
                        continue;
                    }
                    switch (headerRow.Cells[iCol].CellType)
                    {
                        case CellType.Unknown:
                            var columnFound = lstColumnHeader.FirstOrDefault(x => x.Key == iCol).Value;
                            if (columnFound != null && columnFound.Length > 0)
                                newRow[columnFound] = headerRow.Cells[iCol].StringCellValue;
                            break;
                        case CellType.Numeric:
                            columnFound = lstColumnHeader.FirstOrDefault(x => x.Key == iCol).Value;
                            if (columnFound != null && columnFound.Length > 0)
                            {
                                if (columnFound.ToUpper().Contains("TANGGAL") || columnFound.ToUpper().Contains("TGL") ||
                                columnFound.ToUpper().Contains("DATE"))
                                {
                                    newRow[columnFound] = headerRow.Cells[iCol].DateCellValue.Date;
                                }
                                else if (columnFound.ToUpper().Contains("JAM") || columnFound.ToUpper().Contains("HOUR") ||
                                    columnFound.ToUpper().Contains("CLOCK"))
                                {
                                    newRow[columnFound] = headerRow.Cells[iCol].DateCellValue.ToString("HH:mm:ss");
                                }
                                else
                                {
                                    newRow[columnFound] = headerRow.Cells[iCol].NumericCellValue;
                                }
                            }
                            break;
                        case CellType.String:
                            columnFound = lstColumnHeader.FirstOrDefault(x => x.Key == iCol).Value;
                            if (columnFound != null && columnFound.Length > 0)
                                newRow[columnFound] = headerRow.Cells[iCol].StringCellValue;
                            break;
                        case CellType.Formula:
                            columnFound = lstColumnHeader.FirstOrDefault(x => x.Key == iCol).Value;
                            if (columnFound != null && columnFound.Length > 0)
                            {
                                newRow[columnFound] = headerRow.Cells[iCol].NumericCellValue;
                            }
                            break;
                        case CellType.Blank:
                            columnFound = lstColumnHeader.FirstOrDefault(x => x.Key == iCol).Value;
                            if (columnFound != null && columnFound.Length > 0)
                                newRow[columnFound] = headerRow.Cells[iCol].StringCellValue;
                            break;
                        case CellType.Boolean:
                            columnFound = lstColumnHeader.FirstOrDefault(x => x.Key == iCol).Value;
                            if (columnFound != null && columnFound.Length > 0)
                                newRow[columnFound] = headerRow.Cells[iCol].BooleanCellValue;
                            break;
                        case CellType.Error:
                            columnFound = lstColumnHeader.FirstOrDefault(x => x.Key == iCol).Value;
                            if (columnFound != null && columnFound.Length > 0)
                                newRow[columnFound] = headerRow.Cells[iCol].StringCellValue;
                            break;
                        default:
                            break;
                    }

                }

                //Validation to check is row empty
                bool isNotEmpty = false;
                foreach (var item in newRow.ItemArray)
                {
                    if (!string.IsNullOrEmpty(item.ToString()))
                    {
                        isNotEmpty = true;
                        break;
                    }
                }

                if (isNotEmpty)
                {
                    newRow["NOP"] = nop;
                    dt.Rows.Add(newRow);
                }
            }

            hssfwb.Close();
            return dt;
        }

        private DataTable TxtToDatatable(string fileName, char separator, out string errMessage)
        {
            errMessage = string.Empty;
            DataTable dt = new DataTable();
            FileInfo fi = new FileInfo(fileName);
            string[] lines = System.IO.File.ReadAllLines(fileName);
            string nop = fi.Name.ToUpper().Replace(".TXT", string.Empty).Replace(".", string.Empty);
            int iLines = 0;
            bool isHeaderFound = false;

            foreach (string line in lines)
            {
                string[] arrTeks = line.Split(separator);
                //Cek if is row header                

                if (!isHeaderFound)
                {
                    for (int iCol = 0; iCol < arrTeks.Count(); iCol++)
                    {
                        //Cek is header found
                        if (_lstColumnName.FindAll(m => m.TeksKolom.ToUpper().Equals(arrTeks[iCol].ToUpper())).ToList().Count > 0)
                        {
                            isHeaderFound = true;
                            break;
                        }
                    }
                }

                if (isHeaderFound && iLines <= 0)
                {
                    for (int iCol = 0; iCol < arrTeks.Count(); iCol++)
                    {
                        //add header column name to datatable
                        dt.Columns.Add(arrTeks[iCol]);
                    }

                    dt.Columns.Add("NOP");
                }
                else if (isHeaderFound && iLines > 0)
                {
                    DataRow dr = dt.NewRow();
                    for (int iCol = 0; iCol < arrTeks.Count(); iCol++)
                    {
                        //add row by lines
                        dr[iCol] = arrTeks[iCol];
                    }
                    dr[arrTeks.Count()] = nop;
                    dt.Rows.Add(dr);
                }
                else
                {
                    errMessage = "Kolom header tidak ditemukan, mohon cek kembali.";
                    break;
                }

                iLines++;
            }

            return dt;
        }

        private List<ResponseSourceDB> GetSettingDatabase()
        {
            //Get list Source Database                    
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"username\":\"" + ClassHelper.userName + "\"}");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_urlApi + "/setting/retrieveSourceDB");
            var jsonBody = JsonConvert.SerializeObject(sb.ToString(), Newtonsoft.Json.Formatting.Indented);
            List<ResponseSourceDB> body = new List<ResponseSourceDB>();
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(sb.ToString());
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var statusCode = 0;
                var pesan = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                    Newtonsoft.Json.Linq.JToken jCode = jObj["code"];
                    Newtonsoft.Json.Linq.JToken jMessage = jObj["message"];
                    statusCode = Convert.ToInt32(jCode);
                    pesan = jMessage.ToString();
                    if (statusCode == 200)
                    {
                        Newtonsoft.Json.Linq.JToken jBody = jObj["body"];
                        body = JsonConvert.DeserializeObject<List<ResponseSourceDB>>(jBody.ToString());
                    }
                    else
                    {
                        SetLogFileDB("Data gagal diterima, " + pesan);
                        _errGetDataMsg.AppendLine(_lstTeksDB[0]);
                    }

                }
                httpResponse.Close();
            }
            catch (Exception ex)
            {
                SetLogFileDB("Data gagal diterima : " + ex.Message);
                _errGetDataMsg.AppendLine(_lstTeksDB[0]);
                //return;
            }

            return body;
        }
        #endregion

        #region Nested Class
        class RequestDueDate
        {
            public string masapajak { get; set; }
            public string tahunpajak { get; set; }
            public string username { get; set; }
        }

        class RequestCheckPayment
        {
            public string username { get; set; }
            public string nop { get; set; }
            public string masapajak { get; set; }
            public string tahunpajak { get; set; }
        }

        class ResponseDueDate
        {
            public HttpStatusCode code { get; set; }
            public string tanggal { get; set; }
            public DateTime DateJatuhTempo
            {
                get
                {
                    DateTime date = DateTime.ParseExact(this.tanggal, "dd/MM/yyyy", new System.Globalization.CultureInfo("id-ID"));

                    return date;
                }
            }
        }

        class ResponseCheckPayment
        {
            public string status { get; set; }
            public bool IsAlreadyPay { get { return Convert.ToBoolean(this.status); } }
        }

        class RequestSignalRSendMessage
        {
            public string ClientID { get; set; }
            public string TipeRequest { get; set; }
            public string TipeRepository { get; set; }
            public string JenisRepository { get; set; }
            public Dictionary<string, string> ParamRequest { get; set; }
        }
        #endregion

        private void hubungiKamiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool isFormOpen = false;
            foreach (Form frm in fc)
            {
                if (string.Compare(frm.Name, "frmChatMessage") == 0)
                {
                    isFormOpen = true;
                    break;
                }
            }

            if (isFormOpen)
            {
                frmChatMessage chatFrm = new frmChatMessage();
                chatFrm.WindowState = FormWindowState.Normal;
            }
            else
            {
                frmChatMessage chatFrm = new frmChatMessage();
                chatFrm.Show();
            }

        }
    }

    public class SettingEntity
    {
        public string Nop { get; set; }
        public string JenisPajak { get; set; }
        public string NamaKolom { get; set; }
        public string TeksKolom { get; set; }
    }

    //public class SettingDBEntity
    //{
    //    public string jenisPajak { get; set; }
    //    public string nop { get; set; }
    //    public string alias { get; set; }
    //    public string queryPajak { get; set; }
    //    public string queryLampiran { get; set; }
    //}

    public class ResponseSourceDB
    {
        public string nop { get; set; }
        public string settingDB { get; set; }
        public string namaDB { get; set; }
    }

    public class DBPostData
    {
        public DataTable dtPajak { get; set; }
        public DataTable dtLampiran { get; set; }
        public List<NopQuery> lstQuery { get; set; }
    }

    public class NopQuery
    {
        public string nop { get; set; }
        public string queryPajak { get; set; }
        public string queryLampiran { get; set; }
    }

    public class LastErrorRequest
    {
        public string username { get; set; }
    }

    public class LastErrorResponse
    {
        public DateTime TanggalError { get; set; }
    }
}
