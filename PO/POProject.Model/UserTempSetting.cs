namespace POProject.Model
{
    public class UserTempSetting : BaseEntity
    {
        public int id_setting { get; set; }
        public string nama_setting { get; set; }
        public string value { get; set; }
        public string keterangan { get; set; }
    }
}