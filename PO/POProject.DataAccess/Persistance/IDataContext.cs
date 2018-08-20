using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace POProject.DataAccess.Persistance
{
    public interface IDataContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbContextTransaction BeginTransaction();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void SaveChanges();
        IEnumerable<TEntity> SqlQuery<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class;
    }
}
