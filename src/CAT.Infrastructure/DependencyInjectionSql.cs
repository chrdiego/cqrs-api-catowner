using System.Reflection;
using CAT.Domain.Primitives;
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
            services.AddRepositories<int, CatDbContext>();

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

        private static void AddRepositories<TKey, TContext>(this IServiceCollection services) where TContext : DbContext
        {
            Assembly assembly = typeof(TContext).GetTypeInfo().Assembly;

            IEnumerable<Type> @types = assembly.GetTypes().Where(x => !x.IsNested && !x.IsInterface && typeof(IGenericRepository<TKey>).IsAssignableFrom(x));

            foreach (Type type in @types)
            {
                Type @interface = type.GetInterface($"I{type.Name}", false);
                services.AddTransient(@interface, type);
            }
        }
    }
}