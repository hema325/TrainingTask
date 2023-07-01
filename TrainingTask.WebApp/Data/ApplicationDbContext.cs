using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using TrainingTask.WebApp.Entities;
using TrainingTask.WebApp.Options;
using TrainingTask.WebApp.Seeding;

namespace TrainingTask.WebApp.Data
{
    public class ApplicationDbContext:DbContext,IApplicationDbContext
    {
        #region fields 
        private readonly IModelSeeder _seeder;
        #endregion

        #region ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IModelSeeder seeder) : base(options) 
        {
            _seeder = seeder;
        }
        #endregion

        #region methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            _seeder.Seed(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region DBSets
        public DbSet<Company> Companies { get; set; }
        public DbSet<Entities.Type> Types { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Unit> Units { get; set; }
        #endregion
    }
}
