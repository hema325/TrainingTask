
using System.ComponentModel.DataAnnotations;

namespace TrainingTask.WebApp.Options
{
    public class SeedingOption
    {
        public const string Seeding = "Seeding";
        public IEnumerable<ClientOption> Clients { get; set; }
        public IEnumerable<CompanyOption> Companies { get; set; }
        public IEnumerable<InvoiceOption> Invoices { get; set; }
        public IEnumerable<ItemOption> Items { get; set; }
        public IEnumerable<TypeOption> Types { get; set; }
        public IEnumerable<UnitOption> Units { get; set; }
    }
}
