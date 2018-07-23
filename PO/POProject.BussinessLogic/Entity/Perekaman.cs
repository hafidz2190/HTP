using System;

namespace POProject.BusinessLogic.Entity
{
    public class Perekaman
    {
        public string JENIS_PAJAK { get; set; }
        public string NOP { get; set; }
        public string NO_INVOICE { get; set; }
        public double TOTAL { get; set; }
    }

    public class PajakPerekaman
    {
        public string KETERANGAN { get; set; }
        public double TOTAL_PAJAK { get; set; }
        public int ID { get; set; }
        public string JENIS_PAJAK { get; set; }
    }
}
