using POProject.DataAccess;
using POProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic.BusinessData
{
    public class UpdateVersionBusinessDataOracleCommand : IUpdateVersionBusinessData
    {
        public List<UpdateVersion> GetVersion()
        {
            return UpdateVersionData.GetVersion().AsEnumerable<UpdateVersion>().ToList();
        }
    }
}
