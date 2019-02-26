using System;
using System.Collections.Generic;
using System.Linq;
using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
  public class SettingClientBusinessData : ISettingClientBusinessData
  {
    private readonly IDataManager _dataManager;
    private readonly IDataManagerDataTable _dataManagerDataTable;

    public SettingClientBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
    {
      _dataManager = dataManager;
      _dataManagerDataTable = dataManagerDataTable;
    }

    public List<DisplayMonitor> GetDisplayMonitor(string username)
    {
      throw new NotImplementedException();
    }

    public bool InsertUserClient(string username, string idMachine, string password, string phone, string mail, int port)
    {
      bool result = true;

      using (var transaction = _dataManager.BeginTransaction())
      {
        try
        {
          _dataManager.Create(new UserClient()
          {
            Username = username,
            Id_Machine = idMachine,
            Password = password,
            Phone = phone,
            Email = mail,
            Port_Client = port
          });

          _dataManager.Save();
          transaction.Commit();
        }
        catch (Exception)
        {
          result = false;
          transaction.Rollback();
        }
      }

      return result;
    }

    public bool InsertUserNop(string username, string nop, string jenisPajak)
    {
      bool result = true;

      using (var transaction = _dataManager.BeginTransaction())
      {
        try
        {
          _dataManager.Create(new UserNOP()
          {
            Username = username,
            NOP = nop,
            Jenis_Pajak = jenisPajak
          });

          _dataManager.Save();
          transaction.Commit();
        }
        catch (Exception)
        {
          result = false;
          transaction.Rollback();
        }
      }

      return result;
    }

    public bool InsertUserSettingColumn(string username, string nop, string colName, string colText)
    {
      bool result = true;

      using (var transaction = _dataManager.BeginTransaction())
      {
        try
        {
          _dataManager.Create(new UserSettingColumn()
          {
            Username = username,
            Nop = nop,
            Column_Name = colName,
            Column_Text = colText
          });

          _dataManager.Save();
          transaction.Commit();
        }
        catch (Exception)
        {
          result = false;
          transaction.Rollback();
        }
      }

      return result;
    }

    public bool InsertUserSourceDatabase(string username, string nop, string xmlSettDB, string ip, string namaDB)
    {
      throw new NotImplementedException();
    }

    public bool InsertXmlFile(string username, string filename, string xmlContent, string fileNote, string separator)
    {
      bool result = true;

      using (var transaction = _dataManager.BeginTransaction())
      {
        try
        {
          _dataManager.Create(new UserXMLFile()
          {
            Username = username,
            Filename = filename,
            File_XML = xmlContent,
            File_Note = fileNote,
            Separate = separator.Length > 0 ? separator[0] : Char.MinValue
          });

          _dataManager.Save();
          transaction.Commit();
        }
        catch (Exception)
        {
          result = false;
          transaction.Rollback();
        }
      }

      return result;
    }

    public bool InserUserSettingDatabase(string username, string nop, string jenPajak, string tarif, string queryPajak, string queryDetail, string Alias)
    {
      throw new NotImplementedException();
    }

    public bool IsSerialKeyExist(string serialKey, string username, string cpuId)
    {
      throw new NotImplementedException();
    }

    public bool isUserNopExist(string username, string nop)
    {
      throw new NotImplementedException();
    }

    public bool IsUserUsingDatabase(string username)
    {
      throw new NotImplementedException();
    }

    public List<PureNop> RetrieveMultiNopByUsername(string usern)
    {
      throw new NotImplementedException();
    }

    public List<PureNop> RetrieveNopFromUserNop()
    {
      throw new NotImplementedException();
    }

    public List<ExceptionPort> RetrievePortException()
    {
      return _dataManager.Get<ExceptionPort>().ToList();
    }

    public List<settingDBSource> RetrieveSourceDB(string username)
    {
      throw new NotImplementedException();
    }

    public List<UserClient> RetrieveUserClient(string username)
    {
      List<string> usernames = username.Replace("'", "").Split(',').ToList();

      if (usernames.Count <= 0)
        return new List<UserClient>();

      List<UserClient> clients = _dataManager.Get<UserClient>(e => usernames.Contains(e.Username) && e.Status_Aktif == true).ToList();
      return clients;
    }

    public List<UserClient> RetrieveUserClient(string username, string email)
    {
      return _dataManager.Get<UserClient>((e => e.Username == username && e.Email == email)).ToList();
    }

    public List<UserClient> RetrieveUserClient(string username, string idMachine, string password)
    {
      return _dataManager.Get<UserClient>((e => e.Username == username && e.Id_Machine == idMachine && e.Password == password)).ToList();
    }

    public List<UserClient> RetrieveUserClientByWebUsername(string webusername)
    {
      throw new NotImplementedException();
    }

    public List<DatabaseColUsed> RetrieveUserDatabaseColumn(string jenisPajak)
    {
      throw new NotImplementedException();
    }

    public List<UserProfile> RetrieveUserProfile(string webUsername)
    {
      throw new NotImplementedException();
    }

    public List<UserProfile> RetrieveUserProfileDashboard(string webUsername)
    {
      throw new NotImplementedException();
    }

    public List<UserSettingColumn> RetrieveUserSettingColumn(string username, string nop)
    {
      return _dataManager.Get<UserSettingColumn>((e => e.Username == username && e.Nop == nop)).ToList();
    }

    public List<UserXMLFile> RetrieveUserXmlFile(string username)
    {
      throw new NotImplementedException();
    }

    public bool UpdateSerialKey(string username, string serialKey)
    {
      throw new NotImplementedException();
    }

    public bool UpdateUserClient(string email, string phone, string kdBank, string username)
    {
      throw new NotImplementedException();
    }

    public bool UpdateWebUsername(string existUsername, string webUsername)
    {
      throw new NotImplementedException();
    }
  }
}
