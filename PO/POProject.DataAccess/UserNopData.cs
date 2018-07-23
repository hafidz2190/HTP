using POProject.CommandAdapter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POProject.DataAccess
{
    public class UserNopData
    {
        public static DataTable RetrieveNOPByUsername(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT username, nop, jenis_pajak, nama_obyek 
                          FROM user_nop
                          WHERE username =:usern";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);

            return cmd.GetTable();
        }
    }
}
