using Demo.Desktop.Model.Configurations;
using Demo.Desktop.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Desktop.Model;

public class Context : DbContext
{
    public string ConnectionString { get; }

    public Context()
    {
        ConnectionString = @"Filename=./DemoClient.db";
    }

    public Context(DbContextOptions options) : base(options)
    {
    }

    public Context(string connectionString)
    {
        ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }


    public DbSet<Setting> Settings { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!string.IsNullOrEmpty(ConnectionString))
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Setting>().HasKey(t => t.Id);

        modelBuilder.ApplyConfiguration(new SettingConfiguration());
    }
}