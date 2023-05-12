using System.Reflection;
using CAT.Domain.Primitives;
using CAT.Domain.Repository;
using CAT.Infrastructure.Context;
using CAT.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CAT.Infrastructure
{
    public static class DepencyInjectionSql
    {
        public static IServiceCollection AddInfrastructureSql(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            services.AddRepositories<CatDbContext>();

            return services;
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionStrings = configuration.GetConnectionString("Default");

            services.AddDbContext<CatDbContext>(option =>
            {
                DbContextOptionsBuilder dbContextOptionsBuilder = option.UseSqlServer(connectionStrings);
            });
        }

        private static void AddRepositories<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            services.AddTransient<ICatRepository, CatRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
        }
    }
}