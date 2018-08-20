using POProject.DataAccess;
using System;

namespace POProject.BusinessLogic.Entity
{
    public class UserTransactionDetail
    {
        public string Username { get; set; }
        public string Xml_Path { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Ip_Address { get; set; }
        public string Xml_File { get; set; }
        public int Bulan { get; set; }
        public DateTime Create_Date { get; set; }
        public string NamaBulan
        {
            get
            {
                string namaBulan = string.Empty;
                switch (this.Bulan)
                {
                    case 1:
                        namaBulan = "JANUARI";
                        break;
                    case 2:
                        namaBulan = "FEBRUARI";
                        break;
                    case 3:
                        namaBulan = "MARET";
                        break;
                    case 4:
                        namaBulan = "APRIL";
                        break;
                    case 5:
                        namaBulan = "MEI";
                        break;
                    case 6:
                        namaBulan = "JUNI";
                        break;
                    case 7:
                        namaBulan = "JULI";
                        break;
                    case 8:
                        namaBulan = "AGUSTUS";
                        break;
                    case 9:
                        namaBulan = "SEPTEMBER";
                        break;
                    case 10:
                        namaBulan = "OKTOBER";
                        break;
                    case 11:
                        namaBulan = "NOVEMBER";
                        break;
                    case 12:
                        namaBulan = "DESEMBER";
                        break;
                }

                return namaBulan;
            }
        }
        public int Tahun { get; set; }

        public string NOP { get; set; }
    }

    public class UserDetailWithPajak
    {
        public DateTime Transaction_Date { get; set; }
        public string Xml_File
        {
            get
            {
                return UserTransactionDetailData.GetXmlFileByNop(NOP, Bulan, Tahun);
            }
        }
        public int Bulan { get; set; }
        public string NamaBulan
        {
            get
            {
                string namaBulan = string.Empty;
                switch (this.Bulan)
                {
                    case 1:
                        namaBulan = "JANUARI";
                        break;
                    case 2:
                        namaBulan = "FEBRUARI";
                        break;
                    case 3:
                        namaBulan = "MARET";
                        break;
                    case 4:
                        namaBulan = "APRIL";
                        break;
                    case 5:
                        namaBulan = "MEI";
                        break;
                    case 6:
                        namaBulan = "JUNI";
                        break;
                    case 7:
                        namaBulan = "JULI";
                        break;
                    case 8:
                        namaBulan = "AGUSTUS";
                        break;
                    case 9:
                        namaBulan = "SEPTEMBER";
                        break;
                    case 10:
                        namaBulan = "OKTOBER";
                        break;
                    case 11:
                        namaBulan = "NOVEMBER";
                        break;
                    case 12:
                        namaBulan = "DESEMBER";
                        break;
                }

                return namaBulan;
            }
        }
        public int Tahun { get; set; }
        public string NOP { get; set; }

        public string JENIS_PAJAK
        {
            get
            {
                string jen = string.Empty;
                switch (NOP.Substring(10, 3))
                {
                    case "901":
                        jen = "HOTEL";
                        break;
                    case "902":
                        jen = "RESTORAN";
                        break;
                    case "903":
                        jen = "HIBURAN";
                        break;
                    case "907":
                        jen = "PARKIR";
                        break;
                    default:
                        break;
                }

                return jen;
            }
        }
    }
}
