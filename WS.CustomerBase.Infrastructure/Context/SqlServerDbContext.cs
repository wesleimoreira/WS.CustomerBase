using Microsoft.EntityFrameworkCore;
using WS.CustomerBase.Domain.Entities;
using WS.CustomerBase.Infrastructure.Configurations;

namespace WS.CustomerBase.Infrastructure.Context;

public class SqlServerDbContext : DbContext
{
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
    {}

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
    }
}