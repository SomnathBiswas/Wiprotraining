using Microsoft.EntityFrameworkCore;
using MyNewApp.Models; // Make sure to add this namespace for your models

public class NewClassContext : DbContext
{
    public NewClassContext(DbContextOptions<NewClassContext> options)
        : base(options)
    { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
