using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique(true);
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.Notes).HasColumnType("text");
            builder.Property(p => p.SellingPrice).HasPrecision(9, 2);
            builder.Property(p => p.BuyingPrice).HasPrecision(9, 2);
            builder.HasCheckConstraint("CK_Items_SellingBuyingPrice", "SellingPrice >= BuyingPrice and SellingPrice >= 0 and BuyingPrice >= 0");
        }
    }
}
