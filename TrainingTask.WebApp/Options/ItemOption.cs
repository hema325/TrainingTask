using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.CustomAnnotations;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Options
{
    public class ItemOption: IMapTo<Item>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [Range(0, 9999999.99)]
        public decimal SellingPrice { get; set; }

        [Required]
        [Range(0, 9999999.99)]
        [LessThan(nameof(SellingPrice))]
        public decimal BuyingPrice { get; set; }

        public string? Notes { get; set; }

        [Required]
        public int TypeId { get; set; }
    }
}
