using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique(true);
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.Phone).HasMaxLength(24);
            builder.Property(p => p.Address).HasMaxLength(450);
        }
    }
}
