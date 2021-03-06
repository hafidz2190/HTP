﻿using POProject.Model;
using System.Collections.Generic;
using System.Data;

namespace POProject.BusinessLogic.BusinessData
{
    public interface IBankBusinessData
    {
        List<Bank> RetrieveDataBank(string kdBank);
        List<DataBayarBank> RetrieveDataPembayaranByKdBankUser(string kdBank);
        DataTable DtRetrieveDataPembayaranByKdBankUser(string kdBank);
        List<Bank> RetrieveDataBankSqlQuery(string sqlQuery, IDictionary<string, object> parameters);
    }
}
