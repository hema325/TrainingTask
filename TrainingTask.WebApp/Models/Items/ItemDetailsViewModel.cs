using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Controllers;
using TrainingTask.WebApp.CustomAnnotations;

namespace TrainingTask.WebApp.Models.Items
{
    public class ItemDetailsViewModel
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Display(Name = "Selling Price")]
        public decimal SellingPrice { get; set; }

        [Display(Name = "Buying Price")]
        public decimal BuyingPrice { get; set; }

        public string? Notes { get; set; }

        [Display(Name = "Type Name")]
        public string TypeName { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }
}
