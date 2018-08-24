using POProject.DataAccess;
using System.Linq;

namespace POProject.BusinessLogic.Entity
{
    public class Bank
    {
        public string Kode_Bank { get; set; }
        public string Nama_Bank { get; set; }
        public string Username { get; set; }
    }

    public class DataBayarBank
    {
        public string Id_Sptpd { get; set; }
        public string Username { get; set; }
        public int MasaPajak { get; set; }
        public int Tahun { get; set; }
        public double Pajak { get; set; }
        public string StrPajak { get { return Pajak.AsCurrencyNonRp(); } }
        public double Sanksi { get; set; }
        public double Total { get; set; }
        public string StrTotal { get { return Total.AsCurrencyNonRp(); } }
        public string Id_Bayar { get; set; }
        public bool Is_Active { get; set; }
        public string Kode_Bank { get; set; }
        public string Nop { get; set; }
        public string NamaOp
        {
            get
            {
                NopBaru nopBaru = NopBaruData.RetrieveNopBaru(Nop).AsEnumerable<NopBaru>().SingleOrDefault();
                return nopBaru == null ? string.Empty : nopBaru.NAMAOP;
            }
        }
    }
}
