using System.Collections.Generic;
using System.Data;
using System.Linq;
using POProject.DataAccess;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class BankBusinessDataOracleCommand : IBankBusinessData
    {
        public List<Bank> RetrieveDataBank(string kdBank)
        {
            return BankData.RetrieveDataBank(kdBank).AsEnumerable<Bank>().ToList();
        }

        public List<DataBayarBank> RetrieveDataPembayaranByKdBankUser(string kdBank)
        {
            return BankData.RetrieveDataPembayaranByKdBankUser(kdBank).AsEnumerable<DataBayarBank>().ToList();
        }

        public DataTable DtRetrieveDataPembayaranByKdBankUser(string kdBank)
        {
            return BankData.RetrieveDataPembayaranByKdBankUser(kdBank);
        }

        public List<Bank> RetrieveDataBankSqlQuery(string sqlQuery, IDictionary<string, object> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
