using POProject.CommandAdapter;
using System;
using System.Globalization;

namespace POProject.DataAccess
{
    public class UserTransactionData
    {
        public static bool InsertUserTransaction(string username, DateTime tglTransaction, double pajakTerutang, string keterangan, bool isAdjustment,
            string ipSender, string nop)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO user_transaction (username, tanggal, pajak_terutang, keterangan, is_adjusment, createdate, ip_sender, nop)
                            VALUES(:usern, :tgl, :pajak, :keterangan, :isAdj, :createDate, :ipSender,:nop)";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("tgl", OracleCmdParameterDirection.Input, tglTransaction);
            cmd.AddParameter("pajak", OracleCmdParameterDirection.Input, pajakTerutang);
            cmd.AddParameter("keterangan", OracleCmdParameterDirection.Input, keterangan);
            cmd.AddParameter("isAdj", OracleCmdParameterDirection.Input, isAdjustment);
            cmd.AddParameter("createDate", OracleCmdParameterDirection.Input, DateTime.Now);
            cmd.AddParameter("ipSender", OracleCmdParameterDirection.Input, ipSender);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool InsertUserTransaction(string username, DateTime tglTransaction, double pajakTerutang, string keterangan, bool isAdjustment,
           string ipSender, string nop, byte[] file)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO user_transaction 
                            (username, tanggal, pajak_terutang, keterangan, is_adjusment, createdate, ip_sender, nop, file_adjustment)
                            VALUES(:usern, :tgl, :pajak, :keterangan, :isAdj, :createDate, :ipSender,:nop, :fileadjusment)";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("tgl", OracleCmdParameterDirection.Input, tglTransaction);
            cmd.AddParameter("pajak", OracleCmdParameterDirection.Input, pajakTerutang);
            cmd.AddParameter("keterangan", OracleCmdParameterDirection.Input, keterangan);
            cmd.AddParameter("isAdj", OracleCmdParameterDirection.Input, isAdjustment);
            cmd.AddParameter("createDate", OracleCmdParameterDirection.Input, DateTime.Now);
            cmd.AddParameter("ipSender", OracleCmdParameterDirection.Input, ipSender);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("fileadjusment", OracleCmdParameterDirection.Input, file);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static System.Data.DataTable RetrieveUserTransaction(string username, DateTime tglTransaction)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, tanggal, pajak_terutang, keterangan, is_adjusment, createdate, ip_sender, nop, file_adjustment 
                          FROM user_transaction WHERE username=:usern AND trunc(tanggal)=:dateTransaction";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("dateTransaction", OracleCmdParameterDirection.Input, tglTransaction.ToString("dd MMM yyyy", new CultureInfo("en-US")));

            return cmd.GetTable();
        }

        public static System.Data.DataTable RetrieveUserTransactionByNop(string nop, DateTime tglTransaction)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, tanggal, pajak_terutang, keterangan, is_adjusment, createdate, ip_sender, nop, file_adjustment 
                          FROM user_transaction WHERE nop=:nop AND trunc(tanggal)=:dateTransaction and is_generate=1";
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("dateTransaction", OracleCmdParameterDirection.Input, tglTransaction.ToString("dd MMM yyyy", new CultureInfo("en-US")));

            return cmd.GetTable();
        }

        public static System.Data.DataTable RetrieveUserTransactionByMonth(string username, int monthTransaction, int year)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, tanggal, pajak_terutang, keterangan, is_adjusment, createdate, ip_sender ,nop, file_adjustment 
                          FROM user_transaction WHERE username=:usern AND to_char(tanggal,'MM')=:monTrans AND TO_CHAR(tanggal,'YYYY')=:year";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("monTrans", OracleCmdParameterDirection.Input, monthTransaction.ToString("00"));
            cmd.AddParameter("year", OracleCmdParameterDirection.Input, year);

            return cmd.GetTable();
        }

        public static System.Data.DataTable RetrieveUserInformationTransactionByMonth(string username, string nop, int monthTransaction, int year)
        {

            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, tanggal, pajak_terutang, keterangan, is_adjusment, createdate, ip_sender,nop, file_adjustment 
                            FROM(
                            SELECT username, tanggal, pajak_terutang, keterangan, is_adjusment, createdate, ip_sender,nop, file_adjustment, ROW_NUMBER()OVER(PARTITION BY TRUNC(TANGGAL) ORDER BY CREATEDATE DESC) RN
                            FROM user_transaction 
                            WHERE IS_ADJUSMENT = 0 AND to_char(tanggal,'MM')=:monTrans AND TO_CHAR(tanggal,'YYYY')=:year ";
            cmd.AddParameter("monTrans", OracleCmdParameterDirection.Input, monthTransaction.ToString("00"));
            cmd.AddParameter("year", OracleCmdParameterDirection.Input, year);
            if (!string.IsNullOrEmpty(username))
            {
                cmd.Query += @" AND username=:usern ";
                cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            }

            if (!string.IsNullOrEmpty(nop))
            {
                cmd.Query += @" AND nop=:nop ";
                cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            }
            cmd.Query += @" ) WHERE RN = 1";
            return cmd.GetTable();
        }

        //public static System.Data.DataTable RetrieveUserInformationTransactionByMonth(string username, string nop, int monthTransaction, int year)
        //{

        //    OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
        //    cmd.Query = @"SELECT username, tanggal, pajak_terutang, keterangan, is_adjusment, createdate, ip_sender,nop, file_adjustment 
        //                  FROM user_transaction WHERE IS_ADJUSMENT = 0 AND to_char(tanggal,'MM')=:monTrans AND TO_CHAR(tanggal,'YYYY')=:year";
        //    cmd.AddParameter("monTrans", OracleCmdParameterDirection.Input, monthTransaction.ToString("00"));
        //    cmd.AddParameter("year", OracleCmdParameterDirection.Input, year);
        //    if (!string.IsNullOrEmpty(username))
        //    {
        //        cmd.Query += @" AND username=:usern ";
        //        cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
        //    }

        //    if (!string.IsNullOrEmpty(nop))
        //    {
        //        cmd.Query += @" AND nop=:nop ";
        //        cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
        //    }
        //    cmd.Query += @" ORDER BY createdate DESC ";
        //    return cmd.GetTable();
        //}

        public static System.Data.DataTable RetrieveUserTransactionByMonth(string username, string nop, int monthTransaction, int year)
        {

            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, tanggal, pajak_terutang, keterangan, is_adjusment, createdate, ip_sender,nop, file_adjustment 
                          FROM user_transaction WHERE to_char(tanggal,'MM')=:monTrans AND TO_CHAR(tanggal,'YYYY')=:year";


            cmd.AddParameter("monTrans", OracleCmdParameterDirection.Input, monthTransaction.ToString("00"));
            cmd.AddParameter("year", OracleCmdParameterDirection.Input, year);
            if (!string.IsNullOrEmpty(username))
            {
                cmd.Query += @" username=:usern ";
                cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            }

            if (!string.IsNullOrEmpty(nop))
            {
                cmd.Query += @" AND nop=:nop ";
                cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            }

            return cmd.GetTable();
        }

        public static System.Data.DataTable RetrieveUserTransactionByDateTransaction(string nop, DateTime tglTransaksi)
        {

            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, tanggal, pajak_terutang, keterangan, is_adjusment, createdate, ip_sender,nop, file_adjustment 
                          FROM user_transaction WHERE nop =:nop AND tanggal = :tgl";
            cmd.AddParameter("tgl", OracleCmdParameterDirection.Input, tglTransaksi);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            return cmd.GetTable();
        }

        public static bool UpdatePajakUserTransaction(string username, string nop, DateTime tanggal, double pajak)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"UPDATE USER_TRANSACTION SET PAJAK_TERUTANG=:nominal 
            WHERE USERNAME=:usern AND NOP=:nop AND trunc(TANGGAL)=:tgl AND is_adjusment=0";

            cmd.AddParameter("nominal", OracleCmdParameterDirection.Input, pajak);
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("tgl", OracleCmdParameterDirection.Input, tanggal.ToString("dd MMM yyyy"));

            return cmd.ExecuteNonQuery() > 0;
        }

        public static System.Data.DataTable RetrieveRekapResultWp(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();

            cmd.Query = @"select masapajak, tahun,jenis_pajak,sum(pajak_terutang) as total_transaksi
                            from (SELECT * FROM VW_REKAPTRANSACTION)";
            if (!string.IsNullOrEmpty(username))
            {
                cmd.Query += @" WHERE username = :usern ";
                cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            }
            cmd.Query += @" group by masapajak, tahun,jenis_pajak";
            return cmd.GetTable();
        }

        public static System.Data.DataTable RetrieveDataPayment(string username, int? tahun)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"select username, nop,masapajak, tahun,is_generate,
                                    sum(pajak_terutang) as pajak
                            from (
                                select * from vw_generatepayment
                            ) ";
            if (!string.IsNullOrEmpty(username))
            {
                cmd.Query += @"WHERE USERNAME IN (" + username + ") ";
            }

            if (tahun.HasValue)
            {
                if (!cmd.Query.Contains("WHERE"))
                {
                    cmd.Query += @"WHERE tahun =:thn ";
                    cmd.AddParameter("thn", OracleCmdParameterDirection.Input, tahun.Value);
                }
                else
                {
                    cmd.Query += @"AND tahun =:thn";
                    cmd.AddParameter("thn", OracleCmdParameterDirection.Input, tahun.Value);
                }
            }
            cmd.Query += " group by username, nop,masapajak, tahun,is_generate ";
            return cmd.GetTable();
        }

        public static System.Data.DataTable RetrieveAllNopByUsername(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = "SELECT nop FROM user_nop WHERE username in (" + username + @")";

            return cmd.GetTable();
        }

        public static System.Data.DataTable RetrieveUserTransactionBetweenDate(DateTime tglAwal, DateTime tglAkhir)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT a.username,a.tanggal,a.pajak_terutang,a.keterangan,a.is_adjusment,a.createdate,a.ip_sender,a.nop,a.file_adjustment,b.jenis_pajak
                        FROM user_transaction a INNER JOIN user_nop b ON (a.nop=b.nop) 
                        WHERE tanggal BETWEEN :tglAwal AND :tglAkhir";

            cmd.AddParameter("tglAwal", OracleCmdParameterDirection.Input, tglAwal.ToString("dd MMM yyyy"));
            cmd.AddParameter("tglAkhir", OracleCmdParameterDirection.Input, tglAkhir.ToString("dd MMM yyyy"));

            return cmd.GetTable();
        }

        public static System.Data.DataTable RetrieveDataPayment(string nop, int? tahun, int? tahun2)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"select  nop,masapajak, tahun,is_generate,
                                    ROUND(sum(pajak_terutang)) as pajak
                            from (
                                select * from vw_generatepayment WHERE nop in (" + nop + @")
                            ) ";
            if (tahun.HasValue)
            {
                if (tahun2.HasValue)
                {
                    if (!cmd.Query.Contains("WHERE"))
                    {
                        cmd.Query += @"WHERE tahun between :thn and :thn2 ";
                        cmd.AddParameter("thn", OracleCmdParameterDirection.Input, tahun.Value);
                        cmd.AddParameter("thn2", OracleCmdParameterDirection.Input, tahun2.Value);
                    }
                    else
                    {
                        cmd.Query += @"AND tahun between :thn and :thn2 ";
                        cmd.AddParameter("thn", OracleCmdParameterDirection.Input, tahun.Value);
                        cmd.AddParameter("thn2", OracleCmdParameterDirection.Input, tahun2.Value);
                    }
                }
                else
                {
                    if (!cmd.Query.Contains("WHERE"))
                    {
                        cmd.Query += @"WHERE tahun =:thn ";
                        cmd.AddParameter("thn", OracleCmdParameterDirection.Input, tahun.Value);
                    }
                    else
                    {
                        cmd.Query += @"AND tahun =:thn";
                        cmd.AddParameter("thn", OracleCmdParameterDirection.Input, tahun.Value);
                    }
                }

            }

            cmd.Query += " group by  nop,masapajak, tahun,is_generate ";

            return cmd.GetTable();
        }

        public static System.Data.DataTable RetrieveDataPayment(string username, string nop, int month, int year)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT USERNAME, TANGGAL, KETERANGAN, IS_ADJUSMENT, PAJAK_TERUTANG, NOP,MASAPAJAK, TAHUN
                             FROM VW_GENERATEPAYMENT 
                        WHERE nop IN (" + nop + ") and masapajak=:monTrans AND tahun=:year";
            //cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("monTrans", OracleCmdParameterDirection.Input, month.ToString("00"));
            cmd.AddParameter("year", OracleCmdParameterDirection.Input, year);
            return cmd.GetTable();
        }

        public static System.Data.DataTable GetChartDataBeforeAdjustment(string username, int year, int year2)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"select username, nop, to_char(tanggal,'MM') masapajak, to_char(tanggal,'yyyy') tahun, sum(pajak_terutang) pajak
                            from user_transaction
                            where is_adjusment = 0 AND to_char(tanggal,'yyyy') between :thn and :thn2";
            cmd.AddParameter("thn", OracleCmdParameterDirection.Input, year);
            cmd.AddParameter("thn2", OracleCmdParameterDirection.Input, year2);
            if (!string.IsNullOrEmpty(username))
            {
                cmd.Query += @" and username IN (" + username + ")";
                //cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            }
            cmd.Query += @" group by username, nop, to_char(tanggal,'MM'), to_char(tanggal,'yyyy')";
            return cmd.GetTable();
        }

        public static System.Data.DataTable GetChartDataBeforeAdjustment(string username, int year)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"select username, nop, to_char(tanggal,'MM') masapajak, to_char(tanggal,'yyyy') tahun, sum(pajak_terutang) pajak
                            from user_transaction
                            where is_adjusment = 0 AND to_char(tanggal,'yyyy')=:thn";
            cmd.AddParameter("thn", OracleCmdParameterDirection.Input, year);
            if (!string.IsNullOrEmpty(username))
            {
                cmd.Query += @" and username IN (" + username + ")";
                //cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            }
            cmd.Query += @" group by username, nop, to_char(tanggal,'MM'), to_char(tanggal,'yyyy')";
            return cmd.GetTable();
        }
    }
}
