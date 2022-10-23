namespace CleanArchitectureSample.Shared.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
