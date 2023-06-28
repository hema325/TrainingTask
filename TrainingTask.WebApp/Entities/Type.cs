using TrainingTask.WebApp.Common.Entities;

namespace TrainingTask.WebApp.Entities
{
    public class Type: EntityBase
    {
        public string Name { get; set; }
        public string? Notes { get; set; }
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public List<Item> Items { get; set; }
    }
}
