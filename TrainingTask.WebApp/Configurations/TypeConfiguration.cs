using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrainingTask.WebApp.Configurations
{
    public class TypeConfiguration : IEntityTypeConfiguration<Entities.Type>
    {
        public void Configure(EntityTypeBuilder<Entities.Type> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.Notes).HasColumnType("text");
            builder.HasIndex(t => t.Name).IsUnique(true);
        }
    }
}
