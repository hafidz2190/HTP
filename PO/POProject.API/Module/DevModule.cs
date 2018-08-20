using log4net;
using Nancy;
using Nancy.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POProject.BusinessLogic;
using POProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace POProject.API.Module
{
    public class DevModule : NancyModule
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DevModule));
        private readonly IJatuhTempoBusiness _jatuhTempoBusiness;
        private readonly ISettingClientBusiness _settingClientBusiness;
        private readonly ISPTPDDetailBusiness _sPTPDDetailBusiness;
        private readonly IUserActivityBusiness _userActivityBusiness;
        private readonly IUserSettingColumnBusiness _userSettingColumnBusiness;
        private readonly IUserTransactionBusiness _userTransactionBusiness;
        private readonly IUserTransactionDetailBusiness _userTransactionDetailBusiness;

        public DevModule(IJatuhTempoBusiness jatuhTempoBusiness, ISettingClientBusiness settingClientBusiness, ISPTPDDetailBusiness sPTPDDetailBusiness, IUserActivityBusiness userActivityBusiness, IUserSettingColumnBusiness userSettingColumnBusiness, IUserTransactionBusiness userTransactionBusiness, IUserTransactionDetailBusiness userTransactionDetailBusiness)
        {
            _jatuhTempoBusiness = jatuhTempoBusiness;
            _settingClientBusiness = settingClientBusiness;
            _sPTPDDetailBusiness = sPTPDDetailBusiness;
            _userActivityBusiness = userActivityBusiness;
            _userSettingColumnBusiness = userSettingColumnBusiness;
            _userTransactionBusiness = userTransactionBusiness;
            _userTransactionDetailBusiness = userTransactionDetailBusiness;

            Get["/testConnection"] = parameter =>
            {
                var jsonBody = string.Empty;
                try
                {
                    List<ExceptionPort> listPort = new List<ExceptionPort>();
                    listPort = _settingClientBusiness.RetrievePortException();
                    log.Debug("Get list port");
                    jsonBody = JsonConvert.SerializeObject(listPort);
                    log.Debug("Connection Success");
                    return Response.AsJson(new { value = "OK", body = jsonBody });
                }
                catch (Exception ex)
                {
                    return Response.AsJson(new { value = "Error : " + ex.Message, body = jsonBody });
                }


            };

            Get["/dev/getAllUser"] = parameter =>
            {
                log.Debug("Start:/dev/getAllUser");
                List<string> lstUsr = new List<string>();
                try
                {
                    lstUsr = _userSettingColumnBusiness.RetrieveAllUser();
                    log.Debug("Get User Success");
                }
                catch (Exception ex)
                {
                    //log.Debug( "Get User Failed : " + ex.Message );
                    log.Fatal("Error:/dev/getAllUser", ex);
                    return Response.AsJson(new { code = HttpStatusCode.NotFound, message = "Data Not Found", body = string.Empty });
                }

                var jsonBody = JsonConvert.SerializeObject(lstUsr);
                return Response.AsJson(new { code = HttpStatusCode.OK, message = "Ok", body = jsonBody });
            };

            Get["/dev/getSerialKeyIsExist"] = parameter =>
            {
                log.Debug("Start:/dev/getSerialKeyIsExist");
                try
                {
                    string body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    bool isFound = _userSettingColumnBusiness.IsSerialFound(body);
                    if (isFound)
                    {
                        log.Debug("Serial is found");
                        return Response.AsJson(new { code = HttpStatusCode.OK, message = "Found", body = "True" });
                    }
                    else
                    {
                        log.Debug("Serial not found");
                        return Response.AsJson(new { code = HttpStatusCode.OK, message = "Not", body = "False" });
                    }

                }
                catch (Exception ex)
                {
                    //log.Debug( "Get User Failed : " + ex.Message );
                    log.Fatal("Error:/dev/getSerialKeyIsExist", ex);
                    return Response.AsJson(new { code = HttpStatusCode.NotFound, message = "Data Not Found", body = string.Empty });
                }
            };

            Get["/dev/GetUrlApi"] = parameter =>
            {
                log.Debug("Start:/dev/GetUrlApi");
                string urlApi = string.Empty;
                urlApi = _userActivityBusiness.GetUrlApi();
                try
                {
                    var jsonBody = JsonConvert.SerializeObject(urlApi);
                    return Response.AsJson(new { code = HttpStatusCode.OK, message = "Ok", body = jsonBody });
                }
                catch (Exception ex)
                {
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}", body = string.Empty });
                }

            };

            Get["/dev/GetTarifPajak"] = parameter =>
            {
                log.Debug("Start:/dev/GetTarifPajak");
                List<JenisPajak> lstPajak = new List<JenisPajak>();
                try
                {
                    //Get All Tarif Pajak
                    lstPajak = _userSettingColumnBusiness.RetrieveTarifAll();
                    log.Debug("Get tarif pajak success");
                }
                catch (Exception ex)
                {
                    log.Fatal("Error:/dev/GetTarifPajak", ex);
                    return Response.AsJson(new { code = HttpStatusCode.NotFound, message = "Data Not Found", body = string.Empty });
                }

                var jsonBody = JsonConvert.SerializeObject(lstPajak);
                return Response.AsJson(new { code = HttpStatusCode.OK, message = "OK", body = jsonBody });
            };

            Post["/dev/postLastErrorDate"] = parameter =>
            {
                try
                {
                    log.Info("Start : /dev/postLastErrorDate");
                    string ip = Request.UserHostAddress;
                    string body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    log.Info("Deserialize object from json body");
                    var setting = JsonConvert.DeserializeObject<string>(body);
                    //Get Last Error Date By status_error
                    LastErrorResponse resp = new LastErrorResponse();
                    resp.TanggalError = DateTime.Now.Date;

                    resp.TanggalError = _userActivityBusiness.GetLastErrorDate(setting);

                    var jsonBody = JsonConvert.SerializeObject(resp);
                    log.Info("End : /dev/postLastErrorDate");
                    return Response.AsJson(new { code = HttpStatusCode.OK, body = jsonBody });
                }
                catch (Exception ex)
                {
                    log.Fatal("Error : /dev/postLastErrorDate", ex);
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                    throw;
                }
            };

            Post["/dev/postSettingClient"] = parameter =>
            {
                try
                {
                    log.Info("Start : /dev/postSettingClient");
                    log.Info($"incoming request from IP:{this.Request.UserHostAddress}");
                    string body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    log.Info("Deserialize object from json body");
                    JsonSetting setting = JsonConvert.DeserializeObject<JsonSetting>(body);

                    #region Inserting Data Setting Client
                    log.Info("Inserting data setting client");
                    string username = string.Empty;
                    foreach (var item in setting.list_user)
                    {
                        _settingClientBusiness.InsertUserClient(item.userName, item.idMachine, item.guid, item.phone, item.mail, item.port);
                        username = item.userName;
                    }
                    foreach (var item in setting.list_nop)
                    {
                        _settingClientBusiness.InsertUserNop(username, item.nop, item.jenisPajak);
                    }

                    foreach (var item in setting.settings)
                    {
                        _settingClientBusiness.InsertUserSettingColumn(username, item.nop, item.column_name, item.column_text);
                    }
                    #endregion

                    //insert xmlcontent
                    _settingClientBusiness.InsertXmlFile(username, "setUpload.xml", setting.xml_content, setting.jenFile, setting.separator);

                    log.Info("End : /dev/postSettingClient");
                    return Response.AsJson(new { code = HttpStatusCode.OK });
                }
                catch (System.Exception ex)
                {
                    log.Fatal("Error : /dev/postSettingClient", ex);
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                    throw;
                }
            };

            Post["/dev/postSettingClientWithParam"] = parameter =>
            {
                try
                {
                    log.Info("Start : /dev/postSettingClientWithParam");
                    log.Info($"incoming request from IP:{this.Request.UserHostAddress}");
                    var body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    log.Info("Deserialize object from json body");
                    User user = JsonConvert.DeserializeObject<User>(body);

                    //Retrieve Data User Setting
                    if (user != null)
                    {
                        log.Info("Checking user exist");
                        UserClient userClient = _settingClientBusiness.RetrieveUserClient(user.userName, user.idMachine, user.guid).FirstOrDefault();
                        if (userClient != null)
                        {
                            log.Info("Retrieve data setting client from database");
                            List<UserSettingColumn> listSettingColumn = _userSettingColumnBusiness.RetrieveSettingColumnByUsername(userClient.Username);
                            log.Info("Serialize data to json");
                            var jsonBody = JsonConvert.SerializeObject(listSettingColumn);
                            log.Info("End : /dev/postSettingClientWithParam");
                            return Response.AsJson(new { code = HttpStatusCode.OK, message = "Success", body = jsonBody });
                        }
                        else
                        {
                            log.Info("End : /dev/postSettingClientWithParam");
                            return Response.AsJson(new { code = HttpStatusCode.NotFound, message = "Data Not Found", body = string.Empty });
                        }
                    }
                    else
                    {
                        log.Info("End : /dev/postSettingClientWithParam");
                        return Response.AsJson(new { code = HttpStatusCode.Unauthorized, message = "Failed", body = string.Empty });
                    }
                }
                catch (Exception ex)
                {
                    log.Fatal("Error : /dev/postSettingClientWithParam", ex);
                    return Response.AsJson(new { code = HttpStatusCode.BadRequest, message = $"Error, {ex.Message}", body = string.Empty });
                }
            };

            Post["/dev/postTransactionClient"] = parameter =>
            {
                try
                {
                    log.Info("Start : /dev/postTransactionClient");
                    string ip = this.Request.UserHostAddress;
                    log.Info($"incoming request from IP:{ip}");
                    string body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(body);

                    string username = string.Empty;
                    string CultureInfos = string.Empty;
                    username = jsonData.datauser.FirstOrDefault().username;

                    string bulan = jsonData.masapajak.FirstOrDefault().bulan;
                    string tahun = jsonData.masapajak.FirstOrDefault().tahun;
                    CultureInfos = jsonData.items.CultureInfos;
                    log.Info("generating file json to xml");

                    DataTable dtTransaksi = new DataTable();
                    DataTable dtLampiran = new DataTable();
                    dtTransaksi.CaseSensitive = false;
                    dtLampiran.CaseSensitive = false;


                    if (jsonData.items.dtLampiran != null && jsonData.items.dtLampiran.Rows.Count > 0)
                        dtTransaksi = jsonData.items.dtPajak;
                    else
                    {
                        log.Info("Data tidak ditemukan ............");
                        return Response.AsJson(new { code = HttpStatusCode.NotFound, message = $"Error, {"Data tidak ditemukan."}" });
                    }

                    if (jsonData.items.dtLampiran != null && jsonData.items.dtLampiran.Rows.Count > 0)
                        dtLampiran = jsonData.items.dtLampiran;
                    else
                        dtLampiran = dtTransaksi.Copy();

                    List<UserSettingColumn> lstColumnName = new List<UserSettingColumn>();
                    lstColumnName = _settingClientBusiness.RetrieveUserSettingColumn(username, dtLampiran.Rows[0]["NOP"].ToString());
                    string teksTanggal = lstColumnName.Where(m => m.Column_Name.ToUpper().Equals("TGL_TRANSAKSI")).Select(m => m.Column_Text).FirstOrDefault();
                    if (string.IsNullOrEmpty(teksTanggal))
                        teksTanggal = "TGL_TRANSAKSI";

                    #region Delete Null Rows in First column
                    DataView dv = dtTransaksi.AsDataView();
                    dv.RowFilter = teksTanggal + " IS NOT NULL";
                    dtTransaksi = dv.ToTable();

                    dv = new DataView();
                    dv = dtLampiran.AsDataView();
                    dv.RowFilter = teksTanggal + " IS NOT NULL";
                    dtLampiran = dv.ToTable();
                    #endregion

                    string nop = string.Empty;
                    bool isFromDatabase = false;
                    DataColumnCollection col = dtLampiran.Columns;
                    List<string> lstDistNopLampiran = null;
                    if (col.Contains("NOP_LAMPIRAN"))
                    {
                        lstDistNopLampiran = dtLampiran.AsEnumerable().Select(r => r.Field<string>("NOP_LAMPIRAN")).Distinct().ToList();
                        isFromDatabase = true;
                        dtLampiran.Columns["NOP"].ColumnName = "NOP_ALIAS";
                        dtLampiran.Columns["NOP_LAMPIRAN"].ColumnName = "NOP";
                    }
                    else
                        lstDistNopLampiran = dtLampiran.AsEnumerable().Select(r => r.Field<string>("NOP").Trim()).Distinct().ToList();

                    if (lstDistNopLampiran == null || lstDistNopLampiran.Count <= 0)
                    {
                        log.Info("List Nop tidak ditemukan ............");
                        return Response.AsJson(new { code = HttpStatusCode.NotFound, message = $"Error, List Nop tidak ditemukan." });
                    }


                    List<string> lstNopBlokir = new List<string>();
                    foreach (var itemNopLampiran in lstDistNopLampiran)
                    {
                        nop = itemNopLampiran;
                        string queryPajak = string.Empty;

                        //Validate Query
                        if (isFromDatabase)
                        {
                            List<BusinessLogic.queryData> queryLst = _userSettingColumnBusiness.RetrieveQueryPajak(username, nop);
                            if (queryLst != null && queryLst.Count > 0)
                            {
                                bool isQueryValid = true;
                                string queryPajakFromXml = Regex.Replace(jsonData.items.lstQuery.FirstOrDefault().queryPajak, @"\s+", string.Empty);
                                string queryPajakFromDB = Regex.Replace(queryLst.FirstOrDefault().queryPajak, @"\s+", string.Empty);
                                queryPajak = jsonData.items.lstQuery.FirstOrDefault().queryPajak;
                                string queryLampiranFromXml = Regex.Replace(jsonData.items.lstQuery.FirstOrDefault().queryLampiran, @"\s+", string.Empty);
                                string queryLampiranFromDB = Regex.Replace(queryLst.FirstOrDefault().queryLampiran, @"\s+", string.Empty);

                                if (!string.Equals(queryPajakFromDB, queryPajakFromXml, StringComparison.OrdinalIgnoreCase))
                                {
                                    isQueryValid = false;
                                }

                                if (!string.Equals(queryLampiranFromXml, queryLampiranFromDB, StringComparison.OrdinalIgnoreCase))
                                {
                                    isQueryValid = false;
                                }

                                if (!isQueryValid)
                                {
                                    //insert tanggal_error into user_temp_error
                                    DateTime dtmlastTime = dtTransaksi.AsEnumerable().Select(x => x.Field<DateTime>("TGL_TRANSAKSI")).FirstOrDefault();
                                    _userActivityBusiness.InsertUserActivity(username, ip, DateTime.Now, true, "Query tidak sesuai");
                                    log.Info("Query tidak sesuai, mohon periksa kembali. ............");
                                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, Query tidak sesuai, mohon periksa kembali." });
                                }
                            }
                            else
                            {
                                log.Info("Query pada username dan nop tersebut tidak ditemukan ............");
                                return Response.AsJson(new { code = HttpStatusCode.NotFound, message = $"Error, Query pada username dan nop tersebut tidak ditemukan." });
                            }
                        }

                        List<Transaction> lstTransaksi = new List<Transaction>();
                        //Get nama kolom tanggal transaksi 
                        List<UserSettingColumn> lstKolomName = new List<UserSettingColumn>();
                        string namaKolomTanggal = string.Empty;
                        if (!isFromDatabase)
                        {
                            lstKolomName = _userSettingColumnBusiness.RetrieveColumnByUserNop(username, nop);
                        }
                        else
                        {
                            DataColumnCollection colTrans = dtTransaksi.Columns;
                            foreach (var itemKolom in colTrans)
                            {
                                UserSettingColumn userKolom = new UserSettingColumn();
                                userKolom.Username = username;
                                userKolom.Nop = nop;
                                userKolom.Column_Name = itemKolom.ToString();
                                userKolom.Column_Text = itemKolom.ToString();
                                lstKolomName.Add(userKolom);
                            }
                        }

                        namaKolomTanggal = lstKolomName.Where(m => m.Column_Name.ToUpper().Contains("TGL_TRANSAKSI")).Select(m => m.Column_Text.ToUpper()).FirstOrDefault();

                        List<string> namaKolomNilai = lstKolomName.Where(m => m.Column_Name.ToUpper().Contains("PAJAK")).Select(m => m.Column_Text.ToUpper()).ToList();
                        DataView dvTrans = dtTransaksi.DefaultView;
                        dvTrans.RowFilter = "NOP=" + nop;
                        dvTrans.Sort = namaKolomTanggal;
                        DataTable dtSortTransaction = dvTrans.ToTable();
                        DateTime tglOld = new DateTime();
                        double nilaiOld = 0;

                        bool isNopBlokir = false;
                        DataRow last = dtSortTransaction.Rows[dtSortTransaction.Rows.Count - 1];
                        string oldNop = string.Empty;
                        int oldMP = 0;
                        int oldThn = 0;
                        bool isOnDetail = false;

                        foreach (DataRow dRow in dtSortTransaction.Rows)
                        {
                            DateTime tanggal = dRow[namaKolomTanggal].AsDateTime();
                            int mp = tanggal.Month;
                            int thn = tanggal.Year;
                            //check sptpd is generate
                            if (string.Compare(oldNop, dRow["NOP"].ToString()) != 0)
                            {
                                if (oldMP != mp)
                                {
                                    if (oldThn != thn)
                                        isOnDetail = _sPTPDDetailBusiness.isSptpdDetailByNop(dRow["NOP"].ToString(), mp, thn);
                                }
                                oldNop = dRow["NOP"].ToString();
                                oldMP = mp;
                                oldThn = thn;
                            }
                            else
                            {
                                oldNop = dRow["NOP"].ToString();
                                oldMP = mp;
                                oldThn = thn;
                            }


                            if (isOnDetail)
                            {
                                lstNopBlokir.Add(dRow["NOP"].ToString());
                                isNopBlokir = true;
                                break;
                            }

                            double nilaiPajak = 0;

                            try
                            {
                                for (int iNilai = 0; iNilai < namaKolomNilai.Count; iNilai++)
                                {
                                    if (string.Compare(namaKolomNilai[iNilai].ToString(), "-") != 0)
                                        nilaiPajak += dRow[namaKolomNilai[iNilai]].AsDouble();
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            if (tglOld.Year == 1)
                            {
                                tglOld = tanggal;
                                nilaiOld = nilaiPajak;
                                if (dRow == last)
                                {
                                    Transaction itemTrans = new Transaction();
                                    itemTrans = new Transaction();
                                    itemTrans.tanggal = tglOld;
                                    itemTrans.total = nilaiOld;
                                    lstTransaksi.Add(itemTrans);
                                    break;
                                }
                            }
                            else
                            {
                                if (tglOld.Date == tanggal.Date)
                                {
                                    if (dRow == last)
                                    {
                                        nilaiOld += nilaiPajak;
                                        Transaction itemTrans = new Transaction();
                                        itemTrans = new Transaction();
                                        itemTrans.tanggal = tglOld;
                                        itemTrans.total = nilaiOld;
                                        lstTransaksi.Add(itemTrans);
                                        break;
                                    }

                                    nilaiOld += nilaiPajak;
                                }
                                else
                                {
                                    Transaction itemTrans = new Transaction();
                                    itemTrans.tanggal = tglOld;
                                    itemTrans.total = nilaiOld;
                                    lstTransaksi.Add(itemTrans);

                                    tglOld = tanggal.Date;
                                    nilaiOld = nilaiPajak;

                                    if (dRow == last)
                                    {
                                        itemTrans = new Transaction();
                                        itemTrans.tanggal = tglOld;
                                        itemTrans.total = nilaiOld;
                                        lstTransaksi.Add(itemTrans);
                                    }
                                }
                            }
                        }

                        if (isNopBlokir)
                            continue;

                        log.Info("inserting data to user transaction");
                        //cek transaction isExist
                        IEnumerable<UserTransaction> lstTransExist = new List<UserTransaction>();
                        lstTransExist = _userTransactionBusiness.RetrieveUserTransactionByMonth(username, lstTransaksi.FirstOrDefault().tanggal.Month, lstTransaksi.FirstOrDefault().tanggal.Year);

                        //insert into user_transaction
                        foreach (var item in lstTransaksi)
                        {
                            bool isExist = lstTransExist.Where(m => string.Compare(m.Tanggal.ToString("dd-MM-yyyy"), item.tanggal.ToString("dd-MM-yyyy")) == 0 &&
                            m.Nop.Equals(nop)).ToList().Count > 0;
                            try
                            {
                                if (isExist)
                                {
                                    log.Info("update data from user " + username);
                                    _userTransactionBusiness.UpdatePajakUserTransaction(username, nop, item.tanggal, item.total);
                                }
                                else
                                {
                                    log.Info("insert data from user " + username);
                                    _userTransactionBusiness.InsertUserTransaction(username, item.tanggal, item.total, ip, string.Empty, false, nop);
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Info("insert or update error : " + ex.Message);
                            }
                        }

                        log.Info("inserting data to user transaction detail");
                        //insert into user_transaction_detail
                        string dir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "transaction.xml");

                        //Replace nama kolom untuk no_invoice dan tgl_transaksi
                        if (!isFromDatabase)
                        {
                            List<UserSettingColumn> lstSetCol = _settingClientBusiness.RetrieveUserSettingColumn(username, nop);
                            string noInvoice = lstSetCol.Where(x => x.Column_Name.ToUpper().Equals("NO_INVOICE")).Select(x => x.Column_Text.ToUpper()).FirstOrDefault();
                            string tglTransaksi = lstSetCol.Where(x => x.Column_Name.ToUpper().Equals("TGL_TRANSAKSI")).Select(x => x.Column_Text.ToUpper()).FirstOrDefault();

                            dtLampiran.Columns[noInvoice].ColumnName = "NO_INVOICE";
                            dtLampiran.Columns[tglTransaksi].ColumnName = "TGL_TRANSAKSI";
                        }


                        string colTglName = "TGL_TRANSAKSI";

                        //Pecah dan simpan sesuai tanggal transaksi
                        #region Old Code
                        //string[] arrSelect = queryPajak.ToUpper().Split(new string[] { "FROM" }, StringSplitOptions.None);
                        //string[] arrSplit = arrSelect[0].Split(',');
                        //string dbColDateName = string.Empty;
                        //if (isFromDatabase)
                        //{
                        //    foreach (string item in arrSplit)
                        //    {
                        //        if (item.Contains("TGL_TRANSAKSI"))
                        //        {
                        //            dbColDateName = item;
                        //            break;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    dbColDateName = namaKolomTanggal;
                        //}


                        //string[] arrTglName = dbColDateName.Replace("SELECT ", string.Empty).Split(' ');
                        //string colTglName = string.Empty;
                        //if (arrTglName.Count() > 1)
                        //    colTglName = arrTglName[arrTglName.Count() - 2];
                        //else
                        //    colTglName = arrTglName[0];

                        //if (string.IsNullOrEmpty(colTglName))
                        //{
                        //    if (string.IsNullOrEmpty(queryPajak))
                        //        colTglName = "TGL_TRANSAKSI";
                        //}
                        #endregion

                        //DataView dvTrans = new DataView(dtLampiran);
                        //dvTrans.RowFilter = $"NOP={nop}";
                        //DataTable dtDistDate = dvTrans.ToTable(true, colTglName);                        

                        DataTable dtTransByNop = dtLampiran.AsEnumerable().Where(m => m.Field<string>("NOP").Equals(nop)).CopyToDataTable();
                        DataTable dtDistDate = new DataTable();
                        dtDistDate.Columns.Add(colTglName, typeof(DateTime));

                        if (dtTransByNop.Columns[colTglName].DataType != typeof(DateTime))
                        {
                            DataTable copyTransTable = dtTransByNop.Clone();
                            copyTransTable.Columns[colTglName].DataType = typeof(DateTime);

                            foreach (DataRow item in dtTransByNop.Rows)
                            {
                                DataRow nRowTransTable = copyTransTable.NewRow();
                                nRowTransTable.ItemArray = item.ItemArray;
                                copyTransTable.Rows.Add(nRowTransTable);
                            }

                            dtTransByNop = copyTransTable;
                        }

                        DateTime oldDate = DateTime.MinValue;
                        foreach (DataRow item in dtTransByNop.Rows)
                        {
                            //if (Convert.ToInt32(item["NO"]) == 1168)
                            //{

                            //}


                            DateTime newDate = Convert.ToDateTime(item["TGL_TRANSAKSI"]).Date;
                            if (string.Compare(oldDate.ToString("dd-MM-yyyy"), newDate.ToString("dd-MM-yyyy")) != 0)
                            {
                                DataRow newRow = dtDistDate.NewRow();
                                newRow[colTglName] = newDate;
                                dtDistDate.Rows.Add(newRow);
                                oldDate = newDate;
                            }
                        }

                        foreach (DataRow dRow in dtDistDate.Rows)
                        {
                            DataSet ds = new DataSet();
                            DateTime tglTrans = DateTime.MinValue;
                            try
                            {
                                tglTrans = Convert.ToDateTime(dRow[colTglName], new CultureInfo(CultureInfos));
                            }
                            catch (Exception ex)
                            {
                                log.Info("Date format error......" + ex.Message);
                            }


                            DataView vw = dtTransByNop.AsDataView();

                            string startDate = tglTrans.ToString("MM/dd/yyyy 00:00:00", new CultureInfo("en-US"));
                            string endDate = tglTrans.ToString("MM/dd/yyyy 23:59:59", new CultureInfo("en-US"));

                            string filter = string.Format(colTglName + " >= #{0}# AND " + colTglName + "<=#{1}#",
                               startDate, endDate);
                            vw.RowFilter = filter;

                            ds.Tables.Add(vw.ToTable());
                            ds.WriteXml(dir);

                            string xmlString = System.IO.File.ReadAllText(dir);
                            string nopDetail = string.Empty;
                            //Cek username, nop, bulan and tahun is exist
                            bool isDetailExist = false;
                            try
                            {
                                //todo delete 1 row below List<UserTransactionDetail> lstDetail = UserTransactionDetailBusiness.RetrieveUserDetailTransactionByDateTransaction(nop, tglTrans).ToList();
                                List<UserTransactionDetail> lstDetail = null;
                                if (lstDetail != null && lstDetail.Count > 0)
                                    isDetailExist = true;

                                //Delete if username, nop, bulan and tahun is exist
                                if (isDetailExist)
                                    _userTransactionDetailBusiness.DeleteUserDetailTransaction(nop, tglTrans);

                                // insert Trasaction Detail
                                _userTransactionDetailBusiness.InsertUserTransactionDetail(username, dir, bulan.AsInt32(), tahun.AsInt32(), tglTrans, ip, xmlString, nop);
                            }
                            catch (Exception ex)
                            {
                                return Response.AsJson(new { code = HttpStatusCode.MethodNotAllowed, message = "Insert trasanction detail gagal, " + ex.Message });
                            }
                        }
                    }

                    log.Info("End : /dev/postTransactionClient");
                    if (lstNopBlokir != null && lstNopBlokir.Count > 0)
                    {
                        string nopBlokir = string.Empty;
                        foreach (var itemBlokir in lstNopBlokir)
                        {
                            nopBlokir += itemBlokir + ",";
                        }

                        nopBlokir = nopBlokir.Remove(nopBlokir.Length - 1);

                        return Response.AsJson(new { code = HttpStatusCode.MethodNotAllowed, message = "nop (" + nopBlokir + ") pada masapajak tersebut, sudah tergenerate." });
                    }
                    else
                    {
                        try
                        {
                            var connection = SignalR.Utilities.ConnectionMap.GetConnectionMap(username);
                            if (connection.Value.IsRequesting)
                            {
                                connection.Value.IsRequesting = false;
                            }
                        }
                        catch
                        {
                        }


                        return Response.AsJson(new { code = HttpStatusCode.OK, message = "Transaksi berhasil tersimpan" });
                    }
                }
                catch (System.Exception ex)
                {
                    log.Fatal("Error: /dev/postTransactionClient", ex);
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                    //throw;
                }
            };

            Post["/dev/postUserActivity"] = parameter =>
            {
                try
                {
                    log.Info("Start : /dev/postUserActivity");
                    string ip = this.Request.UserHostAddress;
                    log.Info($"incoming request from IP:{ip}");
                    string body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();

                    log.Info("Deserializing Object ............");
                    UserActivity userActivity = JsonConvert.DeserializeObject<UserActivity>(body);
                    DateTime dateNow = DateTime.Now;


                    DateTime tglClient = DateTime.MinValue;
                    try
                    {
                        tglClient = Convert.ToDateTime(userActivity.ActivityDate, new CultureInfo(userActivity.CultureInfos));
                    }
                    catch (Exception ex)
                    {
                        log.Info("Date format error......" + ex.Message);
                    }

                    tglClient = Convert.ToDateTime(tglClient, new CultureInfo("en-US"));


                    if (userActivity != null)
                    {
                        log.Info("Inserting user activity ............");
                        bool status = false;
                        if (string.Compare(userActivity.StatusError, "1") == 0)
                        {
                            status = true;
                        }

                        try
                        {
                            string ipClient = userActivity.IPClient;
                            if (string.IsNullOrEmpty(userActivity.IPClient))
                                ipClient = ip;

                            _userActivityBusiness.InsertUserActivity(userActivity.Username, ipClient, dateNow, status, userActivity.Keterangan);
                            var jsonBody = JsonConvert.SerializeObject(dateNow, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" });

                            log.Info("End : /dev/postUserActivity");
                            return Response.AsJson(new { code = HttpStatusCode.OK, message = "User Activity Berhasil tersimpan.", body = jsonBody });
                        }
                        catch (Exception ex)
                        {
                            log.Fatal("Error : /dev/postUserActivity", ex);
                            return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                        }
                    }
                    else
                    {
                        log.Info("End : /dev/postUserActivity");
                        return Response.AsJson(new { code = HttpStatusCode.Unauthorized, message = "Failed while deserializing object, data not found", body = string.Empty });
                    }
                }
                catch (Exception ex)
                {
                    log.Fatal("Error : /dev/postUserActivity", ex);
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                }
            };

            Post["/dev/RetrieveCpuId"] = Parameter =>
            {
                try
                {
                    log.Info("Start : /dev/RetrieveCpuId");
                    string username = string.Empty;
                    string cpuId = string.Empty;
                    string body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();

                    log.Info("Deserializing Object ............");
                    string[] arrStr = body.Split(',');

                    if (arrStr.Count() > 0)
                    {
                        for (int iArr = 0; iArr < arrStr.Count(); iArr++)
                        {
                            username += "'" + arrStr[iArr] + "',";
                        }

                        username = username.Remove(username.Length - 1);
                    }

                    List<UserClient> lstUsr = _settingClientBusiness.RetrieveUserClient(username);
                    if (lstUsr != null && lstUsr.Count > 0)
                        cpuId = lstUsr.FirstOrDefault().Id_Machine;

                    log.Info("End : /dev/RetrieveCpuId");
                    return Response.AsJson(new { code = HttpStatusCode.OK, message = "OK", cpuId = cpuId });
                }
                catch (Exception ex)
                {
                    log.Info("End : /dev/RetrieveCpuId");
                    return Response.AsJson(new { code = HttpStatusCode.FailedDependency, message = ex.Message, cpuId = "" });
                }
            };

            Post["/dev/RetrieveJatuhTempo"] = parameter =>
            {
                try
                {
                    log.Info("Start : /dev/RetrieveJatuhTempo");
                    string ip = this.Request.UserHostAddress;
                    log.Info($"incoming request from IP:{ip}");
                    string body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();

                    log.Info("Deserializing Object ............");
                    RequestDueDate dueDate = JsonConvert.DeserializeObject<RequestDueDate>(body);

                    string tanggal = string.Empty;
                    if (dueDate != null)
                    {
                        JatuhTempo jthTempo = _jatuhTempoBusiness.RetrieveJatuhTempo(dueDate.masapajak.AsInt32(), dueDate.tahunpajak.AsInt32());
                        if (jthTempo != null)
                        {
                            tanggal = jthTempo.Tgl_Jatuh_Tempo.ToString("dd/MM/yyyy");

                            log.Info("End : /dev/RetrieveJatuhTempo");
                            return Response.AsJson(new { code = HttpStatusCode.OK, tanggal = tanggal });
                        }
                        else
                        {
                            log.Info("End : /dev/RetrieveJatuhTempo");
                            return Response.AsJson(new { code = HttpStatusCode.ExpectationFailed });
                        }
                    }
                    else
                    {
                        log.Info("End : /dev/RetrieveJatuhTempo");
                        return Response.AsJson(new { code = HttpStatusCode.Unauthorized, message = "Failed while deserializing object, data not found", body = string.Empty });
                    }
                }
                catch (Exception ex)
                {
                    log.Fatal("Error : /dev/RetrieveJatuhTempo", ex);
                    return Response.AsJson(new { code = HttpStatusCode.InternalServerError, message = $"Error, {ex.Message}" });
                }
            };
        }

        class RequestDueDate
        {
            public string masapajak { get; set; }
            public string tahunpajak { get; set; }
            public string username { get; set; }
        }

        class ResponseDueDate
        {
            public string tanggal { get; set; }
        }

        class JsonSetting
        {
            public IEnumerable<User> list_user { get; set; }
            public IEnumerable<Nop> list_nop { get; set; }
            public IEnumerable<DBColSetting> settings { get; set; }
            public string xml_content { get; set; }
            public string jenFile { get; set; }
            public string separator { get; set; }
        }

        class Nop
        {
            public string nop { get; set; }
            public string jenisPajak { get; set; }
        }

        class DBColSetting
        {
            public string nop { get; set; }
            public string column_name { get; set; }
            public string column_text { get; set; }
        }

        class User
        {
            public string userName { get; set; }
            public string idMachine { get; set; }
            public string guid { get; set; }
            public string phone { get; set; }
            public string mail { get; set; }
            public int port { get; set; }
        }

        class UserActivity
        {
            public string Username { get; set; }
            public string ActivityDate { get; set; }
            public string StatusError { get; set; }
            public string Keterangan { get; set; }
            public string IPClient { get; set; }
            public string CultureInfos { get; set; }
        }

        class JsonData
        {
            public IEnumerable<DataUser> datauser { get; set; }
            public IEnumerable<MasaPajak> masapajak { get; set; }
            public TbItem items { get; set; }
        }

        class TbItem
        {
            public DataTable dtPajak { get; set; }
            public DataTable dtLampiran { get; set; }
            public string CultureInfos { get; set; }
            public List<queryData> lstQuery { get; set; }
        }

        class queryData
        {
            public string nop { get; set; }
            public string queryPajak { get; set; }
            public string queryLampiran { get; set; }
        }

        class DataUser
        {
            public string username { get; set; }
            public string key { get; set; }
        }

        class MasaPajak
        {
            public string bulan { get; set; }
            public string tahun { get; set; }
        }

        class Transaction
        {
            public DateTime tanggal { get; set; }
            public double total { get; set; }
        }

        class Today
        {
            public DateTime DateNow { get; set; }
        }

        class LastErrorRequest
        {
            public string username { get; set; }
        }

        class LastErrorResponse
        {
            public DateTime TanggalError { get; set; }
        }
    }
}
