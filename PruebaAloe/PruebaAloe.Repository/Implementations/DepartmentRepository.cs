using PruebaAloe.Core.Domain;
using PruebaAloe.Data;
using PruebaAloe.Repository.Contracts;

namespace PruebaAloe.Repository.Implementations
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext database) : base(database) { }
    }
}
