using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Valtegy.Service.Options;

namespace Valtegy.Api.Services
{
    public static class InstallOptions
    {
        public static void InjectOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FtpConfigurations>(configuration.GetSection("Ftp"));
            services.Configure<Service.Services.SmtpEmailConfiguration>(configuration.GetSection("SmtpEmail"));
        }
    }
}
