using Demo.WebServer.DAL.Configurations;
using Demo.WebServer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.WebServer.DAL;

public class Context : IdentityDbContext<IdentityUser>
{
    public Context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryOperation> InventoryOperations { get; set; }
    public DbSet<InventoryOperationDetail> InventoryOperationDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Uom> Uoms { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Inventory>().HasKey(t => t.Id).IsClustered(false);
        modelBuilder.Entity<Inventory>().HasOne<Product>().WithMany().HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Inventory>().HasOne<Uom>().WithMany().HasForeignKey(c => c.UomId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Inventory>().Property(c => c.Quantity).HasPrecision(18, 6);

        modelBuilder.Entity<InventoryOperation>().HasKey(t => t.Id).IsClustered(false);

        modelBuilder.Entity<InventoryOperationDetail>().HasKey(t => t.Id).IsClustered(false);
        modelBuilder.Entity<InventoryOperationDetail>().HasOne<Product>().WithMany().HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<InventoryOperationDetail>().HasOne<Uom>().WithMany().HasForeignKey(c => c.UomId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<InventoryOperationDetail>().HasOne<Warehouse>().WithMany().HasForeignKey(c => c.SourceWarehouseId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<InventoryOperationDetail>().HasOne<Warehouse>().WithMany().HasForeignKey(c => c.TargetWarehouseId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<InventoryOperationDetail>().Property(c => c.Quantity).HasPrecision(18, 6);

        modelBuilder.Entity<Product>().HasKey(t => t.Id).IsClustered(false);
        modelBuilder.Entity<Product>().HasOne<ProductCategory>().WithMany().HasForeignKey(c => c.ProductCategoryId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Product>().HasOne<Uom>().WithMany().HasForeignKey(c => c.UomId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Product>().Property(t => t.Name).HasMaxLength(200);

        modelBuilder.Entity<ProductCategory>().HasKey(t => t.Id).IsClustered(false);
        modelBuilder.Entity<ProductCategory>().Property(t => t.Name).HasMaxLength(200);

        modelBuilder.Entity<Uom>().HasKey(t => t.Id).IsClustered(false);
        modelBuilder.Entity<Uom>().Property(t => t.Code).HasMaxLength(100);

        modelBuilder.Entity<Warehouse>().HasKey(t => t.Id).IsClustered(false);

        //modelBuilder.ApplyConfiguration(new RoleConfiguration());
        // modelBuilder.ApplyConfiguration(new UomConfiguration());
        // modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
        // modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}