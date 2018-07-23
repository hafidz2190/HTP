using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;

namespace POWebClient.Models
{
    public class SptpdModels
    {
        public string KdBill { get; set; }
        public string NamaPajak { get; set; }
        public string NOP { get; set; }
        public string NamaOP { get; set; }
        public string AlamatOP { get; set; }
        public double Pajak { get; set; }
        public double Sanksi { get; set; }
        public double Total
        {
            get
            {
                return Pajak + Sanksi;
            }
        }
        public List<VirtualAccountBankItem> lstVaBank { get; set; }
        public string ReffBill { get; set; }
        public int MasaPajak { get; set; }
        public string NamaBulan
        {
            get
            {
                string nm = string.Empty;
                switch (MasaPajak)
                {
                    case 1:
                        nm = "Januari";
                        break;
                    case 2:
                        nm = "Februari";
                        break;
                    case 3:
                        nm = "Maret";
                        break;
                    case 4:
                        nm = "April";
                        break;
                    case 5:
                        nm = "Mei";
                        break;
                    case 6:
                        nm = "Juni";
                        break;
                    case 7:
                        nm = "Juli";
                        break;
                    case 8:
                        nm = "Agustus";
                        break;
                    case 9:
                        nm = "September";
                        break;
                    case 10:
                        nm = "Oktober";
                        break;
                    case 11:
                        nm = "November";
                        break;
                    case 12:
                        nm = "Desember";
                        break;
                    default:
                        break;
                }

                return nm;
            }
        }
        public int TahunPajak { get; set; }
        public DateTime TglJthTempo { get; set; }
        public string strTglJthTempo
        {
            get
            {
                return TglJthTempo.ToString("dd MMM yyyy");
            }
        }
        public int StatusBayar { get; set; }
        public int StatusAktif { get; set; }
        public string EncryptIdSptpd
        {
            get
            {
                return Pemkot.Encryption.Crypto.ActionEncrypt(ReffBill);
            }

        }

        public List<SptpdPaymentItem> lstSptpd { get; set; }
    }   
}