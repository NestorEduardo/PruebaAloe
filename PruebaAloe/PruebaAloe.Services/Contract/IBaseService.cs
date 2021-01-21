using PruebaAloe.Core.Domain;
using PruebaAloe.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaAloe.Services.Contract
{
    public interface IBaseService<T, U> where T : BaseEntity where U : IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        public Task<int> Create(T entity);
        public Task<int> Update(T entity, int id);
        public Task<int> Delete(int id);
    }
}
