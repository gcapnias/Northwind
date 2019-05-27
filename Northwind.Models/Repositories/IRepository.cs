using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        void Post(T entity);
        void Delete(T entity);
        void Put(T entity);
    }
}
