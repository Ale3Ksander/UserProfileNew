using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace UserProfiles.Domain.Data
{
    public class UnitOfWork<TU> where TU : DbContext, IDisposable
    {
        private readonly TU _dbContext;

        public UnitOfWork(TU dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit(bool dispose = true)
        {
            try
            {
                _dbContext.SaveChanges();
            }
            finally
            {
                if (dispose)
                {
                    _dbContext.Dispose();
                }
            }
        }

        public T Get<T>(Guid id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }
        public IQueryable<T> Query<T>() where T : class
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public T Create<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Attach(entity);
            return entity;
        }

        public void Update<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Attach(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }
}
