using POProject.Model;
using System;
using System.Collections.Generic;

namespace POProject.BusinessLogic.BusinessData
{
    public interface ISPTPDDetailBusinessData
    {
        List<SPTPDDetail> RetrieveDetailSptpd(string idSptpd, string username);
        List<SPTPDDetail> RetrieveDetailSptpdByNop(string idSptpd, string nop);
        bool InsertDetailSptpd(string idsptpd, string nop, string username, int masapajak, int tahun, double pajak);
        bool UpdateIsGenerate(string nop, DateTime tanggal);
        bool isSptpdDetailByNop(string nop, int masapajak, int tahun);
    }
}
