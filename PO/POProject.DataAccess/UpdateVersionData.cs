using POProject.CommandAdapter;
using System.Data;

namespace POProject.DataAccess
{
    public class UpdateVersionData
    {
        public static DataTable GetVersion()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT version,path_directory,is_important,create_date,islatestversion
                        FROM update_version WHERE is_important=1 AND islatestversion=1
                        ORDER BY create_date desc";

            return cmd.GetTable();
        }
    }
}
