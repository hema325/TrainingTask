using TrainingTask.WebApp.Common.Mapping;

namespace TrainingTask.WebApp.Models.Units
{
    public class UnitDetailsViewModel: IMapFrom<Entities.Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Notes { get; set; }
    }
}
