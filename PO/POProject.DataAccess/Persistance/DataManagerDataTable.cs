using POProject.DataAccess.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace POProject.DataAccess.Persistance
{
    public class DataManagerDataTable : IDataManagerDataTable
    {
        private readonly IDataManager _dataManager;
        private readonly ISqlParameterBuilder _sqlParameterBuilder;

        public DataManagerDataTable(IDataManager dataManager, ISqlParameterBuilder sqlParameterBuilder)
        {
            _dataManager = dataManager;
            _sqlParameterBuilder = sqlParameterBuilder;
        }

        public DataTable Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            IList<TEntity> entities = _dataManager.Get(filter, orderBy, includeProperties, skip, take).ToList();

            return DataHelper.ToDataTable(entities);
        }

        public DataTable Get<TEntity>(string sqlQuery, IDictionary<string, object> parameters) where TEntity : class
        {
            IList<TEntity> entities = _dataManager.Get<TEntity>(sqlQuery, parameters).ToList();

            return DataHelper.ToDataTable(entities);
        }

        public DataTable GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            IList<TEntity> entities = _dataManager.GetAll(orderBy, includeProperties, skip, take).ToList();

            return DataHelper.ToDataTable(entities);
        }

        public DataTable GetById<TEntity>(object id) where TEntity : class
        {
            TEntity entity = _dataManager.GetById<TEntity>(id);

            return DataHelper.ToDataTable(entity);
        }

        public DataTable GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        {
            TEntity entity = _dataManager.GetFirst<TEntity>(filter, orderBy, includeProperties);

            return DataHelper.ToDataTable(entity);
        }

        public DataTable GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            TEntity entity = _dataManager.GetOne<TEntity>(filter, includeProperties);

            return DataHelper.ToDataTable(entity);
        }
    }
}
