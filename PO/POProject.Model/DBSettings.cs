using System.Collections.Generic;

namespace POProject.Model
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
}