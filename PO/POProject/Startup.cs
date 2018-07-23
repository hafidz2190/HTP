using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POWebClient.Startup))]
namespace POWebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
