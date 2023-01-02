using Microsoft.EntityFrameworkCore;
using RedArbor.Employees.DAL.Entities;

namespace RedArbor.Employees.DAL.Data
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
