using POProject.BusinessLogic.BusinessData;
using POProject.BusinessLogic.BusinessDataModel;
using POProject.BusinessLogic.Helper;
using POProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class UserTransactionBusiness : IUserTransactionBusiness
    {
        private readonly IUserTransactionBusinessData _userTransactionBusinessData;

        public UserTransactionBusiness(IUserTransactionBusinessData userTransactionBusinessData)
        {
            _userTransactionBusinessData = userTransactionBusinessData;
        }

        public bool InsertUserTransaction(string username, DateTime transactionDate, double taxAmount, string ipAddress, string note, bool isAdjustment, string nop)
        {
            return _userTransactionBusinessData.InsertUserTransaction(username, transactionDate, taxAmount, ipAddress, note, isAdjustment, nop);
        }

        public bool InsertUserTransactionWithFile(string username, DateTime transactionDate, double taxAmount, string ipAddress, string note, bool isAdjustment, string nop, byte[] file)
        {
            return _userTransactionBusinessData.InsertUserTransactionWithFile(username, transactionDate, taxAmount, ipAddress, note, isAdjustment, nop, file);
        }

        public List<UserTransactionBusinessDataModel> RetrieveUserTransaction(string username, DateTime tglTransaction)
        {
            return ModelToBusinessModelMapper.Convert<UserTransaction, UserTransactionBusinessDataModel>(_userTransactionBusinessData.RetrieveUserTransaction(username, tglTransaction));
        }

        public List<UserTransactionBusinessDataModel> RetrieveUserTransactionByNop(string nop, DateTime tglTransaction)
        {
            return ModelToBusinessModelMapper.Convert<UserTransaction, UserTransactionBusinessDataModel>(_userTransactionBusinessData.RetrieveUserTransactionByNop(nop, tglTransaction));
        }

        public List<UserTransactionWithJenisPajak> RetrieveUserTransactionBetweenDate(DateTime tglAwal, DateTime tglAkhir)
        {
            return _userTransactionBusinessData.RetrieveUserTransactionBetweenDate(tglAwal, tglAkhir);
        }

        public IEnumerable<UserTransactionBusinessDataModel> RetrieveUserTransactionByMonth(string username, int monthTransaction, int yearTransaction)
        {
            return ModelToBusinessModelMapper.Convert<UserTransaction, UserTransactionBusinessDataModel>(_userTransactionBusinessData.RetrieveUserTransactionByMonth(username, monthTransaction, yearTransaction).ToList());
        }

        public IEnumerable<UserTransactionBusinessDataModel> RetrieveUserInformationTransactionByMonth(string username, string nop, int monthTransaction, int yearTransaction)
        {
            return ModelToBusinessModelMapper.Convert<UserTransaction, UserTransactionBusinessDataModel>(_userTransactionBusinessData.RetrieveUserInformationTransactionByMonth(username, nop, monthTransaction, yearTransaction).ToList());
        }

        public IEnumerable<UserTransactionBusinessDataModel> RetrieveUserTransactionByMonth(string username, string nop, int monthTransaction, int yearTransaction)
        {
            return ModelToBusinessModelMapper.Convert<UserTransaction, UserTransactionBusinessDataModel>(_userTransactionBusinessData.RetrieveUserTransactionByMonth(username, nop, monthTransaction, yearTransaction).ToList());
        }

        public IEnumerable<UserTransactionBusinessDataModel> RetrieveUserTransactionByDateTransaction(string nop, DateTime tglTransaksi)
        {
            return ModelToBusinessModelMapper.Convert<UserTransaction, UserTransactionBusinessDataModel>(_userTransactionBusinessData.RetrieveUserTransactionByDateTransaction(nop, tglTransaksi).ToList());
        }

        public bool UpdatePajakUserTransaction(string username, string nop, DateTime tanggal, double pajak)
        {
            return _userTransactionBusinessData.UpdatePajakUserTransaction(username, nop, tanggal, pajak);
        }

        public IEnumerable<RekapTransaction> RetrieveRekapResultWp(string username)
        {
            return _userTransactionBusinessData.RetrieveRekapResultWp(username);
        }

        public IEnumerable<PaymentTransaction> RetrieveDataPayment(string username, int? tahun2)
        {
            return _userTransactionBusinessData.RetrieveDataPayment(username, tahun2);
        }

        public IEnumerable<PaymentTransaction> RetrieveDataPayment(string username, int? tahun, int? tahun2)
        {
            return _userTransactionBusinessData.RetrieveDataPayment(username, tahun, tahun2);
        }

        public IEnumerable<VwGeneratePayment> RetrieveDataPayment(string username, string nop, int month, int year)
        {
            return _userTransactionBusinessData.RetrieveDataPayment(username, nop, month, year);
        }

        public IEnumerable<PaymentTransaction> GetChartDataBeforeAdjustment(string username, int year, int year2)
        {
            return _userTransactionBusinessData.GetChartDataBeforeAdjustment(username, year, year2);
        }

        public IEnumerable<PaymentTransaction> GetChartDataBeforeAdjustment(string username, int year)
        {
            return _userTransactionBusinessData.GetChartDataBeforeAdjustment(username, year);
        }
    }
}
