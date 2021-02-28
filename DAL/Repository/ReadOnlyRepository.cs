using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repository
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
    {
        private readonly DbContext _context;

        public IQueryable<T> Query => _context.Set<T>().AsNoTracking();

        public ReadOnlyRepository(DbContext context)
        {
            _context = context;
        }
    }
}
