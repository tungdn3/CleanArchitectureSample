using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Shared.Abstractions.Exceptions;

namespace CleanArchitectureSample.Application.Exceptions
{
    public class PackingListNotFoundException : AppException
    {
        public PackingListNotFoundException(PackingListId id)
            : base ($"No packing list with the given id '{id}' found.")
        {
            Id = id;
        }

        public PackingListId Id { get; }
    }
}
