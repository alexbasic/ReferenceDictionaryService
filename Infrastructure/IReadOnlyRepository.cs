using System.Linq;

namespace Infrastructure
{
    public interface IReadOnlyRepository<T>
    {
        IQueryable<T> Query { get; }
    }
}
