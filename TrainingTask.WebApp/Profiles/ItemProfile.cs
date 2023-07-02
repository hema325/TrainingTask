using AutoMapper;
using TrainingTask.WebApp.DTOs;
using TrainingTask.WebApp.Entities;
using TrainingTask.WebApp.Models.Items;

namespace TrainingTask.WebApp.Profiles
{
    public class ItemProfile:Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDTO>().ForMember(dto => dto.TypeName, options => options.MapFrom(item => item.Type.Name))
            .ForMember(dto => dto.CompanyName, options => options.MapFrom(Item => Item.Type.Company.Name));
            
            CreateMap<Item, ItemDetailsViewModel>().ForMember(model => model.TypeName, options => options.MapFrom(item => item.Type.Name))
           .ForMember(model => model.CompanyName, options => options.MapFrom(Item => Item.Type.Company.Name));
        }
    }
}
