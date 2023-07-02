using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Controllers;

namespace TrainingTask.WebApp.Models.Companies
{
    public class EditCompanyViewModel: IMapFrom<Entities.Company>,IMapTo<Entities.Company>
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string? Notes { get; set; }
    }
}
