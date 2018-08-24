using System.Collections.Generic;

namespace POProject.DataAccess.Persistance
{
    public interface ISqlParameterBuilder
    {
        object[] BuildSqlParameters(IDictionary<string, object> parameters);
    }
}
