using System;
using System.Collections.Generic;
using System.Linq;
using POProject.DataAccess;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class SPTPDDetailBusinessDataOracleCommand : ISPTPDDetailBusinessData
    {
        public List<SPTPDDetail> RetrieveDetailSptpd(string idSptpd, string username)
        {
            return SPTPDDetailData.RetrieveDetailSptpd(idSptpd, username).AsEnumerable<SPTPDDetail>().ToList();
        }

        public List<SPTPDDetail> RetrieveDetailSptpdByNop(string idSptpd, string nop)
        {
            return SPTPDDetailData.RetrieveDetailSptpdByNop(idSptpd, nop).AsEnumerable<SPTPDDetail>().ToList();
        }

        public bool InsertDetailSptpd(string idsptpd, string nop, string username, int masapajak, int tahun, double pajak)
        {
            return SPTPDDetailData.InsertDetailSptpd(idsptpd, nop, username, masapajak, tahun, pajak);
        }

        public bool UpdateIsGenerate(string nop, DateTime tanggal)
        {
            return SPTPDDetailData.UpdateIsGenerate(nop, tanggal);
        }

        public bool isSptpdDetailByNop(string nop, int masapajak, int tahun)
        {
            return SPTPDDetailData.isSptpdDetailByNop(nop, masapajak, tahun);
        }
    }
}
