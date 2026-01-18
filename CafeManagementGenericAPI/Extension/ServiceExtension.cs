using Repository.Abstarct;
using Repository.Concrete;
using Services.Abstarct;
using Services.Concrete;

namespace CafeManagementGenericAPI.Extension
{
    public static class ServiceExtension
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
           services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
        }
    }
}
