using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Avia.Flight.Service.Entities;

namespace Avia.Flight.Service.Repositories
{
    public interface IReadOnlyRepository<T> where T : IEntity
    {
        IReadOnlyCollection<T> GetAll();
        IReadOnlyCollection<T> GetAll(Expression<Func<T, bool>> filter);
        T Get(int id);
        T Get(Expression<Func<T, bool>> filter);
    }
}