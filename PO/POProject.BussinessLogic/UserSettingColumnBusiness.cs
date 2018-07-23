using POProject.BusinessLogic.Entity;
using POProject.DataAccess;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace POProject.BusinessLogic
{
    public class UserSettingColumnBusiness
    {
        public static List<UserSettingColumn> RetrieveSettingColumnByUsername(string username)
        {
            return UserSettingColumnData.RetrieveSettingColumn(username).AsEnumerable<UserSettingColumn>().ToList();
        }

        public static List<UserSettingColumn> RetrieveColumnByUserNop(string username, string nop)
        {
            DataTable dt = UserSettingColumnData.RetrieveColumnByUserNop(username, nop);
            return dt.AsEnumerable<UserSettingColumn>().ToList();
        }

        public static List<UserTempSetting> GetUserTempSetting(string teks)
        {
            return UserSettingColumnData.GetUserTempSetting(teks).AsEnumerable<UserTempSetting>().ToList();
        }

        public static List<string> RetrieveAllUser()
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

        public static bool IsSerialFound(string serialKey)
        {
            return UserSettingColumnData.GetSerialKey(serialKey);
        }

        public static bool RegisterSerialKey(string user, string key, string serialKey)
        {
            return UserSettingColumnData.RegisterSerialKey(user, key, serialKey);
        }

        public static List<JenisPajak> RetrieveTarifAll()
        {
            return UserSettingColumnData.RetrieveTarifAll().AsEnumerable<JenisPajak>().ToList();
        }

        public static List<queryData> RetrieveQueryPajak(string username, string nop)
        {
            return UserSettingColumnData.RetrieveQueryPajak(username, nop).AsEnumerable<queryData>().ToList();
        }
    }

    public class queryData
    {
        public string nop { get; set; }
        public string queryPajak { get; set; }
        public string queryLampiran { get; set; }
    }
}
