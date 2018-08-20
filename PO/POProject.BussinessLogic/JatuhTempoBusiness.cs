using POProject.BusinessLogic.BusinessData;
using POProject.Model;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public class JatuhTempoBusiness : IJatuhTempoBusiness
    {
        private readonly IJatuhTempoBusinessData _jatuhTempoBusinessData;

        public JatuhTempoBusiness(IJatuhTempoBusinessData jatuhTempoBusinessData)
        {
            _jatuhTempoBusinessData = jatuhTempoBusinessData;
        }

        public JatuhTempo RetrieveJatuhTempo(int masapajak, int tahunpajak)
        {
            return _jatuhTempoBusinessData.RetrieveJatuhTempo(masapajak, tahunpajak);
        }

        public List<JatuhTempo> RetrieveAllJatuhTempo(int tahun)
        {
            return _jatuhTempoBusinessData.RetrieveAllJatuhTempo(tahun);
        }

        public List<Year> RetrieveTahunJatuhTempo()
        {
            return _jatuhTempoBusinessData.RetrieveTahunJatuhTempo();
        }

        public List<JatuhTempo> RetrieveAllowMasaPajak()
        {
            return _jatuhTempoBusinessData.RetrieveAllowMasaPajak();
        }
    }
}
