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
            builder.Property(x => x.DateAddProduct).IsRequired();
            builder.Property(x => x.WhoAdded).IsRequired().HasMaxLength(128);
            builder.Property(x => x.IsAvailableOnFactory).IsRequired().HasPrecision(1);
            builder.Property(x => x.ProductId);

            builder.HasOne(x => x.Product);
        }
    }
}
