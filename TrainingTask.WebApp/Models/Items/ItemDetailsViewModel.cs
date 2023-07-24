using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Controllers;
using TrainingTask.WebApp.CustomAnnotations;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Models.Items
{
    public class ItemDetailsViewModel: IMapFrom<Item>
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


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Item, ItemDetailsViewModel>()
                .ForMember(model => model.TypeName, options => options.MapFrom(item => item.Type.Name))
                .ForMember(model => model.CompanyName, options => options.MapFrom(Item => Item.Type.Company.Name));
        }
    }
}
