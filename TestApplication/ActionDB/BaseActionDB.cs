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

        public IQueryable<T> ReturnAll() =>
            _context.Set<T>().AsNoTracking();
        public IQueryable<T> ReturnDistinct(Expression<Func<T, bool>> expression) => 
            _context.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}
