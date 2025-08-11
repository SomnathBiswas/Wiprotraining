using Microsoft.EntityFrameworkCore;

namespace CoreRazorApp.Models
{
    public class OrgContext : DbContext
    {
        public OrgContext(DbContextOptions<OrgContext> options) : base(options)
        {

        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
