﻿using System;
using System.Linq;

namespace Infrastructure
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Query { get; }
        long Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
