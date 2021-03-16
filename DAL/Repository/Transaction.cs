using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Repository
{
    public class Transaction : ITransaction
    {
        private readonly DbContext _context;

        public Transaction(DbContext context)
        {
            _context = context;
        }

        public void WithTransaction(Action action)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                action();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public T WithTransaction<T>(Func<T> func)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var t = func();
                transaction.Commit();
                return t;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
}
