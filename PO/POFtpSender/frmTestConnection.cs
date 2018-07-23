using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace POFtpSender
{
    public partial class frmTestConnection : Form
    {
        #region Private initializer
        private bool _isApiConnect;
        private List<ExceptionPort> _lstPort;
        private string _urlApi;
        private string _pesan;
        #endregion

        public frmTestConnection()
        {
            InitializeComponent();
            StringBuilder sb = new StringBuilder();
            ToolTip tooltp = new ToolTip();
            tooltp.SetToolTip(btnTes, "Tekan tombol ini untuk melakukan tes koneksi.");
            tbAPI.Text = ClassHelper.urlAPI;
            pbLoading.Hide();
        }

        private void btnTes_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAPI.Text))
            {
                MessageBox.Show("Url Web API kosong, Mohon hubungi Admin BPKPD Kota Surabaya", "Peringatan");
                return;
            }

            if (!bgwTesKoneksi.IsBusy)
            {
                _lstPort = new List<ExceptionPort>();
                _urlApi = tbAPI.Text;
                _isApiConnect = false;
                pbLoading.Show();
                bgwTesKoneksi.RunWorkerAsync();
            }
        }

        private void bgwTesKoneksi_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            HttpClient client = new HttpClient();

            _pesan = string.Empty;
            try
            {
                client.BaseAddress = new Uri(tbAPI.Text + "/testConnection");
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("THE HOSTNAME COULD NOT BE PARSED"))
                    _pesan = "Mohon periksa kembali URL tersebut tidak ditemukan.";
                else
                    _pesan = "Mohon periksa kembali URL : " + ex.Message;

                return;
            }

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(_urlApi + "/testConnection");
                var response = (HttpWebResponse)request.GetResponse();
                string valStatus = string.Empty;

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

                        _pesan = "Koneksi Berhasil.";
                        _isApiConnect = true;
                    }
                    else
                    {
                        _pesan = jVal.ToString();
                        _isApiConnect = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().ToUpper().Contains("UNABLE TO CONNECT TO THE REMOTE SERVER"))
                {
                    _pesan = "Koneksi Gagal : API Tidak terhubung ke server";
                }
                _isApiConnect = false;
            }
        }

        private void bgwTesKoneksi_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_isApiConnect)
            {
                MessageBox.Show(_pesan, "Perhatian");
                Application.Restart();
            }
            else
            {
                MessageBox.Show(_pesan, "Peringatan");
            }

            pbLoading.Hide();
        }

        private void frmTestConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isApiConnect)
            {
                if (MessageBox.Show("Koneksi belum berhasil, ingin menutup aplikasi?", "Peringatan", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
        }
    }
}
