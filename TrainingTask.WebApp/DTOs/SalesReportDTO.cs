using AutoMapper;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.DTOs
{
    public class SalesReportDTO: IMapFrom<Invoice>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? PaidUp { get; set; }
        public decimal? Discount { get; set; }
        public string ClientName { get; set; }
        public string ItemName { get; set; }
        public string Number { get; set; }

        public decimal Total => Price * Quantity;
        public decimal TheNet => Discount.HasValue ? Total - (Total * Discount.Value / 100): Total;
        public decimal TheRest => PaidUp.HasValue ? TheNet - PaidUp.Value : TheNet;


        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Invoice, SalesReportDTO>()
                .ForMember(dto => dto.ClientName, options => options.MapFrom(invoice => invoice.Client.Name))
                .ForMember(dto => dto.ItemName, options => options.MapFrom(invoice => invoice.Item.Name));
        }
    }
}
