using CleanArchitectureSample.Shared.Abstractions.Exceptions;

namespace CleanArchitectureSample.Domain.Exceptions
{
    public class PackingItemNotFoundException : AppException
    {
        public string ItemName { get; }

        public PackingItemNotFoundException(string itemName)
            : base($"No Packing Item with the given Name '{itemName}' found.")
        {
            ItemName = itemName;
        }
    }
}
