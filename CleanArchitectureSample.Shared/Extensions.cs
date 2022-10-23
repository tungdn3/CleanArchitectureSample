using CleanArchitectureSample.Shared.Abstractions.Commands;
using CleanArchitectureSample.Shared.Abstractions.Queries;
using CleanArchitectureSample.Shared.Commands;
using CleanArchitectureSample.Shared.Exceptions;
using CleanArchitectureSample.Shared.Queries;
using CleanArchitectureSample.Shared.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitectureSample.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();

            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddHostedService<AppInitializer>();
            services.AddSingleton<ExceptionMiddleware>();
            return services;
        }

        public static IApplicationBuilder UseShared(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
            return builder;
        }
    }
}
