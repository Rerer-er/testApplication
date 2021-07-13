using System;
using System.Linq;
using System.Linq.Expressions;



namespace Pact
{
    public interface IBaseActionDB<T>
    {
        IQueryable<T> ReturnAll(bool trackChange);
        IQueryable<T> ReturnDistinct(Expression<Func<T, bool>> expression, bool trackChange);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
