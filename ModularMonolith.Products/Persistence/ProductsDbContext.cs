using Microsoft.EntityFrameworkCore;
using ModularMonolith.Products.Domain.Entities;

namespace ModularMonolith.Products.Persistence;

public sealed class ProductsDbContext : DbContext
{
    public ProductsDbContext(
        DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ProductsDbContext).Assembly);
    }
}
