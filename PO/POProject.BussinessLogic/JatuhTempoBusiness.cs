using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class JatuhTempoBusiness
    {
        public static Entity.JatuhTempo RetrieveJatuhTempo(int masapajak, int tahunpajak)
        {
            return DataAccess.JatuhTempoData.RetrieveJatuhTempo(masapajak, tahunpajak).AsEnumerable<Entity.JatuhTempo>().FirstOrDefault();
        }

        public static List<Entity.JatuhTempo> RetrieveAllJatuhTempo(int tahun)
        {
            return DataAccess.JatuhTempoData.RetrieveAllJatuhTempo(tahun).AsEnumerable<Entity.JatuhTempo>().ToList();
        }

        public static List<Entity.Year> RetrieveTahunJatuhTempo()
        {
            return DataAccess.JatuhTempoData.RetrieveTahunJatuhTempo().AsEnumerable<Entity.Year>().ToList();
        }

        public static List<Entity.JatuhTempo> RetrieveAllowMasaPajak()
        {
            return DataAccess.JatuhTempoData.RetrieveAllowMasaPajak().AsEnumerable<Entity.JatuhTempo>().ToList();
        }
    }
}
