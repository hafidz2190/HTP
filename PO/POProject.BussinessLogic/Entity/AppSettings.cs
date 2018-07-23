using System.Collections.Generic;

namespace POProject.BusinessLogic.Entity
{
    public class AppSettings
    {
        public IEnumerable<USERAPP> list_user { get; set; }
        public IEnumerable<NOP> list_nop { get; set; }
        public IEnumerable<Setting> settings { get; set; }
        public string xml_content { get; set; }
    }

    public class UserTempSetting
    {
        public int id_setting { get; set; }
        public string nama_setting { get; set; }
        public string value { get; set; }
        public string keterangan { get; set; }
    }
}
