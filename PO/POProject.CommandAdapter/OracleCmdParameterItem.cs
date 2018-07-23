using System;

namespace POProject.CommandAdapter
{
    [Serializable]
    public class OracleCmdParameterItem
    {
        public string Name { get; private set; }
        public string RawName { get; private set; }
        public OracleCmdParameterDirection Direction { get; private set; }
        public object Value { get; set; }

        public OracleCmdParameterItem(string name, OracleCmdParameterDirection direction, object value)
        {
            Name = name;
            RawName = ":" + name;
            Direction = direction;
            Value = value;
        }
    }
}
