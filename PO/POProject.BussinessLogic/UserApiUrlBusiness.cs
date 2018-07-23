using POProject.DataAccess;

namespace POProject.BusinessLogic
{
    public class UserApiUrlBusiness
    {
        public static string RetrieveApiUrl()
        {
           return UserApiUrlData.RetrieveApiUrl();
        }
    }
}
