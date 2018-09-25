using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace POProject.DataAccess.Persistance
{
    public interface IDataManagerDataTable
    {
        DataTable Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class;
        DataTable Get<TEntity>(string sqlQuery, IDictionary<string, object> parameters) where TEntity : class;
        DataTable GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class;
        DataTable GetById<TEntity>(object id) where TEntity : class;
        DataTable GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class;
        DataTable GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;
    }
}
