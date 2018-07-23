using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using POAdministrationTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace POFtpSender
{
    public partial class frmSettingExisting : Form
    {
        private string _strUri;
        private string _username;
        private string _guid;
        private string _errorMessage;
        public frmSettingExisting()
        {
            InitializeComponent();
            pbProccess.Hide();
        }

        private void btnTesUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUrl.Text) || string.IsNullOrEmpty(tbUsername.Text) ||
                string.IsNullOrEmpty(tbGuid.Text))
            {
                MessageBox.Show("Silahkan isi semua isian terlebih dahulu.", "Peringatan");
                return;
            }

            if (!bgwLoad.IsBusy)
            {
                _strUri = string.Empty;
                if (tbUrl.Text.Contains("http"))
                    _strUri = tbUrl.Text;
                else
                    _strUri = "http://" + tbUrl.Text;

                _username = tbUsername.Text;
                _guid = tbGuid.Text;

                pbProccess.Show();
                bgwLoad.RunWorkerAsync();
            }

        }

        private void bgwLoad_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Cek koneksi
            HttpClient client = new HttpClient();
            _errorMessage = string.Empty;

            client.BaseAddress = new Uri(_strUri + "/testConnection");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = client.GetAsync(_strUri + "/testConnection").Result;
                if (!response.IsSuccessStatusCode)
                {
                    _errorMessage = "Koneksi Gagal : " + response.StatusCode;
                    return;
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "Koneksi Gagal : 99";
                return;
            }

            //POST User From API and Get Column Data               
            string cpuInfo = string.Empty;
            cpuInfo = SerialKey.RetrieveIDMachine();

            USERAPP usr = new USERAPP();
            usr.userName = _username;
            usr.guid = _guid;
            usr.idMachine = cpuInfo;

            var jsonBody = JsonConvert.SerializeObject(usr);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_strUri + "/dev/postSettingClientWithParam");

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonBody);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string jsonParse = string.Empty;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                jsonParse = result;
            }
            List<UserSettingColumn> usrSett = new List<UserSettingColumn>();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                JObject jObj = JObject.Parse(jsonParse);
                JToken jUser = jObj["body"];
                JToken jCode = jObj["code"];
                JToken jMessage = jObj["message"];

                if (string.Compare(jCode.ToString(), "200") == 0)
                    usrSett = JsonConvert.DeserializeObject<List<UserSettingColumn>>(jUser.ToString());
                else
                {
                    _errorMessage = jMessage.ToString();
                }

            }

            //Create XML upload excel
            List<Setting> lstSetting = new List<Setting>();
            List<NOP> lstNop = new List<NOP>();
            List<USERAPP> lstUser = new List<USERAPP>();
            string urlApi = _strUri;
            string errMessage = string.Empty;

            lstUser.Add(usr);
            NOP itemNop = new NOP();
            List<string> arrNop = new List<string>();
            arrNop = usrSett.Select(x => x.Nop).Distinct().ToList();
            foreach (var item in arrNop)
            {
                itemNop.nop = item;
                switch (item.Substring(10, 3))
                {
                    case "901":
                        itemNop.jenisPajak = "HOTEL";
                        break;
                    case "902":
                        itemNop.jenisPajak = "RESTORAN";
                        break;
                    case "903":
                        itemNop.jenisPajak = "HIBURAN";
                        break;
                    case "907":
                        itemNop.jenisPajak = "PARKIR";
                        break;
                    default:
                        break;
                }

                lstNop.Add(itemNop);
            }

            foreach (var item in usrSett)
            {
                Setting sett = new Setting();
                sett.nop = item.Nop;
                sett.column_name = item.Column_Name;
                sett.column_text = item.Column_Text;
                lstSetting.Add(sett);
            }

            ClassHelper.WriteXmlFile(lstSetting, lstNop, urlApi, lstUser, out errMessage);

        }

        private void bgwLoad_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_errorMessage))
            {
                MessageBox.Show(_errorMessage, "Peringatan");
            }
            else
            {
                MessageBox.Show("Generate XML Sukses", "Perhatian");
                DialogResult = DialogResult.Yes;
                Close();
            }

            pbProccess.Hide();
        }
    }

    internal class UserSettingColumn
    {
        public string Username { get; set; }
        public string Nop { get; set; }
        public string Column_Name { get; set; }
        public string Column_Text { get; set; }
    }
}
