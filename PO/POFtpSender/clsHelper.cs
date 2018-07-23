using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using FastMember;
using POAdministrationTools;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Collections;
using System.Text;
using System.Data.OleDb;

namespace POFtpSender
{
    internal class ClassHelper
    {
        public const string SerialFile = "POFtpSender.pof";
        public static string SerialNo { get; set; }

        public static List<string> AliasTableSettingDB { get; set; }

        public static string RuntimeMode { get; set; }
        public static string userName { get; set; }
        public static string idMachine { get; set; }
        public static string guid { get; set; }

        public static string urlAPI { get; set; }
        public static string dbConnector { get; set; }
        public static Dictionary<string, string> dictDbConnector { get; set; }

        public static List<DBSettings> lstDBSettings { get; set; }

        public static string MailUser { get; set; }
        public static string PhoneUser { get; set; }

        public static int port { get; set; }

        public static DateTime AppStartDate { get; set; }
        public static List<SettingEntity> lstColumnName { get; set; }
        public static List<SettingDBEntity> lstDB { get; set; }

        public static string pesanUpload { get; set; }
        public static string pesanDB { get; set; }

        public static bool isSetting { get; set; }
        public static bool isSettingDB { get; set; }

        public static string jenisFile { get; set; }
        public static char separator { get; set; }
        public static string cultureInfos { get; set; }

        public static string LoadVersion()
        {
            string version = string.Empty;
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                version = fvi.FileVersion;
            }
            catch (Exception ex)
            {
                throw;
            }


            return version;
        }

        public static void WriteXmlFile(List<Setting> _lstSetting, List<NOP> _listNOP, string _urlApi,
            List<USERAPP> _ListUser, out string pesanError)
        {
            pesanError = string.Empty;
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create("setUpload.xml", settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("settings");
                    string jenPjk = string.Empty;
                    string Nop = string.Empty;
                    List<Setting> listSetting = _lstSetting.OrderBy(x => x.nop).ToList();

                    DataTable table = new DataTable();
                    using (var reader = ObjectReader.Create(listSetting))
                    {
                        table.Load(reader);
                    }

                    writer.WriteStartElement("pajak");
                    writer.WriteStartElement("jenis");
                    writer.WriteAttributeString("nama", "user");
                    writer.WriteElementString("username", _ListUser.FirstOrDefault().userName);
                    if (string.Compare(jenisFile.ToUpper(), "TXT") == 0 || string.Compare(jenisFile.ToUpper(), "CSV") == 0)
                    {
                        writer.WriteElementString("jenisfile", jenisFile);
                        writer.WriteElementString("separator", separator.ToString());
                    }
                    else
                    {
                        writer.WriteElementString("jenisfile", "xls");
                    }
                    writer.WriteEndElement();

                    foreach (var item in listSetting)
                    {
                        if (string.IsNullOrEmpty(Nop) || string.Compare(Nop, item.nop) != 0)
                        {
                            if (!string.IsNullOrEmpty(Nop))
                                writer.WriteEndElement();

                            jenPjk = _listNOP.Where(x => x.nop.Equals(item.nop)).Select(x => x.jenisPajak).FirstOrDefault();

                            writer.WriteStartElement("jenis");
                            writer.WriteAttributeString("nama", jenPjk);
                            writer.WriteElementString("NOP", item.nop);
                            Nop = item.nop;
                        }


                        writer.WriteElementString(item.column_name, item.column_text);
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("jenis");
                    writer.WriteAttributeString("nama", "nop");
                    foreach (var item in _listNOP)
                    {
                        writer.WriteElementString("nop", item.nop);
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("jenis");
                    writer.WriteAttributeString("nama", "urlftp");
                    writer.WriteElementString("urlapi", _urlApi);
                    writer.WriteElementString("port", _ListUser.FirstOrDefault().port.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch (Exception ex)
            {
                pesanError = "Simpan gagal : " + ex.Message;
            }
        }

        public static void GenerateSerialFile(string runtimeMode, string serialNo)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode productsNode = doc.CreateElement("products");
            doc.AppendChild(productsNode);

            XmlNode productNode = doc.CreateElement("product");
            XmlAttribute productAttribute = doc.CreateAttribute("id");
            productAttribute.Value = "2017";
            productNode.Attributes.Append(productAttribute);
            productsNode.AppendChild(productNode);

            XmlNode nameNode = doc.CreateElement("Name");
            nameNode.AppendChild(doc.CreateTextNode("Pajak Online Kota Surabaya"));
            productsNode.AppendChild(nameNode);
            XmlNode priceNode = doc.CreateElement("RuntimeMode");
            priceNode.AppendChild(doc.CreateTextNode(runtimeMode));
            ClassHelper.RuntimeMode = runtimeMode;
            productsNode.AppendChild(priceNode);

            XmlNode versionNode = doc.CreateElement("Version");
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            versionNode.AppendChild(doc.CreateTextNode(version)); // get version from executing assembly version
            productNode.AppendChild(versionNode);

            XmlNode serialNumber = doc.CreateElement("SerialNumber");
            serialNumber.AppendChild(doc.CreateTextNode("0000-0000-0000-0000-0000"));
            productsNode.AppendChild(serialNumber);
            string inputFile = "serial.xml";
            doc.Save(inputFile);

            string message = string.Empty;
            FileCipher.EncryptFile(inputFile, SerialFile, out message);
            FileInfo file = new FileInfo(inputFile);
            file.Delete();
        }

        public static bool IsQueryContainDate(string queryGenerate, out string message)
        {
            bool result = false;
            message = string.Empty;
            string query = queryGenerate.Replace("\r\n", string.Empty);
            switch (ClassHelper.dbConnector)
            {
                case "ORACLE":
                    result = query.Contains(":tglAwal") && query.Contains(":tglAkhir");
                    break;
                case "MYSQL":
                    result = query.Contains("?tglAwal") && query.Contains("?tglAkhir");
                    break;
                case "SQL":
                case "ACCESS":
                    result = query.Contains("@tglAwal") && query.Contains("@tglAkhir");
                    break;
                default:
                    break;
            }

            if (!result)
            {
                message = "Query Filter Tanggal Tidak Ditemukan (tglAwal/tglAkhir)";
            }

            return result;
        }

        public static void ListNotAllowedPort(ref List<ExceptionPort> usedPort)
        {
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            IEnumerator myEnum = tcpConnInfoArray.GetEnumerator();

            while (myEnum.MoveNext())
            {
                TcpConnectionInformation TCPInfo = (TcpConnectionInformation)myEnum.Current;
                Console.WriteLine("Port {0} {1} {2} ", TCPInfo.LocalEndPoint, TCPInfo.RemoteEndPoint, TCPInfo.State);
                usedPort.Add(new ExceptionPort { Port = TCPInfo.LocalEndPoint.Port });
            }
        }

        public static bool CheckAvailabilityPort(int port, out string message)
        {
            bool allowedPort = false;
            try
            {
                System.Net.Sockets.Socket sock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                sock.Connect("localhost", port);
                allowedPort = sock.Connected;
                if (sock.Connected == true)
                {
                    sock.Close();
                }
                message = "Port dapat digunakan";
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                if (ex.ErrorCode == 10061)
                    message = "Port terpakai, silahkan gunakan port yang lain!";
                else
                    message = ex.Message;
            }

            return allowedPort;
        }

        public static string GetConnectionString(string pathExcel)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = pathExcel;

            // XLS - Excel 2003 and Older
            //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = "C:\\MyExcel.xls";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }

        public static DataSet ReadExcelFile(string pathExcel)
        {
            DataSet ds = new DataSet();

            string connectionString = GetConnectionString(pathExcel);

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                // Get all Sheets in Excel File
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                // Loop through all Sheets to get data
                foreach (DataRow dr in dtSheet.Rows)
                {
                    string sheetName = dr["TABLE_NAME"].ToString();

                    if (!sheetName.EndsWith("$"))
                        continue;

                    // Get all rows from the Sheet
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                    DataTable dt = new DataTable();
                    dt.TableName = sheetName;

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    ds.Tables.Add(dt);
                }

                cmd = null;
                conn.Close();
            }

            return ds;
        }
    }

    internal class DBSettings
    {
        public string NamaDB { get; set; }
        public List<SourceDB> lstSourceDB { get; set; }
        public List<NopPajak> LstNop { get; set; }
        public string QueryPajak { get; set; }
        public string QueryDetail { get; set; }
        public string xml_content { get; set; }
    }

    internal class NopPajak
    {
        public string JenisPajak { get; set; }
        public string Nop { get; set; }
        public string Alias { get; set; }
        public string TarifPajak { get; set; }
    }

    internal class SourceDB
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    internal class USERAPP
    {
        public string userName { get; set; }
        public string idMachine { get; set; }
        public string guid { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public int port { get; set; }
    }

    internal class NOP
    {
        public string nop { get; set; }
        public string jenisPajak { get; set; }
    }

    internal class Setting
    {
        public string nop { get; set; }
        public string column_name { get; set; }
        public string column_text { get; set; }
    }

    internal class AppSettings
    {
        public IEnumerable<USERAPP> list_user { get; set; }
        public IEnumerable<NOP> list_nop { get; set; }
        public IEnumerable<Setting> settings { get; set; }
        public string xml_content { get; set; }
        public string jenFile { get; set; }
        public string separator { get; set; }
    }

    internal class UserTempSetting
    {
        public int id_setting { get; set; }
        public string nama_setting { get; set; }
        public string value { get; set; }
        public string keterangan { get; set; }
    }
}

