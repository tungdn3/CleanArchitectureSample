namespace CleanArchitectureSample.Shared.Abstractions.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TResult>(IQuery<TResult> query);
    }
}
