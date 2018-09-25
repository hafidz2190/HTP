using POProject.Model;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public interface IUserSettingColumnBusiness
    {
        List<UserSettingColumn> RetrieveSettingColumnByUsername(string username);
        List<UserSettingColumn> RetrieveColumnByUserNop(string username, string nop);
        List<UserTempSetting> GetUserTempSetting(string teks);
        List<string> RetrieveAllUser();
        bool IsSerialFound(string serialKey);
        bool RegisterSerialKey(string user, string key, string serialKey);
        List<JenisPajak> RetrieveTarifAll();
        List<queryData> RetrieveQueryPajak(string username, string nop);
    }

    public class queryData
    {
        public string nop { get; set; }
        public string queryPajak { get; set; }
        public string queryLampiran { get; set; }
    }
}