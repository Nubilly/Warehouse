using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common;

namespace Warehouse.Data.Extensions
{
    public static class PagingExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }

        public static IQueryable<T> PageBy<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> orderBy, Pager pager)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            // Check if the page number is greater then zero - otherwise use default page number
            pager.Page = pager.Page <= 0 ? 1 : pager.Page;
            pager.PageSize = pager.PageSize <= 0 ? 10 : pager.PageSize;

            // It is necessary sort items before it
            query = pager.OrderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

            return query.Skip((pager.Page - 1) * pager.PageSize).Take(pager.PageSize);
        }
    }
}
