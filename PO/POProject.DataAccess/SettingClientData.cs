using POProject.CommandAdapter;
using System;
using System.Data;

namespace POProject.DataAccess
{
    public class SettingClientData
    {
        #region USER CLIENT
        public static bool IsCodeExist2(string kode, string username, string cpuId)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT COUNT(*) 
                    FROM USER_CLIENT 
                    WHERE SERIAL_KEY=:kodeSerial AND USERNAME=:usern AND ID_MACHINE=:cpuid";
            cmd.AddParameter("kodeSerial", OracleCmdParameterDirection.Input, kode);
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("cpuid", OracleCmdParameterDirection.Input, cpuId);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public static string GetSerialKey(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT KODE
                        FROM USER_HISTORY_REGISTER
                        WHERE ROWNUM <= 1 AND USERNAME=:usern 
                        ORDER BY STATUS DESC";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);

            return cmd.ExecuteScalar().ToString();
        }

        public static DataTable RetrieveUserClient(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, id_machine, password,web_username, serial_key, 
                                 email, phone, kode_bank, status_aktif, port_client
                          FROM USER_CLIENT WHERE STATUS_AKTIF=1 ";
            if (!string.IsNullOrEmpty(username))
            {
                cmd.Query += @"AND USERNAME in (" + username + ")";
            }
            return cmd.GetTable();
        }

        public static DataTable GetDisplayMonitor(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT a.username, a.id_machine, a.password,a.web_username, a.serial_key, a.create_date,
                                 a.email, a.phone, a.kode_bank, a.status_aktif, a.port_client, MAX(b.jenis_pajak) jenis_pajak, count(*) jml_nop, max(b.nama_obyek) nama
                          FROM USER_CLIENT a INNER JOIN USER_NOP b ON (a.username=b.username)
                            WHERE a.STATUS_AKTIF=1 
                            AND b.NAMA_OBYEK is not null
                            AND b.IS_DELETED = 0
                        GROUP BY a.username, a.id_machine, a.password,a.web_username, a.serial_key, 
                                 a.email, a.phone, a.kode_bank, a.status_aktif, a.port_client,a.create_date";

            //if (!string.IsNullOrEmpty(username))
            //{
            //    cmd.Query += @"AND USERNAME in (" + username + ")";
            //}
            return cmd.GetTable();
        }

        public static DataTable RetrieveUserProfile(string webUsername)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT a.USERNAME, a.ID_MACHINE, a.PASSWORD,a.WEB_USERNAME, a.SERIAL_KEY, a.EMAIL, a.PHONE, a.KODE_BANK, B.NAMA_BANK
                            FROM USER_CLIENT a
                            LEFT JOIN BANK b ON A.KODE_BANK = B.KODE_BANK ";
            if (!string.IsNullOrEmpty(webUsername))
            {
                cmd.Query += @" WHERE a.WEB_USERNAME = :usern AND a.STATUS_AKTIF=1";
                cmd.AddParameter("usern", OracleCmdParameterDirection.Input, webUsername);
            }
            else
            {
                cmd.Query += @" WHERE a.STATUS_AKTIF=1";
            }


            return cmd.GetTable();
        }

        public static DataTable RetrieveUserProfileDashboard(string webUsername)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT a.username, a.id_machine, a.password,a.web_username, a.serial_key, a.email, a.phone, a.kode_bank,
                                a.status_aktif, a.port_client  
                          FROM user_client a";
            if (!string.IsNullOrEmpty(webUsername))
            {
                cmd.Query += @" WHERE a.web_username = :usern AND a.status_aktif=1";
                cmd.AddParameter("usern", OracleCmdParameterDirection.Input, webUsername);
            }
            else
            {
                cmd.Query += @" WHERE a.STATUS_AKTIF=1";
            }


            return cmd.GetTable();
        }

        public static DataTable RetrieveUserClient(string username, string email)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, id_machine, password,web_username, serial_key, email, phone,
                                  status_aktif,port_client
                          FROM USER_CLIENT WHERE USERNAME=:usern AND EMAIL = :email";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("email", OracleCmdParameterDirection.Input, email);
            return cmd.GetTable();
        }

        public static bool UpdateSerialKey(string username, string serialKey)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"UPDATE user_client SET serial_key=:ser
                          WHERE username=:usern";

            cmd.AddParameter("ser", OracleCmdParameterDirection.Input, serialKey);
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static DataTable RetrieveUserClientByWebUsername(string webusername)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, id_machine, password,web_username, serial_key, email, phone,
                                status_aktif,port_client
                          FROM USER_CLIENT WHERE WEB_USERNAME=:usern AND STATUS_AKTIF=1";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, webusername);
            return cmd.GetTable();
        }

        public static DataTable RetrieveUserClient(string username, string idMachine, string password)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, id_machine, password,serial_key, email, phone,
                                status_aktif,port_client 
                          FROM user_client
                          WHERE username=:usern
                                AND id_machine=:idmachine
                                AND password=:passw";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("idmachine", OracleCmdParameterDirection.Input, idMachine);
            cmd.AddParameter("passw", OracleCmdParameterDirection.Input, password);
            return cmd.GetTable();
        }
        public static bool InsertUserClient(string username, string idMachine, string password, string phone, string mail, int port)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO USER_CLIENT (username, id_machine, password,phone,email,port_client) 
                            VALUES(:usern, :idmachine, :password,:phone,:mail,:port)";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("idmachine", OracleCmdParameterDirection.Input, idMachine);
            cmd.AddParameter("password", OracleCmdParameterDirection.Input, password);
            cmd.AddParameter("phone", OracleCmdParameterDirection.Input, phone);
            cmd.AddParameter("mail", OracleCmdParameterDirection.Input, mail);
            cmd.AddParameter("port", OracleCmdParameterDirection.Input, port);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool InsertHistoryRegister(string username, string encryptKode)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO USER_HISTORY_REGISTER (KODE, USERNAME,STATUS) 
                            VALUES(:kode,:usern,(
                                                select (nvl(max(status),0) + 1) status 
                                                from user_history_register 
                                                where username=:usern)
                                                )";

            cmd.AddParameter("kode", OracleCmdParameterDirection.Input, encryptKode);
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool UpdateWebUsername(string existUsername, string webUsername)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"UPDATE user_client SET web_username =:webUsern WHERE username =:exstUsern";
            cmd.AddParameter("webUsern", OracleCmdParameterDirection.Input, webUsername);
            cmd.AddParameter("exstUsern", OracleCmdParameterDirection.Input, existUsername);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool UpdateUserClient(string email, string phone, string kdBank, string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"UPDATE user_client 
                          SET email =:email, phone =:phone, kode_bank =:kdbank 
                          WHERE username =:username";
            cmd.AddParameter("email", OracleCmdParameterDirection.Input, email);
            cmd.AddParameter("phone", OracleCmdParameterDirection.Input, phone);
            cmd.AddParameter("kdbank", OracleCmdParameterDirection.Input, kdBank);
            cmd.AddParameter("username", OracleCmdParameterDirection.Input, username);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static DataTable RetrieveMultiNopByUsername(string usern)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT UN.NOP, UN.NAMA_OBYEK FROM USER_NOP UN
                            INNER JOIN M_USER USR on USR.USER_APP = UN.USERNAME                            
                            WHERE USR.USERNAME = :usern AND USR.IS_DELETED=0";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, usern);
            return cmd.GetTable();
        }

        public static string RetrieveIdMachineByUsername(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT id_machine FROM USER_CLIENT
                            WHERE USERNAME=:usern";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            string id = cmd.ExecuteScalar() == null ? string.Empty : cmd.ExecuteScalar().ToString();
            return id;
        }
        #endregion

        #region USER NOP
        public static DataTable RetrieveUserNop()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = "SELECT DISTINCT(NOP) from USER_NOP WHERE IS_DELETED = 0";
            return cmd.GetTable();
        }

        public static bool InsertUserNop(string username, string nop, string jenisPajak)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO USER_NOP (USERNAME, NOP, JENIS_PAJAK) 
                            VALUES(:usern, :nop, :jnsPajak)";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("jnsPajak", OracleCmdParameterDirection.Input, jenisPajak);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool isUserNopExist(string username, string nop)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT count(*) FROM USER_NOP WHERE username=:usern AND nop=:nop AND IS_DELETED = 0";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
        #endregion

        #region USER SETTING COLUMN
        public static bool InsertUserSettingColumn(string username, string nop, string colName, string colText)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO USER_SETTING_COLUMN (USERNAME, NOP, COLUMN_NAME, COLUMN_TEXT) 
                            VALUES(:usern, :nop, :colname, :coltext)";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("colname", OracleCmdParameterDirection.Input, colName);
            cmd.AddParameter("coltext", OracleCmdParameterDirection.Input, colText);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static DataTable RetrieveUserSettingColumn(string username, string nop)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username,nop,column_name,column_text FROM USER_SETTING_COLUMN 
                            WHERE username=:usern AND nop=:nop";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);

            return cmd.GetTable();
        }
        #endregion

        #region USER SOURCE DB
        public static bool InsertUserSourceDatabase(string username, string nop, string xmlSettDB, string ip, string namaDb)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO USER_SOURCE_DB (username,nop,setting_db,ip_sender,nama_db)
                        VALUES(:usern,:nop,:settDB,:ipAdd,:nmDB)";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("settDB", OracleCmdParameterDirection.Input, xmlSettDB);
            cmd.AddParameter("ipAdd", OracleCmdParameterDirection.Input, ip);
            cmd.AddParameter("nmDB", OracleCmdParameterDirection.Input, namaDb);
            return cmd.ExecuteNonQuery() > 0;
        }
        public static DataTable RetrieveSourceDB(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT NOP,SETTING_DB settingdb,NAMA_DB namadb FROM USER_SOURCE_DB WHERE USERNAME=:usern";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);

            return cmd.GetTable();
        }
        #endregion

        #region USER SETTING DATABASE
        public static bool InserUserSettingDatabase(string username, string nop, string jenPajak, string tarif, string queryPajak, string queryDetail, string Alias)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO USER_SETTING_DATABASE (username,nop,jenispajak,tarif,query_pajak,query_detail,alias)
                        VALUES(:usern,:nop,:jen,:tarif,:qPajak,:qDetail,:alias)";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("jen", OracleCmdParameterDirection.Input, jenPajak);
            cmd.AddParameter("tarif", OracleCmdParameterDirection.Input, tarif);
            cmd.AddParameter("qPajak", OracleCmdParameterDirection.Input, queryPajak);
            cmd.AddParameter("qDetail", OracleCmdParameterDirection.Input, queryDetail);
            cmd.AddParameter("alias", OracleCmdParameterDirection.Input, Alias);

            return cmd.ExecuteNonQuery() > 0;
        }
        #endregion

        #region USER DB COLUMN
        public static DataTable RetrieveUserDatabaseColumn(string jenisPajak)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT *
                        FROM USER_DB_COLUMN 
                        WHERE JENISPAJAK=:jen";

            cmd.AddParameter("jen", OracleCmdParameterDirection.Input, jenisPajak);

            return cmd.GetTable();
        }
        #endregion

        #region USER XML FILE
        public static bool InsertXmlFile(string username, string filename, string xmlContent, string fileNote, string separator)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO user_xml_file(username,filename,file_xml,file_note,separate) 
                        VALUES(:usern,:filename,:xmlFile,:fileNote,:separate)";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("filename", OracleCmdParameterDirection.Input, filename);
            cmd.AddParameter("xmlFile", OracleCmdParameterDirection.Input, xmlContent);
            cmd.AddParameter("fileNote", OracleCmdParameterDirection.Input, fileNote);
            cmd.AddParameter("separate", OracleCmdParameterDirection.Input, separator);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool IsUserUsingDatabase(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT COUNT(*) 
                          FROM user_xml_file
                          WHERE username=:usern AND file_note='DATABASE'";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public static DataTable RetrieveUserXmlFile(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT *
                        FROM user_xml_file 
                        WHERE username=:usern";

            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);

            return cmd.GetTable();
        }
        #endregion

        #region PORT
        public static DataTable RetrievePortException()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT PORT FROM EXCEPTION_PORT";
            return cmd.GetTable();
        }

        #endregion

    }
}
