using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using POProject.DataAccess;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class UserSettingColumnBusinessDataOracleCommand : IUserSettingColumnBusinessData
    {
        public List<UserSettingColumn> RetrieveSettingColumnByUsername(string username)
        {
            return UserSettingColumnData.RetrieveSettingColumn(username).AsEnumerable<UserSettingColumn>().ToList();
        }

        public List<UserSettingColumn> RetrieveColumnByUserNop(string username, string nop)
        {
            DataTable dt = UserSettingColumnData.RetrieveColumnByUserNop(username, nop);
            return dt.AsEnumerable<UserSettingColumn>().ToList();
        }

        public List<UserTempSetting> GetUserTempSetting(string teks)
        {
            return UserSettingColumnData.GetUserTempSetting(teks).AsEnumerable<UserTempSetting>().ToList();
        }

        public List<string> RetrieveAllUser()
        {
            List<string> lstUsr = new List<string>();
            DataTable dtUser = new DataTable();
            dtUser = UserSettingColumnData.RetrieveAllUser();
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                Parallel.ForEach(dtUser.AsEnumerable(), dRow =>
                {
                    lstUsr.Add(dRow["USERNAME"].ToString());
                });

            }

            return lstUsr;
        }

        public bool IsSerialFound(string serialKey)
        {
            return UserSettingColumnData.GetSerialKey(serialKey);
        }

        public bool RegisterSerialKey(string user, string key, string serialKey)
        {
            return UserSettingColumnData.RegisterSerialKey(user, key, serialKey);
        }

        public List<JenisPajak> RetrieveTarifAll()
        {
            return UserSettingColumnData.RetrieveTarifAll().AsEnumerable<JenisPajak>().ToList();
        }

        public List<queryData> RetrieveQueryPajak(string username, string nop)
        {
            return UserSettingColumnData.RetrieveQueryPajak(username, nop).AsEnumerable<queryData>().ToList();
        }
    }
}