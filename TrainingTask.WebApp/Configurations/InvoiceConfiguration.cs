using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(p => p.Date).HasColumnType("date");
            builder.Property(p => p.Price).HasPrecision(9, 2);
            builder.Property(p => p.PaidUp).HasPrecision(9, 2);
            builder.Property(p => p.Discount).HasPrecision(5, 2);
            builder.Property(p => p.Number).HasMaxLength(10);

            builder.HasIndex(p => p.Number).IsUnique(true);
            builder.HasCheckConstraint("CK_Invoice_SomConstraintsOnColumns", "Quantity >= 0 and Discount >= 0 and PaidUp >= 0");
        }
    }
}
