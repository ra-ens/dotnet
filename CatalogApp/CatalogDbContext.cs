using Microsoft.EntityFrameworkCore;
using CatalogApp.Models;

public class CatalogDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) {}
}