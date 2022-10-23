using CleanArchitectureSample.Domain.ValueObjects;

namespace CleanArchitectureSample.Domain.Policies
{
    internal class HighTemperaturePolicy : IPackingItemPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        {
            return new List<PackingItem>
            {
                new("Hat", 1),
                new("Sun glasses", 1),
                new("Cream with UV filter", 1),
            };
        }

        public bool IsApplicable(PolicyData data)
        {
            return data.Temperature > 35;
        }
    }
}
