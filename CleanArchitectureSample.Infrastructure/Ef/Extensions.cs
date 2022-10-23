using CleanArchitectureSample.Application.Services;
using CleanArchitectureSample.Domain.Repositories;
using CleanArchitectureSample.Infrastructure.Ef.Contexts;
using CleanArchitectureSample.Infrastructure.Ef.Options;
using CleanArchitectureSample.Infrastructure.Ef.Repositories;
using CleanArchitectureSample.Infrastructure.Ef.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.Infrastructure.Ef
{
    internal static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<PostgresOptions>("Postgres");
            services.AddDbContext<ReadDbContext>(context => context.UseNpgsql(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(context => context.UseNpgsql(options.ConnectionString));
            services.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
            services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();

            return services;
        }
    }
}
