namespace CleanArchitectureSample.Application.Services
{
    public interface IPackingListReadService
    {
        Task<bool> ExistsByName(string name);
    }
}
