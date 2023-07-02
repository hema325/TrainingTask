using System.ComponentModel.DataAnnotations;

namespace TrainingTask.WebApp.Models.Types
{
    public class TypeDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Notes { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }
}
