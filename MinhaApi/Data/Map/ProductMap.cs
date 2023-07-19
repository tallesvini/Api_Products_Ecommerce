using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApi.Models;
using ProductsAPI.Models;

namespace MinhaApi.Data.Map
{
    public class ProductMap : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Sku).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Price).IsRequired().HasPrecision(5, 2);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(30);

            builder.HasOne<CategoryModel>(x => x.Category)
                .WithMany(x => x.Products)
                    .HasForeignKey(x => x.CategoryId);
        }
    }
}
