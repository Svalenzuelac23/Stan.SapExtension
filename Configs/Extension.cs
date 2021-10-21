using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SapExtensions.Connection;

namespace SapExtensions
{
    public static class Extension
    {
        private const string SAP = "SapOptions";

        public static IServiceCollection AddContextSap<TContext>(this IServiceCollection services) where TContext: DbContextSap
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            services.Configure<SapOptions>(configuration.GetSection(SAP));
            services.AddSingleton<TContext>();
            return services;
        }

        public static IServiceCollection AddContextSap<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : DbContextSap
        {
            services.Configure<SapOptions>(configuration.GetSection(SAP));
            services.AddSingleton<TContext>();
            return services;
        }

        public static IServiceCollection AddScopeContextSap<TContext>(this IServiceCollection services) where TContext : DbContextSap
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            services.Configure<SapOptions>(configuration.GetSection(SAP));
            services.AddScoped<TContext>();
            return services;
        }
    }
}
