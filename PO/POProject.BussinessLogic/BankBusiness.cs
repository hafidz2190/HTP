using POProject.BusinessLogic.BusinessData;
using POProject.Model;
using System.Collections.Generic;
using System.Data;

namespace POProject.BusinessLogic
{
    public class BankBusiness : IBankBusiness
    {
        private readonly IBankBusinessData _bankBusinessData;

        public BankBusiness(IBankBusinessData bankBusinessData)
        {
            _bankBusinessData = bankBusinessData;
        }

        public List<Bank> RetrieveDataBank(string kdBank)
        {
            return _bankBusinessData.RetrieveDataBank(kdBank);
        }

        public List<DataBayarBank> RetrieveDataPembayaranByKdBankUser(string kdBank)
        {
            return _bankBusinessData.RetrieveDataPembayaranByKdBankUser(kdBank);
        }

        public DataTable DtRetrieveDataPembayaranByKdBankUser(string kdBank)
        {
            return _bankBusinessData.DtRetrieveDataPembayaranByKdBankUser(kdBank);
        }

        public List<Bank> RetrieveDataBankSqlQuery(string sqlQuery, IDictionary<string, object> parameters)
        {
            return _bankBusinessData.RetrieveDataBankSqlQuery(sqlQuery, parameters);
        }
    }
}
