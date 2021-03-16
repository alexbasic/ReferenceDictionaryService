using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
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

        public void Delete(long entityId)
        {
            try
            {
                var entries = _context.ChangeTracker.Entries<T>();
                var entry = entries.FirstOrDefault(x => x.IsKeySet && x.Entity.Id == entityId) ??
                    _context.Set<T>().Attach(new T { Id = entityId });
                entry.State = EntityState.Deleted;

                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new KeyNotFoundException($"Ошибка удаления из БД: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
