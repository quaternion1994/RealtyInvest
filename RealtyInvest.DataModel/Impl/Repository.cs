using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RealtyInvest.DataModel.Repositories;

namespace RealtyInvest.DataModel.Impl
{
    public abstract class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected RealtyInvestDbContext ContextDb { get; }
    
        protected Repository(RealtyInvestDbContext contextDb)
        {
            ContextDb = contextDb;
        }

        public abstract T GetById(TKey id);


        public virtual T Find(Expression<Func<T, bool>> query)
        {
            return ContextDb.Set<T>().FirstOrDefault<T>(query);
        }

        public virtual IQueryable<T> All()
        {
            return ContextDb.Set<T>().AsQueryable<T>();
        }

        public virtual IQueryable<T> All(Expression<Func<T, bool>> query)
        {
            return ContextDb.Set<T>().Where(query);
        }

        public virtual void Add(T entity)
        {
            ContextDb.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            ContextDb.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            ContextDb.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            ContextDb.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Clone(T entity)
        {
            ContextDb.Entry<T>(entity).State = EntityState.Detached;
        }
    }
}

