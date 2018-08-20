using POProject.BusinessLogic.BusinessDataModel;
using POProject.Model;

namespace POProject.Builder
{
    public class AutoMapBuilder
    {
        public AutoMapBuilder()
        {
        }

        public void BuildAutoMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SerialNote, SerialNoteBusinessDataModel>();
                cfg.CreateMap<SPTPDDetail, SPTPDetailBusinessModel>();
                cfg.CreateMap<UserTransaction, UserTransactionBusinessDataModel>();
                cfg.CreateMap<UserTransactionDetail, UserTransactionDetailBusinessDataModel>();
            });
        }
    }
}
