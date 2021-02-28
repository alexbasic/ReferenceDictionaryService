using System.Linq;

namespace Infrastructure
{
    public interface IRepositoryWithTypedId<T, TId> where T : IEntity<TId>
    {
        IQueryable<T> Query { get; }
        TId Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
