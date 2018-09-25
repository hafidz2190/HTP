using POProject.Model;
using System.Collections.Generic;

namespace POProject.BusinessLogic.BusinessData
{
    public interface ISettingClientBusinessData
    {
        List<UserClient> RetrieveUserClient(string username);
        List<DisplayMonitor> GetDisplayMonitor(string username);
        List<ExceptionPort> RetrievePortException();
        List<UserProfile> RetrieveUserProfile(string webUsername);
        List<UserProfile> RetrieveUserProfileDashboard(string webUsername);
        List<UserClient> RetrieveUserClient(string username, string email);
        List<UserClient> RetrieveUserClientByWebUsername(string webusername);
        bool UpdateSerialKey(string username, string serialKey);
        bool IsSerialKeyExist(string serialKey, string username, string cpuId);
        List<UserClient> RetrieveUserClient(string username, string idMachine, string password);
        bool InsertUserClient(string username, string idMachine, string password, string phone, string mail, int port);
        bool UpdateWebUsername(string existUsername, string webUsername);
        bool UpdateUserClient(string email, string phone, string kdBank, string username);
        List<PureNop> RetrieveNopFromUserNop();
        List<PureNop> RetrieveMultiNopByUsername(string usern);
        bool InsertUserNop(string username, string nop, string jenisPajak);
        bool InsertUserSettingColumn(string username, string nop, string colName, string colText);
        List<UserSettingColumn> RetrieveUserSettingColumn(string username, string nop);
        bool InsertUserSourceDatabase(string username, string nop, string xmlSettDB, string ip, string namaDB);
        bool InserUserSettingDatabase(string username, string nop, string jenPajak, string tarif, string queryPajak, string queryDetail, string Alias);
        bool IsUserUsingDatabase(string username);
        bool isUserNopExist(string username, string nop);
        List<settingDBSource> RetrieveSourceDB(string username);
        List<DatabaseColUsed> RetrieveUserDatabaseColumn(string jenisPajak);
        bool InsertXmlFile(string username, string filename, string xmlContent, string fileNote, string separator);
        List<UserXMLFile> RetrieveUserXmlFile(string username);
    }
}
