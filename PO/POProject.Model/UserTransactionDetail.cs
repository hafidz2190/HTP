using System;

namespace POProject.Model
{
    public class UserTransactionDetail : BaseEntity
    {
        public string Username { get; set; }
        public string Xml_Path { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Ip_Address { get; set; }
        public string Xml_File { get; set; }
        public int Bulan { get; set; }
        public DateTime Create_Date { get; set; }
        public int Tahun { get; set; }
        public string NOP { get; set; }
    }
}