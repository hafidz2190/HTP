using System.Collections.Generic;
using System.Data;
using System.Linq;
using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class BankBusinessData : IBankBusinessData
    {
        private readonly IDataManager _dataManager;
        private readonly IDataManagerDataTable _dataManagerDataTable;

        public BankBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
        {
            _dataManager = dataManager;
            _dataManagerDataTable = dataManagerDataTable;
        }

        public List<Bank> RetrieveDataBank(string kdBank)
        {
            return _dataManager.Get<Bank>((e => e.Kode_Bank == kdBank)).ToList();
        }

        public List<DataBayarBank> RetrieveDataPembayaranByKdBankUser(string kdBank)
        {
            throw new System.NotImplementedException();
        }

        public DataTable DtRetrieveDataPembayaranByKdBankUser(string kdBank)
        {
            throw new System.NotImplementedException();
        }

        public List<Bank> RetrieveDataBankSqlQuery(string sqlQuery, IDictionary<string, object> parameters)
        {
            return _dataManager.Get<Bank>(sqlQuery, parameters).ToList();
        }
    }
}
