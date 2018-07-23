using System.Collections.Generic;
using System.Runtime.Serialization;

namespace POProject.CommandAdapter
{
    public class OracleCmdParameterCollection : Dictionary<string, OracleCmdParameterItem>
    {
        public OracleCmdParameterCollection()
        {

        }
        public OracleCmdParameterCollection(int capacity)
            : base(capacity)
        {

        }
        public OracleCmdParameterCollection(IEqualityComparer<string> comparer)
            : base(comparer)
        {

        }
        public OracleCmdParameterCollection(int capacity, IEqualityComparer<string> comparer)
            : base(capacity, comparer)
        {

        }
        public OracleCmdParameterCollection(IDictionary<string, OracleCmdParameterItem> dictionary)
            : base(dictionary)
        {

        }
        public OracleCmdParameterCollection(IDictionary<string, OracleCmdParameterItem> dictionary, IEqualityComparer<string> comparer)
            : base(dictionary, comparer)
        {

        }
        protected OracleCmdParameterCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
