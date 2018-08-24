using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class NopBaruBusinessData : INopBaruBusinessData
    {
        private readonly IDataManager _dataManager;
        private readonly IDataManagerDataTable _dataManagerDataTable;

        public NopBaruBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
        {
            _dataManager = dataManager;
            _dataManagerDataTable = dataManagerDataTable;
        }

        public NopBaru RetrieveNopBaru(string nop)
        {
            return _dataManager.GetFirst<NopBaru>((e => e.NOP == nop));
        }
    }
}