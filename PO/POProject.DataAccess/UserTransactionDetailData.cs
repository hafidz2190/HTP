using POProject.CommandAdapter;
using System;
using System;
using System.Data;

namespace POProject.DataAccess
{
    public class UserTransactionDetailData
    {
        public static bool InsertUserTransactionDetail(string username, string xmlPath, DateTime sendDate, string ipAddress, string xmlfile, int bulan, int tahun)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO USER_TRANSACTION_DETAIL (username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun)
                            VALUES(:usern, :xmlpath, :senddate, :ipaddress, :xmlfile, :bln, :thn)";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("xmlpath", OracleCmdParameterDirection.Input, xmlPath);
            cmd.AddParameter("senddate", OracleCmdParameterDirection.Input, sendDate);
            cmd.AddParameter("ipaddress", OracleCmdParameterDirection.Input, ipAddress);
            cmd.AddParameter("xmlfile", OracleCmdParameterDirection.Input, xmlfile);
            cmd.AddParameter("bln", OracleCmdParameterDirection.Input, bulan);
            cmd.AddParameter("thn", OracleCmdParameterDirection.Input, tahun);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool InsertUserTransactionDetail(string username, string xmlPath, int month, int year, DateTime sendDate, string ipAddress, string xmlfile, string nop)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO USER_TRANSACTION_DETAIL (username, xml_path, bulan, tahun, transaction_date, ip_address, xml_file,nop)
                            VALUES(:usern, :xmlpath,:bulan,:tahun, :senddate, :ipaddress, :xmlfile,:nop)";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("xmlpath", OracleCmdParameterDirection.Input, xmlPath);
            cmd.AddParameter("bulan", OracleCmdParameterDirection.Input, month);
            cmd.AddParameter("tahun", OracleCmdParameterDirection.Input, year);
            cmd.AddParameter("senddate", OracleCmdParameterDirection.Input, sendDate);
            cmd.AddParameter("ipaddress", OracleCmdParameterDirection.Input, ipAddress);
            cmd.AddParameter("xmlfile", OracleCmdParameterDirection.Input, xmlfile);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static DataTable RetrieveUserDetailTransactionByMonth(string username, int month, int year)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun, nop
                    FROM user_transaction_detail
                    WHERE bulan=:bln AND tahun=:thn";
            if (!string.IsNullOrEmpty(username))
            {
                cmd.Query += " AND username = :usern ";
                cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            }
            cmd.AddParameter("bln", OracleCmdParameterDirection.Input, month);
            cmd.AddParameter("thn", OracleCmdParameterDirection.Input, year);

            return cmd.GetTable();
        }

        public static DataTable RetrieveUserDetailTransactionByDate(string username, DateTime tgltransaksi)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            System.Text.StringBuilder sbQuery = new System.Text.StringBuilder();
            sbQuery.Append(@"SELECT rownum, username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun, nop, create_date
                            FROM(
                                SELECT username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun, nop, create_date
                                FROM user_transaction_detail
                                WHERE TRUNC(transaction_date) = TO_DATE(:dateTrans, 'DD/MM/YYYY') "
                          );

            //cmd.Query = @"SELECT rownum, username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun, nop, create_date
            //            FROM (
            //                SELECT username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun, nop, create_date
            //                                FROM user_transaction_detail
            //                                WHERE TRUNC(transaction_date) = TO_DATE(:dateTrans,'DD/MM/YYYY') and username = :usernm
            //                                ORDER BY create_date DESC
            //            ) WHERE rownum = 1";
            if (!string.IsNullOrEmpty(username))
            {
                sbQuery.Append("AND username = :usern ");
                cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            }

            sbQuery.Append(" ORDER BY create_date DESC) WHERE rownum = 1");
            cmd.Query = sbQuery.ToString();
            cmd.AddParameter("dateTrans", OracleCmdParameterDirection.Input, tgltransaksi.ToString("dd/MM/yyyy"));

            return cmd.GetTable();
        }

        public static DataTable RetrieveUserDetailTransactionByMonth(string username, string nop, int month, int year)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun, nop
                    FROM user_transaction_detail
                    WHERE bulan=:bln AND tahun=:thn ";
            cmd.AddParameter("bln", OracleCmdParameterDirection.Input, month);
            cmd.AddParameter("thn", OracleCmdParameterDirection.Input, year);
            if (!string.IsNullOrEmpty(username))
            {
                cmd.Query += " AND username = :usern ";
                cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            }

            if (!string.IsNullOrEmpty(nop))
            {
                cmd.Query += " AND NOP =:nop ";
                cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            }
            
            return cmd.GetTable();
        }

        public static DataTable RetrieveUserDetailTransactionByDateTransaction(string nop, DateTime tglTransaksi)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun, nop
                    FROM user_transaction_detail
                    WHERE transaction_date =:tgl
                    AND nop=:nop";
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("tgl", OracleCmdParameterDirection.Input, tglTransaksi);
            return cmd.GetTable();
        }
    }
}