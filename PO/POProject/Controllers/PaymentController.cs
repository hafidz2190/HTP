using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using POProject.MVC.Flan.Attributes;
using POWebClient.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POWebClient.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        [CustomAuthorize(Roles = "USER")]
        public ActionResult GeneratePayment()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDateUserPayment(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                string webusername = string.Empty;
                if (!string.IsNullOrEmpty(Session["webusername"].ToString()))
                {
                    webusername = Session["webusername"].ToString();
                }

                List<UserClient> lstUser = SettingClientBusiness.RetrieveUserClientByWebUsername(webusername);
                string username = string.Empty;
                foreach (var item in lstUser)
                {
                    username += "'" + item.Username + "',";
                }
                username = username.Remove(username.Length - 1);

                DateTime LastMonth = DateTime.Now.AddMonths(-1);
                JatuhTempo jt = JatuhTempoBusiness.RetrieveAllowMasaPajak().First();
                var result = UserTransactionBusiness.RetrieveDataPayment(username, null, null).ToList();
                result = result.Where(m => m.Is_Generate != 1).ToList();
                result = result.Where(m => (m.MasaPajak.AsInt32() >= jt.Bulan && m.Tahun.AsInt32() >= jt.Tahun) ||
                                           (m.MasaPajak.AsInt32() == LastMonth.Month && m.Tahun.AsInt32() == LastMonth.Year)).ToList();

                //Sorting column
                string[] arrSorting = string.IsNullOrEmpty(jtSorting) ? null : jtSorting.Split(' ');
                if (arrSorting != null)
                {
                    if (string.Compare(arrSorting[1], "ASC") == 0)
                    {
                        switch (arrSorting[0])
                        {
                            case "Nop":
                                result = result.OrderBy(m => m.Nop).ToList();
                                break;
                            case "Username":
                                result = result.OrderBy(m => m.Username).ToList();
                                break;
                            case "MasaPajak":
                                result = result.OrderBy(m => m.MasaPajak).ToList();
                                break;
                            case "Tahun":
                                result = result.OrderBy(m => m.Tahun).ToList();
                                break;
                            case "Pajak":
                                result = result.OrderBy(m => m.Pajak).ToList();
                                break;
                            case "StrNominal":
                                result = result.OrderBy(m => m.StrNominal).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (arrSorting[0])
                        {
                            case "Nop":
                                result = result.OrderByDescending(m => m.Nop).ToList();
                                break;
                            case "Username":
                                result = result.OrderByDescending(m => m.Username).ToList();
                                break;
                            case "MasaPajak":
                                result = result.OrderByDescending(m => m.MasaPajak).ToList();
                                break;
                            case "Tahun":
                                result = result.OrderByDescending(m => m.Tahun).ToList();
                                break;
                            case "Pajak":
                                result = result.OrderByDescending(m => m.Pajak).ToList();
                                break;
                            case "StrNominal":
                                result = result.OrderByDescending(m => m.StrNominal).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                }


                result = result.Skip(jtStartIndex).Take(jtPageSize).ToList();
                return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count() });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult SaveGeneratePayment(string nop, string masapajak, string tahun, string pajak, string totalpajak)
        {
            bool isSuccess = false;
            string message = string.Empty;
            bool isAllowGenerate = false;
            string redirect = string.Empty;
            try
            {
                //Checking jatuh tempo pembayaran
                JatuhTempo jt = JatuhTempoBusiness.RetrieveJatuhTempo(masapajak.AsInt32(), tahun.AsInt32());
                if (DateTime.Now <= jt.Tgl_Jatuh_Tempo)
                {
                    string username = string.Empty;
                    if (!string.IsNullOrEmpty(Session["webusername"].ToString()))
                    {
                        username = Session["webusername"].ToString();
                    }

                    //check is active pembayaran
                    var sptpd = SPTPDBusiness.RetrieveDataSptpd(username, masapajak.AsInt32(), tahun.AsInt32(), true).FirstOrDefault();
                    if (sptpd != null)
                    {
                        var sptpdDetail = SPTPDDetailBusiness.RetrieveDetailSptpd(sptpd.ID_SPTPD, username).FirstOrDefault();
                        if (sptpdDetail != null)
                        {
                            isSuccess = false;
                            message = $"Pembayaran masih aktif dengan ID SPTPD = {sptpdDetail.ID_SPTPD}";
                        }
                        else
                        {
                            isAllowGenerate = true;
                        }
                    }
                    else
                    {
                        isAllowGenerate = true;
                    }

                    if (isAllowGenerate)
                    {
                        string[] arrNop = nop.Remove(0, 1).Split(',');
                        string[] arrPajak = pajak.Remove(0, 1).Split(',');
                        string resultNop = string.Empty;
                        for (int i = 0; i < arrNop.Length; i++)
                        {
                            resultNop += "'" + arrNop[i] + "',";
                        }
                        resultNop = resultNop.Remove(resultNop.Length - 1);
                        List<VwGeneratePayment> listPayment = UserTransactionBusiness.RetrieveDataPayment(username, resultNop, masapajak.AsInt32(), tahun.AsInt32()).ToList();
                        List<RequestEntity> listRequest = new List<RequestEntity>();
                        foreach (var itemPayment in listPayment)
                        {
                            RequestEntity entity = new RequestEntity();
                            entity.nop = itemPayment.Nop;
                            entity.tanggal = itemPayment.Tanggal;
                            entity.username = username;
                            entity.pajak_terutang = itemPayment.Pajak_Terutang;
                            listRequest.Add(entity);
                        }

                        JsonData jsonData = new JsonData();
                        jsonData.lstTransaksi = listRequest;

                        string RequestUrl = UserApiUrlBusiness.RetrieveApiUrl();
                        RequestUrl = $"{RequestUrl}/GenerateSptpd";
                        var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(RequestUrl);
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";

                        //send request
                        string jsonSent = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);
                        using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            streamWriter.Write(jsonSent);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }

                        var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                        {
                            var resultResponse = streamReader.ReadToEnd();
                            ResultResponse result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultResponse>(resultResponse);
                            if (string.Compare(result.code, ((int)AccountController.Code.Success).ToString("D2")) == 0)
                            {
                                string idSptpd = result.idSptpd;
                                string idBayar = Guid.NewGuid().ToString();
                                double sanksi = 0;
                                double totalpembayaran = totalpajak.AsDouble() + sanksi;

                                SPTPDBusiness.InsertSptpd(idSptpd, username, masapajak.AsInt32(), tahun.AsInt32(), totalpajak.AsDouble(), sanksi, totalpembayaran, idBayar);
                                for (int i = 0; i < arrNop.Length; i++)
                                {
                                    SPTPDDetailBusiness.InsertDetailSptpd(idSptpd, arrNop[i], username, masapajak.AsInt32(), tahun.AsInt32(), arrPajak[i].AsDouble());
                                }

                                foreach (var itemTransaksi in listPayment)
                                {
                                    SPTPDDetailBusiness.UpdateIsGenerate(itemTransaksi.Nop, itemTransaksi.Tanggal);
                                }
                                message = "Sukses, Generate Pembayaran berhasil";
                                isSuccess = true;
                                redirect = $"/Payment/DetailSptpd?idsptpd={idSptpd}";

                            }
                            else
                            {
                                message = $"Generate pembayaran gagal, {result.message}";
                                isSuccess = false;
                            }
                        }
                    }
                }
                else
                {
                    message = $"Pembayaran melebihi jatuh tempo tanggal {jt.Tgl_Jatuh_Tempo.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)}.";
                    isSuccess = false;
                }
                return Json(new { result = "OK", message = message, isSuccess = isSuccess, redirect = redirect });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = "Error",
                    message = $"Error, {ex.Message}",
                    isSuccess = isSuccess
                });
            }
        }

        [CustomAuthorize(Roles = "USER")]
        public ActionResult DetailSptpd(DetailSptpdViewModels model)
        {
            try
            {
                string querystring = Request.QueryString["idsptpd"].ToString();
                if (!string.IsNullOrEmpty(querystring))
                {
                    model.IdSptpd = querystring;
                }
                else
                {
                    return RedirectToAction("NotFoundPage", "Home");
                }

                SPTPD sptpd = SPTPDBusiness.RetrieveDataSptpdById(model.IdSptpd).FirstOrDefault();
                string webusername = string.Empty;
                if (Session["webusername"] == null)
                {
                    return RedirectToAction("NotFoundPage", "Home");
                }
                else
                {
                    webusername = Session["webusername"].ToString();
                }

                if (string.Compare(sptpd.Username, Session["webusername"].ToString()) == 0)
                {
                    model.ListDetail = SPTPDDetailBusiness.RetrieveDetailSptpd(sptpd.ID_SPTPD, sptpd.Username).ToList();
                    model.TotalPembayaran = sptpd.Total.AsCurrencyRp();
                    return View(model);
                }
                else
                {
                    return RedirectToAction("NotFoundPage", "Home");
                }

            }
            catch
            {
                return RedirectToAction("NotFoundPage", "Home");
            }

        }

        #region Nested Class
        class JsonData
        {
            public List<RequestEntity> lstTransaksi { get; set; }
        }

        class RequestEntity
        {
            public string username { get; set; }
            public string nop { get; set; }
            public DateTime tanggal { get; set; }
            public double pajak_terutang { get; set; }
        }

        class ResultResponse
        {
            public string code { get; set; }
            public string message { get; set; }
            public string idSptpd { get; set; }
        }
        #endregion
    }
}