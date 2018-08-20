using POProject.Model;
using System;
using System.Collections.Generic;

namespace POProject.BusinessLogic.BusinessData
{
    public interface IUserTransactionDetailBusinessData
    {
        bool InsertUserTransactionDetail(string username, string xmlPath, int bulan, int tahun, DateTime transDate, string ipAddress, string xmlfile, string nop);
        IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByMonth(string username, int bulan, int tahun);
        IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByDate(string username, DateTime tgltransaksi);
        IEnumerable<UserTransactionDetail> RetrieveUserDetailTransactionByNop(string nop, DateTime tgltransaksi);
        IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByMonth(string username, string nop, int bulan, int tahun);
        IEnumerable<UserTransactionDetail> RetrieveUserDetailTransactionByDateTransaction(string nop, DateTime tglTransaksi);
        IEnumerable<UserDetailWithPajak> RetrieveTransactionDetailOrderByDate(DateTime tglAWal, DateTime tglAkhir);
        string GetXmlFileByNop(string nop, int bulan, int tahun);
        bool DeleteUserDetailTransaction(string nop, DateTime tglTransaksi);
    }
}
