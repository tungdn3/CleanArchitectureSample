using CleanArchitectureSample.Application.Exceptions;
using CleanArchitectureSample.Domain.Repositories;
using CleanArchitectureSample.Shared.Abstractions.Commands;

namespace CleanArchitectureSample.Application.Commands.Handlers
{
    internal class PackPackingItemHandler : ICommandHandler<PackPackingItem>
    {
        private readonly IPackingListRepository _repository;

        public PackPackingItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(PackPackingItem command)
        {
            var packingList = await _repository.Get(command.Id);
            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.Id);
            }

            packingList.PackItem(command.ItemName);
            await _repository.Update(packingList);
        }
    }
}
