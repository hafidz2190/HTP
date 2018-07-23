using POProject.BusinessLogic;
using POProject.Membership.Data;
using POProject.Membership.Entity;
using System.Collections.Generic;
using System.Linq;

namespace POProject.Membership
{
    public class MembershipManager
    {
        private UserData dataUser;
        private RoleData dataRole;

        private static volatile MembershipManager instance;
        private static object locker = new object();
        public static MembershipManager Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new MembershipManager();
                    }
                }

                return instance;
            }
        }

        private MembershipManager()
        {
            dataUser = new UserData();
            dataRole = new RoleData();
        }

        #region User Services
        public List<MembershipUser> GetUsers(string username)
        {
            return dataUser.RetrieveUser(username).AsEnumerable<MembershipUser>().ToList();
        }

        public List<MembershipUser> GetUsers(string username, string password)
        {
            return dataUser.RetrieveUser(username, password).AsEnumerable<MembershipUser>().ToList();
        }

        public List<MembershipUserRole> RetrieveAllUserRole(string username)
        {
            return dataUser.RetrieveUserRoles(username).AsEnumerable<MembershipUserRole>().ToList();
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return dataUser.ChangePassword(username, oldPassword, newPassword);
        }

        public bool InsertUser(string username, string idRole, string password, string userapp)
        {
            return dataUser.InsertUser(username, idRole, password, userapp);
        }
        #endregion

        #region Role Services
        public List<MembershipRole> GetRoles(string id)
        {
            return dataRole.RetrieveRoleById(id).AsEnumerable<MembershipRole>().ToList();
        }

        public List<MembershipRole> GetRolesByName(string role)
        {
            return dataRole.RetrieveRoleByName(role).AsEnumerable<MembershipRole>().ToList();
        }
        #endregion       
    }
}
