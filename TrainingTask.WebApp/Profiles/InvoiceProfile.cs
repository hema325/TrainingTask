using AutoMapper;
using TrainingTask.WebApp.DTOs;
using TrainingTask.WebApp.Entities;
using TrainingTask.WebApp.Models.Invoices;

namespace TrainingTask.WebApp.Profiles
{
    public class InvoiceProfile:Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice,InvoiceDTO>().ForMember(dto=>dto.ClientName,options=>options.MapFrom(invoice=>invoice.Client.Name))
                .ForMember(dto => dto.ItemName, options => options.MapFrom(invoice => invoice.Item.Name));

            CreateMap<Invoice, InvoiceDetailsViewModel>().ForMember(model => model.ClientName, options => options.MapFrom(invoice => invoice.Client.Name))
                .ForMember(model => model.ItemName, options => options.MapFrom(invoice => invoice.Item.Name));

            CreateMap<Invoice, SalesReportDTO>().ForMember(dto => dto.ClientName, options => options.MapFrom(invoice => invoice.Client.Name))
                .ForMember(dto => dto.ItemName, options => options.MapFrom(invoice => invoice.Item.Name));

        }
    }
}
