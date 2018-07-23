using POProject.BusinessLogic.Entity;
using POProject.DataAccess;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class BankBusiness
    {
        public static List<Bank> RetrieveDataBank(string kdBank)
        {
            return BankData.RetrieveDataBank(kdBank).AsEnumerable<Entity.Bank>().ToList();
        }

        public static List<DataBayarBank> RetrieveDataPembayaranByKdBankUser(string kdBank)
        {
            return BankData.RetrieveDataPembayaranByKdBankUser(kdBank).AsEnumerable<DataBayarBank>().ToList();
        }

        public static DataTable DtRetrieveDataPembayaranByKdBankUser(string kdBank)
        {
            return BankData.RetrieveDataPembayaranByKdBankUser(kdBank);
        }
    }
}
