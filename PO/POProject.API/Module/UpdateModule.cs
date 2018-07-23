﻿using log4net;
using Nancy;
using Nancy.Extensions;
using Nancy.Responses;
using Newtonsoft.Json;
using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POProject.API.Module
{
    public class UpdateModule : NancyModule
    {
        class DownloadUpdate
        {
            public string fileName { get; set; }
        }

        private const string ROOT_PATH = "/download/";
        private const string GET_LATEST_VERSION = ROOT_PATH + "getLatestVersion";
        private const string UPDATE = ROOT_PATH + "update";

        private static readonly ILog log = LogManager.GetLogger(typeof(DevModule));
        public UpdateModule()
        {
            //Get["download/update2"] = pars => Response.AsFile("devModule.rar", "application/x-rar-compressed, application/octet-stream");

            Get[GET_LATEST_VERSION] = parameter =>
            {
                log.Debug("Start:/download/getLatestVersion");
                List<UpdateVersion> latestVers = new List<UpdateVersion>();
                try
                {
                    latestVers = UpdateVersionBusiness.GetVersion();
                    log.Debug("Get Version Success");
                }
                catch (Exception ex)
                {
                    //log.Debug( "Get User Failed : " + ex.Message );
                    log.Fatal("Error:/setting/getLatestVersion", ex);
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                }

                //var jsonBody = JsonConvert.SerializeObject(latestVers.FirstOrDefault().version);
                return Response.AsJson(new { code = HttpStatusCode.OK, message = "Ok", Version = latestVers.FirstOrDefault().version, PathDir = latestVers.FirstOrDefault().path_directory });
            };

            Post[UPDATE] = parameter =>
            {
                log.Info("Start : /download/update");
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
                    FileInfo info = new FileInfo(setting.fileName);
                    if (info.Exists)
                    {
                        var file = new FileStream(setting.fileName, FileMode.Open);
                        string fileName = info.Name;//set a filename

                        var response = new StreamResponse(() => file, MimeTypes.GetMimeType(fileName));
                        return response.AsAttachment(fileName);
                    }
                    else
                    {
                        return Response.AsJson(new { message = "File Update Tidak Ditemukan" }, HttpStatusCode.NoContent);
                    }
                }
                else
                {
                    return Response.AsJson(new { message = "File Update Tidak Ditemukan" }, HttpStatusCode.NoContent);
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
    }
}
