using System;

namespace POProject.Model
{
    public class UserDetailWithPajak
    {
        public DateTime Transaction_Date { get; set; }
        public string Xml_File { get; set; }
        public int Bulan { get; set; }
        public string NamaBulan { get; set; }
        public int Tahun { get; set; }
        public string NOP { get; set; }
        public string JENIS_PAJAK { get; set; }
    }
}