using CleanArchitectureSample.Domain.ValueObjects;

namespace CleanArchitectureSample.Domain.Policies
{
    internal class LowTemperaturePolicy : IPackingItemPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        {
            return new List<PackingItem>
            {
                new PackingItem("Winter hat", 1),
                new PackingItem("Scarf", 1),
                new PackingItem("Gloves", 1),
                new PackingItem("Hoodie", 1),
                new PackingItem("Warm jacket", 1),
            };
        }

        public bool IsApplicable(PolicyData data)
        {
            return data.Temperature < 10;
        }
    }
}
