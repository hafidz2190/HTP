using System;
using System.Collections.Generic;
using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class UserTransactionDetailBusinessData : IUserTransactionDetailBusinessData
    {
        private readonly IDataManager _dataManager;
        private readonly IDataManagerDataTable _dataManagerDataTable;

        public UserTransactionDetailBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
        {
            _dataManager = dataManager;
            _dataManagerDataTable = dataManagerDataTable;
        }

        public bool DeleteUserDetailTransaction(string nop, DateTime tglTransaksi)
        {
            bool result = true;

            using (var transaction = _dataManager.BeginTransaction())
            {
                try
                {
                    UserTransactionDetail userTransactionDetail = _dataManager.GetOne<UserTransactionDetail>((e => e.NOP == nop && e.Transaction_Date == tglTransaksi));

                    if (userTransactionDetail == null)
                        return false;
                    else
                    {
                        _dataManager.Delete(userTransactionDetail);
                        _dataManager.Save();
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    result = false;
                    transaction.Rollback();
                }
            }

            return result;
        }

        public string GetXmlFileByNop(string nop, int bulan, int tahun)
        {
            throw new NotImplementedException();
        }

        public bool InsertUserTransactionDetail(string username, string xmlPath, int bulan, int tahun, DateTime transDate, string ipAddress, string xmlfile, string nop)
        {
            bool result = true;

            using (var transaction = _dataManager.BeginTransaction())
            {
                try
                {
                    _dataManager.Create(new UserTransactionDetail()
                    {
                        Username = username,
                        Xml_Path = xmlPath,
                        Bulan = bulan,
                        Tahun = tahun,
                        Transaction_Date = transDate,
                        Ip_Address = ipAddress,
                        Xml_File = xmlfile,
                        NOP = nop
                    });

                    _dataManager.Save();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    result = false;
                    transaction.Rollback();
                }
            }

            return result;
        }

        public IEnumerable<UserDetailWithPajak> RetrieveTransactionDetailOrderByDate(DateTime tglAWal, DateTime tglAkhir)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserDetailTransactionByDateTransaction(string nop, DateTime tglTransaksi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserDetailTransactionByNop(string nop, DateTime tgltransaksi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByDate(string username, DateTime tgltransaksi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByMonth(string username, int bulan, int tahun)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTransactionDetail> RetrieveUserTransactionDetailByMonth(string username, string nop, int bulan, int tahun)
        {
            throw new NotImplementedException();
        }
    }
}
