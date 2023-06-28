using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;

namespace TrainingTask.WebApp.Models.Unit
{
    public class EditUnitViewModel: IMapFrom<Entities.Unit>, IMapTo<Entities.Unit>
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string? Notes { get; set; }
    }
}
