using POProject.Model;

namespace POProject.BusinessLogic.BusinessDataModel
{
    public class SPTPDetailBusinessModel : SPTPDDetail
    {
        private readonly INopBaruBusiness _nopBaruBusiness;

        public SPTPDetailBusinessModel(INopBaruBusiness nopBaruBusiness)
        {
            _nopBaruBusiness = nopBaruBusiness;
        }

        public NopBaru ObyekPajak
        {
            get
            {
                return _nopBaruBusiness.RetrieveNopBaru(Nop);
            }
        }
    }
}
