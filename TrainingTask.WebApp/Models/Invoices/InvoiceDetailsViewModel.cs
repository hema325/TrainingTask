using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Models.Invoices
{
    public class InvoiceDetailsViewModel: IMapFrom<Invoice>
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



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceDetailsViewModel>()
                .ForMember(model => model.ClientName, options => options.MapFrom(invoice => invoice.Client.Name))
                .ForMember(model => model.ItemName, options => options.MapFrom(invoice => invoice.Item.Name));
        }
    }
}
