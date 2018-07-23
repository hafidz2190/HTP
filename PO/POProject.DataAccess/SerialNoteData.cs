using POAdministrationTools;
using POProject.CommandAdapter;
using System.Data;

namespace POProject.DataAccess
{
    public class SerialNoteData
    {
        public static DataTable RetrieveAvailableSerialNote()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = "SELECT kode, taken_username, taken_hw_id, create_date, status, modidate " +
                        "FROM serial_note " +
                        "WHERE status='" + DataBaseHelper.AvailableCommandNote + "'";

            int length = DataBaseHelper.AvailableCommandNote.Length;
            
            return cmd.GetTable();
        }

        public static DataTable RetrieveAllTakenSerialNote()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = "SELECT kode, taken_username, taken_hw_id, create_date, status, modidate " +
                        "FROM serial_note " +
                        "WHERE status !='" + DataBaseHelper.AvailableCommandNote + "'";

            return cmd.GetTable();
        }

        public static bool UpdateData(string kode, string username, string hwID)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = "UPDATE serial_note " +
                        "SET taken_username=:usern," +
                        "    taken_hw_id=:hwID," +
                        "    modidate=sysdate," +
                        "    status=:status" + 
                        " WHERE kode=:kode";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, StringCipher.Encrypt(username, DataBaseHelper.SettingDB));
            cmd.AddParameter("hwID", OracleCmdParameterDirection.Input, StringCipher.Encrypt(hwID, DataBaseHelper.SettingDB));
            cmd.AddParameter("status", OracleCmdParameterDirection.Input, StringCipher.Encrypt("USED", DataBaseHelper.SettingDB));
            cmd.AddParameter("kode", OracleCmdParameterDirection.Input, kode);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
