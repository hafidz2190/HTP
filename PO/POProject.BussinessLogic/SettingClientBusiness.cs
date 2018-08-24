using POProject.BusinessLogic.BusinessData;
using POProject.Model;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public class SettingClientBusiness : ISettingClientBusiness
    {
        private readonly ISettingClientBusinessData _settingClientBusinessData;

        public SettingClientBusiness(ISettingClientBusinessData settingClientBusinessData)
        {
            _settingClientBusinessData = settingClientBusinessData;
        }

        public List<UserClient> RetrieveUserClient(string username)
        {
            return _settingClientBusinessData.RetrieveUserClient(username);
        }

        public List<DisplayMonitor> GetDisplayMonitor(string username)
        {
            return _settingClientBusinessData.GetDisplayMonitor(username);
        }

        public List<ExceptionPort> RetrievePortException()
        {
            return _settingClientBusinessData.RetrievePortException();
        }

        public List<UserProfile> RetrieveUserProfile(string webUsername)
        {
            return _settingClientBusinessData.RetrieveUserProfile(webUsername);
        }

        public List<UserProfile> RetrieveUserProfileDashboard(string webUsername)
        {
            return _settingClientBusinessData.RetrieveUserProfileDashboard(webUsername);
        }

        public List<UserClient> RetrieveUserClient(string username, string email)
        {
            return _settingClientBusinessData.RetrieveUserClient(username, email);
        }

        public List<UserClient> RetrieveUserClientByWebUsername(string webusername)
        {
            return _settingClientBusinessData.RetrieveUserClientByWebUsername(webusername);
        }

        public bool UpdateSerialKey(string username, string serialKey)
        {
            return _settingClientBusinessData.UpdateSerialKey(username, serialKey);
        }

        public bool IsSerialKeyExist(string serialKey, string username, string cpuId)
        {
            return _settingClientBusinessData.IsSerialKeyExist(serialKey, username, cpuId);
        }

        public List<UserClient> RetrieveUserClient(string username, string idMachine, string password)
        {
            return _settingClientBusinessData.RetrieveUserClient(username, idMachine, password);
        }

        public bool InsertUserClient(string username, string idMachine, string password, string phone, string mail, int port)
        {
            return _settingClientBusinessData.InsertUserClient(username, idMachine, password, phone, mail, port);
        }

        public bool UpdateWebUsername(string existUsername, string webUsername)
        {
            return _settingClientBusinessData.UpdateWebUsername(existUsername, webUsername);
        }

        public bool UpdateUserClient(string email, string phone, string kdBank, string username)
        {
            return _settingClientBusinessData.UpdateUserClient(email, phone, kdBank, username);
        }

        public List<PureNop> RetrieveNopFromUserNop()
        {
            return _settingClientBusinessData.RetrieveNopFromUserNop();
        }

        public List<PureNop> RetrieveMultiNopByUsername(string usern)
        {
            return _settingClientBusinessData.RetrieveMultiNopByUsername(usern);
        }

        public bool InsertUserNop(string username, string nop, string jenisPajak)
        {
            return _settingClientBusinessData.InsertUserNop(username, nop, jenisPajak);
        }

        public bool InsertUserSettingColumn(string username, string nop, string colName, string colText)
        {
            return _settingClientBusinessData.InsertUserSettingColumn(username, nop, colName, colText);
        }

        public List<UserSettingColumn> RetrieveUserSettingColumn(string username, string nop)
        {
            return _settingClientBusinessData.RetrieveUserSettingColumn(username, nop);
        }

        public bool InsertUserSourceDatabase(string username, string nop, string xmlSettDB, string ip, string namaDB)
        {
            return _settingClientBusinessData.InsertUserSourceDatabase(username, nop, xmlSettDB, ip, namaDB);
        }

        public bool InserUserSettingDatabase(string username, string nop, string jenPajak, string tarif, string queryPajak, string queryDetail, string Alias)
        {
            return _settingClientBusinessData.InserUserSettingDatabase(username, nop, jenPajak, tarif, queryPajak, queryDetail, Alias);
        }

        public bool IsUserUsingDatabase(string username)
        {
            return _settingClientBusinessData.IsUserUsingDatabase(username);
        }

        public bool isUserNopExist(string username, string nop)
        {
            return _settingClientBusinessData.isUserNopExist(username, nop);
        }

        public List<settingDBSource> RetrieveSourceDB(string username)
        {
            return _settingClientBusinessData.RetrieveSourceDB(username);
        }

        public List<DatabaseColUsed> RetrieveUserDatabaseColumn(string jenisPajak)
        {
            return _settingClientBusinessData.RetrieveUserDatabaseColumn(jenisPajak);
        }

        public bool InsertXmlFile(string username, string filename, string xmlContent, string fileNote, string separator)
        {
            return _settingClientBusinessData.InsertXmlFile(username, filename, xmlContent, fileNote, separator);
        }

        public List<UserXMLFile> RetrieveUserXmlFile(string username)
        {
            return _settingClientBusinessData.RetrieveUserXmlFile(username);
        }
    }
}
