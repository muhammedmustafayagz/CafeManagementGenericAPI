using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository.Abstract
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            var turkeyZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CratedDate =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, turkeyZone);

                    entry.Entity.CreatedBy = "";
                    entry.Entity.IsDeleted = false;
                    entry.Entity.IsActive = true;
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity.IsDeleted)
                    {
                        entry.Entity.DeleteDate =
                            TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, turkeyZone);

                        entry.Entity.DeletedBy = "";
                        entry.Entity.IsActive = false;
                    }
                    else
                    {
                        entry.Entity.LastModifiedDate =
                            TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, turkeyZone);

                        entry.Entity.LastModifiedBy = "";
                        entry.Entity.IsActive = true;
                        entry.Entity.IsDeleted = false;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
