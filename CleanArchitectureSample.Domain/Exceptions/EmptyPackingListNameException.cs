using CleanArchitectureSample.Shared.Abstractions.Exceptions;

namespace CleanArchitectureSample.Domain.Exceptions
{
    public class EmptyPackingListNameException : AppException
    {
        public EmptyPackingListNameException() : base("Packing list name cannot be empty.")
        {
        }
    }
}
