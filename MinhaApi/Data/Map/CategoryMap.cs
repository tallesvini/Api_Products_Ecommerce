using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApi.Models;
using ProductsAPI.Models;

namespace MinhaApi.Data.Map
{
    public class CategoryMap : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(255).IsRequired();
        }
    }
}
