using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Controllers;

namespace TrainingTask.WebApp.Models.Unit
{
    public class AddUnitViewModel : IMapFrom<Entities.Unit>, IMapTo<Entities.Unit>
    {
        [StringLength(250)]
        [Remote(nameof(UnitsController.IsUnitNameValid), "Units", ErrorMessage = "Unit Name Has Been Taken")]
        public string Name { get; set; }
        public string? Notes { get; set; }
    }
}
