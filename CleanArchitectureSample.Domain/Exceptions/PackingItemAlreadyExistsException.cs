using CleanArchitectureSample.Shared.Abstractions.Exceptions;

namespace CleanArchitectureSample.Domain.Exceptions
{
    public class PackingItemAlreadyExistsException : AppException
    {
        public string ListName { get; }

        public string ItemName { get; }

        public PackingItemAlreadyExistsException(string listName, string itemName)
            : base($"Packing list '{listName}' already defined item '{itemName}'.")
        {
            ListName = listName;
            ItemName = itemName;
        }
    }
}
