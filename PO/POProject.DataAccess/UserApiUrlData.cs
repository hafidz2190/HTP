using POProject.CommandAdapter;

namespace POProject.DataAccess
{
    public class UserApiUrlData
    {
        public static string RetrieveApiUrl()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT URL_API from USER_API_URL";
            return cmd.ExecuteScalar().ToString();
        }
    }
}
