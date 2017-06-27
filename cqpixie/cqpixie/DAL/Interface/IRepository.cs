using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cqpixie.DAL.Interface
{
    public interface IRepository<T> where T:class
    {
        void Delete(int id);
        void Insert(T entity);
        void Update(T entity);
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,IOrderedQueryable<T>> orderBy=null);
        int Count();
        int Count(Expression<Func<T, bool>> filter);
    }
}
