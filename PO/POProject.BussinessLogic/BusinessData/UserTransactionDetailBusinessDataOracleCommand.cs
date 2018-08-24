using POProject.DataAccess;
using POProject.Model;
using System;
using System.Collections.Generic;

namespace POProject.BusinessLogic.BusinessData
{
    public class UserTransactionDetailBusinessDataOracleCommand
    {
        public bool InsertUserTransactionDetail(string username, string xmlPath, int bulan, int tahun, DateTime transDate, string ipAddress, string xmlfile, string nop)
        {
            return UserTransactionDetailData.InsertUserTransactionDetail(username, xmlPath, bulan, tahun, transDate, ipAddress, xmlfile, nop);
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByMonth(string username, int bulan, int tahun)
        {
            return UserTransactionDetailData.RetrieveUserDetailTransactionByMonth(username, bulan, tahun).AsEnumerable<UserTransactionDetail>();
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByDate(string username, DateTime tgltransaksi)
        {
            return UserTransactionDetailData.RetrieveUserDetailTransactionByDate(username, tgltransaksi).AsEnumerable<UserTransactionDetail>();
        }
        public IEnumerable<UserTransactionDetail> RetrieveUserDetailTransactionByNop(string nop, DateTime tgltransaksi)
        {
            return UserTransactionDetailData.RetrieveUserDetailTransactionByNop(nop, tgltransaksi).AsEnumerable<UserTransactionDetail>();
        }
        public IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByMonth(string username, string nop, int bulan, int tahun)
        {
            return UserTransactionDetailData.RetrieveUserDetailTransactionByMonth(username, nop, bulan, tahun).AsEnumerable<UserTransactionDetail>();
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserDetailTransactionByDateTransaction(string nop, DateTime tglTransaksi)
        {
            return UserTransactionDetailData.RetrieveUserDetailTransactionByDateTransaction(nop, tglTransaksi).AsEnumerable<UserTransactionDetail>();
        }

        public IEnumerable<UserDetailWithPajak> RetrieveTransactionDetailOrderByDate(DateTime tglAWal, DateTime tglAkhir)
        {
            return UserTransactionDetailData.RetrieveDetailOrderByDate(tglAWal, tglAkhir).AsEnumerable<UserDetailWithPajak>();
        }

        public string GetXmlFileByNop(string nop, int bulan, int tahun)
        {
            return UserTransactionDetailData.GetXmlFileByNop(nop, bulan, tahun);
        }

        public bool DeleteUserDetailTransaction(string nop, DateTime tglTransaksi)
        {
            return UserTransactionDetailData.DeleteUserDetailTransaction(nop, tglTransaksi);
        }
    }
}
