namespace TrainingTask.WebApp.DTOs
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public string ClientName { get; set; }
        public string ItemName { get; set; }
        public string Number { get; set; }
    }
}
