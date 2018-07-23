using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
