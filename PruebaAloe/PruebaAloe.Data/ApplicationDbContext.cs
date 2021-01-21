using Microsoft.EntityFrameworkCore;
using PruebaAloe.Core.Domain;

namespace PruebaAloe.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
    }
}
