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

        public static DataTable RetrieveUserDetailTransactionByNop(string nop, DateTime tgltransaksi)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            System.Text.StringBuilder sbQuery = new System.Text.StringBuilder();
            sbQuery.Append(@"SELECT rownum, username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun, nop, create_date
                            FROM(
                                SELECT username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun, nop, create_date
                                FROM user_transaction_detail
                                WHERE TRUNC(transaction_date) = TO_DATE(:dateTrans, 'DD/MM/YYYY') "
                          );
            if (!string.IsNullOrEmpty(nop))
            {
                sbQuery.Append("AND nop = :nop ");
                cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
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
            cmd.Query = @"SELECT username, xml_path, transaction_date, ip_address, xml_file, bulan, tahun, nop, create_date
                    FROM user_transaction_detail
                    WHERE nop=:nop AND (transaction_date BETWEEN to_date(:tglAwal,'MM/DD/YYYY') AND to_date(:tglAkhir,'MM/DD/YYYY HH24:MI:SS'))
                    order by create_date desc";

            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            string tglAwal = tglTransaksi.ToString("MM/dd/yyyy", new System.Globalization.CultureInfo("en-US"));
            string tglAkhir = tglTransaksi.ToString("MM/dd/yyyy", new System.Globalization.CultureInfo("en-US")) + " 23:59:59";
            cmd.AddParameter("tglAwal", OracleCmdParameterDirection.Input, tglAwal);
            cmd.AddParameter("tglAkhir", OracleCmdParameterDirection.Input, tglAkhir);

            return cmd.GetTableFirstRowOnly();
        }

        public static DataTable RetrieveDetailOrderByDate(DateTime tglAwal, DateTime tglAkhir)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT to_date(to_char(transaction_date,'MM/DD/YYYY'),'MM/DD/YYYY') transaction_date,bulan, tahun, nop, MAX(create_date) create_Date
            FROM user_transaction_detail
            WHERE trunc(transaction_date) between :tglAwal AND :tglAkhir
            GROUP BY to_date(to_char(transaction_date,'MM/DD/YYYY'),'MM/DD/YYYY'),bulan, tahun, nop
            ORDER BY create_date DESC";

            cmd.AddParameter("tglAwal", OracleCmdParameterDirection.Input, tglAwal.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("en-US")));
            cmd.AddParameter("tglAkhir", OracleCmdParameterDirection.Input, tglAkhir.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("en-US")));

            return cmd.GetTable();
        }

        public static string GetXmlFileByNop(string nop, int bulan, int tahun)
        {
            DataTable dt = new DataTable();
            string xml = string.Empty;
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT xml_file FROM user_transaction_detail 
                        WHERE rownum=1 AND nop=:nop AND bulan=:bln AND tahun=:thn";

            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("bln", OracleCmdParameterDirection.Input, bulan);
            cmd.AddParameter("thn", OracleCmdParameterDirection.Input, tahun);

            dt = cmd.GetTable();

            if (dt != null && dt.Rows.Count > 0)
            {
                xml = dt.Rows[0]["XML_FILE"].ToString();
            }
            else
            {
                xml = "Tidak ada data";
            }

            return xml;
        }

        public static bool DeleteUserDetailTransaction(string nop, DateTime tglTransaksi)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"DELETE FROM user_transaction_detail WHERE nop=:nop AND transaction_date=:tgl";

            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("tgl", OracleCmdParameterDirection.Input, tglTransaksi);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}