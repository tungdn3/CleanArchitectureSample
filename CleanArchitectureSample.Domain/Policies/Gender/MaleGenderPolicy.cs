using CleanArchitectureSample.Domain.ValueObjects;

namespace CleanArchitectureSample.Domain.Policies
{
    internal class MaleGenderPolicy : IPackingItemPolicy
    {
        // These items should be get from somewhere else instead of hard-code
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        {
            return new List<PackingItem>
            {
                new PackingItem("Laptop", 1),
                new PackingItem("Beer", 10),
                new PackingItem("Book", (uint) Math.Ceiling(data.Days / 7m)),
            };
        }

        public bool IsApplicable(PolicyData data)
        {
            return data.Gender == Consts.Gender.Male;
        }
    }
}
