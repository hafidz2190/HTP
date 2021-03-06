using POProject.BusinessLogic.Entity;
using POProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class SPTPDBusiness
    {
        public static List<SPTPD> RetrieveDataSptpd(string username, int masapajak, int tahun, bool isActive, double pajak)
        {
            return SPTPDData.RetrieveDataSptpd(username, masapajak, tahun, isActive, pajak).AsEnumerable<SPTPD>().ToList();
        }

        public static List<SPTPD> RetrieveDataSptpdById(string idSptpd)
        {
            return SPTPDData.RetrieveDataSptpdById(idSptpd).AsEnumerable<SPTPD>().ToList();
        }

        public static bool InsertSptpd(string idsptpd, string username, int masapajak, int tahun, double pajak, double sanksi, double total, string idbayar)
        {
            return SPTPDData.InsertSptpd(idsptpd, username, masapajak, tahun, pajak, sanksi, total, idbayar);
        }

        public static bool InsertDetailSptpd(string idsptpd, string nop, string username, int masapajak, int tahun, double pajak)
        {
            return SPTPDDetailData.InsertDetailSptpd(idsptpd, nop, username, masapajak, tahun, pajak);
        }

        public static List<SptpdPaymentItem> RetrieveSptpdPayment(string idSptpd)
        {
            return Mapper.MapSptpdPayment(SPTPDBonangData.RetrieveSptpdPayment(idSptpd));
        }

        public static List<VirtualAccountBankItem> RetrieveVirtualAccount(string idSptpd)
        {
            return Mapper.MapVirtualAccountBank(SPTPDBonangData.RetrieveVirtualAccount(idSptpd));
        }

        public static string GetNamaOPSptpd(string kdValidasi)
        {
            return SPTPDBonangData.GetNamaOPSptpd(kdValidasi);
        }
    }
}
