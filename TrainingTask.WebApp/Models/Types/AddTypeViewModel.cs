using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Controllers;

namespace TrainingTask.WebApp.Models.Types
{
    public class AddTypeViewModel: IMapTo<Entities.Type>
    {
        [StringLength(250)]
        [Remote(nameof(TypesController.IsTypeNameValid), "Types", ErrorMessage = "Type Name Has Been Taken")]
        public string Name { get; set; }
        public string? Notes { get; set; }

        [Display(Name="Company Name")]
        public int CompanyId { get; set; }
        
        public IEnumerable<SelectListItem>? Companies { get; set; }
    }
}
