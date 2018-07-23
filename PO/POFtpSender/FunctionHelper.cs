using POAdministrationTools;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace POFtpSender
{
    public class FunctionHelper
    {
        public static string path_dir { get; set; }
        public static string new_version { get; set; }
        public static bool CheckLatestVersion(out string pesan)
        {
            pesan = string.Empty;
            bool isLatestVersion = false;
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(ass.Location);
            string assemblyVersion = fvi.FileVersion;
            string pofVersion = string.Empty;
            string latestVersion = string.Empty;
            string serialFile = "POFtpSender.pof";
            string message = string.Empty;
            string version = string.Empty;
            GetPofVersion(serialFile, out message, out version);
            pofVersion = version;
            if (string.Compare(pofVersion, assemblyVersion) != 0)
            {
                string outputFile;
                DecryptFile(serialFile, out message, out version, out outputFile);

                FileInfo info = new FileInfo(outputFile);
                if (info.Exists)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(outputFile); //Assuming reader is your XmlReader
                    XmlNode node = doc.SelectSingleNode("products/product").LastChild;
                    node.InnerXml = assemblyVersion;
                    doc.Save(outputFile);
                    FileCipher.EncryptFile(outputFile, serialFile, out message);
                    info.Delete();
                    pofVersion = assemblyVersion;
                }
            }

            string newVersion = DbLatestVersion();
            if (string.IsNullOrEmpty(newVersion))
                pesan = "Gagal mendapatkan versi terbaru server";
            else
            {
                if (string.Compare(pofVersion.Replace(" ", string.Empty), newVersion.Replace(" ", string.Empty)) == 0)
                {
                    isLatestVersion = true;
                }
            }

            return isLatestVersion;
        }

        private static string DbLatestVersion()
        {
            string version = string.Empty;
            int iLoop = 0;
            path_dir = string.Empty;
            string RequestUrl = ClassHelper.urlAPI;


            while (string.IsNullOrEmpty(version) && iLoop < 3)
            {
                RequestUrl = $"{RequestUrl}/download/GetLatestVersion";
                var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(RequestUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultResponse = streamReader.ReadToEnd();
                    ResultRequest result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultRequest>(resultResponse);
                    version = result.Version;
                    new_version = version;
                    path_dir = result.PathDir;
                }

                iLoop++;
            }


            return version;
        }

        private static void GetPofVersion(string serialFile, out string message, out string version)
        {
            string outputFile;
            DecryptFile(serialFile, out message, out version, out outputFile);
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
                            if (string.Compare(xmlReader.Name, "Version") == 0)
                            {
                                version = xmlReader.ReadInnerXml();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            info.Delete();
        }

        private static void DecryptFile(string serialFile, out string message, out string version, out string outputFile)
        {
            outputFile = "version.xml";
            message = string.Empty;
            version = string.Empty;
            FileCipher.DecryptFile(serialFile, outputFile, out message);
        }
    }

    #region Nested Class
    class ResultRequest
    {
        public string Version { get; set; }
        public string PathDir { get; set; }
    }

    #endregion
}
