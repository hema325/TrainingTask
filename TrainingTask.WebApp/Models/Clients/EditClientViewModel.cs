using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Controllers;

namespace TrainingTask.WebApp.Models.Clients
{
    public class EditClientViewModel:IMapFrom<Entities.Client>,IMapTo<Entities.Client>
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(450)]
        public string Address { get; set; }
    }
}
