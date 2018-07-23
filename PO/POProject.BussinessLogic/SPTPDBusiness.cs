using POProject.BusinessLogic.Entity;
using POProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class SPTPDBusiness
    {
        public static List<SPTPD> RetrieveDataSptpd(string username, int masapajak, int tahun, bool isActive)
        {
            return SPTPDData.RetrieveDataSptpd(username, masapajak, tahun, isActive).AsEnumerable<SPTPD>().ToList();
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
    }
    public class SPTPDDetailBusiness
    {
        public static List<SPTPDDetail> RetrieveDetailSptpd(string idSptpd, string username)
        {
            return SPTPDDetailData.RetrieveDetailSptpd(idSptpd, username).AsEnumerable<SPTPDDetail>().ToList();
        }

        public static bool InsertDetailSptpd(string idsptpd, string nop, string username, int masapajak, int tahun, double pajak)
        {
            return SPTPDDetailData.InsertDetailSptpd(idsptpd, nop, username, masapajak, tahun, pajak);
        }

        public static bool UpdateIsGenerate(string nop, DateTime tanggal)
        {
            return SPTPDDetailData.UpdateIsGenerate(nop, tanggal);
        }

        public static bool isSptpdDetailByNop(string nop, int masapajak, int tahun)
        {
            return SPTPDDetailData.isSptpdDetailByNop(nop, masapajak, tahun);
        }
    }
}
