using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserProfiles.Domain.Data
{
    public class Repository<TU, T> : IRepository<TU, T>
        where TU : DbContext
        where T : class
    {
        private readonly UnitOfWork<TU> _unitOfWork;

        protected Repository(UnitOfWork<TU> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UnitOfWork<TU> UnitOfWork => _unitOfWork;

        public IQueryable<T> Query()
        {
            return _unitOfWork.Query<T>();
        }

        //public T Get(Guid id)
        //{
        //    return _unitOfWork.Get<T>(id);
        //}

        public T Create(T entity)
        {
            _unitOfWork.Create(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _unitOfWork.Update(entity);
        }

        public void Delete(T entity)
        {
            _unitOfWork.Delete(entity);
        }
    }
}
