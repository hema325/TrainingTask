using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;

namespace TrainingTask.WebApp.Models.Invoices
{
    public class EditInvoiceViewModel: IMapFrom<Entities.Invoice>, IMapTo<Entities.Invoice>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Range(0, 9999999.99, ErrorMessage = "Quantity Must Be Positive Number")]
        public int Quantity { get; set; }

        [Range(0, 9999999.99, ErrorMessage = "Paid Up Must Be Positive Number")]
        public decimal Price { get; set; }

        [Range(0, 9999999.99, ErrorMessage = "Paid Up Must Be Positive Number")]
        [Display(Name = "Paid Up")]
        public decimal? PaidUp { get; set; }

        [Range(0, 100, ErrorMessage = "Discount Must Be Positive Number Between 0 and 100")]
        public decimal? Discount { get; set; }

        [Display(Name = "Client Name")]
        public int ClientId { get; set; }

        [Display(Name = "Item Name")]
        public int ItemId { get; set; }

        public IEnumerable<SelectListItem>? Items { get; set; }
        public IEnumerable<SelectListItem>? Clients { get; set; }
    }
}
