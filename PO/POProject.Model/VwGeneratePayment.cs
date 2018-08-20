using System;

namespace POProject.Model
{
    public class VwGeneratePayment
    {
        //USERNAME, TANGGAL, KETERANGAN, IS_ADJUSMENT, PAJAK_TERUTANG, NOP,MASAPAJAK, TAHUN
        public string Username { get; set; }
        public string Nop { get; set; }
        public DateTime Tanggal { get; set; }
        public string Keterangan { get; set; }
        public bool Is_Adjusment { get; set; }
        public double Pajak_Terutang { get; set; }
        public int MasaPajak { get; set; }
        public int Tahun { get; set; }
    }
}