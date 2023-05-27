using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApi.Models;

namespace MinhaApi.Data.Map
{
    public class AboutProductMap : IEntityTypeConfiguration<AboutProductModel>
    {
        public void Configure(EntityTypeBuilder<AboutProductModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.AddProduct).IsRequired();
            builder.Property(x => x.AvailableOnFactory).IsRequired().HasMaxLength(3);
            builder.Property(x => x.ProductId);

            builder.HasOne(x => x.Product);
        }
    }
}
