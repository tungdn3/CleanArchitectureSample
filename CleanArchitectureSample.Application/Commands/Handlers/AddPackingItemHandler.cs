using CleanArchitectureSample.Application.Exceptions;
using CleanArchitectureSample.Domain.Repositories;
using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Shared.Abstractions.Commands;

namespace CleanArchitectureSample.Application.Commands.Handlers
{
    internal class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _repository;

        public AddPackingItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddPackingItem command)
        {
            var packingList = await _repository.Get(command.Id);
            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.Id);
            }

            var packingItem = new PackingItem(command.ItemName, command.Quantity);
            packingList.AddItem(packingItem);
            await _repository.Update(packingList);
        }
    }
}
