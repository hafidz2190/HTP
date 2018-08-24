using POProject.DataAccess;
using System;
using System.Linq;

namespace POProject.BusinessLogic.Entity
{
    public class SPTPD
    {
        public string ID_SPTPD { get; set; }
        public string Username { get; set; }
        public int MasaPajak { get; set; }
        public int Tahun { get; set; }
        public double Sanksi { get; set; }
        public double Total { get; set; }
        public string Id_Bayar { get; set; }
        public bool Is_Active { get; set; }
    }

    public class SPTPDDetail
    {
        public string ID_SPTPD { get; set; }
        public string Nop { get; set; }
        public NopBaru ObyekPajak
        {
            get
            {
                return NopBaruData.RetrieveNopBaru(Nop).AsEnumerable<NopBaru>().SingleOrDefault();
            }
        }
        public string Username { get; set; }
        public int MasaPajak { get; set; }
        public int Tahun { get; set; }
        public double Nominal { get; set; }
        public string StrNominal { get { return this.Nominal.AsCurrencyNonRp(); } }
    }

    public class SptpdPaymentItem
    {
        public string KdBill { get; set; }
        public string NOP { get; set; }
        public string NamaOP { get; set; }
        public string AlamatOP { get; set; }
        public double Pajak { get; set; }
        public double Sanksi { get; set; }
        public string ReffBill { get; set; }
        public int MasaPajak { get; set; }
        public int TahunPajak { get; set; }
        public DateTime TglJthTempo { get; set; }
        public int StatusBayar { get; set; }
        public int StatusAktif { get; set; }
    }

    public class VirtualAccountBankItem
    {
        public string VaCode { get; set; }
        public string BankName { get; set; }
    }
}
