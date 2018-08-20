using System.Collections.Generic;

namespace POProject.Model
{
    public class AppSettings
    {
        public IEnumerable<USERAPP> list_user { get; set; }
        public IEnumerable<NOP> list_nop { get; set; }
        public IEnumerable<Setting> settings { get; set; }
        public string xml_content { get; set; }
    }
}