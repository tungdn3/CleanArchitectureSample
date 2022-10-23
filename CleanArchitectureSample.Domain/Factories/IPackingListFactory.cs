using CleanArchitectureSample.Domain.Consts;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.ValueObjects;

namespace CleanArchitectureSample.Domain.Factories
{
    public interface IPackingListFactory
    {
        PackingList Create(PackingListId id, PackingListName name, Localization localization);

        PackingList CreateWithDefaultItems(
            PackingListId id,
            PackingListName name,
            TravelDays days,
            Gender gender,
            Localization localization,
            Temperature temperature);
    }
}
