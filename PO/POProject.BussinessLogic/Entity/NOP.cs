namespace POProject.BusinessLogic.Entity
{
    public class NOP
    {
        public string nop { get; set; }
        public string jenisPajak { get; set; }
    }

    public class PureNop
    {
        public string nop { get; set; }
        public string Nama_Obyek { get; set; }
    }

    public class USERAPP
    {
        public string userName { get; set; }
        public string idMachine { get; set; }
        public string guid { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public int port { get; set; }
    }

    public class NopBaru
    {
        public string NOP { get; set; }
        public string NAMAOP { get; set; }
        public string ALAMAT { get; set; }
        public string NPWPD { get; set; }
        public string KODEREKENING { get; set; }
        public string JENISUSAHA { get; set; }
    }
}
