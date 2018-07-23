using POProject.BusinessLogic.Entity;
using POProject.DataAccess;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class SettingClientBusiness
    {
        public static List<UserClient> RetrieveUserClient(string username)
        {
            return SettingClientData.RetrieveUserClient(username).AsEnumerable<UserClient>().ToList();
        }

        public static List<ExceptionPort> RetrievePortException()
        {
            return SettingClientData.RetrievePortException().AsEnumerable<ExceptionPort>().ToList();
        }

        public static List<UserProfile> RetrieveUserProfile(string webUsername)
        {
            return SettingClientData.RetrieveUserProfile(webUsername).AsEnumerable<UserProfile>().ToList();
        }

        public static List<UserProfile> RetrieveUserProfileDashboard(string webUsername)
        {
            return SettingClientData.RetrieveUserProfileDashboard(webUsername).AsEnumerable<UserProfile>().ToList();
        }

        public static List<UserClient> RetrieveUserClient(string username, string email)
        {
            return SettingClientData.RetrieveUserClient(username, email).AsEnumerable<UserClient>().ToList();
        }

        public static List<UserClient> RetrieveUserClientByWebUsername(string webusername)
        {
            return SettingClientData.RetrieveUserClientByWebUsername(webusername).AsEnumerable<UserClient>().ToList();
        }

        public static bool UpdateSerialKey(string username, string serialKey)
        {
            bool isUpdate = false;
            if (SettingClientData.UpdateSerialKey(username, serialKey))
            {
                string encryptKey = POAdministrationTools.StringCipher.Encrypt(serialKey, "rereg");
                SettingClientData.InsertHistoryRegister(username, encryptKey);
                isUpdate = true;
            }
            return isUpdate;
        }

        public static bool IsSerialKeyExist(string serialKey, string username, string cpuId)
        {
            bool isExist = false;
            string dbKey = POAdministrationTools.StringCipher.Decrypt(SettingClientData.GetSerialKey(username), "rereg");
            if (string.Compare(dbKey, serialKey) == 0)
            {
                string idMachine = SettingClientData.RetrieveIdMachineByUsername(username);
                if (string.Compare(cpuId, idMachine) == 0)
                    isExist = true;
            }

            return isExist;
        }

        public static List<UserClient> RetrieveUserClient(string username, string idMachine, string password)
        {
            return SettingClientData.RetrieveUserClient(username, idMachine, password).AsEnumerable<UserClient>().ToList();
        }
        public static bool InsertUserClient(string username, string idMachine, string password, string phone, string mail, int port)
        {
            return SettingClientData.InsertUserClient(username, idMachine, password, phone, mail, port);
        }

        public static bool UpdateWebUsername(string existUsername, string webUsername)
        {
            return SettingClientData.UpdateWebUsername(existUsername, webUsername);
        }

        public static bool UpdateUserClient(string email, string phone, string kdBank, string username)
        {
            return SettingClientData.UpdateUserClient(email, phone, kdBank, username);
        }

        public static List<PureNop> RetrieveNopFromUserNop()
        {
            return SettingClientData.RetrieveUserNop().AsEnumerable<PureNop>().ToList();
        }

        public static List<PureNop> RetrieveMultiNopByUsername(string usern)
        {
            return SettingClientData.RetrieveMultiNopByUsername(usern).AsEnumerable<PureNop>().ToList();
        }

        public static bool InsertUserNop(string username, string nop, string jenisPajak)
        {
            return SettingClientData.InsertUserNop(username, nop, jenisPajak);
        }

        public static bool InsertUserSettingColumn(string username, string nop, string colName, string colText)
        {
            return SettingClientData.InsertUserSettingColumn(username, nop, colName, colText);
        }

        public static List<UserSettingColumn> RetrieveUserSettingColumn(string username, string nop)
        {
            return SettingClientData.RetrieveUserSettingColumn(username, nop).AsEnumerable<UserSettingColumn>().ToList();
        }

        public static bool InsertUserSourceDatabase(string username, string nop, string xmlSettDB, string ip, string namaDB)
        {
            return SettingClientData.InsertUserSourceDatabase(username, nop, xmlSettDB, ip, namaDB);
        }

        public static bool InserUserSettingDatabase(string username, string nop, string jenPajak, string tarif, string queryPajak, string queryDetail, string Alias)
        {
            return SettingClientData.InserUserSettingDatabase(username, nop, jenPajak, tarif, queryPajak, queryDetail, Alias);
        }

        public static bool isUserNopExist(string username, string nop)
        {
            return SettingClientData.isUserNopExist(username, nop);
        }

        public static List<settingDBSource> RetrieveSourceDB(string username)
        {
            return SettingClientData.RetrieveSourceDB(username).AsEnumerable<settingDBSource>().ToList();
        }

        public static List<DatabaseColUsed> RetrieveUserDatabaseColumn(string jenisPajak)
        {
            DataTable dt = SettingClientData.RetrieveUserDatabaseColumn(jenisPajak);

            return dt.AsEnumerable<DatabaseColUsed>().ToList();
        }

        public static bool InsertXmlFile(string username, string filename, string xmlContent, string fileNote, string separator)
        {
            return SettingClientData.InsertXmlFile(username, filename, xmlContent, fileNote, separator);
        }
    }
}
