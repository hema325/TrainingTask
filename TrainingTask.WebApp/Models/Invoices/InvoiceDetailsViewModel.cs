using System.ComponentModel.DataAnnotations;

namespace TrainingTask.WebApp.Models.Invoices
{
    public class InvoiceDetailsViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? PaidUp { get; set; }
        public decimal? Discount { get; set; }

        [Display(Name ="Client Name")]
        public string ClientName { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        public string Number { get; set; }
    }
}
