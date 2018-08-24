using POProject.BusinessLogic.BusinessData;
using POProject.BusinessLogic.BusinessDataModel;
using POProject.BusinessLogic.Helper;
using POProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class SPTPDDetailBusiness : ISPTPDDetailBusiness
    {
        private readonly ISPTPDDetailBusinessData _sPTPDetailBusinessData;

        public SPTPDDetailBusiness(ISPTPDDetailBusinessData sPTPDetailBusinessData)
        {
            _sPTPDetailBusinessData = sPTPDetailBusinessData;
        }

        public List<SPTPDetailBusinessModel> RetrieveDetailSptpd(string idSptpd, string username)
        {
            return ModelToBusinessModelMapper.Convert<SPTPDDetail, SPTPDetailBusinessModel>(_sPTPDetailBusinessData.RetrieveDetailSptpd(idSptpd, username));
        }

        public List<SPTPDetailBusinessModel> RetrieveDetailSptpdByNop(string idSptpd, string nop)
        {
            return ModelToBusinessModelMapper.Convert<SPTPDDetail, SPTPDetailBusinessModel>(_sPTPDetailBusinessData.RetrieveDetailSptpdByNop(idSptpd, nop));
        }

        public bool InsertDetailSptpd(string idsptpd, string nop, string username, int masapajak, int tahun, double pajak)
        {
            return _sPTPDetailBusinessData.InsertDetailSptpd(idsptpd, nop, username, masapajak, tahun, pajak);
        }

        public bool UpdateIsGenerate(string nop, DateTime tanggal)
        {
            return _sPTPDetailBusinessData.UpdateIsGenerate(nop, tanggal);
        }

        public bool isSptpdDetailByNop(string nop, int masapajak, int tahun)
        {
            return _sPTPDetailBusinessData.isSptpdDetailByNop(nop, masapajak, tahun);
        }
    }
}
