using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Latitude.DataAccess.Repositories.Impl
{
    public abstract class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly ArgusDbContext _context;
        protected Repository(ArgusDbContext context)
        {
            _context = context;
        }

        public abstract T GetById(TKey id);


        public virtual T Find(Expression<Func<T, bool>> query)
        {
            return _context.Set<T>().SingleOrDefault<T>(query);
        }

        public virtual IQueryable<T> All()
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        public virtual IQueryable<T> All(Expression<Func<T, bool>> query)
        {
            return _context.Set<T>().Where(query);
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Clone(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Detached;
        }
    }
}

