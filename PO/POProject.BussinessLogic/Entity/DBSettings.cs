using System.Collections.Generic;

namespace POProject.BusinessLogic.Entity
{
    public class DBSettings
    {
        public string NamaDB { get; set; }
        public List<SourceDB> lstSourceDB { get; set; }
        public List<NopPajak> LstNop { get; set; }
        public string QueryPajak { get; set; }
        public string QueryDetail { get; set; }
        public string xml_content { get; set; }
    }

    public class NopPajak
    {
        public string JenisPajak { get; set; }
        public string Nop { get; set; }
        public string Alias { get; set; }
        public string TarifPajak { get; set; }
    }

    public class SourceDB
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class JenisPajak
    {
        public string JenPajak { get; set; }
        public string Tarif { get; set; }
    }

    public class settingDBSource
    {
        public string nop { get; set; }
        public string settingDB { get; set; }
        public string namaDB { get; set; }
    }

    public class DatabaseColUsed
    {
        public string JenisPajak { get; set; }
        public string ColumnName { get; set; }
        public string ColumnUsedFor { get; set; }
    }
}
