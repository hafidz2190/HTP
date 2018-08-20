using POProject.BusinessLogic.BusinessDataModel;
using POProject.Model;
using System;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public interface IUserTransactionBusiness
    {
        bool InsertUserTransaction(string username, DateTime transactionDate, double taxAmount, string ipAddress, string note, bool isAdjustment, string nop);
        bool InsertUserTransactionWithFile(string username, DateTime transactionDate, double taxAmount, string ipAddress, string note, bool isAdjustment, string nop, byte[] file);
        List<UserTransactionBusinessDataModel> RetrieveUserTransaction(string username, DateTime tglTransaction);
        List<UserTransactionBusinessDataModel> RetrieveUserTransactionByNop(string nop, DateTime tglTransaction);
        List<UserTransactionWithJenisPajak> RetrieveUserTransactionBetweenDate(DateTime tglAwal, DateTime tglAkhir);
        IEnumerable<UserTransactionBusinessDataModel> RetrieveUserTransactionByMonth(string username, int monthTransaction, int yearTransaction);
        IEnumerable<UserTransactionBusinessDataModel> RetrieveUserInformationTransactionByMonth(string username, string nop, int monthTransaction, int yearTransaction);
        IEnumerable<UserTransactionBusinessDataModel> RetrieveUserTransactionByMonth(string username, string nop, int monthTransaction, int yearTransaction);
        IEnumerable<UserTransactionBusinessDataModel> RetrieveUserTransactionByDateTransaction(string nop, DateTime tglTransaksi);
        bool UpdatePajakUserTransaction(string username, string nop, DateTime tanggal, double pajak);
        IEnumerable<RekapTransaction> RetrieveRekapResultWp(string username);
        IEnumerable<PaymentTransaction> RetrieveDataPayment(string username, int? tahun2);
        IEnumerable<PaymentTransaction> RetrieveDataPayment(string username, int? tahun, int? tahun2);
        IEnumerable<VwGeneratePayment> RetrieveDataPayment(string username, string nop, int month, int year);
        IEnumerable<PaymentTransaction> GetChartDataBeforeAdjustment(string username, int year, int year2);
        IEnumerable<PaymentTransaction> GetChartDataBeforeAdjustment(string username, int year);
    }
}
