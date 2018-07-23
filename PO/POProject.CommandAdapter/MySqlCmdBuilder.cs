using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace POProject.CommandAdapter
{
    public class MySqlCmdBuilder
    {

        private const string ConnectionStringFormat = @"Server={0};Port={1};Database={2};Uid={3};Password={4};";

        public List<MySqlParameter> Parameters { get; private set; }
        public string ConnectionString { get; private set; }
        public string Query { get; set; }
        public bool IsStoredProcedure { get; set; }

        public MySqlCmdBuilder()
        {

        }

        public MySqlCmdBuilder(string server, string dataBase, string userId, string password)
        {
            Parameters = new List<MySqlParameter>();

            string port = string.Empty;
            string strServer = string.Empty;
            string[] arrIp = server.Split(':');

            if (arrIp.Length > 1)
            {
                strServer = arrIp[0];
                port = arrIp[arrIp.Length - 1];
            }                
            else
            {
                strServer = arrIp[0];
                port = "3306";
            }
                


            ConnectionString = string.Format(ConnectionStringFormat, strServer, port, dataBase, userId, password);
            IsStoredProcedure = false;
        }

        public void AddParameter(string name, System.Data.ParameterDirection direction, object value)
        {
            MySqlParameter newParameter = new MySqlParameter();
            newParameter.Direction = direction;
            newParameter.ParameterName = name;
            newParameter.Value = value;
            Parameters.Add(newParameter);
        }

        public void AddBlobParameter(string name, System.Data.ParameterDirection direction, object value)
        {
            if (value != null)
            {
                byte[] pictValue = value as byte[];

                MySqlParameter newParameter = new MySqlParameter(name, MySqlDbType.Blob, pictValue.Length);
                newParameter.Value = value;
                Parameters.Add(newParameter);
            }
            else
            {
                AddParameter(name, direction, value);
            }
        }

        public int ExecuteNonQueryWithoutTransactionOperation()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            int affectedRows = 0;
            using (MySqlConnection conn = CreateConnection())
            {
                try
                {
                    MySqlCommand cmd = CreateCommand(conn);
                    conn.Open();
                    affectedRows = cmd.ExecuteNonQuery();
                    //UpdateParameterValue(cmd);
                }
                catch (Exception ex)
                {
                    affectedRows = -1;
                    throw ex;
                }
                finally
                {
                    CloseConnection(conn);
                }
            }

            return affectedRows;
        }

        public int ExecuteNonQuery()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            int affectedRows = 0;
            using (MySqlConnection conn = CreateConnection())
            {
                MySqlTransaction trans = null;
                try
                {
                    MySqlCommand cmd = CreateCommand(conn);
                    conn.Open();
                    trans = conn.BeginTransaction();
                    cmd.Transaction = trans;
                    affectedRows = cmd.ExecuteNonQuery();
                    trans.Commit();
                    //UpdateParameterValue(cmd);
                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    CloseConnection(conn);
                }
            }

            return affectedRows;
        }

        public object ExecuteScalar()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            object result = 0;
            using (MySqlConnection conn = CreateConnection())
            {
                MySqlTransaction trans = null;
                try
                {
                    MySqlCommand cmd = CreateCommand(conn);
                    conn.Open();
                    trans = conn.BeginTransaction();
                    cmd.Transaction = trans;
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    CloseConnection(conn);
                }
            }

            return result;
        }

        public System.Data.DataTable GetTable()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            System.Data.DataTable result = null;
            using (MySqlConnection conn = CreateConnection())
            {
                try
                {
                    MySqlCommand cmd = CreateCommand(conn);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    result = new System.Data.DataTable("Output");
                    da.Fill(result);

                    //UpdateParameterValue(cmd);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    CloseConnection(conn);
                }
            }

            return result;
        }

        public bool TestConnection(out string errMsg)
        {
            bool result = true;
            errMsg = string.Empty;
            using (MySqlConnection conn = CreateConnection())
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    result = false;
                    errMsg = ex.Message;
                }
                finally
                {
                    try
                    {
                        CloseConnection(conn);
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        errMsg = ex.Message;
                    }
                }
            }

            return result;
        }

        //private void UpdateParameterValue(SqlCommand cmd)
        //{
        //    foreach (SqlParameter param in cmd.Parameters)
        //    {
        //        if (param.Direction == System.Data.ParameterDirection.InputOutput || 
        //            param.Direction == System.Data.ParameterDirection.Output ||
        //            param.Direction == System.Data.ParameterDirection.ReturnValue)
        //        {
        //            OraCmdParameterItem paramItem = Parameters[param.ParameterName];
        //            paramItem.Value = param.Value;
        //            Parameters[param.ParameterName] = paramItem;
        //        }
        //    }
        //}

        private MySqlCommand CreateCommand(MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = Query;
                cmd.CommandType = System.Data.CommandType.Text;
                if (IsStoredProcedure)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                if (Parameters.Count > 0)
                {
                    foreach (MySqlParameter param in Parameters)
                    {
                        //if (iParam.Value.DBType != 0)
                        //    param.OracleDbType = iParam.Value.DBType;
                        cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                }

                return cmd;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        private MySqlConnection CreateConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                return conn;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        private static void CloseConnection(MySqlConnection conn)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
    }
}
