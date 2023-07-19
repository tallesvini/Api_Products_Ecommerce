using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data.Map;
using MinhaApi.Models;
using ProductsAPI.Models;

namespace MinhaApi.Data
{
    public class ProductDBContext : IdentityDbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base (options) { }
        
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<AboutProductModel> AboutProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new AboutProductMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
