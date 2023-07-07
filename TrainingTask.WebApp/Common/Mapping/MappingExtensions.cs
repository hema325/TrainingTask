using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TrainingTask.WebApp.Common.Models;

namespace TrainingTask.WebApp.Common.Mapping
{
    public static class MappingExtensions
    {
        public static async Task<PaginatedList<TDestinition>> PaginateAsync<TDestinition>(this IQueryable<TDestinition> source, int pageNumber, int pageSize) where TDestinition : class
        {
            int totalCount = await source.CountAsync();
            var data = await source.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<TDestinition>(data, totalCount, pageNumber, pageSize);
        }
    }
}
