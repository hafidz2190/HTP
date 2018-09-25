using System;
using System.Collections.Generic;
using System.Linq;
using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class UserTransactionBusinessData : IUserTransactionBusinessData
    {
        private readonly IDataManager _dataManager;
        private readonly IDataManagerDataTable _dataManagerDataTable;

        public UserTransactionBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
        {
            _dataManager = dataManager;
            _dataManagerDataTable = dataManagerDataTable;
        }

        public IEnumerable<PaymentTransaction> GetChartDataBeforeAdjustment(string username, int year, int year2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentTransaction> GetChartDataBeforeAdjustment(string username, int year)
        {
            throw new NotImplementedException();
        }

        public bool InsertUserTransaction(string username, DateTime transactionDate, double taxAmount, string ipAddress, string note, bool isAdjustment, string nop)
        {
            bool result = true;

            using (var transaction = _dataManager.BeginTransaction())
            {
                try
                {
                    _dataManager.Create(new UserTransaction()
                    {
                        Username = username,
                        Tanggal = transactionDate,
                        Pajak_Terutang = taxAmount,
                        Ip_Sender = ipAddress,
                        Keterangan = note,
                        Is_Adjusment = isAdjustment,
                        Nop = nop
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

        public bool InsertUserTransactionWithFile(string username, DateTime transactionDate, double taxAmount, string ipAddress, string note, bool isAdjustment, string nop, byte[] file)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentTransaction> RetrieveDataPayment(string username, int? tahun2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentTransaction> RetrieveDataPayment(string username, int? tahun, int? tahun2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VwGeneratePayment> RetrieveDataPayment(string username, string nop, int month, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RekapTransaction> RetrieveRekapResultWp(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTransaction> RetrieveUserInformationTransactionByMonth(string username, string nop, int monthTransaction, int yearTransaction)
        {
            throw new NotImplementedException();
        }

        public List<UserTransaction> RetrieveUserTransaction(string username, DateTime tglTransaction)
        {
            throw new NotImplementedException();
        }

        public List<UserTransactionWithJenisPajak> RetrieveUserTransactionBetweenDate(DateTime tglAwal, DateTime tglAkhir)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTransaction> RetrieveUserTransactionByDateTransaction(string nop, DateTime tglTransaksi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTransaction> RetrieveUserTransactionByMonth(string username, int monthTransaction, int yearTransaction)
        {
            return _dataManager.Get<UserTransaction>((e => e.Username == username && e.Tanggal.Month == monthTransaction && e.Tanggal.Year == yearTransaction)).ToList();
        }

        public IEnumerable<UserTransaction> RetrieveUserTransactionByMonth(string username, string nop, int monthTransaction, int yearTransaction)
        {
            throw new NotImplementedException();
        }

        public List<UserTransaction> RetrieveUserTransactionByNop(string nop, DateTime tglTransaction)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePajakUserTransaction(string username, string nop, DateTime tanggal, double pajak)
        {
            bool result = true;

            using (var transaction = _dataManager.BeginTransaction())
            {
                try
                {
                    UserTransaction userTransaction = _dataManager.GetOne<UserTransaction>((e => e.Username == username && e.Nop == nop && e.Tanggal == tanggal && e.Is_Adjusment == false));

                    if (userTransaction == null)
                        return false;
                    else
                    {
                        userTransaction.Pajak_Terutang = pajak;
                        _dataManager.Update(userTransaction);
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
    }
}
