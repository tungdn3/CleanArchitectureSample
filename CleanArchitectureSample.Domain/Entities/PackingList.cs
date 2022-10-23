using CleanArchitectureSample.Domain.Events;
using CleanArchitectureSample.Domain.Exceptions;
using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Shared.Abstractions.Domain;

namespace CleanArchitectureSample.Domain.Entities
{
    public class PackingList : AggregateRoot<PackingListId>
    {
        private PackingListName _name;

        private Localization _localization;

        private readonly LinkedList<PackingItem> _items = new();

        private PackingList()
        {
            // For EF core
        }

        internal PackingList(PackingListId id, PackingListName name, Localization localization)
        {
            Id = id;
            _name = name;
            _localization = localization;
        }

        private PackingList(PackingListId id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
        {
            Id = id;
            _name = name;
            _localization = localization;
            _items = items;
        }

        public void AddItem(PackingItem item)
        {
            var exists = _items.Any(x => x.Name == item.Name);

            if (exists)
            {
                throw new PackingItemAlreadyExistsException(_name, item.Name);
            }

            _items.AddLast(item);
            AddEvent(new PackingItemAdded(this, item));
        }

        public void AddItems(IEnumerable<PackingItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            var packedItem = item with { IsPacked = true };
            _items.Find(item)!.Value = packedItem;
            AddEvent(new PackingItemPacked(this, packedItem));
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);
            _items.Remove(item);
            AddEvent(new PackingItemRemoved(this, item));
        }

        private PackingItem GetItem (string itemName)
        {
            var item = _items.SingleOrDefault(x => x.Name.Equals(itemName));
             
            if (item == null)
            {
                throw new PackingItemNotFoundException(itemName);
            }

            return item;
        }
    }
}
