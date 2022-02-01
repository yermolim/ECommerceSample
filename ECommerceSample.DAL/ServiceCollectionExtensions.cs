using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace ECommerceSample.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddECommerceContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
