using CleanArchitectureSample.Domain.ValueObjects;

namespace CleanArchitectureSample.Domain.Policies.Universal
{
    internal class BasicPolicy : IPackingItemPolicy
    {
        private const uint MaximumQuantityOfCloses = 7;

        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        {
            return new List<PackingItem>
            {
                new PackingItem("Pants", Math.Min(data.Days, MaximumQuantityOfCloses)),
                new PackingItem("Socks", Math.Min(data.Days, MaximumQuantityOfCloses)),
                new PackingItem("T-Shirt", Math.Min(data.Days, MaximumQuantityOfCloses)),
                new PackingItem("Trousers", data.Days < 7 ? 1U : 2U),
                new PackingItem("Shampoo", 1),
                new PackingItem("Toothbrush", 1),
                new PackingItem("Toothpaste", 1),
                new PackingItem("Towel", 1),
                new PackingItem("Bag pack", 1),
                new PackingItem("Phone charger", 1),
            };
        }

        public bool IsApplicable(PolicyData data)
        {
            return true;
        }
    }
}
