using CleanArchitectureSample.Application.Services;
using CleanArchitectureSample.Infrastructure.Ef;
using CleanArchitectureSample.Infrastructure.Logging;
using CleanArchitectureSample.Infrastructure.Services;
using CleanArchitectureSample.Shared;
using CleanArchitectureSample.Shared.Abstractions.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQueries();
            services.AddPostgres(configuration);
            services.AddSingleton<IWeatherService, DumbWeatherService>();
            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
            return services;
        }

        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
            where TOptions : new()
        {
            var options = new TOptions();
            configuration.GetSection(sectionName).Bind(options);
            return options;
        }
    }
}
