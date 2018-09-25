namespace POProject.Model
{
    public class UserClient : BaseEntity
    {
        public string Username { get; set; }
        public string Id_Machine { get; set; }
        public string Password { get; set; }
        public string Web_Username { get; set; }
        public string Serial_Key { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Kode_Bank { get; set; }
        public bool Status_Aktif { get; set; }
        public int Port_Client { get; set; }
    }
}