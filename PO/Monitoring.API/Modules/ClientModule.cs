using log4net;
using Nancy;
using Nancy.Extensions;
using Nancy.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Monitoring.API.Modules
{
    public class ClientModule : NancyModule
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ClientModule));
        const string ProjectName = "POFtpSender.exe";
        const string ProjectName64 = "POFtpSender.exe *32";
        const string PATH_CLIENT = "/client";
        public ClientModule()
        {
            Get[PATH_CLIENT + "/getPOApplicationStatus"] = parameter =>
            {
                try
                {
                    Process[] processes = Process.GetProcesses();
                    List<string> processImageName = new List<string>();
                    try
                    {
                        foreach (Process p in processes)
                        {
                            if (!String.IsNullOrEmpty(p.MainWindowTitle))
                            {
                                processImageName.Add(p.MainModule.ModuleName);
                            }
                        }
                    }
                    catch { }

                    var isRunning = processImageName.Select(x => string.Compare(x, ProjectName) == 0 ||
                                        string.Compare(x, ProjectName64) == 0).FirstOrDefault();
                    
                    var message = "Applikasi Tidak Ditemukan";
                    if (isRunning)
                    {
                        message = "Aplikasi sedang running";
                    }
                    return Response.AsJson(new { IsRunning = isRunning, message = message });
                }
                catch (Exception ex)
                {
                    return Response.AsJson(new { IsRunning = false, message = ex.Message }, HttpStatusCode.ExpectationFailed);
                }
            };

            //overwrite local file with file from server
            Post[PATH_CLIENT + "/overwriteXmlSetting"] = parameter =>
             {
                 var message = string.Empty;
                 try
                 {
                     log.Info("Mulai : /client/overwriteXmlSetting");
                     log.Info($"Request dari IP:{this.Request.UserHostAddress}");
                     var body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                     log.Info("Memparsing isi dari request API ");
                     RequestOverwriteXmlSetting setting = JsonConvert.DeserializeObject<RequestOverwriteXmlSetting>(body);
                     log.Info("Parsing sukses");

                     log.Info($"Mencari file {setting.file_name} di direktori :  { AssemblyDirectory }");
                     System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(AssemblyDirectory);
                     System.IO.FileInfo info = new System.IO.FileInfo(setting.file_name);
                     if (info.Exists)
                     {
                         log.Info($"file {setting.file_name} ditemukan");
                         //overwrite existing xml with content
                         //StreamReader reader = new StreamReader(info.FullName,false);
                         using (StreamWriter writer = new StreamWriter(info.Name, true))
                         {
                             {
                                 writer.Write(setting.file_content);
                             }
                             writer.Close();
                         }

                         message = $"Sukses mengganti content xml file {setting.file_name}";
                         log.Info("End : /client/overwriteXmlSetting");
                         return Response.AsJson(new { message = message });
                     }
                     else
                     {
                         log.Info($"Setting xml {setting.file_name} tidak ditemukan");
                         message = $"File Setting {setting.file_name} Tidak Ditemukan pada Client";
                         log.Info("End : /client/overwriteXmlSetting");
                         return Response.AsJson(new { message = message }, HttpStatusCode.NotFound);
                     }

                     
                 }
                 catch (System.Exception ex)
                 {
                     log.Fatal("Error : /client/overwriteXmlSetting", ex);
                     message = $"Error, {ex.Message}";
                     return Response.AsJson(new { message = message }, HttpStatusCode.ExpectationFailed);
                 }
             };

            Post[PATH_CLIENT + "/downloadFile"] = parameter =>
            {
                log.Info("Start : /client/downloadUpdateFile");
                log.Info($"incoming request from IP:{this.Request.UserHostAddress}");
                var body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                log.Info("Deserialize object from json body");
                DownloadUpdate setting = JsonConvert.DeserializeObject<DownloadUpdate>(body);

                string[] files = Directory.GetFiles(AssemblyDirectory);
                var result = string.Empty;
                foreach (string item in files)
                {
                    FileInfo localFile = new FileInfo(item);
                    if (string.Compare(localFile.Name, setting.fileName) == 0)
                    {
                        result = item;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(result))
                {
                    FileInfo info = new FileInfo(result);
                    if (info.Exists)
                    {
                        var file = new System.IO.FileStream(info.FullName, System.IO.FileMode.Open);

                        var response = new Nancy.Responses.StreamResponse(() => file, MimeTypes.GetMimeType(setting.fileName));
                        return response.AsAttachment(setting.fileName);
                    }
                    else
                    {
                        return Response.AsJson(new { message = "File Tidak Ditemukan" }, HttpStatusCode.NoContent);
                    }
                }
                else
                {
                    return Response.AsJson(new { message = "File Tidak Ditemukan" }, HttpStatusCode.NoContent);
                }
            };

            Post[PATH_CLIENT + "/restartSender"] = parameter =>
            {
                log.Info("Start : /client/restartSender");
                log.Info($"incoming request from IP:{this.Request.UserHostAddress} @{DateTime.Now}");
                var body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                log.Info("Deserialize object from json body");
                RestartRequest request = JsonConvert.DeserializeObject<RestartRequest>(body);

                try
                {
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.CreateNoWindow = false;
                    startInfo.FileName = request.ApplicationName;
                    foreach (var process in System.Diagnostics.Process.GetProcessesByName(request.ApplicationName))
                    {
                        process.Kill();
                        break;
                    }

                    System.Diagnostics.Process.Start(startInfo);

                    return Response.AsJson(new { message = "Aplikasi Sukses Di Restart" }, HttpStatusCode.NoContent);
                }
                catch
                {
                    return Response.AsJson(new { message = "Aplikasi Gagal DiRestart" }, HttpStatusCode.NoContent);
                }
            };
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return System.IO.Path.GetDirectoryName(path);
            }
        }

        class RequestOverwriteXmlSetting
        {
            public string file_name { get; set; }
            public string file_content { get; set; }
        }

        class DownloadUpdate
        {
            public string fileName { get; set; }
        }

        class RestartRequest
        {
            public string ApplicationName { get; set; }
        }
    }


}
