using POProject.DataAccess;
using POProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace POProject.BusinessLogic.BusinessData
{
    public class UserActivityBusinessDataOracleCommand : IUserActivityBusinessData
    {
        public List<UserActivity> RetrieveUserActivity(string username)
        {
            return UserActivityData.RetrieveUserActivity(username).AsEnumerable<UserActivity>().ToList();
        }

        public bool InsertUserActivity(string username, string ipAddress, DateTime activityDate, bool status, string keterangan)
        {
            return UserActivityData.InsertUserActivity(username, ipAddress, activityDate, status, keterangan);
        }

        public bool InsertUserTempError(string username, DateTime activityDate)
        {
            return UserActivityData.InsertUserTempError(username, activityDate);
        }

        public string GetUrlApi()
        {
            return UserActivityData.GetUrlApi();
        }

        public DateTime GetLastErrorDate(string username)
        {
            DateTime tgl = new DateTime();
            DataTable dt = new DataTable();
            bool isError = false;

            dt = UserActivityData.GetLastErrorDate(username);
            if (dt != null && dt.Rows.Count > 0)
            {
                #region Old Code
                //foreach (DataRow dRow in dt.Rows)
                //{
                //    int status_error = Convert.ToInt32(dRow["STATUS_ERROR"]);
                //    if (isError && status_error == 0)
                //        break;

                //    if (status_error == 1)
                //    {
                //        tgl = Convert.ToDateTime(dRow["ACTIVITY_DATE"]);
                //        isError = true;
                //    }
                //}
                #endregion
                #region New Code
                tgl = dt.Rows[0]["LAST_DATE"].AsDateTime();
                isError = true;
                #endregion
            }

            if (!isError)
                tgl = DateTime.Now.AddDays(-1);

            return tgl;
        }
    }
}
