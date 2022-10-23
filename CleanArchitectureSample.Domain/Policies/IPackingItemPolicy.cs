using CleanArchitectureSample.Domain.ValueObjects;

namespace CleanArchitectureSample.Domain.Policies
{
    public interface IPackingItemPolicy
    {
        bool IsApplicable(PolicyData data);

        IEnumerable<PackingItem> GenerateItems(PolicyData data);
    }
}
