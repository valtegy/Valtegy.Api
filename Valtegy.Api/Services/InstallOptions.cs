using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Valtegy.Api.Services
{
    public static class InstallOptions
    {
        public static void InjectOptions(this IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
