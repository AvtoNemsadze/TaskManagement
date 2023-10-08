using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Common.Interfaces.Repositories;
using TaskManagement.Persistence.Repository;

namespace TaskManagement.Persistence
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementDbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TaskManagementConnectionString"));
            });

            services.AddTransient<TaskManagementDbContext>();
            services.AddTransient<ITaskManagementDbRepository, GenericRepository>();

            return services;
        }
    }
}