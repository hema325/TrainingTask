using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;

namespace TrainingTask.WebApp.Models.Types
{
    public class TypeDetailsViewModel: IMapFrom<Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Notes { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Type, TypeDetailsViewModel>()
                .ForMember(model => model.CompanyName, options => options.MapFrom(type => type.Company.Name));
        }
    }
}
