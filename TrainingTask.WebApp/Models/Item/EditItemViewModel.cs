using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.CustomAnnotations;

namespace TrainingTask.WebApp.Models.Item
{
    public class EditItemViewModel: IMapFrom<Entities.Item>,IMapTo<Entities.Item>
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Display(Name = "Selling Price")]
        [Range(0, 9999999.99, ErrorMessage = "Selling Price Must Be Positive Number")]
        public decimal SellingPrice { get; set; }

        [Display(Name = "Buying Price")]
        [Range(0, 9999999.99, ErrorMessage = "Buying Price Must Be Positive Number")]
        [LessThan(nameof(SellingPrice))]
        public decimal BuyingPrice { get; set; }

        public string? Notes { get; set; }

        [Display(Name = "Type Name")]
        public int TypeId { get; set; }

        public IEnumerable<SelectListItem>? Types { get; set; }
    }
}
