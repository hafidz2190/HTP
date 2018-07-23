using POProject.CommandAdapter;
using System.Data;

namespace POProject.DataAccess
{
    public class UserSettingColumnData
    {
        public static DataTable RetrieveSettingColumn(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT USERNAME, NOP, COLUMN_NAME, COLUMN_TEXT
                            FROM USER_SETTING_COLUMN WHERE USERNAME=:usern";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            return cmd.GetTable();
        }

        public static DataTable RetrieveAllUser()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT USERNAME
                          FROM USER_CLIENT";

            return cmd.GetTable();
        }

        public static bool GetSerialKey(string serialKey)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT COUNT(*)
                          FROM USER_CLIENT WHERE SERIAL_KEY=:serial";

            cmd.AddParameter("serial", OracleCmdParameterDirection.Input, serialKey);

            return System.Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public static bool RegisterSerialKey(string user, string key, string serialKey)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"UPDATE USER_CLIENT
                    SET serial_key=:serialKey
                    WHERE username=:usern AND id_machine=:idMachine";

            cmd.AddParameter("serialKey", OracleCmdParameterDirection.Input, serialKey);
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, user);
            cmd.AddParameter("idMachine", OracleCmdParameterDirection.Input, key);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static DataTable RetrieveTarifAll()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT jenispajak jenpajak, tarif FROM user_tarif_pajak";

            return cmd.GetTable();
        }

        public static DataTable RetrieveColumnByUserNop(string username, string nop)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT USERNAME, NOP, COLUMN_NAME, COLUMN_TEXT
                            FROM USER_SETTING_COLUMN WHERE USERNAME=:usern AND NOP=:nop ";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            return cmd.GetTable();
        }

        public static DataTable RetrieveQueryPajak(string username, string nop)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT NOP, QUERY_PAJAK querypajak, QUERY_DETAIL querylampiran
                        FROM USER_SETTING_DATABASE WHERE USERNAME=:usern AND NOP=:nop";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);

            return cmd.GetTable();
        }

        public static DataTable GetUserTempSetting(string teks)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT ID_SETTING,NAMA_SETTING,VALUE,KETERANGAN 
                        FROM USER_TEMP_SETTING 
                        WHERE UPPER(NAMA_SETTING) LIKE :teks";

            cmd.AddParameter("teks", OracleCmdParameterDirection.Input, "%" + teks.ToUpper() + "%");

            return cmd.GetTable();
        }
    }
}
