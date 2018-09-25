using System;
using System.Collections.Generic;
using System.Linq;
using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class JatuhTempoBusinessData : IJatuhTempoBusinessData
    {
        private readonly IDataManager _dataManager;
        private readonly IDataManagerDataTable _dataManagerDataTable;

        public JatuhTempoBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
        {
            _dataManager = dataManager;
            _dataManagerDataTable = dataManagerDataTable;
        }

        public List<JatuhTempo> RetrieveAllJatuhTempo(int tahun)
        {
            return tahun == 0 ? _dataManager.Get<JatuhTempo>().ToList() : _dataManager.Get<JatuhTempo>((e => e.Tahun == tahun)).ToList();
        }

        public List<JatuhTempo> RetrieveAllowMasaPajak()
        {
            return _dataManager.Get<JatuhTempo>(null, (q => q.OrderBy(e => e.Bulan).ThenBy(e => e.Tahun))).ToList();
        }

        public JatuhTempo RetrieveJatuhTempo(int masapajak, int tahunpajak)
        {
            return _dataManager.GetFirst<JatuhTempo>((e => e.Bulan == masapajak && e.Tahun == tahunpajak));
        }

        public List<Year> RetrieveTahunJatuhTempo()
        {
            return _dataManager.Get<JatuhTempo>().Select(e => new Year() { Tahun = e.Tahun }).Distinct().ToList();
        }
    }
}
