using PruebaAloe.Core.Domain;
using PruebaAloe.Repository.Contracts;
using PruebaAloe.Services.Contract;
using PruebaAloe.Services.Framework;

namespace PruebaAloe.Services.Implementations
{
    public class DepartmentService : BaseService<Department, IDepartmentRepository>, IDepartmentService
    {
        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository) { }
        protected override TaskResult<Department> ValidateOnCreate(Department department) => new TaskResult<Department>();
        protected override TaskResult<Department> ValidateOnDelete(Department department) => new TaskResult<Department>();
        protected override TaskResult<Department> ValidateOnUpdate(Department department) => new TaskResult<Department>();
    }
}
