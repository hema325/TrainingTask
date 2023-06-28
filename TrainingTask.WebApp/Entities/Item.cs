using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Entities;

namespace TrainingTask.WebApp.Entities
{
    public class Item: EntityBase
    {
        public string Name { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public string? Notes { get; set; }
        public int TypeId { get; set; }

        public Entities.Type Type { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
