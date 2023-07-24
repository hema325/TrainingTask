using AutoMapper;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.DTOs
{
    public class ItemDTO: IMapFrom<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public string TypeName { get; set; }
        public string CompanyName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Item, ItemDTO>().ForMember(dto => dto.TypeName, options => options.MapFrom(item => item.Type.Name))
            .ForMember(dto => dto.CompanyName, options => options.MapFrom(Item => Item.Type.Company.Name));
        }
    }
}
