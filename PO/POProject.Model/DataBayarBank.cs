namespace POProject.Model
{
    public class DataBayarBank
    {
        public string Id_Sptpd { get; set; }
        public string Username { get; set; }
        public int MasaPajak { get; set; }
        public int Tahun { get; set; }
        public double Pajak { get; set; }
        public string StrPajak { get; set; }
        public double Sanksi { get; set; }
        public double Total { get; set; }
        public string StrTotal { get; set; }
        public string Id_Bayar { get; set; }
        public bool Is_Active { get; set; }
        public string Kode_Bank { get; set; }
        public string Nop { get; set; }
        public string NamaOp { get; set; }
    }
}