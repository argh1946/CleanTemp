//using AutoMapper;
//using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

namespace Core.Helper
{

    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber = 1, int pageSize = 10) where TDestination : class
            => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

        //public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
        //    => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
    }
}