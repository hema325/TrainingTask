using TrainingTask.WebApp.Common.Entities;

namespace TrainingTask.WebApp.Entities
{
    public class Invoice:EntityBase
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? PaidUp { get; set; }
        public decimal? Discount { get; set; }
        public int ClientId { get; set; }
        public int ItemId { get; set; }
        public string Number { get; set; }

        public Client Client { get; set; }
        public Item Item { get; set; }
    }
}
