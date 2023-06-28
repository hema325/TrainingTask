using Microsoft.EntityFrameworkCore;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Company> Companies { get; }
        DbSet<Entities.Type> Types { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<Unit> Units { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
