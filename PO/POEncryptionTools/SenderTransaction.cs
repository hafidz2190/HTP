using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using System.Xml;

namespace POAdministrationTools
{
    public class SenderTransaction
    {
        public static bool SendTransactionDB(DataTable tablePajak, DataTable tableLampiran, string queryPajak, string queryLampiran, string urlApi,
            string username, List<SettingDBEntity> lstDB, string jenisPajak, string CultureInfos, out string errMsg, out string sccMsg)
        {
            //Read POF Name
            errMsg = string.Empty;
            sccMsg = string.Empty;
            string serialFile = "POFtpSender.pof";
            string messageReg = string.Empty;
            string mode = string.Empty;
            ValidateRuntimeMode(serialFile, out messageReg, out mode);
            if (mode.ToUpper().Contains("TRIAL"))
            {
                errMsg = "Tidak dapat mengirim data, Aplikasi dalam mode TRIAL";
                return false;
            }


            //Send into API
            try
            {
                DBPostData dbData = new DBPostData();
                dbData.dtPajak = tablePajak;
                dbData.dtLampiran = tableLampiran;
                dbData.CultureInfos = CultureInfos;
                dbData.lstQuery = new List<NopQuery>();
                var lstNopPajak = lstDB.Where(m => m.jenisPajak.Equals(jenisPajak)).ToList();
                foreach (var itemQuery in lstNopPajak)
                {
                    NopQuery nopQuery = new NopQuery();
                    nopQuery.nop = itemQuery.nop;
                    nopQuery.queryPajak = queryPajak;
                    nopQuery.queryLampiran = queryLampiran;

                    dbData.lstQuery.Add(nopQuery);
                }

                DateTime tglTransaksi = Convert.ToDateTime(tablePajak.Rows[0]["TGL_TRANSAKSI"]);

                var httpWebRequestDB = (HttpWebRequest)WebRequest.Create(urlApi + "/dev/postTransactionClient");

                var jsonBodyDB = JsonConvert.SerializeObject(dbData, Newtonsoft.Json.Formatting.Indented);
                StringBuilder sbDB = new StringBuilder();
                sbDB.Append("{\"datauser\":[{\"username\":\"" + username + "\",\"key\":\"datatable\"}],");
                sbDB.Append("\"masapajak\":[{\"bulan\":\"" + tglTransaksi.Month.ToString() + "\",\"tahun\":\"" + tglTransaksi.Year.ToString() + "\"}],");
                sbDB.Append("\"items\":" + jsonBodyDB + "}");
                httpWebRequestDB.ContentType = "application/json";
                httpWebRequestDB.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequestDB.GetRequestStream()))
                {
                    streamWriter.Write(sbDB.ToString());
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponseDB = (HttpWebResponse)httpWebRequestDB.GetResponse();
                int statusCode = 0;
                string pesan = string.Empty;
                using (var streamReader = new StreamReader(httpResponseDB.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                    Newtonsoft.Json.Linq.JToken jCode = jObj["code"];
                    Newtonsoft.Json.Linq.JToken jMessage = jObj["message"];
                    statusCode = Convert.ToInt32(jCode);
                    pesan = jMessage.ToString();
                }

                if (statusCode == 200)
                {
                    sccMsg = "Data sukses terkirim ke server.";
                    //_errGetDataMsg.AppendLine(DateTime.Now.ToString("HH:mm:ss") + " = " + "Data sukses terkirim ke server.");
                }
                else
                {
                    errMsg = "Data gagal terkirim, " + pesan;
                    //_errGetDataMsg.AppendLine(DateTime.Now.ToString("HH:mm:ss") + " = " + "Data gagal terkirim, " + pesan);
                }
                httpResponseDB.Close();

                return true;
            }
            catch (Exception ex)
            {
                errMsg = "Terjadi kesalahan : " + ex.Message;
                return false;
            }

        }

        public static bool SendTransactionFile(string urlApi, DataTable tableTransaction, string username, int iBln, int iThn, string filePath,
            string successPath, string failedPath, string cultureInfos, out List<string> errMsg, out List<string> sccMsg)
        {
            //Read POF Name
            errMsg = new List<string>();
            sccMsg = new List<string>();
            string serialFile = "POFtpSender.pof";
            string messageReg = string.Empty;
            string mode = string.Empty;
            ValidateRuntimeMode(serialFile, out messageReg, out mode);
            if (mode.ToUpper().Contains("TRIAL"))
            {
                errMsg.Add("Tidak dapat mengirim data, Aplikasi dalam mode TRIAL");
                return false;
            }

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlApi + "/dev/postTransactionClient");
                DBPostData postData = new DBPostData();
                postData.dtPajak = tableTransaction;
                postData.dtLampiran = tableTransaction;
                postData.CultureInfos = cultureInfos;
                postData.lstQuery = new List<NopQuery>();


                var jsonBody = JsonConvert.SerializeObject(postData, Newtonsoft.Json.Formatting.Indented);
                StringBuilder sb = new StringBuilder();
                sb.Append("{\"datauser\":[{\"username\":\"" + username + "\",\"key\":\"datatable\"}],");
                sb.Append("\"masapajak\":[{\"bulan\":\"" + iBln.ToString() + "\",\"tahun\":\"" + iThn.ToString() + "\"}],");
                sb.Append("\"items\":" + jsonBody + "}");
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
                FileInfo fi = new FileInfo(filePath);
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                    Newtonsoft.Json.Linq.JToken jCode = jObj["code"];
                    Newtonsoft.Json.Linq.JToken jMessage = jObj["message"];
                    statusCode = Convert.ToInt32(jCode);
                    pesan = jMessage.ToString();
                }

                if (statusCode == 200)
                {
                    //Move file to success directory
                    fi.MoveTo(successPath + @"\" + DateTime.Now.ToString("ddMMyyHHmmss") + "_" + fi.Name);
                    sccMsg.Add("Data sukses terkirim ke FTP");
                    sccMsg.Add("File " + fi.Name + " dipindah ke folder SUCCESS.");
                    httpResponse.Close();
                    return true;
                }
                else
                {
                    //Move file to failed directory
                    fi.MoveTo(failedPath + @"\" + DateTime.Now.ToString("ddMMyyHHmmss") + "_" + fi.Name);
                    errMsg.Add("Data gagal terkirim : " + pesan);
                    errMsg.Add("File " + fi.Name + " dipindah ke folder FAILED.");
                    httpResponse.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errMsg.Add("Data gagal terkirim : " + ex.Message);
                return false;
            }

        }

        public static string GetIdMachineByUsername(string username, string urlApi)
        {
            string cpuId = string.Empty;
            var httpWebReq = (HttpWebRequest)WebRequest.Create(urlApi + "/dev/RetrieveCpuId");

            httpWebReq.ContentType = "application/json";
            httpWebReq.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebReq.GetRequestStream()))
                {
                    streamWriter.Write(username);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                int statusCode = 0;
                string pesan = string.Empty;
                var httpResponse = (HttpWebResponse)httpWebReq.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                    Newtonsoft.Json.Linq.JToken jCode = jObj["code"];
                    Newtonsoft.Json.Linq.JToken jMessage = jObj["message"];
                    Newtonsoft.Json.Linq.JToken jBody = jObj["cpuId"];
                    statusCode = Convert.ToInt32(jCode);
                    pesan = jMessage.ToString();
                    cpuId = jBody == null ? string.Empty : jBody.ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("UNABLE TO CONNECT"))
                {
                    return "Error : Tidak dapat konek ke server " + urlApi;
                }
                else
                {
                    return "Error : " + ex.Message;
                }
            }




            return cpuId.Replace(" ", string.Empty);
        }

        public static bool SendActivity_2(string username, string urlApi, int statusError, string keterangan, out DateTime serverDate, out string errMsg)
        {
            errMsg = string.Empty;
            serverDate = DateTime.Now;
            bool isSend = false;
            int statusCode = 0;
            string pesan = string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append("{\"Username\":\"" + username + "\",\"ActivityDate\":\"" + DateTime.Now + "\",\"StatusError\":\"" + statusError + "\",\"Keterangan\":\"" + keterangan + "\"}");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlApi + "/dev/postUserActivity");
            var jsonBody = JsonConvert.SerializeObject(sb.ToString(), Newtonsoft.Json.Formatting.Indented);

            //while (!isSend)
            //{
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
                if (statusError == 0)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                        Newtonsoft.Json.Linq.JToken jCode = jObj["code"];
                        Newtonsoft.Json.Linq.JToken jMessage = jObj["message"];
                        Newtonsoft.Json.Linq.JToken jBody = jObj["body"];
                        statusCode = Convert.ToInt32(jCode);
                        pesan = jMessage.ToString();
                        string tanggal = jBody.ToString().Trim('"');
                        serverDate = DateTime.ParseExact(tanggal, "yyyy-MM-dd HH:mm:ss", null);
                    }
                }

                httpResponse.Close();
                isSend = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("UNABLE TO CONNECT TO THE REMOTE SERVER"))
                {
                    pesan = "Aplikasi tidak terhubung dengan Server Pusat.";
                }
                else
                {
                    pesan = ex.Message;
                }
            }
            //}

            if (statusCode == 200)
            {
                errMsg = "data sukses terkirim ke server.";
            }
            else
            {
                errMsg = "data gagal terkirim : " + pesan;
                isSend = false;
            }

            return isSend;

        }
        public static bool SendActivity(string username, string urlApi, int statusError, string keterangan, string ipAddress, string cultureInfos, out DateTime serverDate, out string errMsg)
        {
            errMsg = string.Empty;
            serverDate = DateTime.Now;
            bool isSend = false;
            int statusCode = 0;
            string pesan = string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append("{\"Username\":\"" + username + "\",\"ActivityDate\":\"" + DateTime.Now + "\",\"StatusError\":\"" + statusError +
                "\",\"Keterangan\":\"" + keterangan + "\",\"IPClient\":\"" + ipAddress + "\",\"CultureInfos\":\"" + cultureInfos + "\"}");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlApi + "/dev/postUserActivity");
            var jsonBody = JsonConvert.SerializeObject(sb.ToString(), Newtonsoft.Json.Formatting.Indented);

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
                if (statusError == 0)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                        Newtonsoft.Json.Linq.JToken jCode = jObj["code"];
                        Newtonsoft.Json.Linq.JToken jMessage = jObj["message"];
                        Newtonsoft.Json.Linq.JToken jBody = jObj["body"];
                        statusCode = Convert.ToInt32(jCode);
                        pesan = jMessage.ToString();
                        string tanggal = jBody.ToString().Trim('"');
                        serverDate = DateTime.ParseExact(tanggal, "yyyy-MM-dd HH:mm:ss", null);
                    }
                }

                httpResponse.Close();
                isSend = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("UNABLE TO CONNECT TO THE REMOTE SERVER"))
                {
                    pesan = "Aplikasi tidak terhubung dengan Server Pusat.";
                }
                else
                {
                    pesan = ex.Message;
                }
            }

            if (statusCode == 200)
            {
                errMsg = "data sukses terkirim ke server.";
                isSend = true;
            }
            else
            {
                errMsg = "data gagal terkirim : " + pesan;
                isSend = false;
            }

            return isSend;

        }

        public static void ValidateRuntimeMode(string serialFile, out string message, out string RuntimeMode)
        {
            var outputFile = "serial.xml";
            message = string.Empty;
            RuntimeMode = string.Empty;
            FileCipher.DecryptFile(serialFile, outputFile, out message);
            if (message.ToUpper().Contains("FILE DECRYPTED"))
                message = string.Empty;
            else
                return;


            FileInfo info = new FileInfo(outputFile);
            if (!info.Exists)
            {
                message = "Aplikasi Tidak Dapat DiBuka";
                return;
            }


            using (var xmlReader = new XmlTextReader(outputFile))
            {
                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (string.Compare(xmlReader.Name, "RuntimeMode") == 0)
                            {
                                RuntimeMode = xmlReader.ReadInnerXml();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            info.Delete();
        }

        public static void GetSettingTime(string udlApi, out int iTmrUpload, out int iTmrDB)
        {
            iTmrUpload = 0;
            iTmrDB = 0;
            var httpWebRequestTime = (HttpWebRequest)WebRequest.Create(udlApi + "/setting/getTime");
            httpWebRequestTime.ContentType = "application/json";
            httpWebRequestTime.Method = "GET";

            var httpResponseTime = (HttpWebResponse)httpWebRequestTime.GetResponse();
            List<UserTempSetting> valueText = new List<UserTempSetting>();
            using (var streamReader = new StreamReader(httpResponseTime.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(result);
                Newtonsoft.Json.Linq.JToken jUser = jObj["body"];

                valueText = JsonConvert.DeserializeObject<List<UserTempSetting>>(jUser.ToString());
                httpResponseTime.Close();
            }

            if (valueText != null && valueText.Count > 0)
            {
                foreach (var item in valueText)
                {
                    string[] arrStr = item.value.Split(' ');
                    int iTimer = Convert.ToInt32(arrStr[0]);
                    switch (arrStr[1])
                    {
                        case "DETIK":
                            iTimer *= 1;
                            break;
                        case "MENIT":
                            iTimer *= 60;
                            break;
                        case "JAM":
                            iTimer *= 3600;
                            break;
                        default:
                            break;
                    }

                    if (item.nama_setting.ToUpper().Contains("DATAFILE"))
                        iTmrUpload = iTimer;
                    else
                        iTmrDB = iTimer;
                }
            }
        }
    }

    public class DBPostData
    {
        public DataTable dtPajak { get; set; }
        public DataTable dtLampiran { get; set; }
        public string CultureInfos { get; set; }
        public List<NopQuery> lstQuery { get; set; }
    }

    public class NopQuery
    {
        public string nop { get; set; }
        public string queryPajak { get; set; }
        public string queryLampiran { get; set; }
    }

    public class SettingDBEntity
    {
        public string jenisPajak { get; set; }
        public string nop { get; set; }
        public string alias { get; set; }
        public string queryPajak { get; set; }
        public string queryLampiran { get; set; }
    }

    public class UserTempSetting
    {
        public int id_setting { get; set; }
        public string nama_setting { get; set; }
        public string value { get; set; }
        public string keterangan { get; set; }
    }
}
