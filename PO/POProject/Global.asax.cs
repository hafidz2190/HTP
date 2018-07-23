using POWebClient;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace POWebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");
            //Dashboard route
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                defaults: new { controller = "User", action = "Dashboard", id = UrlParameter.Optional }// Parameter defaults
            );
        }

        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        public class FilterConfig
        {
            public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
                filters.Add(new HandleErrorAttribute());
                //filters.Add(new AntiForgeryTokenFilter());
            }
        }

        //public class AntiForgeryTokenFilter : FilterAttribute, IExceptionFilter
        //{
        //    public void OnException(ExceptionContext filterContext)
        //    {
        //        if (filterContext.Exception.GetType() == typeof(HttpAntiForgeryException))
        //        {
        //            filterContext.Result = new RedirectResult("/Frontend/IndexBeranda"); // whatever the url that you want to redirect to
        //            filterContext.ExceptionHandled = true;
        //        }
        //    }
        //}
    }
}
