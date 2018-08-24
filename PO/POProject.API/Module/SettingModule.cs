using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Nancy;
using Nancy.Extensions;
using Newtonsoft.Json;
using POProject.BusinessLogic;
using System.Data;
using POProject.Model;
using POProject.BusinessLogic.BusinessDataModel;

namespace POProject.API.Module
{
    public class SettingModule : NancyModule
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SettingModule));
        private readonly ISerialNoteBusiness _serialNoteBusiness;
        private readonly ISettingClientBusiness _settingClientBusiness;
        private readonly IUserSettingColumnBusiness _userSettingColumnBusiness;

        public SettingModule(ISerialNoteBusiness serialNoteBusiness, ISettingClientBusiness settingClientBusiness, IUserSettingColumnBusiness userSettingColumnBusiness)
        {
            _serialNoteBusiness = serialNoteBusiness;
            _settingClientBusiness = settingClientBusiness;
            _userSettingColumnBusiness = userSettingColumnBusiness;

            Get["/setting/getTime"] = parameter =>
            {
                log.Debug("Start:/setting/getTime");
                List<UserTempSetting> timeSetting = new List<UserTempSetting>();
                try
                {
                    timeSetting = _userSettingColumnBusiness.GetUserTempSetting("JAM SETTING");
                    log.Debug("Get Time Success");
                }
                catch (Exception ex)
                {
                    //log.Debug( "Get User Failed : " + ex.Message );
                    log.Fatal("Error:/setting/getTime", ex);
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                }

                var jsonBody = JsonConvert.SerializeObject(timeSetting);
                return Response.AsJson(new { code = HttpStatusCode.OK, message = "Ok", body = jsonBody });
            };

            Post["/setting/register_serialkey"] = parameter =>
            {
                try
                {
                    log.Info("Start : /setting/register_serialkey");
                    log.Info($"incoming request from IP:{this.Request.UserHostAddress}");
                    var body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    log.Info("Deserialize object from json body");
                    RegisterSerialKey user = JsonConvert.DeserializeObject<RegisterSerialKey>(body);

                    _userSettingColumnBusiness.RegisterSerialKey(user.userName, user.key, user.serialKey);

                    return Response.AsJson(new { code = HttpStatusCode.OK });
                }
                catch (System.Exception ex)
                {
                    log.Fatal("Error : /setting/register_serialkey", ex);
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                    //throw;
                }
            };

            Post["/setting/online_register_serialKey"] = parameter =>
            {
                try
                {
                    log.Info("Start : /setting/online_register_serialKey");
                    log.Info($"incoming request from IP:{this.Request.UserHostAddress}");
                    string body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    log.Info("Deserialize object from json body");
                    RequestRegisteredSerialKey setting = JsonConvert.DeserializeObject<RequestRegisteredSerialKey>(body);

                    #region Get Unused Serial Key
                    log.Info("Get Unused Serial Key");
                    List<SerialNoteBusinessDataModel> listAvailableSerialNote = _serialNoteBusiness.RetrieveAvailableSerialNote();
                    #endregion

                    #region Compare Serial Key
                    log.Info("Compare Available Serial Key With Key : " + setting.serial);
                    SerialNote note = listAvailableSerialNote.Where(m => m.Dec_Kode == setting.serial).FirstOrDefault();
                    if (note != null)
                    {
                        log.Debug("Serial is found");
                        log.Info("End : /setting/online_register_serialKey");

                        //TODO: change value username and HW ID ok tambah parameter y
                        _serialNoteBusiness.UpdateData(note.Kode, setting.username, setting.HWId);

                        return Response.AsJson(new { message = "Valid" });
                    }
                    else
                    {
                        log.Debug("Serial not found");
                        log.Info("End : /setting/online_register_serialKey");

                        return Response.AsJson(new { message = "Invalid Key" }, HttpStatusCode.NoContent);
                    }
                    #endregion
                }
                catch (System.Exception ex)
                {
                    log.Fatal("Error : /setting/online_register_serialKey", ex);
                    return Response.AsJson(new { message = $"Error, {ex.Message}" }, HttpStatusCode.InternalServerError);
                    throw;
                }
            };

            Post["/setting/postSerialKey"] = parameter =>
            {
                try
                {
                    log.Info("Start : /setting/postSerialKey");
                    var body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    log.Info("Deserialize object from json body");
                    var jsonBody = JsonConvert.DeserializeObject<SerialRequest>(body);

                    _settingClientBusiness.UpdateSerialKey(jsonBody.username, jsonBody.serialKey);

                    return Response.AsJson(new { code = HttpStatusCode.OK, message = "Serial key berhasil" });
                }
                catch (Exception ex)
                {
                    log.Fatal("Error : /setting/postSerialKey", ex);
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                }
            };

            Post["/setting/SerialKeyExist"] = parameter =>
            {
                try
                {
                    log.Info("Start : /setting/SerialKeyExist");
                    var body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    log.Info("Deserialize object from json body");
                    var jsonBody = JsonConvert.DeserializeObject<CheckSerialKeyRequest>(body);

                    bool isFound = _settingClientBusiness.IsSerialKeyExist(jsonBody.serialKey, jsonBody.username, jsonBody.cpuId);
                    if (!isFound)
                    {
                        List<SerialNoteBusinessDataModel> takenSerial = _serialNoteBusiness.RetrieveTakenSerialNote();
                        if (takenSerial.Where(s => s.Dec_Kode == jsonBody.serialKey && s.Dec_Taken_Username == jsonBody.username && s.Dec_Taken_HW_ID == jsonBody.cpuId).FirstOrDefault() != null)
                        {
                            isFound = true;
                        }
                    }

                    if (isFound)
                    {
                        return Response.AsJson(new { message = "Serial key ditemukan" });
                    }
                    else
                    {
                        return Response.AsJson(new { message = "Serial Key Tidak Ditemukan" }, HttpStatusCode.NotFound);
                    }
                }
                catch (Exception ex)
                {
                    log.Fatal("Error : /setting/postSerialKey", ex);
                    return Response.AsJson(new { message = $"Error, {ex.Message}" }, HttpStatusCode.ExpectationFailed);
                }
            };

            Post["/setting/retrieveSourceDB"] = parameter =>
            {
                try
                {
                    log.Info("Start : /setting/retrieveSourceDB");
                    var body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    log.Info("Deserialize object from json body");
                    SourceDBRequest source = JsonConvert.DeserializeObject<SourceDBRequest>(body);
                    //todo delete 1 row below List<settingDBSource> lstSource = _settingClientBusiness.RetrieveSourceDB(source.username);
                    List<settingDBSource> lstSource = null;

                    log.Info("Serialize json from body");
                    var jsonBody = JsonConvert.SerializeObject(lstSource);

                    return Response.AsJson(new { code = HttpStatusCode.OK, message = "Success", body = jsonBody });
                }
                catch (Exception ex)
                {
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                }
            };

            Post["/setting/postSettingDBWithParam"] = parameter =>
            {
                try
                {
                    log.Info("Start : /setting/postSettingDBWithParam");
                    log.Info($"incoming request from IP:{this.Request.UserHostAddress}");
                    string ipRequest = Request.UserHostAddress;
                    var body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    log.Info("Deserialize object from json body");
                    Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(body);
                    Newtonsoft.Json.Linq.JToken jMachine = jObj["machineInfo"];
                    Newtonsoft.Json.Linq.JToken jBody = jObj["body"];

                    List<DBSettings> lstSetDB = JsonConvert.DeserializeObject<List<DBSettings>>(jBody.ToString()).ToList();
                    List<USERAPP> lstUser = JsonConvert.DeserializeObject<List<USERAPP>>(jMachine.ToString()).ToList();
                    //Retrieve Data User Setting
                    if (lstSetDB != null && lstUser != null)
                    {
                        log.Info("Inserting user client ............");
                        _settingClientBusiness.InsertUserClient(lstUser.FirstOrDefault().userName, lstUser.FirstOrDefault().idMachine, lstUser.FirstOrDefault().guid,
                            lstUser.FirstOrDefault().phone, lstUser.FirstOrDefault().mail, lstUser.FirstOrDefault().port);
                        _settingClientBusiness.InsertXmlFile(lstUser.FirstOrDefault().userName, "setDB.xml", lstSetDB.FirstOrDefault().xml_content, "DATABASE", "");
                        log.Info("Inserting user nop, user setting db, user source db ............");
                        foreach (var item in lstSetDB)
                        {
                            foreach (var itemSetting in item.LstNop)
                            {
                                string username = lstUser.FirstOrDefault().userName;
                                if (!_settingClientBusiness.isUserNopExist(username, itemSetting.Nop))
                                    _settingClientBusiness.InsertUserNop(username, itemSetting.Nop, itemSetting.JenisPajak);
                                string dir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sourceDB.xml");
                                DataSet ds = new DataSet();
                                ds.Tables.Add(item.lstSourceDB.ToDataTable());
                                ds.WriteXml(dir);

                                string xmlSettDB = System.IO.File.ReadAllText(dir);
                                //insert into user_source_db                                
                                _settingClientBusiness.InsertUserSourceDatabase(username, itemSetting.Nop, xmlSettDB, ipRequest, item.NamaDB);
                                //insert into user_setting_database
                                _settingClientBusiness.InserUserSettingDatabase(username, itemSetting.Nop, itemSetting.JenisPajak, itemSetting.TarifPajak, item.QueryPajak,
                                    item.QueryDetail, itemSetting.Alias);
                            }
                        }
                        return Response.AsJson(new { code = HttpStatusCode.OK, message = "Success", body = "" });
                    }
                    else
                    {
                        log.Info("End : /setting/postSettingDBWithParam");
                        return Response.AsJson(new { code = HttpStatusCode.Unauthorized, message = "Failed", body = string.Empty });
                    }
                }
                catch (Exception ex)
                {
                    log.Fatal("Error : /setting/postSettingDBWithParam", ex);
                    return Response.AsJson(new { code = HttpStatusCode.BadRequest, message = $"Error, {ex.Message}", body = string.Empty });
                }
            };
        }

        class RegisterSerialKey
        {
            public string userName { get; set; }
            public string key { get; set; }
            public string serialKey { get; set; }
        }

        class RequestRegisteredSerialKey
        {
            public string serial { get; set; }
            public string username { get; set; }
            public string HWId { get; set; }
        }

        class SourceDBRequest
        {
            public string username { get; set; }
        }

        class SerialRequest
        {
            public string serialKey { get; set; }
            public string username { get; set; }
        }

        class CheckSerialKeyRequest
        {
            public string serialKey { get; set; }
            public string username { get; set; }
            public string cpuId { get; set; }
        }
    }
}
