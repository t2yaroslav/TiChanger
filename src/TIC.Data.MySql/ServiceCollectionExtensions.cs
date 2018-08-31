using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TIC.Data.MySql;

namespace TIC.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBBWTMySQLDataContext(this IServiceCollection services,
            string connectionString, Action<IdentityOptions> identityOptions)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseMySql(connectionString));

            services.AddScoped<IDataContext, DataContext>();
/*
            services
                .AddIdentity<User, Role>(identityOptions)
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
*/
            return services;
        }
    }
}