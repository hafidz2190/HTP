using POProject.BusinessLogic.BusinessData;
using POProject.Model;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public class UserSettingColumnBusiness : IUserSettingColumnBusiness
    {
        private readonly IUserSettingColumnBusinessData _userSettingColumnBusinessData;

        public UserSettingColumnBusiness(IUserSettingColumnBusinessData userSettingColumnBusinessData)
        {
            _userSettingColumnBusinessData = userSettingColumnBusinessData;
        }

        public List<UserSettingColumn> RetrieveSettingColumnByUsername(string username)
        {
            return _userSettingColumnBusinessData.RetrieveSettingColumnByUsername(username);
        }

        public List<UserSettingColumn> RetrieveColumnByUserNop(string username, string nop)
        {
            return _userSettingColumnBusinessData.RetrieveColumnByUserNop(username, nop);
        }

        public List<UserTempSetting> GetUserTempSetting(string teks)
        {
            return _userSettingColumnBusinessData.GetUserTempSetting(teks);
        }

        public List<string> RetrieveAllUser()
        {
            return _userSettingColumnBusinessData.RetrieveAllUser();
        }

        public bool IsSerialFound(string serialKey)
        {
            return _userSettingColumnBusinessData.IsSerialFound(serialKey);
        }

        public bool RegisterSerialKey(string user, string key, string serialKey)
        {
            return _userSettingColumnBusinessData.RegisterSerialKey(user, key, serialKey);
        }

        public List<JenisPajak> RetrieveTarifAll()
        {
            return _userSettingColumnBusinessData.RetrieveTarifAll();
        }

        public List<queryData> RetrieveQueryPajak(string username, string nop)
        {
            return _userSettingColumnBusinessData.RetrieveQueryPajak(username, nop);
        }
    }
}
