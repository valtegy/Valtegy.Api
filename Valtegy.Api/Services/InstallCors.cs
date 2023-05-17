using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Valtegy.Api.Services
{
    public static class InstallCors
    {
        public static void EnableOrigins(this IServiceCollection services, IConfiguration configuration, string policyName)
        {
            var origins = configuration.GetSection("Cors:Origins")
                                .Value
                                .Split(',');

            services.AddCors(options =>
            {
                options.AddPolicy(policyName,
                builder =>
                {
                    builder
                    .WithOrigins(origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }
    }
}
