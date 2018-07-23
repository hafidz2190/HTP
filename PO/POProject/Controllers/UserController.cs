using CaptchaMvc.Attributes;
using POAdministrationTools;
using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using POProject.MVC.Flan.Attributes;
using POWebClient.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace POWebClient.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        #region Profile
        [CustomAuthorize(Roles = "USER")]
        public ActionResult ProfileUser()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetProfileUser(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                string webUsern = string.Empty;
                if (!string.IsNullOrEmpty(Session["WebUsername"].ToString()))
                {
                    webUsern = Session["WebUsername"].ToString();
                }
                List<UserProfile> result = SettingClientBusiness.RetrieveUserProfile(webUsern).ToList();

                string[] arrSorting = string.IsNullOrEmpty(jtSorting) ? null : jtSorting.Split(' ');
                if (arrSorting != null)
                {
                    if (string.Compare(arrSorting[1], "ASC") == 0)
                    {
                        switch (arrSorting[0])
                        {
                            case "Username":
                                result = result.OrderBy(m => m.Username).ToList();
                                break;
                            case "Phone":
                                result = result.OrderBy(m => m.Phone).ToList();
                                break;
                            case "Email":
                                result = result.OrderBy(m => m.Email).ToList();
                                break;
                            case "Nama_Bank":
                                result = result.OrderBy(m => m.Nama_Bank).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (arrSorting[0])
                        {
                            case "Username":
                                result = result.OrderByDescending(m => m.Username).ToList();
                                break;
                            case "Phone":
                                result = result.OrderByDescending(m => m.Phone).ToList();
                                break;
                            case "Email":
                                result = result.OrderByDescending(m => m.Email).ToList();
                                break;
                            case "Nama_Bank":
                                result = result.OrderByDescending(m => m.Nama_Bank).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (result.Count > 0)
                {
                    result = result.Skip(jtStartIndex).Take(jtPageSize).ToList();
                }
                return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", message = ex.Message }); ;
            }
        }

        [HttpPost]
        public JsonResult UpdateProfile(UserProfile profile)
        {
            try
            {
                SettingClientBusiness.UpdateUserClient(profile.Email, profile.Phone, profile.Kode_Bank, profile.Username);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion

        #region Information

        [CustomAuthorize(Roles = "USER")]
        public ActionResult Information()
        {
            if (Session["WebUsername"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public JsonResult FindNopUserApp()
        {
            try
            {
                List<PureNop> ListNop = new List<PureNop>();
                ListNop = SettingClientBusiness.RetrieveMultiNopByUsername(Session["WebUsername"].ToString()).ToList();
                return Json(new { resultDetail = ListNop });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult TransactionList(string nop, string month, string year, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                if (string.IsNullOrEmpty(nop))
                {
                    nop = string.Empty;
                }
                if (string.IsNullOrEmpty(month))
                {
                    month = DateTime.Now.Month.ToString();
                }
                if (string.IsNullOrEmpty(year))
                {
                    year = DateTime.Now.Year.ToString();
                }
                string username = string.Empty;
                if (Session["Username"] != null)
                {
                    username = Session["Username"].ToString();
                    POProject.Membership.Entity.MembershipRole role = Session["MembershipRole"] as POProject.Membership.Entity.MembershipRole;
                    if (string.Compare(role.Id_Role, "2") != 0)
                    {
                        username = string.Empty;
                    }
                }

                List<UserTransaction> result = new List<UserTransaction>();
                if (string.IsNullOrEmpty(nop))
                    result = UserTransactionBusiness.RetrieveUserInformationTransactionByMonth(username, nop, month.AsInt32(), year.AsInt32()).ToList();
                else
                    result = UserTransactionBusiness.RetrieveUserInformationTransactionByMonth(string.Empty, nop, month.AsInt32(), year.AsInt32()).ToList();

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
                            case "strPajak_Terutang":
                                result = result.OrderBy(m => m.strPajak_Terutang).ToList();
                                break;
                            case "StrTanggal":
                                result = result.OrderBy(m => m.StrTanggal).ToList();
                                break;
                            case "Is_Adjusment":
                                result = result.OrderBy(m => m.Is_Adjusment).ToList();
                                break;
                            case "Ip_Sender":
                                result = result.OrderBy(m => m.Ip_Sender).ToList();
                                break;
                            case "Keterangan":
                                result = result.OrderBy(m => m.Keterangan).ToList();
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
                            case "strPajak_Terutang":
                                result = result.OrderByDescending(m => m.strPajak_Terutang).ToList();
                                break;
                            case "StrTanggal":
                                result = result.OrderByDescending(m => m.StrTanggal).ToList();
                                break;
                            case "Is_Adjusment":
                                result = result.OrderByDescending(m => m.Is_Adjusment).ToList();
                                break;
                            case "Ip_Sender":
                                result = result.OrderByDescending(m => m.Ip_Sender).ToList();
                                break;
                            case "Keterangan":
                                result = result.OrderByDescending(m => m.Keterangan).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (result.Count > 0)
                {
                    result = result.Skip(jtStartIndex).Take(jtPageSize).ToList();
                }
                Session["ListTransaction"] = result;
                Session["ListInformasi"] = result;
                return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult TransactionDetailList(string date, string nop, int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                string username = string.Empty;
                if (Session["Username"] != null)
                {
                    username = Session["Username"].ToString();
                    POProject.Membership.Entity.MembershipRole role = Session["MembershipRole"] as POProject.Membership.Entity.MembershipRole;
                    if (string.Compare(role.Id_Role, "2") != 0)
                    {
                        username = string.Empty;
                    }
                }
                DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                int month = dt.Month;
                int year = dt.Year;
                List<UserTransactionDetail> transactionDetail = new List<UserTransactionDetail>();
                //transactionDetail = UserTransactionDetailBusiness.RetrieveUserTransactionDetailByDate(username, dt).ToList();
                transactionDetail = UserTransactionDetailBusiness.RetrieveUserDetailTransactionByDateTransaction(nop, dt).ToList();
                Session["transactionDetail"] = transactionDetail;

                //List<UserTransactionDetail> transactionDetail = UserTransactionDetailBusiness.RetrieveUserTransactionDetailByDate(username, dt).ToList();                
                List<DataTable> listTable = new List<DataTable>();
                System.IO.StringReader reader = new System.IO.StringReader(transactionDetail[0].Xml_File);
                DataSet ds = new DataSet();
                ds.ReadXml(reader);

                DataTable tableReader = ds.Tables[0].Clone();
                if (tableReader.Columns.Count < ds.Tables[0].Columns.Count)
                {
                    tableReader = ds.Tables[0].Clone();
                }
                DataTable sourcetable = ds.Tables[0];
                for (int isource = 0; isource < sourcetable.Rows.Count; isource++)
                {
                    DataRow newRow = tableReader.NewRow();
                    DataRow row = sourcetable.Rows[isource];

                    newRow.ItemArray = row.ItemArray;
                    tableReader.Rows.Add(newRow);
                }

                listTable.Add(tableReader);

                DataTable result = new DataTable("result");
                result.Columns.Add("Record_Data", typeof(string));
                DataTable dtFilter = new DataTable();

                if (listTable.Count > 0)
                {
                    foreach (DataTable table in listTable)
                    {
                        DataView view = table.AsDataView();
                        try
                        {
                            string startDate = dt.ToString("MM/dd/yyyy 00:00:00", new System.Globalization.CultureInfo("en-US"));
                            string endDate = dt.ToString("MM/dd/yyyy 23:59:59", new System.Globalization.CultureInfo("en-US"));
                            string filter = "TGL_TRANSAKSI >='" + startDate + "' AND TGL_TRANSAKSI <='" + endDate + "'";
                            dtFilter = filterData(result, table, view, filter);

                            if (dtFilter == null || dtFilter.Rows.Count <= 0)
                            {
                                startDate = dt.ToString("dd/MM/yyyy 00:00:00", new System.Globalization.CultureInfo("id-ID"));
                                endDate = dt.ToString("dd/MM/yyyy 23:59:59", new System.Globalization.CultureInfo("id-ID"));
                                filter = "TGL_TRANSAKSI >='" + startDate + "' AND TGL_TRANSAKSI <='" + endDate + "'";

                                dtFilter = filterData(result, table, view, filter);
                            }

                            if (dtFilter == null || dtFilter.Rows.Count <= 0)
                            {
                                startDate = dt.ToString("MM/dd/yyyy 00:00:00", new System.Globalization.CultureInfo("en-US"));
                                endDate = dt.ToString("MM/dd/yyyy 23:59:59", new System.Globalization.CultureInfo("en-US"));
                                filter = $"TGL_TRANSAKSI >=#{ startDate}# AND TGL_TRANSAKSI <= #{endDate}#";

                                dtFilter = filterData(result, table, view, filter);
                            }
                        }
                        catch (Exception ex)
                        {
                            
                        }                        
                    }
                }
                #region old code
                //DataTable table = new DataTable();
                //for (int iTrans = 0; iTrans < transactionDetail.Count; iTrans++)
                //{
                //    System.IO.StringReader reader = new System.IO.StringReader(transactionDetail[iTrans].Xml_File);
                //    DataSet ds = new DataSet();
                //    ds.ReadXml(reader);

                //    if (iTrans == 0) { table = ds.Tables[0].Clone(); }

                //    if(table.Columns.Count < ds.Tables[0].Columns.Count)
                //    {
                //        table = ds.Tables[0].Clone();
                //    }

                //    foreach (DataRow row in ds.Tables[0].Rows)
                //    {
                //        try
                //        {
                //            DataRow newRow = table.NewRow();
                //            newRow.ItemArray = row.ItemArray;
                //            table.Rows.Add(newRow);
                //        }
                //        catch (Exception ex)
                //        {

                //            throw;
                //        }

                //    }
                //}

                //DataTable result = new DataTable("result");
                //result.Columns.Add("Record_Data", typeof(string));

                //if (table.Rows.Count > 0)
                //{
                //    DataView view = table.AsDataView();
                //    string startDate = dt.ToString("MM/dd/yyyy 00:00:01", new System.Globalization.CultureInfo("en-US"));
                //    string endDate = dt.ToString("MM/dd/yyyy 23:59:59", new System.Globalization.CultureInfo("en-US"));
                //    string filter = $"TGL_TRANSAKSI >=#{startDate}# AND TGL_TRANSAKSI <=#{endDate}#";

                //    view.RowFilter = filter;
                //    foreach (DataRow item in view.ToTable().Rows)
                //    {
                //        DataRow resRow = result.NewRow();
                //        StringBuilder sb = new StringBuilder();
                //        foreach (DataColumn colItem in table.Columns)
                //        {
                //            sb.Append($"{colItem.ColumnName} : {item[colItem.ColumnName].ToString()};<br>");
                //        }
                //        resRow["Record_Data"] = sb.ToString();
                //        result.Rows.Add(resRow);
                //    }
                //} 
                #endregion

                List<RecordData> resultList = dtFilter.AsEnumerable<RecordData>().ToList();
                List<RecordData> resultPage = new List<RecordData>();
                if (resultList.Count > 0)
                {
                    resultPage = resultList.Skip(jtStartIndex).Take(jtPageSize).ToList();
                }
                return Json(new { Result = "OK", Records = resultPage, TotalRecordCount = resultList.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        private DataTable filterData(DataTable result, DataTable table, DataView view, string filter)
        {
            view.RowFilter = filter;
            foreach (DataRow item in view.ToTable().Rows)
            {
                DataRow resRow = result.NewRow();
                StringBuilder sb = new StringBuilder();
                foreach (DataColumn colItem in table.Columns)
                {
                    sb.Append($"{colItem.ColumnName} : {item[colItem.ColumnName].ToString()};<br>");
                }
                resRow["Record_Data"] = sb.ToString();
                result.Rows.Add(resRow);
            }

            return result;
        }

        [HttpPost]
        public JsonResult TransactionDetailRekapList(string month, string year, int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                string username = string.Empty;
                if (Session["Username"] != null)
                {
                    username = Session["Username"].ToString();
                    POProject.Membership.Entity.MembershipRole role = Session["MembershipRole"] as POProject.Membership.Entity.MembershipRole;
                    if (string.Compare(role.Id_Role, "2") == 0)
                    {
                        username = string.Empty;
                    }
                }

                var transactionDetail = new List<UserTransactionDetail>();
                if (Session["TransactionDetailRekapList"] == null)
                {
                    transactionDetail = UserTransactionDetailBusiness.RetrieveUserTransactionDetailByMonth(username, month.AsInt32(), year.AsInt32()).ToList();
                    Session["TransactionDetailRekapList"] = transactionDetail;
                }
                else
                {
                    transactionDetail = Session["TransactionDetailRekapList"] as List<UserTransactionDetail>;
                }

                DataTable table = new DataTable();
                for (int iTrans = 0; iTrans < transactionDetail.Count; iTrans++)
                {
                    System.IO.StringReader reader = new System.IO.StringReader(transactionDetail[iTrans].Xml_File);
                    DataSet ds = new DataSet();
                    ds.ReadXml(reader);

                    if (iTrans == 0) { table = ds.Tables[0].Clone(); }

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataRow newRow = table.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        table.Rows.Add(newRow);
                    }
                }

                DataTable result = new DataTable("result");
                result.Columns.Add("Record_Data", typeof(string));
                if (table.Rows.Count > 0)
                {
                    string nop = table.Rows[0]["NOP"].ToString();
                    string kodePajak = nop.Substring(10, 3);
                    DataView view = table.AsDataView();
                    DataTable dtCopy = table.Clone();
                    var firstDay = new DateTime(year.AsInt32(), month.AsInt32(), 1);
                    var lastDay = firstDay.AddMonths(1).AddDays(-1);
                    string filter = $"TGL_TRANSAKSI >= #{firstDay.ToString("MM/dd/yyyy")}# AND  TGL_TRANSAKSI <= #{lastDay.ToString("MM/dd/yyyy")}#";
                    view.RowFilter = filter;
                    table = view.ToTable();
                    foreach (DataRow item in table.Rows)
                    {
                        DataRow resRow = result.NewRow();
                        StringBuilder sb = new StringBuilder();
                        foreach (DataColumn colItem in table.Columns)
                        {
                            sb.Append($"{colItem.ColumnName} : {item[colItem.ColumnName].ToString()};<br>");
                        }
                        resRow["Record_Data"] = sb.ToString();
                        result.Rows.Add(resRow);
                    }
                }
                List<RecordData> resultList = result.AsEnumerable<RecordData>().ToList();
                resultList = resultList.Skip(jtStartIndex).Take(jtPageSize).ToList();
                return Json(new { Result = "OK", Records = resultList, TotalRecordCount = resultList.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public FileContentResult ExportDetailToExcel(string date, string nop)
        {
            string username = string.Empty;
            if (Session["Username"] != null)
            {
                username = Session["Username"].ToString();
                POProject.Membership.Entity.MembershipRole role = Session["MembershipRole"] as POProject.Membership.Entity.MembershipRole;
                if (string.Compare(role.Id_Role, "2") != 0)
                {
                    username = string.Empty;
                }
            }
            DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //var transactionDetail = new List<UserTransactionDetail>();
            //if (Session["transactionDetail"] == null)
            //{
            List<UserTransactionDetail> transactionDetail = UserTransactionDetailBusiness.RetrieveUserDetailTransactionByNop(nop, dt).ToList();
            //Session["transactionDetail"] = transactionDetail;
            //}
            //else {
            //    transactionDetail = Session["transactionDetail"] as List<UserTransactionDetail>;
            //}

            List<DataTable> listTable = new List<DataTable>();
            System.IO.StringReader reader = new System.IO.StringReader(transactionDetail[0].Xml_File);
            DataSet ds = new DataSet();
            ds.ReadXml(reader);

            DataTable tableReader = ds.Tables[0].Clone();
            if (tableReader.Columns.Count < ds.Tables[0].Columns.Count)
            {
                tableReader = ds.Tables[0].Clone();
            }
            DataTable sourcetable = ds.Tables[0];
            for (int isource = 0; isource < sourcetable.Rows.Count; isource++)
            {
                DataRow newRow = tableReader.NewRow();
                DataRow row = sourcetable.Rows[isource];

                newRow.ItemArray = row.ItemArray;
                tableReader.Rows.Add(newRow);
            }

            listTable.Add(tableReader);
            List<string> columnToTake = new List<string>();
            if (listTable.Count > 0)
            {
                foreach (DataTable table in listTable)
                {
                    DataView view = table.AsDataView();
                    string startDate = dt.ToString("MM/dd/yyyy 00:00:00", new System.Globalization.CultureInfo("en-US"));
                    string endDate = dt.ToString("MM/dd/yyyy 23:59:59", new System.Globalization.CultureInfo("en-US"));
                    string filter = $"TGL_TRANSAKSI >=#{startDate}# AND TGL_TRANSAKSI <=#{endDate}#";

                    view.RowFilter = filter;
                    foreach (DataRow item in view.ToTable().Rows)
                    {
                        foreach (DataColumn colItem in table.Columns)
                        {
                            columnToTake.Add(colItem.ColumnName);
                        }
                    }
                }
            }

            byte[] filecontent = ExcelExportHelper.ExportExcelFromListDataTable(listTable, "Detail Pajak", true, columnToTake.ToArray());
            return File(filecontent, ExcelExportHelper.ExcelContentType, "Detail Pajak.xlsx");
        }

        public FileContentResult ExportHasilPerekamanToExcel(string nop, string month, string year)
        {
            string username = string.Empty;
            if (Session["Username"] != null)
            {
                username = Session["Username"].ToString();
                POProject.Membership.Entity.MembershipRole role = Session["MembershipRole"] as POProject.Membership.Entity.MembershipRole;
                if (string.Compare(role.Id_Role, "2") != 0)
                {
                    username = string.Empty;
                }
            }

            var listTransaction = new List<UserTransaction>();
            if (Session["ListTransaction"] == null)
            {
                listTransaction = UserTransactionBusiness.RetrieveUserInformationTransactionByMonth(username, nop, month.AsInt32(), year.AsInt32()).ToList();
                Session["ListTransaction"] = listTransaction;
            }
            else
            {
                listTransaction = Session["ListTransaction"] as List<UserTransaction>;
            }
            //List<UserTransaction> listTransaction = UserTransactionBusiness.RetrieveUserInformationTransactionByMonth(username, nop, month.AsInt32(), year.AsInt32()).ToList();
            List<HasilPerekaman> resultList = new List<HasilPerekaman>();

            foreach (var item in listTransaction)
            {
                HasilPerekaman result = new HasilPerekaman();
                result.Nop = item.Nop;
                result.Tanggal = item.StrTanggal;
                result.PajakTerutang = item.strPajak_Terutang;
                result.Username = item.Username;
                resultList.Add(result);
            }

            DataTable dt = BusinessHelpers.ToDataTable(resultList);

            List<String> columnToTake = new List<string>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn colItem in dt.Columns)
                    {
                        columnToTake.Add(colItem.ColumnName);
                    }
                }
            }

            byte[] filecontent = ExcelExportHelper.ExportExcel(dt, "Hasil Perekaman", true, columnToTake.ToArray());
            return File(filecontent, ExcelExportHelper.ExcelContentType, "Hasil Perekaman Detail Pajak.xlsx");
        }
        #endregion

        #region Adjusment
        [CustomAuthorize(Roles = "USER,ADMINISTRATOR")]
        public ActionResult Adjusment()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Session["lstAdjustment"] = new List<AdjusmentEntity>();
            return View();
        }

        [HttpPost]
        public JsonResult GetListMonth()
        {
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            string[] monthName = { lastMonth.ToString("MMMM", new System.Globalization.CultureInfo("id-ID")), DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("id-ID")) };
            int[] monthValue = { lastMonth.Month, DateTime.Now.Month };
            //List<int> years = new List<int>();
            //if (string.Compare(lastMonth.Year.ToString(), DateTime.Now.Year.ToString()) != 0)
            //{
            //    years.Add(DateTime.Now.Year);
            //}
            //years.Add(DateTime.Now.Year);
            int[] years = { lastMonth.Year, DateTime.Now.Year };

            return Json(new { monthName = monthName, monthValue = monthValue, years = years });
        }

        [HttpPost]
        public JsonResult ResultAdjusment(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                List<AdjusmentEntity> ListAdjustment = new List<AdjusmentEntity>();
                if (Session["lstAdjustment"] != null)
                {
                    ListAdjustment = Session["lstAdjustment"] as List<AdjusmentEntity>;
                }
                var resultList = ListAdjustment.OrderByDescending(m => m.date).Skip(jtStartIndex).Take(jtPageSize).ToList();
                return Json(new { Result = "OK", Records = resultList, TotalRecordCount = resultList.Count() });
            }
            catch (Exception ex)
            {
                return Json(new { Result = $"Error,{ex.Message}" });
            }
        }

        [HttpPost]
        public JsonResult FinalResultAdjusment(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                List<AdjusmentEntity> ListAdjustment = new List<AdjusmentEntity>();
                if (Session["lstAdjustment"] != null)
                {
                    ListAdjustment = Session["lstAdjustment"] as List<AdjusmentEntity>;
                }
                var resultList = ListAdjustment.OrderByDescending(m => m.date).Skip(jtStartIndex).Take(jtPageSize).ToList();
                return Json(new { Result = "OK", Records = resultList, TotalRecordCount = resultList.Count() });
            }
            catch (Exception ex)
            {
                return Json(new { Result = $"Error, {ex.Message}" });
            }
        }

        [HttpPost]
        public JsonResult SaveTempAdjusment(string nop, string date, string nominal, string keterangan)
        {
            List<AdjusmentEntity> listAdjusment = new List<AdjusmentEntity>();
            listAdjusment = Session["lstAdjustment"] as List<AdjusmentEntity>;
            AdjusmentEntity entity = new AdjusmentEntity();
            DateTime tglTransaksi = DateTime.ParseExact(date, "MM/dd/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            List<UserTransaction> lstTrans = UserTransactionBusiness.RetrieveUserTransactionByNop(nop, tglTransaksi);
            if (lstTrans != null && lstTrans.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Proses Adjusment gagal :");
                sb.AppendLine("Transaksi pada tanggal tersebut sudah ter Generate.");
                return Json(new { isError = sb.ToString() });
            }
            entity.date = date;
            entity.nominal = nominal;
            entity.keterangan = keterangan;
            //save value entity to session
            Session["AdjusmentEntity"] = entity;
            var cekLstAdj = listAdjusment.Where(m => m.date.Equals(date));
            if (cekLstAdj != null && cekLstAdj.Count() > 0)
            {
                listAdjusment.Remove(cekLstAdj.SingleOrDefault());
                listAdjusment.Add(entity);
            }
            else
            {
                listAdjusment.Add(entity);
            }
            //DataTable dtTemp = listAdjusment.ToDataTable();
            DataTable dtTemp = POAdministrationTools.FunctionHelpers.ToDataTable(listAdjusment);
            Session["TempAdjusment"] = dtTemp;
            bool isSave = false;
            if (dtTemp != null)
            {
                isSave = true;
            }
            return Json(new { isSave = isSave });
        }

        [HttpPost]
        public JsonResult GetResultAdjusment()
        {
            var listData = Session["ListTransaction"] as List<UserTransaction>;
            var data = listData.FirstOrDefault();
            var listAdjustment = Session["lstAdjustment"] as List<AdjusmentEntity>;
            List<ResultAdjusmentEntity> listResult = new List<ResultAdjusmentEntity>();
            ResultAdjusmentEntity result = new ResultAdjusmentEntity();
            foreach (var item in listAdjustment)
            {
                result.nop = data.Nop;
                result.date = data.Tanggal.ToString("dd MMMM yyyy");
                result.username = data.Username;
                result.nominalbefore = data.Pajak_Terutang.AsCurrencyNonRp();
                result.nominalafter = item.nominal.AsDouble().AsCurrencyNonRp();
                result.keterangan = item.keterangan;
                listResult.Add(result);
            }
            return Json(new { listResult = listResult });
        }

        [HttpPost]
        public JsonResult DeleteResultAdjusment(string date)
        {
            try
            {
                List<AdjusmentEntity> listAdjustment = new List<AdjusmentEntity>();
                listAdjustment = Session["lstAdjustment"] as List<AdjusmentEntity>;
                listAdjustment = listAdjustment.Where(m => m.date != date).ToList();
                Session["lstAdjustment"] = listAdjustment;
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult SaveAdjusment(string file)
        {
            string username = string.Empty;
            if (Session["WebUsername"] != null)
            {
                username = Session["Username"].ToString();
                POProject.Membership.Entity.MembershipRole role = Session["MembershipRole"] as POProject.Membership.Entity.MembershipRole;
                if (string.Compare(role.Id_Role, "2") != 0)
                {
                    username = string.Empty;
                }
            }
            bool isSave = false;
            try
            {
                var listData = Session["ListTransaction"] as List<UserTransaction>;
                var listAdjustment = Session["lstAdjustment"] as List<AdjusmentEntity>;
                UserTransaction data = listData.FirstOrDefault();
                string[] arrFile = file.Split(',');
                byte[] byteFile = null;
                foreach (var item in listAdjustment)
                {
                    if (UserTransactionBusiness.InsertUserTransactionWithFile(username, item.date.AsDateTime(), item.nominal.AsDouble(), data.Ip_Sender, item.keterangan, true, data.Nop, byteFile))
                    {
                        isSave = true;
                    }
                }
                return Json(new { isSave = isSave });
            }
            catch
            {

                return Json(new { });
            }

        }
        #endregion

        #region Peranan Masyarakat
        [CustomAuthorize(Roles = "ADMINISTRATOR,USER")]
        public ActionResult PerananMasyarakat()
        {
            return View();
        }

        [HttpPost]
        public JsonResult FindNop()
        {
            try
            {
                List<PureNop> RegisteredNOP = SettingClientBusiness.RetrieveNopFromUserNop();
                string jsonSent = Newtonsoft.Json.JsonConvert.SerializeObject(RegisteredNOP);
                string RequestUrl = UserApiUrlBusiness.RetrieveApiUrl();
                RequestUrl = $"{RequestUrl}/Nop/DetailNop";
                var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(RequestUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                //send request
                using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonSent);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                List<DetailNop> resultDetail = new List<DetailNop>();
                var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultResponse = streamReader.ReadToEnd();

                    JsonData result = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonData>(resultResponse);
                    resultDetail = result.ListNOP.ToList();
                }

                return Json(new { resultDetail = resultDetail });
            }
            catch
            {

                throw;
            }
        }

        [CaptchaVerify("Captcha tidak valid")]
        [HttpPost]
        public JsonResult FindResult(string nop, string tgl, string nobill)
        {
            bool isFound = false;
            try
            {
                string message = string.Empty;
                string[] arrNop = nop.Split('/');
                nop = arrNop[1].Replace(".", string.Empty);
                DateTime dt = DateTime.ParseExact(tgl, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                var transaction = UserTransactionBusiness.RetrieveUserTransactionByDateTransaction(nop, dt).FirstOrDefault();
                if (transaction != null)
                {
                    UserTransactionDetail detail = UserTransactionDetailBusiness.RetrieveUserDetailTransactionByDateTransaction(nop, dt).FirstOrDefault();
                    if (detail != null)
                    {
                        DataTable dtSource = new DataTable();
                        string xmlString = detail.Xml_File;
                        System.IO.StringReader strReader = new System.IO.StringReader(xmlString);
                        DataSet ds = new DataSet();
                        ds.ReadXml(strReader);

                        dtSource = ds.Tables[0];

                        string colName = "NO_INVOICE";
                        DataColumnCollection col = dtSource.Columns;
                        if (col.Contains(colName))
                        {
                            isFound = dtSource.AsEnumerable().Any(row => nobill == row.Field<string>(colName));
                            if (isFound)
                            {
                                message = "No. Invoice " + nobill + " SUDAH TEREKAM";
                            }
                            else
                            {
                                message = "No. Invoice " + nobill + " BELUM TEREKAM";
                            }
                        }
                        else
                        {
                            message = "No. Invoice " + nobill + " BELUM TEREKAM";
                        }
                    }
                    else
                    {
                        message = "DETAIL DATA TRANSAKSI BELUM TEREKAM";
                    }
                }
                else
                {
                    message = "DATA TRANSAKSI BELUM TEREKAM";
                }

                return Json(new { isFound = isFound, message = message });
            }
            catch (Exception ex)
            {
                return Json(new { isFound = isFound, message = ex.Message });
            }
        }
        #endregion

        #region Data Wajib Pajak
        [CustomAuthorize(Roles = "ADMINISTRATOR, KABAN")]
        public ActionResult ResultRekapWp()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDataRekapTransaction(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                string username = string.Empty;
                List<RekapTransaction> resultList = UserTransactionBusiness.RetrieveRekapResultWp(username).ToList();
                resultList = resultList.Skip(jtStartIndex).Take(jtPageSize).ToList();
                return Json(new { Result = "OK", Records = resultList, TotalRecordCount = resultList.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion

        #region Grafik dan Jatuh Tempo
        [CustomAuthorize(Roles = "ADMINISTRATOR, USER, BANK, KABAN")]
        public ActionResult Dashboard(JatuhTempoViewModels model)
        {
            try
            {
                if (string.Compare(Session["Nama_Role"].ToString(), "BANK") == 0)
                {
                    return RedirectToAction("Index", "Bank");
                }
                else if (string.Compare(Session["Nama_Role"].ToString(), "KABAN") == 0)
                {
                    return RedirectToAction("ResultRekapWp", "User");
                }

                //if (string.Compare(Request.QueryString["kbn"].ToString(),"kaban") != 0)
                //{
                //    return RedirectToAction("Login", "Account", new { iskbn = false });
                //}

                model.ListTahun = JatuhTempoBusiness.RetrieveTahunJatuhTempo().ToList();
                model.ListJatuhTempo = JatuhTempoBusiness.RetrieveAllJatuhTempo(0).ToList();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA"))
                {
                    return RedirectToAction("ErrorPage");
                }
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult GetDataChart(string nop, string year)
        {
            if (string.IsNullOrEmpty(year))
            {
                year = DateTime.Now.Year.ToString();
            }
            else
            {
                year = (DateTime.Now.Year - 1).ToString();
            }
            string webusername = Session["WebUsername"].ToString();
            List<UserProfile> listUser = SettingClientBusiness.RetrieveUserProfileDashboard(webusername);
            string username = string.Empty;
            if (listUser.Count > 0)
            {
                foreach (var item in listUser)
                {
                    username += "'" + item.Username + "',";
                }
                username = username.Remove(username.Length - 1);
            }

            List<PaymentTransaction> listParentAfterAdjustment = UserTransactionBusiness.RetrieveDataPayment(username, year.AsInt32())
                .OrderBy(m => m.Tahun).ThenBy(m => m.MasaPajak)
                .ToList();
            List<PaymentTransaction> listParentBeforeAdjustment = UserTransactionBusiness.GetChartDataBeforeAdjustment(username, year.AsInt32())
               .OrderBy(m => m.Tahun).ThenBy(m => m.MasaPajak)
                .ToList();

            if (!string.IsNullOrEmpty(nop))
            {
                listParentAfterAdjustment = listParentAfterAdjustment.Where(m => m.Nop == nop).ToList();
                listParentBeforeAdjustment = listParentBeforeAdjustment.Where(m => m.Nop == nop).ToList();
            }

            List<ChartEntity> listDataChartAfter = new List<ChartEntity>();
            var lstChartByMonthAfter = listParentAfterAdjustment.Select(m => new { m.MasaPajak, m.Tahun, m.StrMasaPajak, m.Pajak }).
                GroupBy(m => new { m.MasaPajak, m.Tahun, m.StrMasaPajak }).Select(g => new
                {
                    MasaPajak = g.Key.MasaPajak,
                    Tahun = g.Key.Tahun,
                    StrMasaPajak = g.Key.StrMasaPajak,
                    Pajak = g.Sum(x => Math.Round(x.Pajak, 2))
                });

            foreach (var item in lstChartByMonthAfter)
            {
                listDataChartAfter.Add(new ChartEntity { month = item.StrMasaPajak + " " + item.Tahun, nominal = item.Pajak });
            }

            List<ChartEntity> listDataChartBefore = new List<ChartEntity>();
            var lstChartByMonthBefore = listParentBeforeAdjustment.Select(m => new { m.MasaPajak, m.Tahun, m.StrMasaPajak, m.Pajak }).
               GroupBy(m => new { m.MasaPajak, m.Tahun, m.StrMasaPajak }).Select(g => new
               {
                   MasaPajak = g.Key.MasaPajak,
                   Tahun = g.Key.Tahun,
                   StrMasaPajak = g.Key.StrMasaPajak,
                   Pajak = g.Sum(x => Math.Round(x.Pajak, 2))
               });
            foreach (var itemB in lstChartByMonthBefore)
            {
                listDataChartBefore.Add(new ChartEntity { month = itemB.StrMasaPajak + " " + itemB.Tahun, nominal = itemB.Pajak });
            }
            return Json(new { listDataChartAfter = listDataChartAfter, listDataChartBefore = listDataChartBefore, year = year });
        }
        #endregion

        #region NestedClass
        class HasilPerekaman
        {
            public string Username { get; set; }
            public string Nop { get; set; }
            public string Tanggal { get; set; }
            public string PajakTerutang { get; set; }
        }

        class ResultAdjusmentEntity
        {
            public string username { get; set; }
            public string nop { get; set; }
            public string nominalbefore { get; set; }
            public string date { get; set; }
            public string nominalafter { get; set; }
            public string keterangan { get; set; }
        }

        class AdjusmentEntity
        {
            public string date { get; set; }
            public string nominal { get; set; }
            public string keterangan { get; set; }
        }
        class ChartEntity
        {
            public string month { get; set; }
            public double nominal { get; set; }
        }
        class JsonData
        {
            public IEnumerable<DetailNop> ListNOP { get; set; }
        }

        class DetailNop
        {
            public string NOP { get; set; }
            public string NAMAOP { get; set; }
            public string ALAMATOP { get; set; }
        }

        class RecordData
        {
            public string Record_Data { get; set; }
        }
        #endregion
    }
}