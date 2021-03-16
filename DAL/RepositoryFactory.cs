using DAL.Repository;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly DbContext _context;

        public RepositoryFactory(DbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : Entity, new()
        {
            return new Repository<T>(_context);
        }
    }
}
