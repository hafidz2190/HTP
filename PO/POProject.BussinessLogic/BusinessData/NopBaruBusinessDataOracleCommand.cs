using POProject.DataAccess;
using POProject.Model;
using System.Linq;

namespace POProject.BusinessLogic.BusinessData
{
    public class NopBaruBusinessDataOracleCommand : INopBaruBusinessData
    {
        public NopBaru RetrieveNopBaru(string nop)
        {
            return NopBaruData.RetrieveNopBaru(nop).AsEnumerable<NopBaru>().SingleOrDefault();
        }
    }
}