using System;
using System.Collections.Generic;
using System.Linq;
using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
  public class UserSettingColumnBusinessData : IUserSettingColumnBusinessData
  {
    private readonly IDataManager _dataManager;
    private readonly IDataManagerDataTable _dataManagerDataTable;

    public UserSettingColumnBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
    {
      _dataManager = dataManager;
      _dataManagerDataTable = dataManagerDataTable;
    }

    public List<UserTempSetting> GetUserTempSetting(string teks)
    {
      return _dataManager.Get<UserTempSetting>((e => e.nama_setting.Contains(teks.ToUpper()))).ToList();
    }

    public bool IsSerialFound(string serialKey)
    {
      return _dataManager.GetExist<UserClient>((e => e.Serial_Key == serialKey));
    }

    public bool RegisterSerialKey(string user, string key, string serialKey)
    {
      bool result = true;

      using (var transaction = _dataManager.BeginTransaction())
      {
        try
        {
          UserClient userClient = _dataManager.GetOne<UserClient>((e => e.Username == user && e.Id_Machine == key));

          if (userClient == null)
            return false;
          else
          {
            userClient.Serial_Key = serialKey;
            _dataManager.Update(userClient);
            _dataManager.Save();
            transaction.Commit();
          }
        }
        catch (Exception)
        {
          result = false;
          transaction.Rollback();
        }
      }

      return result;
    }

    public List<string> RetrieveAllUser()
    {
      List<string> users = new List<string>();
      _dataManager.Get<UserClient>().ToList().ForEach(e => users.Add(e.Username));

      return users;
    }

    public List<UserSettingColumn> RetrieveColumnByUserNop(string username, string nop)
    {
      return _dataManager.Get<UserSettingColumn>((e => e.Username == username && e.Nop == nop)).ToList();
    }

    public List<queryData> RetrieveQueryPajak(string username, string nop)
    {
      List<queryData> queryDatas = new List<queryData>();
      List<UserSettingDatabase> userSettingDatabases = _dataManager.Get<UserSettingDatabase>((e => e.Username == username && e.Nop == nop)).ToList();

      foreach (UserSettingDatabase userSettingDatabase in userSettingDatabases)
      {
        queryDatas.Add(new queryData()
        {
          nop = userSettingDatabase.Nop,
          queryPajak = userSettingDatabase.Query_Pajak,
          queryLampiran = userSettingDatabase.Query_Detail
        });
      }

      return queryDatas;
    }

    public List<UserSettingColumn> RetrieveSettingColumnByUsername(string username)
    {
      return _dataManager.Get<UserSettingColumn>((e => e.Username == username)).ToList();
    }

    public List<JenisPajak> RetrieveTarifAll()
    {
      return _dataManager.Get<JenisPajak>().ToList();
    }
  }
}