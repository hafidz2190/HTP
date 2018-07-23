using POProject.Membership;
using POProject.MVC.Flan.EnhancedMenu;
using System.Collections.Generic;
using System.Linq;

namespace POWebClient.Models
{
    public class NavigationModels
    {
        public static IEnumerable<NavigationItem> DataSource
        {
            get
            {
                List<NavigationItem> tempLinks = new List<NavigationItem>();
                tempLinks.Add(new NavigationItem
                {
                    Id = "dashboard",
                    Text = "Dashboard",
                    Role = "ADMINISTRATOR,USER",
                    ControllerName = "User",
                    ActionName = "Dashboard",
                    Visible = true,
                    IsLoginNeed = true,
                    IconBootstrap = "fa fa-home"
                });

                //tempLinks.Add(new NavigationItem
                //{
                //    Id = "peranan",
                //    Text = "Partisipasi",
                //    Role = "ADMINISTRATOR,USER",
                //    ControllerName = "User",
                //    ActionName = "PerananMasyarakat",
                //    Visible = true,
                //    IsLoginNeed = true,
                //    IconBootstrap = "fa fa-users"
                //});

                tempLinks.Add(new NavigationItem
                {
                    Id = "profile",
                    Text = "Profil",
                    Role = "USER",
                    ControllerName = "User",
                    ActionName = "ProfileUser",
                    Visible = true,
                    IsLoginNeed = true,
                    IconBootstrap = "fa fa-user"
                });

                tempLinks.Add(new NavigationItem
                {
                    Id = "information",
                    Text = "Hasil Perekaman",
                    Role = "ADMINISTRATOR, USER",
                    ControllerName = "User",
                    ActionName = "Information",
                    Visible = true,
                    IsLoginNeed = true,
                    IconBootstrap = "fa fa-info"
                });

                tempLinks.Add(new NavigationItem
                {
                    Id = "adjustmen",
                    Text = "Adjustmen",
                    Role = "ADMINISTRATOR, USER",
                    ControllerName = "User",
                    ActionName = "Adjusment",
                    Visible = true,
                    IsLoginNeed = true,
                    IconBootstrap = "fa fa-desktop"
                });

                tempLinks.Add(new NavigationItem
                {
                    Id = "rekap",
                    Text = "Rekap Transaksi",
                    Role = "ADMINISTRATOR, KABAN",
                    ControllerName = "User",
                    ActionName = "ResultRekapWp",
                    Visible = true,
                    IsLoginNeed = true,
                    IconBootstrap = "fa fa-desktop"
                });

                tempLinks.Add(new NavigationItem
                {
                    Id = "payment",
                    Text = "Generate Pembayaran",
                    Role = "USER",
                    ControllerName = "Payment",
                    ActionName = "GeneratePayment",
                    Visible = true,
                    IsLoginNeed = true,
                    IconBootstrap = "fa fa-money"
                });

                tempLinks.Add(new NavigationItem
                {
                    Id = "bank",
                    Text = "Data Pajak Terutang",
                    Role = "BANK",
                    ControllerName = "Bank",
                    ActionName = "Index",
                    Visible = true,
                    IsLoginNeed = true,
                    IconBootstrap = "fa fa-money"
                });

                string role = string.Empty;
                if (LoginManager.Instance.IsLoggedIn)
                {
                    role = LoginManager.Instance.getLoginInUserRole().Name_Role;
                }

                List<NavigationItem> result = null;
                if (string.IsNullOrEmpty(role))
                {
                    result = tempLinks.Where(m => string.IsNullOrEmpty(m.Role)).ToList();
                }
                else
                {
                    result = tempLinks.Where(m => m.Role.ToLower().Contains(role.ToLower()) || string.IsNullOrEmpty(m.Role)).ToList();
                }
                NavigationDataSource.NavigationItems = result;

                return NavigationDataSource.NavigationItems;
            }
        }
    }
}