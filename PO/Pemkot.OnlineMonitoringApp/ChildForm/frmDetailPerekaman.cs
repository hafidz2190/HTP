using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp.ChildForm
{
    public partial class frmDetailPerekaman : Form
    {
        private List<Perekaman> _lstPerekaman;

        private List<Perekaman> _lstPerekamanHotel;
        private List<Perekaman> _lstPerekamanRestoran;
        private List<Perekaman> _lstPerekamanHiburan;
        private List<Perekaman> _lstPerekamanParkir;

        private List<string> _lstNop;

        private List<PajakPerekaman> _lstPajak;

        private double _totPajakHotel;
        private double _totPajakRestoran;
        private double _totPajakHiburan;
        private double _totPajakParkir;

        private Random rnd = new Random();
        public frmDetailPerekaman()
        {
            InitializeComponent();
            tmrLoadProses.Stop();
            tmrRandom.Stop();
        }

        private void frmDetailPerekaman_Load(object sender, EventArgs e)
        {
            if (!bgwProses.IsBusy)
            {
                string strTanggal = string.Empty;
                DateTime tglSekarang = DateTime.Now;
                switch (DateTime.Now.ToString("MM"))
                {
                    case "01":
                        strTanggal = tglSekarang.ToString("dd") + " JANUARI " + tglSekarang.ToString("yyyy");
                        break;
                    case "02":
                        strTanggal = tglSekarang.ToString("dd") + " FEBRUARI " + tglSekarang.ToString("yyyy");
                        break;
                    case "03":
                        strTanggal = tglSekarang.ToString("dd") + " MARET " + tglSekarang.ToString("yyyy");
                        break;
                    case "04":
                        strTanggal = tglSekarang.ToString("dd") + " APRIL " + tglSekarang.ToString("yyyy");
                        break;
                    case "05":
                        strTanggal = tglSekarang.ToString("dd") + " MEI " + tglSekarang.ToString("yyyy");
                        break;
                    case "06":
                        strTanggal = tglSekarang.ToString("dd") + " JUNI " + tglSekarang.ToString("yyyy");
                        break;
                    case "07":
                        strTanggal = tglSekarang.ToString("dd") + " JULI " + tglSekarang.ToString("yyyy");
                        break;
                    case "08":
                        strTanggal = tglSekarang.ToString("dd") + " AGUSTUS " + tglSekarang.ToString("yyyy");
                        break;
                    case "09":
                        strTanggal = tglSekarang.ToString("dd") + " SEPTEMBER " + tglSekarang.ToString("yyyy");
                        break;
                    case "10":
                        strTanggal = tglSekarang.ToString("dd") + " OKTOBER " + tglSekarang.ToString("yyyy");
                        break;
                    case "11":
                        strTanggal = tglSekarang.ToString("dd") + " NOVEMBER " + tglSekarang.ToString("yyyy");
                        break;
                    case "12":
                        strTanggal = tglSekarang.ToString("dd") + " DESEMBER " + tglSekarang.ToString("yyyy");
                        break;
                    default:
                        break;
                }
                lblTanggal.Text = strTanggal;

                bgwProses.RunWorkerAsync();
            }

        }

        private void bgwProses_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _lstNop = new List<string>();
            _lstPerekaman = new List<Perekaman>();
            _lstPerekamanHotel = new List<Perekaman>();
            _lstPerekamanRestoran = new List<Perekaman>();
            _lstPerekamanHiburan = new List<Perekaman>();
            _lstPerekamanParkir = new List<Perekaman>();

            List<UserDetailWithPajak> lstDetail = new List<UserDetailWithPajak>();
            List<UserTransactionWithJenisPajak> lstTransaction = new List<UserTransactionWithJenisPajak>();

            DateTime tglKemaren = DateTime.Now.AddDays(-1);
            DateTime awalBulan = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            lstDetail = UserTransactionDetailBusiness.RetrieveTransactionDetailOrderByDate(tglKemaren, DateTime.Now).ToList();
            lstTransaction = UserTransactionBusiness.RetrieveUserTransactionBetweenDate(awalBulan, DateTime.Now);

            if (lstDetail != null && lstDetail.Count > 0)
            {
                bool isNopAdd = false;
                foreach (var det in lstDetail)
                {
                    if (_lstNop != null && _lstNop.Count > 0)
                        isNopAdd = _lstNop.Equals(det.NOP);

                    if (!isNopAdd)
                    {
                        DataTable dtPerekaman = xmlToDatatable(det.Xml_File);
                        bool colNameFound = false;
                        string[] estimateColumn = { "TOTAL", "BIAYA", "NOMINAL", "PAY", "COST", "NILAI", "PRICE" };
                        string columnName = string.Empty;
                        string[] allColumnName = dtPerekaman.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                        for (int iAllCol = 0; iAllCol < allColumnName.Length; iAllCol++)
                        {
                            if (colNameFound)
                                break;

                            for (int iEst = 0; iEst < estimateColumn.Length; iEst++)
                            {
                                if (allColumnName[iAllCol].ToUpper().Contains(estimateColumn[iEst]))
                                {
                                    columnName = allColumnName[iAllCol];
                                    colNameFound = true;
                                    break;
                                }
                            }
                        }


                        if (dtPerekaman != null && dtPerekaman.Rows.Count > 0)
                        {
                            for (int iRow = 0; iRow < dtPerekaman.Rows.Count; iRow++)
                            {
                                Perekaman itemPerekaman = new Perekaman();
                                itemPerekaman.NOP = det.NOP;
                                itemPerekaman.NO_INVOICE = dtPerekaman.Rows[iRow]["NO_INVOICE"].ToString();
                                itemPerekaman.TOTAL = Convert.ToDouble(dtPerekaman.Rows[iRow][columnName] == null ? 0 : dtPerekaman.Rows[iRow][columnName]);
                                itemPerekaman.JENIS_PAJAK = det.JENIS_PAJAK;

                                _lstPerekaman.Add(itemPerekaman);
                            }
                        }
                        _lstNop.Add(det.NOP);
                    }
                }
            }

            _lstPerekamanHotel = _lstPerekaman.Where(m => m.JENIS_PAJAK.Equals("HOTEL")).ToList();
            _lstPerekamanRestoran = _lstPerekaman.Where(m => m.JENIS_PAJAK.Equals("RESTORAN")).ToList();
            _lstPerekamanHiburan = _lstPerekaman.Where(m => m.JENIS_PAJAK.Equals("HIBURAN")).ToList();
            _lstPerekamanParkir = _lstPerekaman.Where(m => m.JENIS_PAJAK.Equals("PARKIR")).ToList();


            _lstPajak = new List<PajakPerekaman>();
            for (int iList = 0; iList < 10; iList++)
            {
                List<UserTransactionWithJenisPajak> copyTransaction = new List<UserTransactionWithJenisPajak>();
                DateTime firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endDay = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                switch (iList)
                {
                    case 1:
                        copyTransaction = SetListTransactionByJenisPajak(lstTransaction, "HOTEL", firstDay, endDay);
                        break;
                    case 2:
                        copyTransaction = SetListTransactionByJenisPajak(lstTransaction, "RESTORAN", firstDay, endDay);
                        break;
                    case 3:
                        copyTransaction = SetListTransactionByJenisPajak(lstTransaction, "HIBURAN", firstDay, endDay);
                        break;
                    case 4:
                        copyTransaction = SetListTransactionByJenisPajak(lstTransaction, "PARKIR", firstDay, endDay);
                        break;
                    default:
                        break;
                }
            }
        }

        private List<UserTransactionWithJenisPajak> SetListTransactionByJenisPajak(List<UserTransactionWithJenisPajak> lstTransaction, string jenPajak, DateTime firstDay, DateTime endDay)
        {
            List<UserTransactionWithJenisPajak> copyTransaction = lstTransaction.Where(m => m.JENIS_PAJAK.ToUpper().Equals(jenPajak)).ToList();
            if (copyTransaction != null && copyTransaction.Count > 0)
            {
                for (int iTrans = 0; iTrans < 3; iTrans++)
                {
                    PajakPerekaman item = new PajakPerekaman();
                    item.JENIS_PAJAK = jenPajak;
                    item.ID = iTrans;
                    switch (iTrans)
                    {
                        case 0:
                            item.KETERANGAN = "HARI INI";
                            item.TOTAL_PAJAK = copyTransaction.Where(m => m.Tanggal.Date == DateTime.Today.Date).Sum(m => m.Pajak_Terutang);
                            break;
                        case 1:
                            item.KETERANGAN = "KEMAREN";
                            item.TOTAL_PAJAK = copyTransaction.Where(m => m.Tanggal.Date == DateTime.Today.Date.AddDays(-1)).Sum(m => m.Pajak_Terutang);
                            break;
                        case 2:
                            item.KETERANGAN = "BULAN INI";
                            item.TOTAL_PAJAK = copyTransaction.Where(m => m.Tanggal.Date >= firstDay.Date && m.Tanggal.Date <= endDay).Sum(m => m.Pajak_Terutang);
                            break;
                        default:
                            break;
                    }
                    _lstPajak.Add(item);
                }
            }

            return copyTransaction;
        }

        private DataTable xmlToDatatable(string xml)
        {
            List<DataTable> listTable = new List<DataTable>();
            System.IO.StringReader reader = new System.IO.StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(reader);

            DataTable tableReader = ds.Tables[0].Clone();
            if (tableReader.Columns.Count < ds.Tables[0].Columns.Count)
            {
                tableReader = ds.Tables[0].Clone();
            }
            DataTable sourcetable = ds.Tables[0];


            return sourcetable;
        }

        private void bgwProses_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_lstPerekaman != null && _lstPerekaman.Count > 0)
            {
                dgvHotel.DataSource = _lstPerekamanHotel;
                dgvRestoran.DataSource = _lstPerekamanRestoran;
                dgvHiburan.DataSource = _lstPerekamanHiburan;
                dgvParkir.DataSource = _lstPerekamanParkir;

                dgvTotalHotel.DataSource = _lstPajak.Where(m => m.JENIS_PAJAK.ToUpper().Equals("HOTEL")).OrderBy(m => m.ID);
                dgvTotalResto.DataSource = _lstPajak.Where(m => m.JENIS_PAJAK.ToUpper().Equals("RESTORAN")).OrderBy(m => m.ID);
                dgvTotalHiburan.DataSource = _lstPajak.Where(m => m.JENIS_PAJAK.ToUpper().Equals("HIBURAN")).OrderBy(m => m.ID);
                dgvTotalParkir.DataSource = _lstPajak.Where(m => m.JENIS_PAJAK.ToUpper().Equals("PARKIR")).OrderBy(m => m.ID);
            }

            if (!bgwRandom.IsBusy)
            {
                bgwRandom.RunWorkerAsync();
            }

            if (!bgwProses.IsBusy)
            {
                tmrLoadProses.Start();
            }
            else
            {
                while (bgwProses.IsBusy)
                {
                    if (!bgwProses.IsBusy)
                    {
                        tmrLoadProses.Start();
                        break;
                    }
                }
            }
        }

        private void bgwRandom_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            dgvHotel.DataSource = new List<Perekaman>();
            dgvRestoran.DataSource = new List<Perekaman>();
            dgvHiburan.DataSource = new List<Perekaman>();
            dgvParkir.DataSource = new List<Perekaman>();


            if (_lstPerekamanHotel != null && _lstPerekamanHotel.Count > 0)
                dgvHotel.DataSource = _lstPerekamanHotel;

            if (_lstPerekamanRestoran != null && _lstPerekamanRestoran.Count > 0)
                dgvRestoran.DataSource = _lstPerekamanRestoran;

            if (_lstPerekamanHiburan != null && _lstPerekamanHiburan.Count > 0)
                dgvHiburan.DataSource = _lstPerekamanHiburan;

            if (_lstPerekamanParkir != null && _lstPerekamanParkir.Count > 0)
                dgvParkir.DataSource = _lstPerekamanParkir;

            if (!bgwRandom.IsBusy)
            {
                tmrRandom.Start();
            }
        }

        private void bgwRandom_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _lstPerekamanHotel.Suffle<Perekaman>();
            _lstPerekamanRestoran.Suffle<Perekaman>();
            _lstPerekamanHiburan.Suffle<Perekaman>();
            _lstPerekamanParkir.Suffle<Perekaman>();
        }

        int _iTimer = 0;
        private void tmrLoadProses_Tick(object sender, EventArgs e)
        {
            if (_iTimer >= 600)
            {
                if (!bgwProses.IsBusy)
                {
                    bgwProses.RunWorkerAsync();
                    _iTimer = 0;
                    tmrLoadProses.Stop();
                }
                else
                {
                    while (bgwProses.IsBusy)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                    bgwProses.RunWorkerAsync();
                    _iTimer = 0;
                    tmrLoadProses.Stop();
                }
            }
            _iTimer++;
        }

        int _iRandom = 0;
        private void tmrRandom_Tick(object sender, EventArgs e)
        {
            if (_iRandom >= 100)
            {
                if (!bgwRandom.IsBusy)
                {
                    bgwRandom.RunWorkerAsync();
                    _iRandom = 0;
                    tmrRandom.Stop();
                }
                else
                {
                    while (bgwProses.IsBusy)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                    bgwRandom.RunWorkerAsync();
                    _iRandom = 0;
                    tmrRandom.Stop();
                }
            }

            _iRandom++;
        }
    }
}
