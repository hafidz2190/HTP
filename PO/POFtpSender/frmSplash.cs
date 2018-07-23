using POAdministrationTools;
using POFtpSender.Properties;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace POFtpSender
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
            pbLoading.Hide();
            lblLoading.Hide();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            string vers = ClassHelper.LoadVersion();
            lblVers.Text = "App V." + vers;
            Opacity = .01;
            tmrSplash.Interval = 100;
            tmrLoading.Interval = 1000;
            tmrSplash.Tick += ChangeOpacity;
            tmrSplash.Start();
        }

        private void ChangeOpacity(object sender, EventArgs e)
        {
            Opacity += .02;
            if (Opacity == 1)
            {
                tmrSplash.Stop();
                tmrLoading.Start();
            }
        }

        int _maxUpdateLoop = 5;
        int _currLoop = 0;
        bool _isSukses = false;
        private void tmrLoading_Tick(object sender, EventArgs e)
        {
            //Validate version
            string pesanError = string.Empty;
            if (!FunctionHelper.CheckLatestVersion(out pesanError))
            {
                if (!string.IsNullOrEmpty(pesanError))
                {
                    MessageBox.Show(pesanError);
                    frmTestConnection frmKoneksi = new frmTestConnection();
                    frmKoneksi.ShowDialog();
                }

                if (!bgwDownload.IsBusy)
                {
                    tmrLoading.Stop();
                    pbLoading.Show();
                    lblLoading.Show();
                    bgwDownload.RunWorkerAsync();
                }
            }
            else
            {
                Close();
            }

        }

        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        private void bgwDownload_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _currLoop = 0;
            _isSukses = false;
            //Run Update apps
            string file = "update.zip";

            string RequestUrl = ClassHelper.urlAPI;
            #region Framework 4.0
            //string body = "{\"fileName\":\"" + FunctionHelper.path_dir + @"Fx40/" + FunctionHelper.new_version + ".zip" + "\"}";
            #endregion
            #region Framework 4.5
            string pathUrl = FunctionHelper.path_dir + @"Fx452/" + FunctionHelper.new_version + ".zip";
            #endregion

            #region Download With FTP
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(pathUrl);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.            
                string uName = StringCipher.Decrypt(Settings.Default.FtpUserCredential, "ftp");
                string pass = StringCipher.Decrypt(Settings.Default.FtpPassCredential, "ftp");

                request.Credentials = new NetworkCredential(uName, pass);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                //StreamReader reader = new StreamReader(responseStream);

                using (FileStream output = System.IO.File.OpenWrite(file))
                {
                    CopyStream(responseStream, output);
                }
                response.Close();
            }
            catch (Exception ex)
            {
                //Temporary skip download if failed
                _isSukses = true;
            }
            #endregion           

            while (!_isSukses)
            {
                _currLoop++;
                try
                {

                    FileInfo downloadedFile = new FileInfo(file);
                    if (downloadedFile.Exists)
                    {
                        Application.Exit();
                        System.Diagnostics.Process.Start("POUpdaterApps.exe");
                        _isSukses = true;
                    }
                    else
                    {
                        _isSukses = false;
                        MessageBox.Show($"Validasi Aplikasi / Update Gagal. Tekan OK untuk Mengulangi ({_currLoop} dari {_maxUpdateLoop} percobaan)");
                        if (_currLoop == _maxUpdateLoop)
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _isSukses = false;

                    if (_currLoop == _maxUpdateLoop)
                    {
                        break;
                    }
                    else
                    {
                        MessageBox.Show($"Validasi Aplikasi/ Update Gagal. Tekan OK untuk Mengulangi ({_currLoop} dari {_maxUpdateLoop} percobaan)");
                    }
                }
            }
        }

        private void bgwDownload_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        private void frmSplash_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
    }
}
