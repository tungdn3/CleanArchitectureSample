using CleanArchitectureSample.Domain.Consts;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Policies;
using CleanArchitectureSample.Domain.ValueObjects;

namespace CleanArchitectureSample.Domain.Factories
{
    public sealed class PackingListFactory : IPackingListFactory
    {
        private readonly IEnumerable<IPackingItemPolicy> _policies;

        public PackingListFactory(IEnumerable<IPackingItemPolicy> policies)
        {
            _policies = policies;
        }

        public PackingList Create(PackingListId id, PackingListName name, Localization localization)
        {
            return new PackingList(id, name, localization);
        }

        public PackingList CreateWithDefaultItems(
            PackingListId id,
            PackingListName name,
            TravelDays days,
            Gender gender,
            Localization localization,
            Temperature temperature)
        {
            var policyData = new PolicyData(days, gender, temperature, localization);
            var applicablePolicies = _policies.Where(x => x.IsApplicable(policyData)).ToList();
            var items = applicablePolicies.SelectMany(p => p.GenerateItems(policyData)).ToList();
            var packingList = new PackingList(id, name, localization);
            packingList.AddItems(items);
            return packingList;
        }
    }
}
