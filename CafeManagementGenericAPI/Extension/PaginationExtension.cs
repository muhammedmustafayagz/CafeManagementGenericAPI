using System.Linq;

namespace CafeManagementGenericAPI.Extensions
{
    public static class PaginationExtension
    {
        public static IQueryable<T> ApplyPagination<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize)
        {
            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
