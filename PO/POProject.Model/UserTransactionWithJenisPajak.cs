﻿using System;

namespace POProject.Model
{
    public class UserTransactionWithJenisPajak
    {
        public string Username { get; set; }
        public DateTime Tanggal { get; set; }
        public string StrTanggal { get; set; }
        public double Pajak_Terutang { get; set; }
        public string strPajak_Terutang { get; set; }
        public string Keterangan { get; set; }
        public bool Is_Adjusment { get; set; }
        public DateTime CreateDate { get; set; }
        public string Ip_Sender { get; set; }
        public string Nop { get; set; }
        public byte[] File_Adjustment { get; set; }
        public string JENIS_PAJAK { get; set; }
    }
}