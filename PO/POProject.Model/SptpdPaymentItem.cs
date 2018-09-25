using System;

namespace POProject.Model
{
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
}