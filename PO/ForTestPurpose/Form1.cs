using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForTestPurpose
{
    class DownloadUpdate
    {
        public string fileName { get; set; }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DownloadUpdate dwload = new DownloadUpdate { fileName= "devModule.rar" };

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:2202/download/update");
            var jsonBody = JsonConvert.SerializeObject(dwload, Newtonsoft.Json.Formatting.Indented);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonBody);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (Stream stream = (httpResponse.GetResponseStream()))
                {
                    using (FileStream output = File.OpenWrite(dwload.fileName))
                    {
                        CopyStream(stream, output);
                    }
                }

                //if (httpResponse.StatusCode == HttpStatusCode.OK)
                //{
                //    _isSendDBSuccess = true;
                //}
            }
            catch (Exception ex)
            {
                //_lstErrMsgDB.Add(ex.Message);
                //_isSendDBSuccess = false;
            }
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
    }
}
