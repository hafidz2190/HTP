using POProject.BusinessLogic.Entity;
using POProject.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class NopBaruBusiness
    {
        public static NopBaru RetrieveNopBaru(string nop)
        {
            return NopBaruData.RetrieveNopBaru(nop).AsEnumerable<NopBaru>().SingleOrDefault();
        }
    }
}
