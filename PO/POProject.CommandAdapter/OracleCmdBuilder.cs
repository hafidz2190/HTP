using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace POProject.CommandAdapter
{
    public class OracleCmdBuilder
    {
        //private const string ConnectionStringFormat = @"Data Source = (DESCRIPTION =
        // (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.21.31.221)(PORT = 1521)))
        // (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = SUNANBONANG)));
        //User Id = PHRH_MAMIN; Password=taxbarupajak_201301";
        private const string ConnectionStringFormat = "Data Source={0};User Id={1};Password={2};Unicode=True";

        public OracleCmdParameterCollection Parameters { get; private set; }
        public string ConnectionString { get; private set; }
        public string Query { get; set; }
        public bool IsStoredProcedure { get; set; }

        public OracleCmdBuilder(string dataSource, string userId, string password)
        {
            Parameters = new OracleCmdParameterCollection();
            ConnectionString = string.Format(ConnectionStringFormat, dataSource, userId, password);
            IsStoredProcedure = false;
        }

        public void ResetCommand()
        {
            Query = string.Empty;
            Parameters.Clear();
            IsStoredProcedure = false;
        }

        public void AddParameter(OracleCmdParameterItem parameterItem)
        {
            Parameters.Add(parameterItem.Name, parameterItem);
        }

        public void AddParameter(string name, OracleCmdParameterDirection direction, object value)
        {
            if (value != null)
            {
                Parameters.Add(name, new OracleCmdParameterItem(name, direction, value));
            }
            else
            {
                Parameters.Add(name, new OracleCmdParameterItem(name, direction, DBNull.Value));
            }
        }

        public int ExecuteNonQueryWithoutTransactionOperation()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            int affectedRows = 0;
            using (OracleConnection conn = CreateConnection())
            {
                try
                {
                    OracleCommand cmd = CreateCommand(conn);
                    conn.Open();
                    affectedRows = cmd.ExecuteNonQuery();
                    UpdateParameterValue(cmd);
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

        //public void AddParameter(string v, CmdParameterDirection input, object kodeDokumen)
        //{
        //    throw new NotImplementedException();
        //}

        public int ExecuteNonQuery()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            int affectedRows = 0;
            using (OracleConnection conn = CreateConnection())
            {
                OracleTransaction trans = null;
                try
                {
                    OracleCommand cmd = CreateCommand(conn);
                    conn.Open();
                    trans = conn.BeginTransaction();
                    cmd.Transaction = trans;
                    affectedRows = cmd.ExecuteNonQuery();
                    trans.Commit();
                    UpdateParameterValue(cmd);
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
            using (OracleConnection conn = CreateConnection())
            {
                OracleTransaction trans = null;
                try
                {
                    OracleCommand cmd = CreateCommand(conn);
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

        public DataTable GetTableFirstRowOnly()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            DataTable result = null;
            using (OracleConnection conn = CreateConnection())
            {
                try
                {
                    conn.Open();
                    OracleCommand cmd = CreateCommand(conn);
                    OracleDataReader reader = cmd.ExecuteReader();
                    result = new DataTable("Output");

                    DataTable dtSchema = reader.GetSchemaTable();
                    foreach (DataRow item in dtSchema.Rows)
                    {
                        string columnName = System.Convert.ToString(item["ColumnName"]);
                        DataColumn column = new DataColumn(columnName, (Type)(item["DataType"]));
                        column.AllowDBNull = (bool)item["AllowDBNull"];
                        result.Columns.Add(column);
                    }
                    
                    if (reader.Read())
                    {
                        object[] ColArray = new object[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            ColArray[i] = reader[i];
                        }

                        result.LoadDataRow(ColArray, true);
                    }


                    //UpdateParameterValue(cmd);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

            return result;
        }

        public DataTable GetTable()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            DataTable result = null;
            using (OracleConnection conn = CreateConnection())
            {
                try
                {
                    OracleCommand cmd = CreateCommand(conn);

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    result = new DataTable("Output");
                    da.Fill(result);

                    UpdateParameterValue(cmd);
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
            errMsg = string.Empty;
            bool result = true;
            using (OracleConnection conn = CreateConnection())
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

        private void UpdateParameterValue(OracleCommand cmd)
        {
            foreach (OracleParameter param in cmd.Parameters)
            {
                if (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output ||
                    param.Direction == ParameterDirection.ReturnValue)
                {
                    OracleCmdParameterItem paramItem = Parameters[param.ParameterName];
                    paramItem.Value = param.Value;
                    Parameters[param.ParameterName] = paramItem;
                }
            }
        }

        private OracleCommand CreateCommand(OracleConnection conn)
        {
            try
            {
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = Query;
                cmd.CommandType = CommandType.Text;
                if (IsStoredProcedure)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                if (Parameters.Count > 0)
                {
                    foreach (KeyValuePair<string, OracleCmdParameterItem> iParam in Parameters)
                    {
                        OracleParameter param = new OracleParameter(iParam.Key, iParam.Value.Value);
                        switch (iParam.Value.Direction)
                        {
                            case OracleCmdParameterDirection.Output:
                                param.Direction = ParameterDirection.Output;
                                break;
                            case OracleCmdParameterDirection.InputOutput:
                                param.Direction = ParameterDirection.InputOutput;
                                break;
                            case OracleCmdParameterDirection.ReturnValue:
                                param.Direction = ParameterDirection.ReturnValue;
                                break;
                            default:
                                param.Direction = ParameterDirection.Input;
                                break;
                        }
                        cmd.Parameters.Add(param);
                    }
                }

                return cmd;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }

        private OracleConnection CreateConnection()
        {
            try
            {
                OracleConnection conn = new OracleConnection(ConnectionString);
                return conn;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }

        private static void CloseConnection(OracleConnection conn)
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }
    }
}
