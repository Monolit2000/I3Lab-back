using I3Lab.Treatments.Application.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Configuration.Paginations
{
    public static class QueryablePagingExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, int page, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, page, pageSize, totalCount);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> enumerable, int page, int pageSize)
        {
            var totalCount = enumerable.Count();
            var items = enumerable.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, page, pageSize, totalCount);
        }
    }
}
