using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Controllers;

namespace TrainingTask.WebApp.Models.Type
{
    public class EditTypeViewModel: IMapFrom<Entities.Type>, IMapTo<Entities.Type>
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string? Notes { get; set; }

        [Display(Name = "Company Name")]
        public int CompanyId { get; set; }

        public IEnumerable<SelectListItem>? Companies { get; set; }
    }
}
