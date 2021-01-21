using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PruebaAloe.Repository.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> CommitChanges();
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> where, string includeProperties = "");
        IQueryable<T> Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        IQueryable<T> Get(params Expression<Func<T, object>>[] include);
        Task<int> Insert(T entity);
        public Task<int> Update(T entity);
        Task<int> Update(T entity, int id);
        public Task<int> SoftDelete(int id);
        int Count();
    }
}
