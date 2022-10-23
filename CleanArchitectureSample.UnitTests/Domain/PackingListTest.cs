using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Events;
using CleanArchitectureSample.Domain.Exceptions;
using CleanArchitectureSample.Domain.Factories;
using CleanArchitectureSample.Domain.Policies;
using CleanArchitectureSample.Domain.ValueObjects;
using Shouldly;

namespace CleanArchitectureSample.UnitTests.Domain
{
    public class PackingListTest
    {
        [Fact]
        public void AddItem_Item_With_The_Same_Name_Exists_Throws_PackingItemAlreadyExistsException()
        {
            var packingList = CreatePackingList();
            packingList.AddItem(new PackingItem("Item 1", 1));
            
            var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 2)));
            
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType(typeof(PackingItemAlreadyExistsException));
        }

        [Fact]
        public void AddItem_Success_Should_Add_PackingItemAdded_Event()
        {
            var packingList = CreatePackingList();
            var item1 = new PackingItem("Item 1", 1);
            
            packingList.AddItem(item1);
            
            packingList.Events.Count().ShouldBe(1);
            var @event = packingList.Events.First() as PackingItemAdded;
            @event.ShouldNotBeNull();
            @event.PackingList.ShouldBe(packingList);
            @event.PackingItem.ShouldBe(item1);
        }

        private PackingList CreatePackingList()
        {
            var packingList = _factory.Create(Guid.NewGuid(), "My list", Localization.Create("HCM,Vietnam"));
            return packingList;
        }

        private readonly IPackingListFactory _factory;

        public PackingListTest()
        {
            _factory = new PackingListFactory(Enumerable.Empty<IPackingItemPolicy>());
        }
    }
}
