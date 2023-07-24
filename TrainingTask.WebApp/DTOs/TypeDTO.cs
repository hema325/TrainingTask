using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;

namespace TrainingTask.WebApp.DTOs
{
    public class TypeDTO: IMapFrom<Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Type, TypeDTO>()
                .ForMember(dto => dto.CompanyName, options => options.MapFrom(type => type.Company.Name));
        }
    }
}
