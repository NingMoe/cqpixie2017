using cqpixie.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using cqpixie.Model;

namespace cqpixie.DAL.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private cqpixieEntities context;

        private DbSet<T> dbSet;
        public Repository()
        {
           this.context = new cqpixieEntities();
           this.dbSet = context.Set<T>();
        }

        public int Count()
        {
            IQueryable<T> query = dbSet;
            return query.Count();
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                return query.Count(filter);
            }
            else
            {
                return query.Count();
            }
        }

        public virtual void Delete(int id)
        {
            dbSet.Remove(dbSet.Find(id));
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (query == null)
            {
                return null;
            }
            else
            {
               return query.FirstOrDefault();
            }
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet; 
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return query;

        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
            
        }

        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}