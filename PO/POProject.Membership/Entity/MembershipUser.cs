using System;

namespace POProject.Membership.Entity
{
    [Serializable]
    public class MembershipUser
    {
        public string Id_Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Is_Active { get; set; }
        public string User_App { get; set; }
        public DateTime Create_Date { get; set; }
    }
}
