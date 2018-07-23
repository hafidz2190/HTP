using POProject.CommandAdapter;
using POProject.DataAccess;
using System;
using System.Data;
using System.Web;

namespace POProject.Membership.Data
{
    [Serializable]
    public class UserData
    {
        public DataTable RetrieveUser(string uName)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT ID_ROLE, USERNAME, PASSWORD, CREATE_DATE, IS_ACTIVE,IS_DELETED, USER_APP
                            FROM M_USER
                          WHERE UPPER(USERNAME)=:uName AND IS_ACTIVE = 1 AND IS_DELETED = 0";
            cmd.AddParameter("uName", OracleCmdParameterDirection.Input, uName.ToUpper());

            return cmd.GetTable();
        }

        public DataTable RetrieveUser(string uName, string pass)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT ID_ROLE, USERNAME, PASSWORD, CREATE_DATE,IS_ACTIVE,IS_DELETED, USER_APP
                          FROM M_USER
                          WHERE UPPER(USERNAME)=:uName AND PASSWORD=:pass AND IS_ACTIVE = 1 AND IS_DELETED = 0";
            cmd.AddParameter("uName", OracleCmdParameterDirection.Input, uName.ToUpper());
            cmd.AddParameter("pass", OracleCmdParameterDirection.Input, pass.ToUpper());
            return cmd.GetTable();
        }

        public DataTable RetrieveUserRoles(string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT *
                          FROM M_USER usr INNER JOIN M_ROLE uro " +
                        @"ON usr.id_role = uro.id_role";

            if (!string.IsNullOrEmpty(username))
            {
                cmd.Query += "WHERE UPPER(usr.username)=:uName";
                cmd.AddParameter("uName", OracleCmdParameterDirection.Input, username.ToUpper());
            }

            return cmd.GetTable();
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            string encNewPassword = POAdministrationTools.StringCipher.Encrypt(newPassword, HttpContext.Current.Session["Serial_key"].ToString());
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"UPDATE M_USER SET password =:password WHERE Username =:uName AND Password =:oldPass";
            cmd.AddParameter("password", OracleCmdParameterDirection.Input, encNewPassword);
            cmd.AddParameter("uName", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("oldPass", OracleCmdParameterDirection.Input, oldPassword);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool InsertUser(string username, string idRole, string password, string userapp)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO M_USER (USERNAME, ID_ROLE, PASSWORD, USER_APP)
                            VALUES(:usern, :idrole, :passw, :userapp)";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("idrole", OracleCmdParameterDirection.Input, idRole);
            cmd.AddParameter("passw", OracleCmdParameterDirection.Input, password);
            cmd.AddParameter("userapp", OracleCmdParameterDirection.Input, userapp);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
