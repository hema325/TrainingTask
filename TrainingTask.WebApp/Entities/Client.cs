using TrainingTask.WebApp.Common.Entities;

namespace TrainingTask.WebApp.Entities
{
    public class Client:EntityBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}
