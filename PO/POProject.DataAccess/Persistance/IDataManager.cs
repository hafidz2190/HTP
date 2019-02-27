using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace POProject.DataAccess.Persistance
{
  public interface IDataManager
  {
    DbContextTransaction BeginTransaction();
    TEntity Create<TEntity>(TEntity entity) where TEntity : class;
    TEntity Update<TEntity>(TEntity entity) where TEntity : class;
    int Delete<TEntity>(TEntity entity) where TEntity : class;
    int Delete<TEntity>(object id) where TEntity : class;
    IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class;
    IEnumerable<TEntity> Get<TEntity>(string sqlQuery, IDictionary<string, object> parameters) where TEntity : class;
    IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class;
    TEntity GetById<TEntity>(object id) where TEntity : class;
    TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class;
    TEntity GetFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class;
    TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;
    int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
    bool GetExist<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
    void Save();
  }
}
