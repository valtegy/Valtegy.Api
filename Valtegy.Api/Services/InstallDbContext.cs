using Valtegy.Repository.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Valtegy.Api.Services
{
    public static class InstallDbContext
    {
        public static void InjectDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<Domain.Entities.Users>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddSignInManager<SignInManager<Domain.Entities.Users>>()
                .AddEntityFrameworkStores<UsersDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;

                // User settings.
                options.User.RequireUniqueEmail = true;

            });

            services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
            services.AddDbContext<ValtegyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
            services.AddScoped<UsersDbContext>();
            services.AddScoped<ValtegyDbContext>();

        }
    }
}
