using POProject.Model;
using System;

namespace POProject.BusinessLogic.BusinessDataModel
{
    public class UserTransactionBusinessDataModel : UserTransaction
    {
        public string StrTanggal
        {
            get
            {
                return Tanggal.ToString("dd/MM/yyyy");
            }
        }

        public string strPajak_Terutang
        {
            get
            {
                return Math.Round(Pajak_Terutang, MidpointRounding.AwayFromZero).AsCurrencyNonRp();
            }
        }
    }
}
