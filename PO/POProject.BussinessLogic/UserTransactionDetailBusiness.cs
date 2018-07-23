using POProject.DataAccess;
using System;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public class UserTransactionDetailBusiness
    {
        public static bool InsertUserTransactionDetail(string username, string xmlPath, int bulan, int tahun, DateTime transDate, string ipAddress, string xmlfile, string nop)
        {
            return UserTransactionDetailData.InsertUserTransactionDetail(username, xmlPath, bulan, tahun, transDate, ipAddress, xmlfile, nop);
        }

        public static IEnumerable<Entity.UserTransactionDetail> RetrieveUserTransactionDetailByMonth(string username, int bulan, int tahun)
        {
            return UserTransactionDetailData.RetrieveUserDetailTransactionByMonth(username, bulan, tahun).AsEnumerable<Entity.UserTransactionDetail>();
        }

        public static IEnumerable<Entity.UserTransactionDetail> RetrieveUserTransactionDetailByDate(string username, DateTime tgltransaksi)
        {
            return UserTransactionDetailData.RetrieveUserDetailTransactionByDate(username, tgltransaksi).AsEnumerable<Entity.UserTransactionDetail>();
        }
        public static IEnumerable<Entity.UserTransactionDetail> RetrieveUserDetailTransactionByNop(string nop, DateTime tgltransaksi)
        {
            return UserTransactionDetailData.RetrieveUserDetailTransactionByNop(nop, tgltransaksi).AsEnumerable<Entity.UserTransactionDetail>();
        }
        public static IEnumerable<Entity.UserTransactionDetail> RetrieveUserTransactionDetailByMonth(string username, string nop, int bulan, int tahun)
        {
            return UserTransactionDetailData.RetrieveUserDetailTransactionByMonth(username, nop, bulan, tahun).AsEnumerable<Entity.UserTransactionDetail>();
        }

        public static IEnumerable<Entity.UserTransactionDetail> RetrieveUserDetailTransactionByDateTransaction(string nop, DateTime tglTransaksi)
        {
            return UserTransactionDetailData.RetrieveUserDetailTransactionByDateTransaction(nop, tglTransaksi).AsEnumerable<Entity.UserTransactionDetail>();
        }

        public static IEnumerable<Entity.UserDetailWithPajak> RetrieveTransactionDetailOrderByDate(DateTime tglAWal, DateTime tglAkhir)
        {
            return UserTransactionDetailData.RetrieveDetailOrderByDate(tglAWal, tglAkhir).AsEnumerable<Entity.UserDetailWithPajak>();
        }

        public static string GetXmlFileByNop(string nop, int bulan, int tahun)
        {
            return UserTransactionDetailData.GetXmlFileByNop(nop, bulan, tahun);
        }

        public static bool DeleteUserDetailTransaction(string nop, DateTime tglTransaksi)
        {
            return UserTransactionDetailData.DeleteUserDetailTransaction(nop, tglTransaksi);
        }
    }
}
