using Valtegy.Domain.Repositories;
using Valtegy.Repository.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Valtegy.Api.Services
{
    public static class InstallRepositories
    {
        public static void InjectRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataRepository<Domain.Entities.Activities>, DataRepository<Domain.Entities.Activities>>();
            services.AddScoped<IDataRepository<Domain.Entities.Users>, UsersRepository>();
            services.AddScoped<IDataRepository<Domain.Entities.Notification>, DataRepository<Domain.Entities.Notification>>();
            services.AddScoped<IDataRepository<Domain.Entities.ActivityType>, DataRepository<Domain.Entities.ActivityType>>();
            services.AddScoped<IDataRepository<Domain.Entities.StatusActivity>, DataRepository<Domain.Entities.StatusActivity>>();
            services.AddScoped<IDataRepositoryDapper, DataRepositoryDapper>();
        }
    }
}
