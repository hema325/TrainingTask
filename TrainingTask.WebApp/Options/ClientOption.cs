using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Options
{
    public class ClientOption: IMapTo<Client>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(24)]
        [RegularExpression("[\\d\\-\\+\\s]+")]
        public string Phone { get; set; }

        [Required]
        [StringLength(450)]
        public string Address { get; set; }
    }
}
