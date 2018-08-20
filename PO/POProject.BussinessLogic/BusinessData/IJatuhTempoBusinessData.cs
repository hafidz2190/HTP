using POProject.Model;
using System.Collections.Generic;

namespace POProject.BusinessLogic.BusinessData
{
    public interface IJatuhTempoBusinessData
    {
        JatuhTempo RetrieveJatuhTempo(int masapajak, int tahunpajak);
        List<JatuhTempo> RetrieveAllJatuhTempo(int tahun);
        List<Year> RetrieveTahunJatuhTempo();
        List<JatuhTempo> RetrieveAllowMasaPajak();
    }
}