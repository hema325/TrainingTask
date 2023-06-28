using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique(true);
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.Notes).HasColumnType("text");
        }
    }
}
