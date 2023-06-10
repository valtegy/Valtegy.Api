using Valtegy.Domain.Services;
using Valtegy.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Valtegy.Api.Services
{
    public static class InstallServices
    {
        public static void InjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<IActivitiesService, ActivitiesService>();
        }
    }
}
