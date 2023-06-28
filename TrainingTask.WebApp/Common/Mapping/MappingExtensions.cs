using AutoMapper;
using AutoMapper.QueryableExtensions;
using TrainingTask.WebApp.Common.Models;

namespace TrainingTask.WebApp.Common.Mapping
{
    public static class MappingExtensions
    {
        public static async Task<PaginatedList<TDestinition>> PaginateAsync<TDestinition>(this IQueryable<TDestinition> source, int pageNumber, int pageSize) =>
           await PaginatedList<TDestinition>.CreateAsync(source, pageNumber, pageSize);

        public static async Task<PaginatedList<TResult>> PaginateWithProjectionAsync<TDestinition,TResult>(this IQueryable<TDestinition> source, IMapper mapper, int pageNumber, int pageSize) =>
          await PaginatedList<TDestinition>.CreateAsync<TResult>(source,mapper, pageNumber, pageSize);
    }
}
