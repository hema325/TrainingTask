using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Options
{
    public class InvoiceOption: IMapTo<Invoice>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0, 9999999.99)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, 9999999.99)]
        public decimal Price { get; set; }

        [Range(0, 9999999.99)]
        [Display(Name = "Paid Up")]
        public decimal? PaidUp { get; set; }

        [Range(0, 100)]
        public decimal? Discount { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public string Number { get; set; }
    }
}
