using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace POProject.DataAccess.Persistance
{
  public class DataManagerEntityFramework : IDataManager
  {
    private readonly IDataContext _dataContext;
    private readonly ISqlParameterBuilder _sqlParameterBuilder;

    public DataManagerEntityFramework(IDataContext dataContext, ISqlParameterBuilder sqlParameterBuilder)
    {
      _dataContext = dataContext;
      _sqlParameterBuilder = sqlParameterBuilder;
    }

    public DbContextTransaction BeginTransaction()
    {
      return _dataContext.BeginTransaction();
    }

    public TEntity Create<TEntity>(TEntity entity) where TEntity : class
    {
      DbSet<TEntity> dbSet = _dataContext.Set<TEntity>();

      return dbSet.Add(entity);
    }

    public TEntity Update<TEntity>(TEntity entity) where TEntity : class
    {
      _dataContext.Set<TEntity>().Attach(entity);
      _dataContext.Entry(entity).State = EntityState.Modified;

      return entity;
    }

    public int Delete<TEntity>(TEntity entity) where TEntity : class
    {
      DbSet<TEntity> dbSet = _dataContext.Set<TEntity>();

      if (_dataContext.Entry(entity).State == EntityState.Detached)
      {
        dbSet.Attach(entity);
      }

      dbSet.Remove(entity);

      return 1;
    }

    public int Delete<TEntity>(object id) where TEntity : class
    {
      DbSet<TEntity> dbSet = _dataContext.Set<TEntity>();
      TEntity entity = dbSet.Find(id);

      return Delete(entity);
    }

    public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
    {
      return GetQueryable(filter, orderBy, includeProperties, skip, take).ToList();
    }

    public IEnumerable<TEntity> Get<TEntity>(string sqlQuery, IDictionary<string, object> parameters) where TEntity : class
    {
      return _dataContext.SqlQuery<TEntity>(sqlQuery, _sqlParameterBuilder.BuildSqlParameters(parameters));
    }

    public IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
    {
      return GetQueryable(null, orderBy, includeProperties, skip, take).ToList();
    }

    public TEntity GetById<TEntity>(object id) where TEntity : class
    {
      DbSet<TEntity> dbSet = _dataContext.Set<TEntity>();
      TEntity entity = dbSet.Find(id);

      return entity;
    }

    public TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
    {
      return GetQueryable(filter, orderBy, includeProperties).First();
    }

    public TEntity GetFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
    {
      return GetQueryable(filter, orderBy, includeProperties).FirstOrDefault();
    }

    public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
    {
      return GetQueryable(filter, null, includeProperties).SingleOrDefault();
    }

    public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
    {
      return GetQueryable(filter).Count();
    }

    public bool GetExist<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
    {
      return GetQueryable(filter).Any();
    }

    private IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
    {
      includeProperties = includeProperties ?? string.Empty;
      IQueryable<TEntity> query = _dataContext.Set<TEntity>();

      if (filter != null)
      {
        query = query.Where(filter);
      }

      foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(includeProperty);
      }

      if (orderBy != null)
      {
        query = orderBy(query);
      }

      if (skip.HasValue)
      {
        query = query.Skip(skip.Value);
      }

      if (take.HasValue)
      {
        query = query.Take(take.Value);
      }

      return query;
    }

    public void Save()
    {
      _dataContext.SaveChanges();
    }
  }
}
