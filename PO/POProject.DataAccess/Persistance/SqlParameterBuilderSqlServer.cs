using System.Collections.Generic;
using System.Data.SqlClient;

namespace POProject.DataAccess.Persistance
{
    public class SqlParameterBuilderSqlServer : ISqlParameterBuilder
    {
        public object[] BuildSqlParameters(IDictionary<string, object> parameters)
        {
            List<object> sqlParameters = new List<object>();

            foreach (KeyValuePair<string, object> keyValue in parameters)
            {
                sqlParameters.Add(new SqlParameter(keyValue.Key, keyValue.Value));
            }

            return sqlParameters.ToArray();
        }
    }
}
