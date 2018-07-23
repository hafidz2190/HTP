using System;

namespace POProject.BusinessLogic.Entity
{
    public class UserTransaction
    {
        public string Username { get; set; }
        public DateTime Tanggal { get; set; }
        public string StrTanggal
        {
            get
            {
                return Tanggal.ToString("dd/MM/yyyy");
            }
        }
        public double Pajak_Terutang { get; set; }
        public string strPajak_Terutang
        {
            get
            {
                return Math.Round(Pajak_Terutang, MidpointRounding.AwayFromZero).AsCurrencyNonRp();
            }
        }
        public string Keterangan { get; set; }
        public bool Is_Adjusment { get; set; }
        public DateTime CreateDate { get; set; }
        public string Ip_Sender { get; set; }
        public string Nop { get; set; }
        public byte[] File_Adjustment { get; set; }
    }

    public class UserTransactionWithJenisPajak
    {
        public string Username { get; set; }
        public DateTime Tanggal { get; set; }
        public string StrTanggal
        {
            get
            {
                return Tanggal.ToString("dd/MM/yyyy");
            }
        }
        public double Pajak_Terutang { get; set; }
        public string strPajak_Terutang
        {
            get
            {
                return Math.Round(Pajak_Terutang, MidpointRounding.AwayFromZero).AsCurrencyNonRp();
            }
        }
        public string Keterangan { get; set; }
        public bool Is_Adjusment { get; set; }
        public DateTime CreateDate { get; set; }
        public string Ip_Sender { get; set; }
        public string Nop { get; set; }
        public byte[] File_Adjustment { get; set; }
        public string JENIS_PAJAK { get; set; }
    }

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

    public class PaymentTransaction
    {
        public string Username { get; set; }
        public string Nop { get; set; }
        public string MasaPajak { get; set; }
        public string StrMasaPajak
        {
            get
            {
                string namaBulan = string.Empty;
                switch (this.MasaPajak)
                {
                    case "01":
                        namaBulan = "Jan";
                        break;
                    case "02":
                        namaBulan = "Feb";
                        break;
                    case "03":
                        namaBulan = "Mar";
                        break;
                    case "04":
                        namaBulan = "Apr";
                        break;
                    case "05":
                        namaBulan = "Mei";
                        break;
                    case "06":
                        namaBulan = "Jun";
                        break;
                    case "07":
                        namaBulan = "Jul";
                        break;
                    case "08":
                        namaBulan = "Agu";
                        break;
                    case "09":
                        namaBulan = "Sep";
                        break;
                    case "10":
                        namaBulan = "Okt";
                        break;
                    case "11":
                        namaBulan = "Nov";
                        break;
                    case "12":
                        namaBulan = "Des";
                        break;
                }

                return namaBulan;
            }
        }
        public string Tahun { get; set; }
        public double Pajak { get; set; }
        public string StrNominal { get { return this.Pajak.AsCurrencyNonRp(); } }

        public int Is_Generate { get; set; }
    }
    public class RekapTransaction
    {
        public string MasaPajak { get; set; }
        public string Tahun { get; set; }
        public string Jenis_Pajak { get; set; }
        public double Total_Transaksi { get; set; }

        public string StrTotalTransaksi
        {
            get
            {
                return this.Total_Transaksi.AsCurrencyRp();
            }
        }
    }

    public class GenerateTransaction
    {
        public string USERNAME { get; set; }
        public double PAJAK_TERUTANG { get; set; }
        public DateTime TANGGAL { get; set; }
        public string NOP { get; set; }
    }
}
