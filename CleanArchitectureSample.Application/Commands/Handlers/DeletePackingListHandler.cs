using CleanArchitectureSample.Application.Exceptions;
using CleanArchitectureSample.Domain.Repositories;
using CleanArchitectureSample.Shared.Abstractions.Commands;

namespace CleanArchitectureSample.Application.Commands.Handlers
{
    internal class DeletePackingListHandler : ICommandHandler<DeletePackingList>
    {
        private readonly IPackingListRepository _repository;

        public DeletePackingListHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeletePackingList command)
        {
            var packingList = await _repository.Get(command.Id);

            if (packingList == null)
            {
                throw new PackingListNotFoundException(command.Id);
            }

            await _repository.Delete(packingList);
        }
    }
}
