using Desafio.ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.ProductService.Data
{
    public class ProductServiceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOwner> ProductOwners { get; set; }
        public ProductServiceContext(DbContextOptions<ProductServiceContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasOne(p => p.ProductOwner).WithMany(po => po.Products).HasForeignKey(p => p.ProductOwnerId);
        }
    }
}
