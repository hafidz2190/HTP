using POProject.CommandAdapter;
using POProject.DataAccess;
using System;
using System.Data;

namespace POProject.Membership.Data
{
    [Serializable]
    public class RoleData
    {
        public DataTable RetrieveRoleById(string idRole)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT *
                          FROM M_ROLE
                          WHERE ID_ROLE=:idRole";
            cmd.AddParameter("idRole", OracleCmdParameterDirection.Input, idRole);
            return cmd.GetTable();
        }

        public DataTable RetrieveRoleByName(string nameRole)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT *
                          FROM M_ROLE
                          WHERE NAME_ROLE=:nameRole";
            cmd.AddParameter("nameRole", OracleCmdParameterDirection.Input, nameRole);
            return cmd.GetTable();
        }
    }
}
