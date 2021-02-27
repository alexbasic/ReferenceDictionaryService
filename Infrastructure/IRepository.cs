using System;
using System.Linq;

namespace Infrastructure
{
    public interface IRepository<T>
    {
        IQueryable<T> Query { get; }
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
