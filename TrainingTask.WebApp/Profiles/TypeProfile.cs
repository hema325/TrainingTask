using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingTask.WebApp.DTOs;
using TrainingTask.WebApp.Models.Types;

namespace TrainingTask.WebApp.Profiles
{
    public class TypeProfile:Profile
    {
        public TypeProfile()
        {
            CreateMap<Entities.Type, TypeDTO>().ForMember(dto => dto.CompanyName, options => options.MapFrom(type => type.Company.Name));
            CreateMap<Entities.Type, TypeDetailsViewModel>().ForMember(model => model.CompanyName, options => options.MapFrom(type => type.Company.Name));
        }
    }
}
