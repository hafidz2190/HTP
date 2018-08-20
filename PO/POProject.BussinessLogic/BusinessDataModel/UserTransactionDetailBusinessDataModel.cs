using POProject.Model;

namespace POProject.BusinessLogic.BusinessDataModel
{
    public class UserTransactionDetailBusinessDataModel : UserTransactionDetail
    {
        public string NamaBulan
        {
            get
            {
                string namaBulan = string.Empty;

                switch (Bulan)
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
    }
}