using System;
using System.Collections.Generic;
using System.Linq;
using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class SPTPDDetailBusinessData : ISPTPDDetailBusinessData
    {
        private readonly IDataManager _dataManager;
        private readonly IDataManagerDataTable _dataManagerDataTable;

        public SPTPDDetailBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
        {
            _dataManager = dataManager;
            _dataManagerDataTable = dataManagerDataTable;
        }

        public bool InsertDetailSptpd(string idsptpd, string nop, string username, int masapajak, int tahun, double pajak)
        {
            bool result = true;

            using (var transaction = _dataManager.BeginTransaction())
            {
                try
                {
                    _dataManager.Create(new SPTPDDetail()
                    {
                        ID_SPTPD = idsptpd,
                        Nop = nop,
                        Username = username,
                        MasaPajak = masapajak,
                        Tahun = tahun,
                        Nominal = pajak
                    });

                    _dataManager.Save();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    result = false;
                    transaction.Rollback();
                }
            }

            return result;
        }

        public bool isSptpdDetailByNop(string nop, int masapajak, int tahun)
        {
            return _dataManager.GetCount<SPTPDDetail>((e => e.Nop == nop && e.MasaPajak == masapajak && e.Tahun == tahun)) > 0;
        }

        public List<SPTPDDetail> RetrieveDetailSptpd(string idSptpd, string username)
        {
            return _dataManager.Get<SPTPDDetail>((e => e.ID_SPTPD == idSptpd && e.Username == username)).ToList();
        }

        public List<SPTPDDetail> RetrieveDetailSptpdByNop(string idSptpd, string nop)
        {
            return _dataManager.Get<SPTPDDetail>((e => e.ID_SPTPD == idSptpd && e.Nop == nop)).ToList();
        }

        public bool UpdateIsGenerate(string nop, DateTime tanggal)
        {
            throw new NotImplementedException();
        }
    }
}
