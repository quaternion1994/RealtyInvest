using System;
using System.Linq;
using System.Linq.Expressions;

namespace RealtyInvest.DataModel.Repositories
{
    public interface IRepository<T, in TKey> where T : class
    {
        T GetById(TKey id);

        T Find(Expression<Func<T, bool>> query);

        IQueryable<T> All();

        IQueryable<T> All(Expression<Func<T, bool>> query);

        void Add(T entity);

        void Delete(T entity);

        void Save();

        void Update(T entity);

        void Clone(T entity);
    }
}
