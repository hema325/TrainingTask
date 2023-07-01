using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;

namespace TrainingTask.WebApp.Options
{
    public class TypeOption: IMapTo<Entities.Type>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string? Notes { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
