using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasKey(t => t.Id);
    }
}