using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Nancy;
using POProject.BusinessLogic;

namespace POProject.API.Module
{
  public class DashboardModule : NancyModule
  {
    private static readonly ILog log = LogManager.GetLogger( typeof( DashboardModule ) );
    private readonly IUserTransactionBusiness _userTransactionBusiness;
    private readonly IUserTransactionDetailBusiness _userTransactionDetailBusiness;

    public DashboardModule(IUserTransactionBusiness userTransactionBusiness, IUserTransactionDetailBusiness userTransactionDetailBusiness)
    {
      _userTransactionBusiness = userTransactionBusiness;
      _userTransactionDetailBusiness = userTransactionDetailBusiness;

      Get["/dev/getAllDailyTransaction"] = parameter =>
      {
        log.Debug( "Start:/dev/getAllDailyTransaction" );
        return Response.AsJson( new { code = HttpStatusCode.OK, message = "Ok"} );
      };
    }
  }
}
