using POProject.BusinessLogic.BusinessData;
using POProject.Model;

namespace POProject.BusinessLogic
{
    public class NopBaruBusiness : INopBaruBusiness
    {
        private readonly INopBaruBusinessData _nopBaruBusinessData;

        public NopBaruBusiness(INopBaruBusinessData nopBaruBusinessData)
        {
            _nopBaruBusinessData = nopBaruBusinessData;
        }

        public NopBaru RetrieveNopBaru(string nop)
        {
            return _nopBaruBusinessData.RetrieveNopBaru(nop);
        }
    }
}
