using PruebaAloe.Core.Domain;
using PruebaAloe.Repository.Contracts;

namespace PruebaAloe.Services.Contract
{
    public interface IDepartmentService : IBaseService<Department, IDepartmentRepository> { }
}
