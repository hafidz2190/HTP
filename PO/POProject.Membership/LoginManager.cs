using POAdministrationTools;
using POProject.BusinessLogic.Entity;
using POProject.Membership.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POProject.Membership
{
    public class LoginManager
    {
        private static volatile LoginManager instance;
        private static object locker = new object();
        public static LoginManager Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new LoginManager();
                    }
                }
                return instance;
            }
        }

        private LoginManager() { }

        /// <summary>
        /// Validate username dan password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Boolean</returns>
        public bool Login(string username, string password)
        {
            bool result = false;
            MembershipUser user;
            List<MembershipUser> users = MembershipManager.Instance.GetUsers(username);
            if (users.Count > 0)
                user = users[0];
            else
                user = null;
            if (user != null)
            {
                UserClient userClient = BusinessLogic.SettingClientBusiness.RetrieveUserClientByWebUsername(username).FirstOrDefault();
                var usern = userClient == null ? username : userClient.Username;
                bool isPasswordCorrect = false;
                try
                {
                    var decryptPass = userClient == null ? StringCipher.Decrypt(user.Password, "SURABAYA") :
                                                           StringCipher.Decrypt(user.Password, userClient.Serial_Key);

                    isPasswordCorrect = decryptPass == password;
                }
                catch (Exception ex)
                {
                    return false;
                }

                if (isPasswordCorrect)
                {
                    //sukses login
                    result = true;
                    if (HttpContext.Current != null)
                    {
                        var serial = userClient != null ? userClient.Serial_Key : "SURABAYA";
                        HttpContext.Current.Session.Add("WebUsername", user.Username);
                        HttpContext.Current.Session.Add("Username", usern);
                        HttpContext.Current.Session.Add("Xpword", user.Password);
                        HttpContext.Current.Session.Add("Serial_Key", serial);
                        HttpContext.Current.Session.Add("Nama_Role", getLoginInUserRole().Name_Role);
                        HttpContext.Current.Session.Add("Token", StringCipher.Encrypt(string.Format("{0}_{1}", user.Username.ToUpper(), password), serial));
                    }
                }
            }

            HttpContext.Current.Session["MembershipUser"] = user;
            return result;
        }

        public bool UpdateToken(string newPassword)
        {
            bool result = true;
            try
            {
                if (HttpContext.Current.Session["Username"] != null)
                {
                    var serial = HttpContext.Current.Session["Serial_Key"].ToString();
                    var newToken = (HttpContext.Current.Session["Username"].ToString().ToUpper() + "_" + newPassword);
                    HttpContext.Current.Session["Token"] = StringCipher.Encrypt(newToken, serial);
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }


        /// <summary>
        /// Logout
        /// </summary>
        public void Logout()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Session.Clear();
            }
        }

        /// <summary>
        /// Get logged in user
        /// </summary>
        /// <returns>MembershipUser</returns>
        public MembershipUser GetLoggedInUser()
        {
            MembershipUser result = null;
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["MembershipUser"] == null)
                {
                    if (HttpContext.Current.Session["Username"] != null)
                    {
                        List<MembershipUser> users = MembershipManager.Instance.GetUsers(HttpContext.Current.Session["Username"].ToString());
                        if (users.Count > 0)
                        {
                            result = users[0];
                        }
                    }
                }
                else
                {
                    result = HttpContext.Current.Session["MembershipUser"] as MembershipUser;
                }
            }

            HttpContext.Current.Session["MembershipUser"] = result;

            return result;
        }

        public MembershipRole getLoginInUserRole()
        {
            MembershipRole result = null;
            MembershipUser membershipUser = null;
            try
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session["MembershipUser"] == null)
                    {
                        List<MembershipUser> userList = MembershipManager.Instance.GetUsers(HttpContext.Current.Session["WebUsername"].ToString());
                        membershipUser = userList[0];
                    }
                    else
                    {
                        membershipUser = HttpContext.Current.Session["MembershipUser"] as MembershipUser;
                    }

                    if (membershipUser != null)
                    {
                        if (HttpContext.Current.Session["MembershipRole"] == null)
                        {
                            List<MembershipRole> roleList = MembershipManager.Instance.GetRoles(membershipUser.Id_Role);
                            if (roleList.Count > 0)
                            {
                                result = roleList[0];
                            }
                        }
                        else
                        {
                            result = HttpContext.Current.Session["MembershipRole"] as MembershipRole;
                        }

                        HttpContext.Current.Session["MembershipRole"] = result;
                    }
                }
            }
            catch (Exception)
            {

            }
            return result;
        }

        public bool IsLoggedIn
        {
            get
            {
                bool loggedIn = false;
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session["Token"] != null &&
                        HttpContext.Current.Session["WebUsername"] != null)
                    {
                        var serial = HttpContext.Current.Session["Serial_Key"].ToString();

                        string plainToken = StringCipher.Decrypt((HttpContext.Current.Session["Token"].ToString()), serial);
                        MembershipUser user = null;
                        if (HttpContext.Current.Session["MembershipUser"] == null)
                        {
                            List<MembershipUser> users = MembershipManager.Instance.GetUsers(HttpContext.Current.Session["WebUsername"].ToString());

                            if (users.Count > 0)
                            {
                                user = users[0];
                            }
                        }
                        else
                        {
                            user = HttpContext.Current.Session["MembershipUser"] as MembershipUser;
                        }


                        if (user != null)
                        {
                            string originalToken = string.Format("{0}_{1}", HttpContext.Current.Session["WebUsername"].ToString().ToUpper(), StringCipher.Decrypt(user.Password, serial));
                            if (string.Compare(plainToken, originalToken) == 0)
                            {
                                loggedIn = true;
                            }
                            else
                            {
                                Logout();
                            }
                        }
                        else
                        {
                            Logout();
                        }
                    }
                }

                return loggedIn;
            }
        }
    }
}
