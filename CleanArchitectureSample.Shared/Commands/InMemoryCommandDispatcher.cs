using CleanArchitectureSample.Shared.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.Shared.Commands
{
    public class InMemoryCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        async Task ICommandDispatcher.Dispatch<TCommand>(TCommand command)
        {
            using var scope = _serviceProvider.CreateScope();

            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

            await handler.Handle(command);
        }
    }
}
