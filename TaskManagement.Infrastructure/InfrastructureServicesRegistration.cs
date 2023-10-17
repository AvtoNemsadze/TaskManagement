using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Common.Interfaces.Repositories;
using TaskManagement.Infrastructure.Scheduler;

namespace TaskManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITaskRepository, TaskDeadlineCheckerService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            return services;
        }
    }
}
