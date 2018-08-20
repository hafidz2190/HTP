namespace POProject.Model
{
    public class UserSettingDatabase : BaseEntity
    {
        public string Username { get; set; }
        public string Nop { get; set; }
        public string JenisPajak { get; set; }
        public string Tarif { get; set; }
        public string Query_Pajak { get; set; }
        public string Query_Detail { get; set; }
        public string Alias { get; set; }
    }
}
