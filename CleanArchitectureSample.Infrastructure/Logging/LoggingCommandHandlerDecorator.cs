using CleanArchitectureSample.Shared.Abstractions.Commands;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureSample.Infrastructure.Logging
{
    internal sealed class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : class, ICommand
    {
        private readonly ILogger<LoggingCommandHandlerDecorator<TCommand>> _logger;
        private readonly ICommandHandler<TCommand> _handler;

        public LoggingCommandHandlerDecorator(
            ILogger<LoggingCommandHandlerDecorator<TCommand>> logger,
            ICommandHandler<TCommand> handler)
        {
            _logger = logger;
            _handler = handler;
        }

        public async Task Handle(TCommand command)
        {
            var commandType = command.GetType().Name;
            try
            {
                _logger.LogInformation($"Started processing {commandType} command.");
                await _handler.Handle(command);
                _logger.LogInformation($"Finished processing {commandType} command.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to process command {commandType}.");
                throw;
            }
        }
    }
}
