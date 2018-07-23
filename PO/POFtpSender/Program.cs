using IWshRuntimeLibrary;
using Microsoft.AspNet.SignalR.Client;
using POAdministrationTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace POFtpSender
{
  static class Program
  {
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow( IntPtr hWnd );

    public const string serialFile = "POFtpSender.pof";
    public static List<SettingEntity> _lstColumnName;
    public static List<SettingDBEntity> _lstDB;
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      //flag to allow application only run one instance
      bool createdNew = true;
      bool isSetting = false;
      bool isSettingDB = false;
      using(Mutex mutex = new Mutex(true, System.AppDomain.CurrentDomain.FriendlyName, out createdNew))
      {
        if(createdNew)
        {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);



#if(!DEBUG)
            string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\" + "POFtpSender.lnk";
            string pathExe = Application.ExecutablePath;

            FileInfo fiPath = new FileInfo(shortcutPath);
            if (!fiPath.Exists)
            {
                CreateShortcut(shortcutPath, true);
            } 
            
            try
            {
                //System.IO.File.Copy(Application.ExecutablePath, pathExe);
                RegistryKey RegStartUp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                RegStartUp.SetValue("POFtpSender", pathExe);
            }
            catch { }
#endif

          //bool isSukses = false;
          //var maxUpdateLoop = 5;
          //var currLoop = 0;
          //while (!isSukses)
          //{
          //    currLoop++;
          //    try
          //    {


          FileInfo info = new FileInfo(serialFile);
          if(!info.Exists)
          {
            GenerateSerialFile();
          }

          string message = string.Empty;
          string mode = string.Empty;
          SenderTransaction.ValidateRuntimeMode(serialFile, out message, out mode);
          if(!string.IsNullOrEmpty(message))
          {
            MessageBox.Show(message);
            Application.Exit();
          }
          ClassHelper.RuntimeMode = mode;

          #region Tes Ftp
          //Application.Run(new frmFtpSender());
          #endregion

          #region Release Ftp
          string fileName = "setUpload.xml";
          string fileDB = "setDB.xml";
          FileInfo fi = new FileInfo(fileName);
          FileInfo fiDB = new FileInfo(fileDB);
          if(!fi.Exists && !fiDB.Exists)
          {
            frmFtpSettings ftpSetting = new frmFtpSettings();
            if(ftpSetting.ShowDialog() == DialogResult.Yes)
            {
              string pesanError = string.Empty;
              _lstDB = new List<SettingDBEntity>();
              _lstColumnName = new List<SettingEntity>();
              SettingEntity itemSetting = new SettingEntity();
              CekUploadXml(itemSetting, out isSetting, out pesanError);
              CekDBXml(out pesanError, out isSettingDB, out _lstDB);

              ClassHelper.isSetting = isSetting;
              ClassHelper.isSettingDB = isSettingDB;

              if(isSetting && string.IsNullOrEmpty(ClassHelper.jenisFile))
                ClassHelper.jenisFile = "XLS";

              frmSplash splash = new frmSplash();
              if(splash.ShowDialog() == DialogResult.Yes)
              {
                //ConnectMonitorHub(ClassHelper.urlAPI, ClassHelper.userName);

                frmFtpSender ftpSender = new frmFtpSender();
                Application.Run(ftpSender);
              }
            }
          }
          else
          {
            string pesanError = string.Empty;
            _lstDB = new List<SettingDBEntity>();
            _lstColumnName = new List<SettingEntity>();
            SettingEntity itemSetting = new SettingEntity();
            CekUploadXml(itemSetting, out isSetting, out pesanError);
            CekDBXml(out pesanError, out isSettingDB, out _lstDB);

            ClassHelper.isSetting = isSetting;
            ClassHelper.isSettingDB = isSettingDB;

            if(isSetting && string.IsNullOrEmpty(ClassHelper.jenisFile))
              ClassHelper.jenisFile = "XLS";

            frmSplash splash = new frmSplash();
            if(splash.ShowDialog() == DialogResult.Yes)
            {
              //ConnectMonitorHub(ClassHelper.urlAPI, ClassHelper.userName);
              Application.Run(new frmFtpSender());
            }
          }
          #endregion

          //Launch CLIENT API
          //CloseMonitoringAPI();
          //LaunchMonitoringAPI();
        }
        else
        {
          System.Diagnostics.Process current = System.Diagnostics.Process.GetCurrentProcess();
          foreach(System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName(current.ProcessName))
          {
            if(process.Id != current.Id)
            {
              SetForegroundWindow(process.MainWindowHandle);
              break;
            }
          }
        }
      }
    }

    //private static void CloseMonitoringAPI()
    //{
    //    //close monitoring.API
    //    foreach (var process in System.Diagnostics.Process.GetProcessesByName("Monitoring.API.exe"))
    //    {
    //        process.Kill();
    //        break;
    //    }
    //}

    //private static void LaunchMonitoringAPI()
    //{
    //    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    //    startInfo.CreateNoWindow = false;
    //    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
    //    startInfo.FileName = "Monitoring.API.exe";
    //    try
    //    {
    //        System.Diagnostics.Process.Start(startInfo);
    //        //System.Diagnostics.Process.Start(path);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //    }

    //}

    //private static void CreateShortcut(string shortcutPathName, bool create)
    //{
    //    if (create)
    //    {
    //        try
    //        {
    //            string shortcutTarget = System.IO.Path.Combine(Application.StartupPath, "POFtpSender.exe");
    //            WshShell myShell = new WshShell();
    //            WshShortcut myShortcut = (WshShortcut)myShell.CreateShortcut(shortcutPathName);
    //            myShortcut.TargetPath = shortcutTarget; //The exe file this shortcut executes when double clicked 
    //            myShortcut.IconLocation = shortcutTarget + ",0"; //Sets the icon of the shortcut to the exe`s icon 
    //            myShortcut.WorkingDirectory = Application.StartupPath; //The working directory for the exe 
    //            myShortcut.Arguments = ""; //The arguments used when executing the exe 
    //            myShortcut.Save(); //Creates the shortcut 
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message);
    //        }
    //    }
    //    else
    //    {
    //        try
    //        {
    //            if (System.IO.File.Exists(shortcutPathName))
    //                System.IO.File.Delete(shortcutPathName);
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message);
    //        }
    //    }
    //}

    private static void GenerateSerialFile()
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
      productNode.AppendChild(nameNode);
      XmlNode priceNode = doc.CreateElement("RuntimeMode");
      priceNode.AppendChild(doc.CreateTextNode("Trial"));
      ClassHelper.RuntimeMode = "Trial";
      productNode.AppendChild(priceNode);

      XmlNode versionNode = doc.CreateElement("Version");
      System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
      System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
      string version = fvi.FileVersion;
      versionNode.AppendChild(doc.CreateTextNode(version)); // get version from executing assembly version
      productNode.AppendChild(versionNode);

      string inputFile = "serial.xml";
      doc.Save(inputFile);

      string message = string.Empty;
      FileCipher.EncryptFile(inputFile, serialFile, out message);
      FileInfo file = new FileInfo(inputFile);
      file.Delete();
    }

    private static void CekUploadXml( SettingEntity itemSetting, out bool isSetting, out string pesanError )
    {
      pesanError = string.Empty;
      isSetting = false;
      string elementName = string.Empty;
      string fileName = "setUpload.xml";
      string jenisPajak = string.Empty;
      string versi = string.Empty;
      string nop = string.Empty;

      FileInfo fi = new FileInfo(fileName);
      if(!fi.Exists)
      {
        pesanError = "File Setting Upload tidak ditemukan";
        //DialogResult = DialogResult.No;
        //Close();
        return;
      }

      try
      {
        using(XmlReader reader = XmlReader.Create(fileName))
        {
          while(reader.Read())
          {
            if(reader.IsStartElement())
            {
              switch(reader.Name.ToUpper())
              {
                case "SETTING":
                  versi = reader["version"];
                  break;
                case "JENIS":
                  jenisPajak = reader["nama"];
                  break;
                default:
                  break;
              }
            }

            if(reader.NodeType == XmlNodeType.Element)
            {
              if(!string.IsNullOrEmpty(reader.Name))
                elementName = reader.Name;
            }

            if(reader.NodeType == XmlNodeType.Text)
            {
              string teks = reader.Value;
              //insert into list
              if(!string.IsNullOrEmpty(elementName) && string.Compare(elementName.ToUpper(), "USERNAME") == 0)
              {
                ClassHelper.userName = teks;
              }

              if(!string.IsNullOrEmpty(elementName) && string.Compare(elementName.ToUpper(), "JENISFILE") == 0)
              {
                ClassHelper.jenisFile = teks;
              }

              if(!string.IsNullOrEmpty(elementName) && string.Compare(elementName.ToUpper(), "SEPARATOR") == 0)
              {
                ClassHelper.separator = Convert.ToChar(teks);
              }

              if(jenisPajak.ToUpper() == "URLFTP")
              {
                if(string.Compare(elementName.ToUpper(), "URLAPI") == 0)
                  ClassHelper.urlAPI = teks;
                if(string.Compare(elementName.ToUpper(), "PORT") == 0)
                  ClassHelper.port = Convert.ToInt32(teks);
              }
              else
              {
                if(!string.IsNullOrEmpty(elementName) && string.Compare(elementName.ToUpper(), "NOP") != 0)
                {
                  if(string.Compare(elementName.ToUpper(), "USERNAME") != 0
                      && string.Compare(elementName.ToUpper(), "JENISFILE") != 0
                      && string.Compare(elementName.ToUpper(), "SEPARATOR") != 0)
                  {
                    itemSetting = new SettingEntity();
                    itemSetting.JenisPajak = jenisPajak;
                    itemSetting.Nop = nop;
                    itemSetting.NamaKolom = elementName;
                    itemSetting.TeksKolom = teks;
                    _lstColumnName.Add(itemSetting);
                  }
                }
                else
                  nop = teks;
              }
            }
          }
        }
        isSetting = true;
        ClassHelper.lstColumnName = _lstColumnName;
      }
      catch(Exception ex)
      {
        pesanError = ex.Message;
      }
    }

    private static void CekDBXml( out string pesanError, out bool isSettingDB, out List<SettingDBEntity> listDB )
    {
      string fileName = "setDB.xml";
      string jenis = string.Empty;
      string elementName = string.Empty;
      isSettingDB = false;
      pesanError = string.Empty;
      string jenisPajak = string.Empty;
      listDB = new List<SettingDBEntity>();
      SettingDBEntity setDB = new SettingDBEntity();

      FileInfo fi = new FileInfo(fileName);
      if(!fi.Exists)
      {
        pesanError = "File Setting DB tidak ditemukan";
        return;
      }

      try
      {
        using(XmlReader reader = XmlReader.Create(fileName))
        {
          while(reader.Read())
          {
            if(reader.IsStartElement())
            {
              switch(reader.Name.ToUpper())
              {
                case "SETTINGDATABASE":
                  break;
                case "JENIS":
                  jenis = reader["nama"];
                  break;
                case "JENISPAJAK":
                  setDB = new SettingDBEntity();
                  jenisPajak = reader["nama"];
                  setDB.jenisPajak = jenisPajak;
                  break;
                default:
                  break;
              }
            }

            if(reader.NodeType == XmlNodeType.Element)
            {
              elementName = reader.Name;
            }

            if(reader.NodeType == XmlNodeType.Text)
            {
              string teks = reader.Value;
              //insert into list
              if(!string.IsNullOrEmpty(elementName) && string.Compare(elementName.ToUpper(), "USERNAME") == 0)
              {
                ClassHelper.userName = teks;
              }

              if(string.Compare(elementName.ToUpper(), "URLAPI") == 0)
              {
                ClassHelper.urlAPI = teks;
              }
              else if(string.Compare(elementName.ToUpper(), "PORT") == 0)
              {
                ClassHelper.port = Convert.ToInt32(teks);
              }
              else
              {
                if(!string.IsNullOrEmpty(elementName) && string.Compare(elementName.ToUpper(), "USERNAME") != 0)
                {
                  if(string.Compare(elementName.ToUpper(), "NOP") == 0)
                    setDB.nop = teks;

                  if(string.Compare(elementName.ToUpper(), "ALIAS") == 0)
                    setDB.alias = teks;

                  if(string.Compare(elementName.ToUpper(), "QUERYPAJAK") == 0)
                    setDB.queryPajak = teks;

                  if(string.Compare(elementName.ToUpper(), "QUERYLAMPIRAN") == 0)
                  {
                    setDB.queryLampiran = teks;
                    listDB.Add(setDB);
                  }
                }
              }
            }
          }
        }
        isSettingDB = true;
        _lstDB = listDB;
        ClassHelper.lstDB = listDB;
      }
      catch(Exception ex)
      {
        pesanError = ex.Message;
      }
    }

    // example of how to connect to monitor hub
    // key => connection id
    private static void ConnectMonitorHub( string url, string key )
    {
      string[] arrUrl = url.Split(':');
      string signalRpath = string.Concat(arrUrl[0], ":8885");

      var querystringData = new Dictionary<string, string>();
      querystringData.Add("Key", key);

      var hubConnection = new HubConnection(signalRpath, querystringData);
      IHubProxy myHubProxy = hubConnection.CreateHubProxy("MonitorHub");
      hubConnection.StateChanged += HubConnection_StateChanged;

      hubConnection.Start().Wait();
    }

    // notify client on state change event
    // Connected, Reconnecting, Disconnected
    private static void HubConnection_StateChanged( StateChange obj )
    {
      //Console.WriteLine(string.Format("State Changed => {0}", obj.NewState));
    }
  }
}
