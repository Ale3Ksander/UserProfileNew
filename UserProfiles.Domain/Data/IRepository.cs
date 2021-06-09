using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserProfiles.Domain.Data
{
    public interface IRepository<TU, T>
        where TU : DbContext
        where T : class
    {
        UnitOfWork<TU> UnitOfWork { get; }
        IQueryable<T> Query();
        //T Get(Guid id);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
