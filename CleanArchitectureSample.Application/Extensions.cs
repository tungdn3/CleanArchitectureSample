using CleanArchitectureSample.Domain.Factories;
using CleanArchitectureSample.Domain.Policies;
using CleanArchitectureSample.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<IPackingListFactory, PackingListFactory>();
            services.Scan(x => x.FromAssemblies(typeof(IPackingItemPolicy).Assembly)
                .AddClasses(c => c.AssignableTo<IPackingItemPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
