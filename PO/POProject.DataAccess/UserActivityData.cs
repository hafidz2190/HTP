
using POProject.CommandAdapter;
using System;
using System.Data;

namespace POProject.DataAccess
{
    public class UserActivityData
    {
        public static DataTable RetrieveUserActivity(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username,ip_address, activity_date, status_error, keterangan 
                          FROM user_activity
                          WHERE username =:usern";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            return cmd.GetTable();
        }

        public static bool InsertUserActivity(string username, string ipAddress, DateTime activityDate, bool status, string keterangan)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO user_activity(username, ip_address,activity_date, status_error, keterangan)
                            VALUES(:usern, :ipaddress,:actdate, :status, :ket)";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("ipaddress", OracleCmdParameterDirection.Input, ipAddress);
            cmd.AddParameter("actdate", OracleCmdParameterDirection.Input, activityDate);
            cmd.AddParameter("status", OracleCmdParameterDirection.Input, status);
            cmd.AddParameter("ket", OracleCmdParameterDirection.Input, keterangan);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static DataTable GetLastErrorDate(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            //cmd.Query = @"SELECT username,activity_date,status_error 
            //            FROM user_activity WHERE username=:usern ORDER BY activity_date DESC";

            cmd.Query = @"SELECT username,max(tanggal) last_date
                        FROM user_transaction 
                        WHERE username=:usern
                        GROUP BY username";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);

            return cmd.GetTable();
        }
        
        public static bool InsertUserTempError(string username, DateTime activityDate)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO user_temp_error(username, tanggal_error)
                            VALUES(:usern, :actdate)";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("actdate", OracleCmdParameterDirection.Input, activityDate);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static string GetUrlApi()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT url_api FROM user_api_url";

            return cmd.ExecuteScalar().ToString();
        }
    }
}
