using Nancy;
using Nancy.TinyIoc;

namespace POProject.API
{
  internal class Bootstrapper:DefaultNancyBootstrapper
  {
    protected override void ApplicationStartup( TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines )
    {
      //Enable CORS
      pipelines.AfterRequest += ( ctx ) =>
      {
        ctx.Response.Headers.Add( "Access-Control-Allow-Origin", "*" );
        ctx.Response.Headers.Add( "Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept" );
      };
    }

  }
}
