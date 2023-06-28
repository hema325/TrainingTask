using TrainingTask.WebApp.Common.Entities;

namespace TrainingTask.WebApp.Entities
{
    public class Unit:EntityBase
    {
        public string Name { get; set; }
        public string? Notes { get; set; }
    }
}
