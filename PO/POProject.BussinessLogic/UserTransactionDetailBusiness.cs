using POProject.BusinessLogic.BusinessData;
using POProject.Model;
using System;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public class UserTransactionDetailBusiness : IUserTransactionDetailBusiness
    {
        private readonly IUserTransactionDetailBusinessData _userTransactionDetailBusinessData;

        public UserTransactionDetailBusiness(IUserTransactionDetailBusinessData userTransactionDetailBusinessData)
        {
            _userTransactionDetailBusinessData = userTransactionDetailBusinessData;
        }

        public bool InsertUserTransactionDetail(string username, string xmlPath, int bulan, int tahun, DateTime transDate, string ipAddress, string xmlfile, string nop)
        {
            return _userTransactionDetailBusinessData.InsertUserTransactionDetail(username, xmlPath, bulan, tahun, transDate, ipAddress, xmlfile, nop);
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByMonth(string username, int bulan, int tahun)
        {
            return _userTransactionDetailBusinessData.RetrieveUserTransactionDetailByMonth(username, bulan, tahun);
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByDate(string username, DateTime tgltransaksi)
        {
            return _userTransactionDetailBusinessData.RetrieveUserTransactionDetailByDate(username, tgltransaksi);
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserDetailTransactionByNop(string nop, DateTime tgltransaksi)
        {
            return _userTransactionDetailBusinessData.RetrieveUserDetailTransactionByNop(nop, tgltransaksi);
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByMonth(string username, string nop, int bulan, int tahun)
        {
            return _userTransactionDetailBusinessData.RetrieveUserTransactionDetailByMonth(username, nop, bulan, tahun);
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserDetailTransactionByDateTransaction(string nop, DateTime tglTransaksi)
        {
            return _userTransactionDetailBusinessData.RetrieveUserDetailTransactionByDateTransaction(nop, tglTransaksi);
        }

        public IEnumerable<UserDetailWithPajak> RetrieveTransactionDetailOrderByDate(DateTime tglAWal, DateTime tglAkhir)
        {
            return _userTransactionDetailBusinessData.RetrieveTransactionDetailOrderByDate(tglAWal, tglAkhir);
        }

        public string GetXmlFileByNop(string nop, int bulan, int tahun)
        {
            return _userTransactionDetailBusinessData.GetXmlFileByNop(nop, bulan, tahun);
        }

        public bool DeleteUserDetailTransaction(string nop, DateTime tglTransaksi)
        {
            return _userTransactionDetailBusinessData.DeleteUserDetailTransaction(nop, tglTransaksi);
        }
    }
}
