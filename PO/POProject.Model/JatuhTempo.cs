using System;

namespace POProject.Model
{
    public class JatuhTempo : BaseEntity
    {
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public DateTime Tgl_Jatuh_Tempo { get; set; }
    }
}