using POProject.BusinessLogic.BusinessDataModel;
using System;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public interface ISPTPDDetailBusiness
    {
        List<SPTPDetailBusinessModel> RetrieveDetailSptpd(string idSptpd, string username);
        List<SPTPDetailBusinessModel> RetrieveDetailSptpdByNop(string idSptpd, string nop);
        bool InsertDetailSptpd(string idsptpd, string nop, string username, int masapajak, int tahun, double pajak);
        bool UpdateIsGenerate(string nop, DateTime tanggal);
        bool isSptpdDetailByNop(string nop, int masapajak, int tahun);
    }
}
