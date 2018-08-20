using System;

namespace POProject.Model
{
    public class UserTempError : BaseEntity
    {
        public string Username { get; set; }
        public DateTime tanggal_error { get; set; }
    }
}