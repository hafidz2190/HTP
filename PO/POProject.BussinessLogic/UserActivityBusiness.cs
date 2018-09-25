using POProject.BusinessLogic.BusinessData;
using POProject.Model;
using System;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public class UserActivityBusiness : IUserActivityBusiness
    {
        private readonly IUserActivityBusinessData _userActivityBusinessData;

        public UserActivityBusiness(IUserActivityBusinessData userActivityBusinessData)
        {
            _userActivityBusinessData = userActivityBusinessData;
        }

        public List<UserActivity> RetrieveUserActivity(string username)
        {
            return _userActivityBusinessData.RetrieveUserActivity(username);
        }

        public bool InsertUserActivity(string username, string ipAddress, DateTime activityDate, bool status, string keterangan)
        {
            return _userActivityBusinessData.InsertUserActivity(username, ipAddress, activityDate, status, keterangan);
        }

        public bool InsertUserTempError(string username, DateTime activityDate)
        {
            return _userActivityBusinessData.InsertUserTempError(username, activityDate);
        }

        public string GetUrlApi()
        {
            return _userActivityBusinessData.GetUrlApi();
        }

        public DateTime GetLastErrorDate(string username)
        {
            return _userActivityBusinessData.GetLastErrorDate(username);
        }
    }
}
