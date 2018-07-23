using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace POAdministrationTools
{
    public class DataParser
    {
        public static bool TesOracleConnection(string DataSource, string Username, string Password, out string pesan)
        {
            string errMsg = string.Empty;
            pesan = string.Empty;
            bool isConnect = false;

            try
            {
                POProject.CommandAdapter.OracleCmdBuilder cmd = new POProject.CommandAdapter.OracleCmdBuilder(DataSource, Username, Password);
                if (cmd.TestConnection(out errMsg))
                {
                    pesan = "Koneksi Berhasil";
                    isConnect = true;
                }
                else
                    pesan = "Koneksi Gagal : " + errMsg;
            }
            catch (Exception ex)
            {
                pesan = "Koneksi Gagal : " + ex.Message;
            }

            return isConnect;
        }

        public static bool TesSQLConnection(string server, string database, string username, string password, out string pesan)
        {
            bool isConnect = false;
            pesan = string.Empty;
            string errMsg = string.Empty;
            try
            {
                POProject.CommandAdapter.SqlCmdBuilder cmd = new POProject.CommandAdapter.SqlCmdBuilder(server, database, username, password);
                if (cmd.TestConnection(out errMsg))
                {
                    pesan = "Koneksi Berhasil";
                    isConnect = true;
                }
                else
                    pesan = "Koneksi Gagal : " + errMsg;
            }
            catch (Exception ex)
            {
                pesan = "Koneksi Gagal : " + ex.Message;
            }

            return isConnect;
        }

        public static bool TesMySqlConnection(string server, string database, string username, string password, out string pesan)
        {
            bool isConnect = false;
            pesan = string.Empty;
            string errMsg = string.Empty;
            try
            {
                POProject.CommandAdapter.MySqlCmdBuilder cmd = new POProject.CommandAdapter.MySqlCmdBuilder(server, database, username, password);
                if (cmd.TestConnection(out errMsg))
                {
                    pesan = "Koneksi Berhasil";
                    isConnect = true;
                }
                else
                    pesan = "Koneksi Gagal : " + errMsg;
            }
            catch (Exception ex)
            {
                pesan = "Koneksi Gagal : " + ex.Message;
            }

            return isConnect;
        }

        public static bool TesAccessConnection(string path, string password, out string pesan)
        {
            bool isConnect = false;
            pesan = string.Empty;
            string errMsg = string.Empty;
            try
            {
                POProject.CommandAdapter.MsAccessCmdBuilder cmd = new POProject.CommandAdapter.MsAccessCmdBuilder(path, password);
                if (cmd.TestConnection(out errMsg))
                {
                    pesan = "Koneksi Berhasil";
                    isConnect = true;
                }
                else
                    pesan = "Koneksi Gagal : " + errMsg;
            }
            catch (Exception ex)
            {
                pesan = "Koneksi Gagal : " + ex.Message;
            }

            return isConnect;
        }

        public static void OracleDataParser(DataTable dtSource, string queryPajak, string queryLampiran, DateTime LastErrDate, DateTime Serverdate, out DataTable dtPajak, out DataTable dtLampiran)
        {
            string oracleDatasource = dtSource.Select("NAME='tbOracleDataSource'").FirstOrDefault().Field<string>("VALUE");
            string oracleUserId = dtSource.Select("NAME='tbOracleUsername'").FirstOrDefault().Field<string>("VALUE");
            string oraclePassword = dtSource.Select("NAME='tbOraclePassword'").FirstOrDefault().Field<string>("VALUE");
            //query get pajak
            POProject.CommandAdapter.OracleCmdBuilder cmdOra = new POProject.CommandAdapter.OracleCmdBuilder(oracleDatasource, oracleUserId, oraclePassword);
            //cmdOra.Query = "SELECT * FROM (" + queryPajak + ") WHERE TRUNC(TGL_TRANSAKSI) BETWEEN :tglAwal AND :tglAkhir";
            cmdOra.Query = queryPajak;

            cmdOra.AddParameter("tglAwal", POProject.CommandAdapter.OracleCmdParameterDirection.Input, LastErrDate.ToString("dd-MMM-yyyy", new CultureInfo("en-US")));
            cmdOra.AddParameter("tglAkhir", POProject.CommandAdapter.OracleCmdParameterDirection.Input, Serverdate.ToString("dd-MMM-yyyy", new CultureInfo("en-US")));

            dtPajak = cmdOra.GetTable();
            //query get detail
            cmdOra = new POProject.CommandAdapter.OracleCmdBuilder(oracleDatasource, oracleUserId, oraclePassword);
            cmdOra.Query = queryLampiran;

            cmdOra.AddParameter("tglAwal", POProject.CommandAdapter.OracleCmdParameterDirection.Input, LastErrDate.ToString("dd-MMM-yyyy", new CultureInfo("en-US")));
            cmdOra.AddParameter("tglAkhir", POProject.CommandAdapter.OracleCmdParameterDirection.Input, Serverdate.ToString("dd-MMM-yyyy", new CultureInfo("en-US")));

            dtLampiran = cmdOra.GetTable();

        }

        public static void MySqlDataParser(DataTable dtSource, string queryPajak, string queryLampiran, DateTime LastErrDate, DateTime Serverdate, out DataTable dtPajak, out DataTable dtLampiran)
        {

            string mySqlServer = dtSource.Select("NAME='tbMySqlServer'").FirstOrDefault().Field<string>("VALUE");
            string mySqlDatabase = dtSource.Select("NAME='tbMySqlDatabase'").FirstOrDefault().Field<string>("VALUE");
            string mySqlUserId = dtSource.Select("NAME='tbMySqlUsername'").FirstOrDefault().Field<string>("VALUE");
            string mySqlPassword = dtSource.Select("NAME='tbMySqlPassword'").FirstOrDefault().Field<string>("VALUE");
            //get pajak
            POProject.CommandAdapter.MySqlCmdBuilder cmdMySql = new POProject.CommandAdapter.MySqlCmdBuilder(mySqlServer, mySqlDatabase, mySqlUserId, mySqlPassword);
            //cmdMySql.Query = "SELECT * FROM (" + queryPajak + ") al WHERE DATE(TGL_TRANSAKSI) BETWEEN ?tglAwal AND ?tglAkhir ";
            cmdMySql.Query = queryPajak;

            cmdMySql.AddParameter("tglAwal", ParameterDirection.Input, LastErrDate.ToString("yyyy-MM-dd"));
            cmdMySql.AddParameter("tglAkhir", ParameterDirection.Input, Serverdate.ToString("yyyy-MM-dd"));

            dtPajak = cmdMySql.GetTable();
            //get detail
            cmdMySql = new POProject.CommandAdapter.MySqlCmdBuilder(mySqlServer, mySqlDatabase, mySqlUserId, mySqlPassword);
            //cmdMySql.Query = "SELECT * FROM (" + queryLampiran + ") al WHERE DATE(" + colTglName + ") BETWEEN ?tglAwal AND ?tglAkhir ";
            cmdMySql.Query = queryLampiran;

            cmdMySql.AddParameter("tglAwal", ParameterDirection.Input, LastErrDate.ToString("yyyy-MM-dd"));
            cmdMySql.AddParameter("tglAkhir", ParameterDirection.Input, Serverdate.ToString("yyyy-MM-dd"));

            dtLampiran = cmdMySql.GetTable();
        }

        public static void SQLDataParser(DataTable dtSource, string queryPajak, string queryLampiran, DateTime LastErrDate, DateTime ServerDate, out DataTable dtPajak, out DataTable dtLampiran)
        {
            string SqlServer = dtSource.Select("NAME='tbSqlServer'").FirstOrDefault().Field<string>("VALUE");
            string SqlDatabase = dtSource.Select("NAME='tbSqlDatabase'").FirstOrDefault().Field<string>("VALUE");
            string SqlUserId = dtSource.Select("NAME='tbSqlUsername'").FirstOrDefault().Field<string>("VALUE");
            string SqlPassword = dtSource.Select("NAME='tbSqlPassword'").FirstOrDefault().Field<string>("VALUE");
            //get Pajak
            POProject.CommandAdapter.SqlCmdBuilder cmdSql = new POProject.CommandAdapter.SqlCmdBuilder(SqlServer, SqlDatabase, SqlUserId, SqlPassword);
            //cmdSql.Query = "SELECT * FROM (" + queryPajak + ") WHERE " + colTglName + " BETWEEN @tglAwal AND @tglAkhir ";
            cmdSql.Query = queryPajak;

            cmdSql.AddParameter("tglAwal", ParameterDirection.Input, LastErrDate.ToString("yyyy-MM-dd"));
            cmdSql.AddParameter("tglAkhir", ParameterDirection.Input, ServerDate.ToString("yyyy-MM-dd"));

            dtPajak = cmdSql.GetTable();
            //get detail
            cmdSql = new POProject.CommandAdapter.SqlCmdBuilder(SqlServer, SqlDatabase, SqlUserId, SqlPassword);
            //cmdSql.Query = "SELECT * FROM (" + queryLampiran + ") WHERE " + colTglName + " BETWEEN @tglAwal AND @tglAkhir ";
            cmdSql.Query = queryLampiran;

            cmdSql.AddParameter("tglAwal", ParameterDirection.Input, LastErrDate.ToString("yyyy-MM-dd"));
            cmdSql.AddParameter("tglAkhir", ParameterDirection.Input, ServerDate.ToString("yyyy-MM-dd"));

            dtLampiran = cmdSql.GetTable();

        }

        public static void AccessDataParser(DataTable dtSource, string queryPajak, string queryLampiran, DateTime LastErrDate, DateTime ServerDate, out DataTable dtPajak, out DataTable dtLampiran)
        {
            string AccessPath = dtSource.Select("NAME='tbAccessPath'").FirstOrDefault().Field<string>("VALUE");
            string AccessPassword = dtSource.Select("NAME='tbAccessPassword'").FirstOrDefault().Field<string>("VALUE");
            //get Pajak
            POProject.CommandAdapter.MsAccessCmdBuilder cmdAccess = new POProject.CommandAdapter.MsAccessCmdBuilder(AccessPath, AccessPassword);
            //cmdAccess.Query = "SELECT * FROM (" + queryPajak + ") WHERE " + colTglName + " BETWEEN @tglAwal AND @tglAkhir";
            cmdAccess.Query = queryPajak;

            cmdAccess.AddParameter("@tglAwal", ParameterDirection.Input, LastErrDate.ToString("yyyy-MM-dd"));
            cmdAccess.AddParameter("@tglAkhir", ParameterDirection.Input, ServerDate.ToString("yyyy-MM-dd"));
            dtPajak = cmdAccess.GetTable();

            //get Detail
            cmdAccess = new POProject.CommandAdapter.MsAccessCmdBuilder(AccessPath, AccessPassword);
            //cmdAccess.Query = "SELECT * FROM (" + queryLampiran + ") WHERE " + colTglName + " BETWEEN @tglAwal AND @tglAkhir";
            cmdAccess.Query = queryLampiran;

            cmdAccess.AddParameter("@tglAwal", ParameterDirection.Input, LastErrDate.ToString("yyyy-MM-dd"));
            cmdAccess.AddParameter("@tglAkhir", ParameterDirection.Input, ServerDate.ToString("yyyy-MM-dd"));
            dtLampiran = cmdAccess.GetTable();
        }

        public static void CekValidQuery(string query, string DBConnector, Dictionary<string, string> dictDbConnector, out DataTable dt)
        {
            dt = new DataTable();
            switch (DBConnector)
            {
                case "ORACLE":
                    POProject.CommandAdapter.OracleCmdBuilder cmdOra = new POProject.CommandAdapter.OracleCmdBuilder(dictDbConnector["tbOracleDataSource"].ToString(),
                        dictDbConnector["tbOracleUsername"].ToString(), dictDbConnector["tbOraclePassword"].ToString());

                    cmdOra.Query = query;

                    if (query.Contains("tglAwal") && query.Contains("tglAkhir"))
                    {
                        cmdOra.AddParameter("tglAwal", POProject.CommandAdapter.OracleCmdParameterDirection.Input, DateTime.Now.ToString("dd-MMM-yyyy", new CultureInfo("en-US")));
                        cmdOra.AddParameter("tglAkhir", POProject.CommandAdapter.OracleCmdParameterDirection.Input, DateTime.Now.ToString("dd-MMM-yyyy", new CultureInfo("en-US")));
                    }

                    dt = cmdOra.GetTable();
                    break;
                case "SQL":
                    POProject.CommandAdapter.SqlCmdBuilder cmdSql = new POProject.CommandAdapter.SqlCmdBuilder(dictDbConnector["tbSqlServer"].ToString(), dictDbConnector["tbSqlDatabase"].ToString(),
                        dictDbConnector["tbSqlUsername"].ToString(), dictDbConnector["tbSqlPassword"].ToString());
                    cmdSql.Query = query;

                    if (query.Contains("tglAwal") && query.Contains("tglAkhir"))
                    {
                        cmdSql.AddParameter("tglAwal", ParameterDirection.Input, DateTime.Now.ToString("yyyy-MM-dd"));
                        cmdSql.AddParameter("tglAkhir", ParameterDirection.Input, DateTime.Now.ToString("yyyy-MM-dd"));
                    }

                    dt = cmdSql.GetTable();
                    break;
                case "MYSQL":
                    POProject.CommandAdapter.MySqlCmdBuilder cmdMySql = new POProject.CommandAdapter.MySqlCmdBuilder(dictDbConnector["tbMySqlServer"].ToString(), dictDbConnector["tbMySqlDatabase"].ToString(),
                        dictDbConnector["tbMySqlUsername"].ToString(), dictDbConnector["tbMySqlPassword"].ToString());
                    cmdMySql.Query = query;

                    if (query.Contains("tglAwal") && query.Contains("tglAkhir"))
                    {
                        cmdMySql.AddParameter("tglAwal", ParameterDirection.Input, DateTime.Now.ToString("yyyy-MM-dd"));
                        cmdMySql.AddParameter("tglAkhir", ParameterDirection.Input, DateTime.Now.ToString("yyyy-MM-dd"));
                    }

                    dt = cmdMySql.GetTable();
                    break;
                case "ACCESS":
                    POProject.CommandAdapter.MsAccessCmdBuilder cmdAccess = new POProject.CommandAdapter.MsAccessCmdBuilder(dictDbConnector["tbAccessPath"].ToString(), dictDbConnector["tbAccessPassword"].ToString());
                    cmdAccess.Query = query;

                    if (query.Contains("tglAwal") && query.Contains("tglAkhir"))
                    {
                        cmdAccess.AddParameter("@tglAwal", ParameterDirection.Input, DateTime.Now.ToString("yyyy-MM-dd"));
                        cmdAccess.AddParameter("@tglAkhir", ParameterDirection.Input, DateTime.Now.ToString("yyyy-MM-dd"));
                    }

                    dt = cmdAccess.GetTable();
                    break;
                default:
                    break;
            }
        }
    }
}
