using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Contracts.Infrastructure;
using TaskManagement.Application.Models.Mail;
using TaskManagement.Infrastructure.Mail;

namespace TaskManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {

        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>()! ?? new EmailSettings();

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSingleton(emailSettings);

            return services;
        }
    }
}

