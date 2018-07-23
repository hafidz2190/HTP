using POProject.BusinessLogic.Entity;
using POProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class UserTransactionBusiness
    {
        public static bool InsertUserTransaction(string username, DateTime transactionDate, double taxAmount, string ipAddress, string note, bool isAdjustment, string nop)
        {
            return UserTransactionData.InsertUserTransaction(username, transactionDate, taxAmount, note, isAdjustment, ipAddress, nop);
        }

        public static bool InsertUserTransactionWithFile(string username, DateTime transactionDate, double taxAmount, string ipAddress, 
            string note, bool isAdjustment, string nop, byte[] file)
        {
            return UserTransactionData.InsertUserTransaction(username, transactionDate, taxAmount, note, isAdjustment, ipAddress, nop, file);
        }
        public static List<UserTransaction> RetrieveUserTransaction(string username, DateTime tglTransaction)
        {
            return UserTransactionData.RetrieveUserTransaction(username, tglTransaction).AsEnumerable<UserTransaction>().ToList();
        }

        public static List<UserTransaction> RetrieveUserTransactionByNop(string nop, DateTime tglTransaction)
        {
            return UserTransactionData.RetrieveUserTransactionByNop(nop, tglTransaction).AsEnumerable<UserTransaction>().ToList();
        }

        public static IEnumerable<UserTransaction> RetrieveUserTransactionByMonth(string username, int monthTransaction, int yearTransaction)
        {
            return UserTransactionData.RetrieveUserTransactionByMonth(username, monthTransaction, yearTransaction).AsEnumerable<UserTransaction>();
        }

        public static IEnumerable<UserTransaction> RetrieveUserInformationTransactionByMonth(string username, string nop, int monthTransaction, int yearTransaction)
        {
            return UserTransactionData.RetrieveUserInformationTransactionByMonth(username, nop, monthTransaction, yearTransaction).AsEnumerable<UserTransaction>();
        }

        public static IEnumerable<UserTransaction> RetrieveUserTransactionByMonth(string username, string nop, int monthTransaction, int yearTransaction)
        {
            return UserTransactionData.RetrieveUserTransactionByMonth(username, nop, monthTransaction, yearTransaction).AsEnumerable<UserTransaction>();
        }

        public static IEnumerable<UserTransaction> RetrieveUserTransactionByDateTransaction(string nop,DateTime tglTransaksi)
        {
            return UserTransactionData.RetrieveUserTransactionByDateTransaction(nop,tglTransaksi).AsEnumerable<UserTransaction>();
        }

        public static bool UpdatePajakUserTransaction(string username, string nop, DateTime tanggal, double pajak)
        {
            return UserTransactionData.UpdatePajakUserTransaction(username, nop, tanggal, pajak);
        }

        public static IEnumerable<RekapTransaction> RetrieveRekapResultWp(string username)
        {
            return UserTransactionData.RetrieveRekapResultWp(username).AsEnumerable<RekapTransaction>();
        }

        public static IEnumerable<PaymentTransaction> RetrieveDataPayment(string username, int? tahun2)
        {
            return UserTransactionData.RetrieveDataPayment(username, tahun2).AsEnumerable<PaymentTransaction>();
        }

        public static IEnumerable<PaymentTransaction> RetrieveDataPayment(string username, int? tahun, int? tahun2)
        {
            return UserTransactionData.RetrieveDataPayment(username, tahun, tahun2).AsEnumerable<PaymentTransaction>();
        }

        public static IEnumerable<VwGeneratePayment> RetrieveDataPayment(string username, string nop, int month, int year)
        {
            return UserTransactionData.RetrieveDataPayment(username, nop, month, year).AsEnumerable<VwGeneratePayment>();
        }

        public static IEnumerable<PaymentTransaction> GetChartDataBeforeAdjustment(string username, int year, int year2)
        {
            return UserTransactionData.GetChartDataBeforeAdjustment(username, year, year2).AsEnumerable<PaymentTransaction>();
        }

        public static IEnumerable<PaymentTransaction> GetChartDataBeforeAdjustment(string username, int year)
        {
            return UserTransactionData.GetChartDataBeforeAdjustment(username, year).AsEnumerable<PaymentTransaction>();
        }
    }
}
