using CleanArchitectureSample.Domain.ValueObjects;

namespace CleanArchitectureSample.Domain.Policies
{
    internal class FemaleGenderPolicy : IPackingItemPolicy
    {
        // These items should be get from somewhere else instead of hard-code
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        {
            return new List<PackingItem>
            {
                new PackingItem("Lipstick", 1),
                new PackingItem("Powder", 1),
                new PackingItem("Eyeliner", 1),
            };
        }

        public bool IsApplicable(PolicyData data)
        {
            return data.Gender == Consts.Gender.Female;
        }
    }
}
