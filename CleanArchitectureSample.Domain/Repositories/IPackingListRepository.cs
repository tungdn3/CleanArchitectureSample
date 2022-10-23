using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.ValueObjects;

namespace CleanArchitectureSample.Domain.Repositories
{
    public interface IPackingListRepository
    {
        Task<PackingList?> Get(PackingListId id);

        Task Add(PackingList packingList);

        Task Update(PackingList packingList);

        Task Delete(PackingList packingList);
    }
}
