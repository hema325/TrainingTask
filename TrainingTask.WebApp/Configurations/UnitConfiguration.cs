using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique(true);
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.Notes).HasColumnType("text");
        }
    }
}
