using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Controllers;

namespace TrainingTask.WebApp.Models.Companies
{
    public class AddCompanyViewModel: IMapTo<Entities.Company>
    {
        [StringLength(250)]
        [Remote(nameof(CompaniesController.IsCompanyNameValid),"Companies",ErrorMessage = "Company Name Has Been Taken")]
        public string Name { get; set; }
        public string? Notes { get; set; }
    }
}
