using TrainingTask.WebApp.Common.Entities;

namespace TrainingTask.WebApp.Entities
{
    public class Company: EntityBase
    {
        public string Name { get; set; }
        public string? Notes { get; set; }

        public List<Type> Types { get; set; }
    }
}
