using Microsoft.Practices.Unity;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Unity;

namespace POProject.API
{
    public class CustomNancyBootstrapper : UnityNancyBootstrapper
    {
        private IUnityContainer _container;

        public CustomNancyBootstrapper(IUnityContainer container)
        {
            _container = container;
            _container.AddNewExtension<EnumerableExtension>();
        }

        protected override IUnityContainer GetApplicationContainer()
        {
            return _container;
        }

        protected override void ApplicationStartup(IUnityContainer container, IPipelines pipelines)
        {
            //Enable CORS
            pipelines.AfterRequest += (ctx) =>
            {
                ctx.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                ctx.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            };
        }
    }
}
