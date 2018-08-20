using System;

namespace POProject.Model
{
    public class UserActivity : BaseEntity
    {
        public string Username { get; set; }
        public string Ip_Address { get; set; }
        public DateTime Activity_Date { get; set; }
        public bool Status_Error { get; set; }
        public string Keterangan { get; set; }
    }
}
