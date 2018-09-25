using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace POProject.DataAccess.Persistance
{
    public class SqlParameterBuilderMySql : ISqlParameterBuilder
    {
        public object[] BuildSqlParameters(IDictionary<string, object> parameters)
        {
            List<object> sqlParameters = new List<object>();

            foreach (KeyValuePair<string, object> keyValue in parameters)
            {
                sqlParameters.Add(new MySqlParameter(keyValue.Key, keyValue.Value));
            }

            return sqlParameters.ToArray();
        }
    }
}
