using POProject.Model;
using System;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public interface IUserActivityBusiness
    {
        List<UserActivity> RetrieveUserActivity(string username);
        bool InsertUserActivity(string username, string ipAddress, DateTime activityDate, bool status, string keterangan);
        bool InsertUserTempError(string username, DateTime activityDate);
        string GetUrlApi();
        DateTime GetLastErrorDate(string username);
    }
}