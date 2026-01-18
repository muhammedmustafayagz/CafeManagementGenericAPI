using Entities.Model;

namespace CafeManagementGenericAPI.Filters
{
    public static class BaseEntityFilter
    {
        public static IQueryable<T> Apply<T>(
            IQueryable<T> query,
            BaseFilterModel filter)
            where T : BaseEntity
        {
            if (filter.IsActive.HasValue)
                query = query.Where(x => x.IsActive == filter.IsActive.Value);

            if (filter.IsDeleted.HasValue)
                query = query.Where(x => x.IsDeleted == filter.IsDeleted.Value);

            if (filter.CreatedDateFrom.HasValue)
                query = query.Where(x => x.CratedDate >= filter.CreatedDateFrom.Value);

            if (filter.CreatedDateTo.HasValue)
                query = query.Where(x => x.CratedDate <= filter.CreatedDateTo.Value);

            if (!string.IsNullOrEmpty(filter.CreatedBy))
                query = query.Where(x => x.CreatedBy == filter.CreatedBy);

            return query;
        }
    }
}
