using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using POProject.Membership;
using POProject.Membership.Entity;
using POProject.MVC.Flan.Attributes;
using POWebClient.Models;

using CaptchaMvc.HtmlHelpers;
using CaptchaMvc.Attributes;

namespace POWebClient.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public IFormsAuthenticationService FormsService { get; set; }

        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            //repository = new UserRepository();
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.QueryString["ischangepwd"].AsBoolean())
            {
                ViewBag.Message = "Ganti password berhasil, Mohon coba gunakan kembali akun anda.";
            }
            else if (Request.QueryString["isregister"].AsBoolean())
            {
                ViewBag.Message = "Register Berhasil. Gunakan Akun yang sudah anda daftarkan.";
            }
            else
            {
                ViewBag.Message = string.Empty;
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModels model)
        {
            string userName = string.IsNullOrEmpty(model.Username) ? string.Empty : model.Username.ToUpper();
            MembershipUser membershipUser = new MembershipUser();
            List<MembershipUser> lstUser = MembershipManager.Instance.GetUsers(userName);
            if (lstUser == null || lstUser.Count() < 1)
            {
                ModelState.AddModelError("", "Maaf username atau password salah, Mohon ulangi lagi.");
                return View(model);
            }

            if (lstUser.FirstOrDefault().Id_Role == "2")
            {
                string userGroup = string.Empty;
                for (int iList = 0; iList < lstUser.Count; iList++)
                {
                    userGroup += "'" + lstUser[iList].User_App + "',";
                }

                userGroup = userGroup.Remove(userGroup.Length - 1);
                List<UserClient> lstClient = SettingClientBusiness.RetrieveUserClient(userGroup);
                string decryptPass = string.Empty;
                bool isPassCorrect = false;
                foreach (var item in lstClient)
                {

                    string passKey = lstUser.Where(m => m.User_App.Equals(item.Username)).Select(m => m.Password).FirstOrDefault();
                    int i = 0;
                    while (!isPassCorrect && i < lstClient.Count)
                    {
                        try
                        {
                            decryptPass = POAdministrationTools.StringCipher.Decrypt(passKey, item.Serial_Key);
                            if (string.Compare(model.Password, decryptPass) == 0)
                            {
                                membershipUser = lstUser.Where(m => m.User_App.Equals(item.Username) && m.Password.Equals(passKey)).FirstOrDefault();
                               
                            }
                            isPassCorrect = true;
                        }
                        catch (Exception)
                        {
                            
                        }
                        i++;
                    }
                    if (isPassCorrect)
                    {
                        break;
                    }
                }
            }
            else
            {
                membershipUser = lstUser.FirstOrDefault();
            }


            if (ModelState.IsValid)
            {
                if (membershipUser != null)
                {
                    FormsService.SignIn(model.Username, true);
                    Session["WebUsername"] = model.Username.ToUpper();
                    Session["ID"] = Guid.NewGuid();
                    if (MembershipService.ValidateUser(membershipUser.User_App, model.Username, model.Password))
                    {
                        string decodeUrl = "";
                        if (!string.IsNullOrEmpty(model.ReturnUrl))
                        {
                            decodeUrl = Server.UrlDecode(model.ReturnUrl);
                        }
                        if (Url.IsLocalUrl(decodeUrl))
                        {
                            return Redirect(decodeUrl);
                        }
                        else
                        {
                            return RedirectToAction("Dashboard", "User");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Maaf username atau password salah, Mohon ulangi lagi.");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Maaf username atau password salah, Mohon ulangi lagi.");
            }
            return View(model);
        }

        [CustomAuthorize(Roles = "ADMINISTRATOR, USER")]
        public ActionResult ChangePassword()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            model.Username = Session["WebUsername"].ToString();

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model, FormCollection coll)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                //MembershipUser user = MembershipManager.Instance.GetUsers(model.Username).FirstOrDefault();
                string decToken = POAdministrationTools.StringCipher.Decrypt(Session["Token"].ToString(), Session["Serial_Key"].ToString());
                string[] token = decToken.Split('_');
                string oldPassword = token[1];
                if (string.Compare(model.OldPassword, oldPassword) == 0)
                {
                    if (MembershipManager.Instance.ChangePassword(model.Username, Session["xpword"].ToString(), model.ConfirmPassword))
                    {
                        return RedirectToAction("Login", "Account", new { ischangepwd = true });
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Username atau Password Lama Anda Tidak Sesuai. Mohon ulangi isian kembali");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "Password Lama tidak sesuai");
                }

            }
            else
            {
                ModelState.AddModelError("Error", "Form Tidak Valid. Mohon periksa kembali isian anda");
            }

            return View(model);
        }

        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterViewModels model)
        //{
        //    if (this.IsCaptchaValid("Hasil captcha salah"))
        //    {
        //        ModelState.AddModelError("Error", "Form Tidak Valid. Mohon periksa kembali isian anda");
        //    }
        //    else
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            UserClient userClient = SettingClientBusiness.RetrieveUserClient(model.ExistUsername, model.Email).FirstOrDefault();
        //            if (userClient != null)
        //            {
        //                if (!string.IsNullOrEmpty(userClient.Serial_Key))
        //                {
        //                    string webusername = string.Empty;
        //                    UserClient userClientWeb = SettingClientBusiness.RetrieveUserClientByWebUsername(model.Username).FirstOrDefault();
        //                    if (userClientWeb != null)
        //                    {
        //                        webusername = userClientWeb.Web_Username;
        //                    }

        //                    if (string.Compare(webusername, model.Username) != 0)
        //                    {
        //                        if (MembershipManager.Instance.InsertUser(model.Username, "2", POAdministrationTools.StringCipher.Encrypt(model.Password, userClient.Serial_Key),model.us))
        //                        {
        //                            SettingClientBusiness.UpdateWebUsername(model.ExistUsername, model.Username);
        //                            return RedirectToAction("Login", "Account", new { isregister = true });
        //                        }
        //                        else
        //                        {
        //                            ModelState.AddModelError("Error", "Form Tidak Valid. Mohon periksa kembali isian anda");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ModelState.AddModelError("Error", $"Username {model.Username} sudah tersedia.");
        //                    }
        //                }
        //                else
        //                {
        //                    ModelState.AddModelError("Error", $"Username {model.Username} belum di registrasi.");
        //                }
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("Error", $"Username {model.ExistUsername} tidak ditemukan.");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("Error", "Form Tidak Valid. Mohon periksa kembali isian anda");
        //        }
        //    }

        //    return View(model);
        //}

        [AllowAnonymous]
        public ActionResult RegisterExisting()
        {
            return View();
        }

        [HttpPost]
        [CaptchaVerify("Captcha tidak valid")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterExisting(RegisterExistingViewModels model)
        {
            //if (this.IsCaptchaValid("Hasil captcha salah"))
            //{
            //    ModelState.AddModelError("Error", "Hasil captcha tidak valid");
            //}
            //else
            //{
            var errors = ViewData.ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
            if (ModelState.IsValid)
            {
                bool isExist = IsExistUserBPKPD(model.UsernameBpkpd, model.Password);
                //checking if username exist on bpkpd
                if (isExist)
                {
                    UserClient userClient = SettingClientBusiness.RetrieveUserClient(model.UsernameExisting, model.Email).FirstOrDefault();
                    if (userClient != null)
                    {
                        if (!string.IsNullOrEmpty(userClient.Serial_Key))
                        {
                            if (MembershipManager.Instance.InsertUser(model.UsernameBpkpd, "2", POAdministrationTools.StringCipher.Encrypt(model.Password, userClient.Serial_Key), model.UsernameExisting))
                            {
                                SettingClientBusiness.UpdateWebUsername(model.UsernameExisting, model.UsernameBpkpd);
                                return RedirectToAction("Login", "Account", new { isregister = true });
                            }
                            else
                            {
                                ModelState.AddModelError("Error", "Form Tidak Valid. Mohon periksa kembali isian anda");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Error", $"Username {model.UsernameBpkpd} belum di registrasi.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Error", $"Username {model.UsernameBpkpd} tidak ditemukan.");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", $"Username {model.UsernameExisting} tidak ditemukan.");
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Form Tidak Valid. Mohon periksa kembali isian anda");
            }
            //}
            return View(model);
        }

        bool IsExistUserBPKPD(string username, string password)
        {
            var isExist = false;
            string RequestUrl = UserApiUrlBusiness.RetrieveApiUrl();
            RequestUrl = $"{RequestUrl}/UserBpkpd/CheckUserBpkpd";
            var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(RequestUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            UserRequest user = new UserRequest();
            user.username = username;
            user.password = password;
            user.key = "ponline";

            string jsonSent = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            //send request
            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonSent);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
            {
                var resultResponse = streamReader.ReadToEnd();
                //{ "code":"00","status":"true"}
                ResultRequest result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultRequest>(resultResponse);
                if (string.Compare(result.code, ((int)Code.Success).ToString("D2")) == 0)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
            }

            return isExist;
        }
        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //if (Session["Username"] != null)
            //{
            //    MembershipManager.Instance.UpdateIsLogin(Session["Username"].ToString(), false, DateTime.Now);
            //}
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsService.SignOut();
            Session.Abandon();

            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Services
        public interface IMembershipService
        {
            int MinPasswordLength { get; }

            bool ValidateUser(string usernameapp, string username, string password);
            string GetRoleId(string name);
            MembershipRole GetRole(string id);
            List<MembershipUser> RetrieveUsers(string username);
            List<MembershipRole> RetrieveRoles(string role);
            List<MembershipUserRole> RetrieveUserRole(string username);
        }

        public class AccountMembershipService : IMembershipService
        {
            public int MinPasswordLength
            {
                get
                {
                    return 6;
                }
            }

            public bool ValidateUser(string usernameapp, string username, string password)
            {
                return LoginManager.Instance.Login(usernameapp, username, password);
            }

            public string GetRoleId(string name)
            {
                return MembershipManager.Instance.GetRoles(name)[0].Id_Role.ToString();
            }

            public MembershipRole GetRole(string id)
            {
                List<MembershipRole> result = MembershipManager.Instance.GetRoles(id);

                return (result != null && result.Count > 0) ? result[0] : null;
            }

            public List<MembershipUser> RetrieveUsers(string username)
            {
                return MembershipManager.Instance.GetUsers(username);
            }

            public List<MembershipRole> RetrieveRoles(string role)
            {
                return MembershipManager.Instance.GetRolesByName(role);
            }

            public List<MembershipUserRole> RetrieveUserRole(string username)
            {
                return MembershipManager.Instance.RetrieveAllUserRole((username));
            }
        }

        public interface IFormsAuthenticationService
        {
            void SignIn(string userName, bool createPersistentCookie);
            void SignOut();
        }

        public class FormsAuthenticationService : IFormsAuthenticationService
        {
            public void SignIn(string userName, bool createPersistentCookie)
            {
                if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
                System.Web.Security.FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
            }

            public void SignOut()
            {
                System.Web.Security.FormsAuthentication.SignOut();
                LoginManager.Instance.Logout();
            }
        }
        #endregion

        #region Validation
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class ValidatePasswordLengthAttribute : ValidationAttribute, IClientValidatable
        {
            private const string _defaultErrorMessage = "'{0}' minimal panjangnya harus {1} karakter.";
            private readonly int _minCharacters = 6;

            public ValidatePasswordLengthAttribute()
                : base(_defaultErrorMessage)
            {
            }

            public override string FormatErrorMessage(string name)
            {
                return String.Format(CultureInfo.CurrentCulture, ErrorMessageString,
                    name, _minCharacters);
            }

            public override bool IsValid(object value)
            {
                string valueAsString = value as string;
                return (valueAsString != null && valueAsString.Length >= _minCharacters);
            }

            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                return new[]{
                new ModelClientValidationStringLengthRule(FormatErrorMessage(metadata.GetDisplayName()), _minCharacters, int.MaxValue)
            };
            }
        }
        #endregion

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

        #region NestedClass
        public class UserRequest
        {
            public string username { get; set; }
            public string password { get; set; }
            public string key { get; set; }
        }

        class ResultRequest
        {
            public string code { get; set; }
            public string status { get; set; }
        }

        public enum Code
        {
            Success = 00,
            WrongKey = 10,
            FatalError = 99
        }
        #endregion
    }
}