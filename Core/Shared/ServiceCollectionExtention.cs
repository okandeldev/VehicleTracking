using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Shared
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddDatabaseContext<T>(this IServiceCollection services, IConfiguration config, bool useSnakeCaseNamingConvention = true) where T : DbContext
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddPostgres<T>(connectionString!, useSnakeCaseNamingConvention);
            return services;
        }
        private static IServiceCollection AddPostgres<T>(this IServiceCollection services, string connectionString, bool useSnakeCaseNamingConvention = true) where T : DbContext
        {
            services.AddDbContextPool<T>(m =>
            {
                if (useSnakeCaseNamingConvention)
                    m.UseNpgsql(connectionString, e => e.MigrationsAssembly(typeof(T).Assembly.FullName)).UseSnakeCaseNamingConvention();
                else
                    m.UseNpgsql(connectionString, e => e.MigrationsAssembly(typeof(T).Assembly.FullName));
            });


            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            dbContext.Database.Migrate();
            return services;
        }
    }
}
