using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Avia.Flight.Service.Entities;

namespace Avia.Flight.Service.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        void Create(T entity);
        IReadOnlyCollection<T> GetAll();
        IReadOnlyCollection<T> GetAll(Expression<Func<T, bool>> filter);
        T Get(int id);
        T Get(Expression<Func<T, bool>> filter);
        void RemoveAsync(int id);
        void Update(T entity);
    }
}