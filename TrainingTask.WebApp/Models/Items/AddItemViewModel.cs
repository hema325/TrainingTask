using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Controllers;
using TrainingTask.WebApp.CustomAnnotations;

namespace TrainingTask.WebApp.Models.Items
{
    public class AddItemViewModel: IMapTo<Entities.Item>
    {
        [StringLength(250)]
        [Remote(nameof(ItemsController.IsItemNameValid), "Items", ErrorMessage = "Item Name Has Been Taken")]
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
