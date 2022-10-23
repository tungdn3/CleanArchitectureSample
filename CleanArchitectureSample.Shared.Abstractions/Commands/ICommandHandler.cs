namespace CleanArchitectureSample.Shared.Abstractions.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        Task Handle(TCommand command);
    }
}
