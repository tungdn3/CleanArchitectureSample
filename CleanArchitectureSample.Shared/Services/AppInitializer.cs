using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitectureSample.Shared.Services
{
    internal sealed class AppInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public AppInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => typeof(DbContext).IsAssignableFrom(t) && !t.IsInterface && t != typeof(DbContext))
                .ToList();

            using var scope = _serviceProvider.CreateScope();
            foreach (var dbContextType in dbContextTypes)
            {
                var dbContext = scope.ServiceProvider.GetRequiredService(dbContextType) as DbContext;
                await dbContext!.Database.MigrateAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
