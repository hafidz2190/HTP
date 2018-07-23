using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POProject.CommandAdapter;

namespace POProject.DataAccess
{
    public class TestimoniData
    {
        public static bool InsertTestimoni(string username, string commend)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = "";

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
