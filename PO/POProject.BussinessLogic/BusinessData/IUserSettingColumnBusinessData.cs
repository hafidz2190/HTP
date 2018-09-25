using POProject.Model;
using System.Collections.Generic;

namespace POProject.BusinessLogic.BusinessData
{
    public interface IUserSettingColumnBusinessData
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
}