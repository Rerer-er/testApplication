using System;
using System.Collections.Generic;
using System.Text;

using Pact;
using Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ActionDB
{
    public abstract class BaseActionDB<T> : IBaseActionDB<T> where T : class
    {
        protected ApplicationContext _context;
        public BaseActionDB(ApplicationContext context) 
        { 
            _context = context; 
        }

        public IQueryable<T> ReturnAll(bool trackChanges) => !trackChanges ?
            _context.Set<T>().AsNoTracking() : _context.Set<T>();
        public IQueryable<T> ReturnDistinct(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ?
            _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);
        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}
