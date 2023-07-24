using AutoMapper;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.DTOs
{
    public class InvoiceDTO: IMapFrom<InvoiceDTO>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public string ClientName { get; set; }
        public string ItemName { get; set; }
        public string Number { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceDTO>()
                .ForMember(dto => dto.ClientName, options => options.MapFrom(invoice => invoice.Client.Name))
                .ForMember(dto => dto.ItemName, options => options.MapFrom(invoice => invoice.Item.Name));
        }
    }
}
