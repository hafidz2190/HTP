using POProject.DataAccess;
using POProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace POProject.BusinessLogic.BusinessData
{
    public class UserTransactionBusinessDataOracleCommand : IUserTransactionBusinessData
    {
        public bool InsertUserTransaction(string username, DateTime transactionDate, double taxAmount, string ipAddress, string note, bool isAdjustment, string nop)
        {
            return UserTransactionData.InsertUserTransaction(username, transactionDate, taxAmount, note, isAdjustment, ipAddress, nop);
        }

        public bool InsertUserTransactionWithFile(string username, DateTime transactionDate, double taxAmount, string ipAddress,
            string note, bool isAdjustment, string nop, byte[] file)
        {
            return UserTransactionData.InsertUserTransaction(username, transactionDate, taxAmount, note, isAdjustment, ipAddress, nop, file);
        }

        public List<UserTransaction> RetrieveUserTransaction(string username, DateTime tglTransaction)
        {
            return UserTransactionData.RetrieveUserTransaction(username, tglTransaction).AsEnumerable<UserTransaction>().ToList();
        }

        public List<UserTransaction> RetrieveUserTransactionByNop(string nop, DateTime tglTransaction)
        {
            return UserTransactionData.RetrieveUserTransactionByNop(nop, tglTransaction).AsEnumerable<UserTransaction>().ToList();
        }

        public List<UserTransactionWithJenisPajak> RetrieveUserTransactionBetweenDate(DateTime tglAwal, DateTime tglAkhir)
        {
            return UserTransactionData.RetrieveUserTransactionBetweenDate(tglAwal, tglAkhir).AsEnumerable<UserTransactionWithJenisPajak>().ToList();
        }

        public IEnumerable<UserTransaction> RetrieveUserTransactionByMonth(string username, int monthTransaction, int yearTransaction)
        {
            return UserTransactionData.RetrieveUserTransactionByMonth(username, monthTransaction, yearTransaction).AsEnumerable<UserTransaction>();
        }

        public IEnumerable<UserTransaction> RetrieveUserInformationTransactionByMonth(string username, string nop, int monthTransaction, int yearTransaction)
        {
            return UserTransactionData.RetrieveUserInformationTransactionByMonth(username, nop, monthTransaction, yearTransaction).AsEnumerable<UserTransaction>();
        }

        public IEnumerable<UserTransaction> RetrieveUserTransactionByMonth(string username, string nop, int monthTransaction, int yearTransaction)
        {
            return UserTransactionData.RetrieveUserTransactionByMonth(username, nop, monthTransaction, yearTransaction).AsEnumerable<UserTransaction>();
        }

        public IEnumerable<UserTransaction> RetrieveUserTransactionByDateTransaction(string nop, DateTime tglTransaksi)
        {
            return UserTransactionData.RetrieveUserTransactionByDateTransaction(nop, tglTransaksi).AsEnumerable<UserTransaction>();
        }

        public bool UpdatePajakUserTransaction(string username, string nop, DateTime tanggal, double pajak)
        {
            return UserTransactionData.UpdatePajakUserTransaction(username, nop, tanggal, pajak);
        }

        public IEnumerable<RekapTransaction> RetrieveRekapResultWp(string username)
        {
            return UserTransactionData.RetrieveRekapResultWp(username).AsEnumerable<RekapTransaction>();
        }

        public IEnumerable<PaymentTransaction> RetrieveDataPayment(string username, int? tahun2)
        {
            return UserTransactionData.RetrieveDataPayment(username, tahun2).AsEnumerable<PaymentTransaction>();
        }

        public IEnumerable<PaymentTransaction> RetrieveDataPayment(string username, int? tahun, int? tahun2)
        {
            string allNop = string.Empty;
            DataTable dt = new DataTable();
            dt = UserTransactionData.RetrieveAllNopByUsername(username);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    allNop += "'" + item["NOP"].ToString() + "'" + ",";
                }
                allNop = allNop.Remove(allNop.Length - 1);
            }
            return UserTransactionData.RetrieveDataPayment(allNop, tahun, tahun2).AsEnumerable<PaymentTransaction>();
        }

        public IEnumerable<VwGeneratePayment> RetrieveDataPayment(string username, string nop, int month, int year)
        {
            return UserTransactionData.RetrieveDataPayment(username, nop, month, year).AsEnumerable<VwGeneratePayment>();
        }

        public IEnumerable<PaymentTransaction> GetChartDataBeforeAdjustment(string username, int year, int year2)
        {
            return UserTransactionData.GetChartDataBeforeAdjustment(username, year, year2).AsEnumerable<PaymentTransaction>();
        }

        public IEnumerable<PaymentTransaction> GetChartDataBeforeAdjustment(string username, int year)
        {
            return UserTransactionData.GetChartDataBeforeAdjustment(username, year).AsEnumerable<PaymentTransaction>();
        }
    }
}