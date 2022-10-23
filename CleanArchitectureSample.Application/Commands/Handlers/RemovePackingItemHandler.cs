using CleanArchitectureSample.Application.Exceptions;
using CleanArchitectureSample.Domain.Repositories;
using CleanArchitectureSample.Shared.Abstractions.Commands;

namespace CleanArchitectureSample.Application.Commands.Handlers
{
    internal class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _repository;

        public RemovePackingItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePackingItem command)
        {
            var packingList = await _repository.Get(command.Id);
            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.Id);
            }

            packingList.RemoveItem(command.ItemName);
            await _repository.Update(packingList);
        }
    }
}
