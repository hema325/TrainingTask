using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TrainingTask.WebApp.Entities;
using TrainingTask.WebApp.Options;

namespace TrainingTask.WebApp.Seeding
{
    public class ModelSeeder: IModelSeeder
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly SeedingOption _seeding;
        #endregion

        #region ctor
        public ModelSeeder(IMapper mapper,IOptions<SeedingOption> option)
        {
            _mapper = mapper;
            _seeding = option.Value;
        }
        #endregion

        #region methods
        public void Seed(ModelBuilder builder)
        {
            var companies = _mapper.Map<IEnumerable<Company>>(_seeding.Companies);
            builder.Entity<Company>().HasData(companies);

            var types = _mapper.Map<IEnumerable<Entities.Type>>(_seeding.Types);
            builder.Entity<Entities.Type>().HasData(types);

            var items = _mapper.Map<IEnumerable<Item>>(_seeding.Items);
            builder.Entity<Item>().HasData(items);

            var clients = _mapper.Map<IEnumerable<Client>>(_seeding.Clients);
            builder.Entity<Client>().HasData(clients);

            var invoices = _mapper.Map<IEnumerable<Invoice>>(_seeding.Invoices);
            builder.Entity<Invoice>().HasData(invoices);

            var units = _mapper.Map<IEnumerable<Unit>>(_seeding.Units);
            builder.Entity<Unit>().HasData(units);
        }
        #endregion
    }
}
