using POProject.Model;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public interface IJatuhTempoBusiness
    {
        JatuhTempo RetrieveJatuhTempo(int masapajak, int tahunpajak);
        List<JatuhTempo> RetrieveAllJatuhTempo(int tahun);
        List<Year> RetrieveTahunJatuhTempo();
        List<JatuhTempo> RetrieveAllowMasaPajak();
    }
}
