using DAL.Repository;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal.Tests
{
    public class TestRepositoryFactory : IRepositoryFactory
    {
        private readonly DbContext _context;

        public TestRepositoryFactory(DbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetReadOnlyRepository<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public IRepository<T> GetRepository<T>() where T : Entity
        {
            return new Repository<T>(_context);
        }
    }
}