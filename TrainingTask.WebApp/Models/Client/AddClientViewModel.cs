using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Controllers;

namespace TrainingTask.WebApp.Models.Client
{
    public class AddClientViewModel: IMapTo<Entities.Client>
    {
        [StringLength(250)]
        [Remote(nameof(ClientsController.IsClientNameValid),"Clients",ErrorMessage = "Client Name Has Been Taken")]
        public string Name { get; set; }

        [StringLength(24)]
        [RegularExpression("[\\d\\-\\+\\s]+", ErrorMessage = "Phone Can Only Contain digits, white spaces, plus, minus")]
        public string Phone { get; set; }

        [StringLength(450)]
        public string Address { get; set; }
    }
}
