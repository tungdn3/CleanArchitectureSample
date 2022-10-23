using CleanArchitectureSample.Shared.Abstractions.Exceptions;

namespace CleanArchitectureSample.Domain.Exceptions
{
    public class EmptyPackingListItemNameException : AppException
    {
        public EmptyPackingListItemNameException() : base("Packing list item name cannot be empty.")
        {
        }
    }
}
