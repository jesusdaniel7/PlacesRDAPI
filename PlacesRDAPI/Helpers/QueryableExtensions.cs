using PlacesRDAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginateDTO paginateDTO)
        {
            return queryable
                .Skip((paginateDTO.Page - 1) * paginateDTO.RecordsPerPage)
                .Take(paginateDTO.RecordsPerPage);
        }
    }
}
