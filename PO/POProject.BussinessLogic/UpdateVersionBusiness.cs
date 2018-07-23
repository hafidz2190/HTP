using POProject.BusinessLogic.Entity;
using POProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POProject.BusinessLogic
{
    public class UpdateVersionBusiness
    {
        public static List<UpdateVersion> GetVersion()
        {
            return UpdateVersionData.GetVersion().AsEnumerable<UpdateVersion>().ToList();
        }
    }
}
