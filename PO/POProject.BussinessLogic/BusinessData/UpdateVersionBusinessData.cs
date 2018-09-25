using System;
using System.Collections.Generic;
using System.Linq;
using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class UpdateVersionBusinessData : IUpdateVersionBusinessData
    {
        private readonly IDataManager _dataManager;
        private readonly IDataManagerDataTable _dataManagerDataTable;

        public UpdateVersionBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
        {
            _dataManager = dataManager;
            _dataManagerDataTable = dataManagerDataTable;
        }

        public List<UpdateVersion> GetVersion()
        {
            return _dataManager.Get<UpdateVersion>((e => e.is_important == 1 && e.islatestversion == 1)).ToList();
        }
    }
}
