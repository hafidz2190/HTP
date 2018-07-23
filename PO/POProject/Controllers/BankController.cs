using POAdministrationTools;
using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using POProject.MVC.Flan.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace POWebClient.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        [CustomAuthorize(Roles = "BANK")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDataPembayaranBank(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                string webusername = string.Empty;
                if (!string.IsNullOrEmpty(Session["WebUsername"].ToString()))
                {
                    webusername = Session["WebUsername"].ToString();
                }

                List<DataBayarBank> result = null;
                if (!string.IsNullOrEmpty(webusername))
                {
                    string kdBank = BankBusiness.RetrieveDataBank(string.Empty).Where(m => m.Username == webusername).FirstOrDefault().Kode_Bank;
                    Session["KodeBank"] = kdBank;
                    result = BankBusiness.RetrieveDataPembayaranByKdBankUser(kdBank).ToList();
                    result = result.Skip(jtStartIndex).Take(jtPageSize).ToList();
                }

                return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count() });
            }
            catch (Exception ex)
            {
                return Json(new { Result = $"Error, {ex.Message}" });
            }
        }

        public FileContentResult ExportDetailToPdf()
        {
            string kdBank = Session["KodeBank"].ToString();
            var listBayar = BankBusiness.RetrieveDataPembayaranByKdBankUser(kdBank);

            DataTable dtDataBayar = new DataTable();
            dtDataBayar.Columns.Add("Username");
            dtDataBayar.Columns.Add("ID_SPTPD");
            dtDataBayar.Columns.Add("Nama");
            dtDataBayar.Columns.Add("Masa_Pajak");
            dtDataBayar.Columns.Add("Tahun");
            dtDataBayar.Columns.Add("Total_Pembayaran");

            DataRow dr = dtDataBayar.NewRow();
            foreach (var item in listBayar)
            {
                dr["Username"] = item.Username;
                dr["ID_SPTPD"] = item.Id_Sptpd;
                dr["Nama"] = item.NamaOp;
                dr["Masa_Pajak"] = item.MasaPajak;
                dr["Tahun"] = item.Tahun;
                dr["Total_Pembayaran"] = item.StrTotal;
            }

            dtDataBayar.Rows.Add(dr);
            List<string> columnToTake = new List<string>();
            string path = Request.MapPath("~/Content/images/pemkot.png");
            byte[] filecontent = ExportPdfHelper.ExportPdf(dtDataBayar, path, "Data Pajak Terutang");
            return File(filecontent, "application/pdf", "Detail Pembayaran.pdf");
        }
    }
}