using Microsoft.Practices.Unity;
using POProject.BusinessLogic;
using POProject.BusinessLogic.BusinessData;
using POProject.DataAccess.Persistance;
using System.Collections.Generic;

namespace POProject.Builder
{
    public class MainObjectBuilder
    {
        private readonly IUnityContainer _container;

        public MainObjectBuilder(IUnityContainer container)
        {
            _container = container;
        }

        public IDictionary<string, object> BuildMainObject()
        {
            _container.RegisterType<ISqlParameterBuilder, SqlParameterBuilderMySql>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IDataContext, DataContext>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IDataManager, DataManagerEntityFramework>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IDataManagerDataTable, DataManagerDataTable>(new ContainerControlledLifetimeManager());

            _container.RegisterType<IBankBusinessData, BankBusinessData>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IJatuhTempoBusinessData, JatuhTempoBusinessData>(new ContainerControlledLifetimeManager());
            _container.RegisterType<INopBaruBusinessData, NopBaruBusinessData>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUpdateVersionBusinessData, UpdateVersionBusinessData>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISerialNoteBusinessData, SerialNoteBusinessData>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISettingClientBusinessData, SettingClientBusinessData>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISPTPDDetailBusinessData, SPTPDDetailBusinessData>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserActivityBusinessData, UserActivityBusinessData>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserSettingColumnBusinessData, UserSettingColumnBusinessData>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserTransactionBusinessData, UserTransactionBusinessData>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserTransactionDetailBusinessData, UserTransactionDetailBusinessData>(new ContainerControlledLifetimeManager());

            _container.RegisterType<IBankBusiness, BankBusiness>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IJatuhTempoBusiness, JatuhTempoBusiness>(new ContainerControlledLifetimeManager());
            _container.RegisterType<INopBaruBusiness, NopBaruBusiness>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUpdateVersionBusiness, UpdateVersionBusiness>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISerialNoteBusiness, SerialNoteBusiness>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISettingClientBusiness, SettingClientBusiness>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISPTPDDetailBusiness, SPTPDDetailBusiness>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserActivityBusiness, UserActivityBusiness>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserSettingColumnBusiness, UserSettingColumnBusiness>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserTransactionBusiness, UserTransactionBusiness>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserTransactionDetailBusiness, UserTransactionDetailBusiness>(new ContainerControlledLifetimeManager());

            IDictionary<string, object> mainObjectMap = new Dictionary<string, object>();

            return mainObjectMap;
        }
    }
}
