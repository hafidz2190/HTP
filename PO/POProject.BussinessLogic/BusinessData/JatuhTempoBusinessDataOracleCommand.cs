using System.Collections.Generic;
using System.Linq;
using POProject.DataAccess;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class JatuhTempoBusinessDataOracleCommand : IJatuhTempoBusinessData
    {
        public JatuhTempo RetrieveJatuhTempo(int masapajak, int tahunpajak)
        {
            return JatuhTempoData.RetrieveJatuhTempo(masapajak, tahunpajak).AsEnumerable<JatuhTempo>().FirstOrDefault();
        }

        public List<JatuhTempo> RetrieveAllJatuhTempo(int tahun)
        {
            return JatuhTempoData.RetrieveAllJatuhTempo(tahun).AsEnumerable<JatuhTempo>().ToList();
        }

        public List<Year> RetrieveTahunJatuhTempo()
        {
            return JatuhTempoData.RetrieveTahunJatuhTempo().AsEnumerable<Year>().ToList();
        }

        public List<JatuhTempo> RetrieveAllowMasaPajak()
        {
            return JatuhTempoData.RetrieveAllowMasaPajak().AsEnumerable<JatuhTempo>().ToList();
        }
    }
}