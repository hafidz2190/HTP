using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace POProject.CommandAdapter
{
    public class MsAccessCmdBuilder
    {
        //private const string ConnectionStringFormat = "Provider=Microsoft.ACE.OLEDB.16.0;Dbq={0};Uid={1};Pwd={2};";
        private string ExcelConnection(string fileName, string password)
        {
            //return @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            //       @"Data Source=F:\MyDatabase.accdb;" +
            //       @"Extended Properties=" + Convert.ToChar(34).ToString() +
            //       @"Excel 8.0" + Convert.ToChar(34).ToString() + $";Uid={username};Pwd={password};";
            //return @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =F:\MyDatabase2.mdb;Persist Security Info = False;";
            //return @"Provider =Microsoft.Jet.OLEDB.12.0;Data Source=F:\MyDatabase.accdb;Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'; ";
            return string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};
                                Jet OLEDB:Database Password={1};
                                Persist Security Info=True;", fileName, password);
        }

        public List<OleDbParameter> Parameters { get; private set; }
        public string ConnectionString { get; private set; }
        public string Query { get; set; }
        public bool IsStoredProcedure { get; set; }
        public MsAccessCmdBuilder()
        {

        }

        public MsAccessCmdBuilder(string path, string password)
        {
            //ConnectionString = string.Format(ConnectionStringFormat, path, userId, password);
            ConnectionString = ExcelConnection(path, password);
        }

        private OleDbConnection CreateConnection()
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(ConnectionString);
                return conn;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        private static void CloseConnection(OleDbConnection conn)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void AddParameter(string name, System.Data.ParameterDirection direction, object value)
        {
            OleDbParameter newParameter = new OleDbParameter();
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
                OleDbParameter newParameter = new OleDbParameter(name, OleDbType.Binary, pictValue.Length);
                newParameter.Value = value;
                Parameters.Add(newParameter);
            }
            else
            {
                AddParameter(name, direction, value);
            }
        }

        private OleDbCommand CreateCommand(OleDbConnection conn)
        {
            try
            {
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = Query;
                cmd.CommandType = System.Data.CommandType.Text;
                if (IsStoredProcedure)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }

                if (Parameters != null && Parameters.Count > 0)
                {
                    foreach (OleDbParameter param in Parameters)
                    {
                        cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                }
                return cmd;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public int ExecuteNonQueryWithoutTransactionOperation()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            int affectedRows = 0;
            using (OleDbConnection conn = CreateConnection())
            {
                try
                {
                    OleDbCommand cmd = CreateCommand(conn);
                    conn.Open();
                    affectedRows = cmd.ExecuteNonQuery();
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
            using (OleDbConnection conn = CreateConnection())
            {
                OleDbTransaction trans = null;
                try
                {
                    OleDbCommand cmd = CreateCommand(conn);
                    conn.Open();
                    trans = conn.BeginTransaction();
                    cmd.Transaction = trans;
                    affectedRows = cmd.ExecuteNonQuery();
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

            return affectedRows;
        }

        public object ExecuteScalar()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            object result = 0;
            using (OleDbConnection conn = CreateConnection())
            {
                OleDbTransaction trans = null;
                try
                {
                    OleDbCommand cmd = CreateCommand(conn);
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

        public bool TestConnection(out string errMsg)
        {
            errMsg = string.Empty;
            bool result = true;
            using (OleDbConnection conn = CreateConnection())
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

        public System.Data.DataTable GetTable()
        {
            if (string.IsNullOrEmpty(Query))
            {
                throw new Exception("Query not initialized");
            }

            System.Data.DataTable result = null;
            using (OleDbConnection conn = CreateConnection())
            {
                try
                {
                    OleDbCommand cmd = CreateCommand(conn);

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    result = new System.Data.DataTable("Output");
                    da.Fill(result);
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
    }
}
