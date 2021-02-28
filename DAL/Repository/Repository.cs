using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;

        public IQueryable<T> Query => _context.Set<T>().AsNoTracking();

        public Repository(DbContext context)
        {
            _context = context;
        }

        public long Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
