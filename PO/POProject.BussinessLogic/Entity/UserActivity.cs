using System;

namespace POProject.BusinessLogic.Entity
{
    public class UserActivity
    {
        public string Username { get; set; }
        public string Ip_Address { get; set; }
        public DateTime Activity_Date { get; set; }
        public bool Status_Error { get; set; }
        public string Keterangan { get; set; }
    }
}
