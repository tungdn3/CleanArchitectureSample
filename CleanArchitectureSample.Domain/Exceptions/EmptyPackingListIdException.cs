using CleanArchitectureSample.Shared.Abstractions.Exceptions;

namespace CleanArchitectureSample.Domain.Exceptions
{
    public class EmptyPackingListIdException : AppException
    {
        public EmptyPackingListIdException()
            : base ("Packing list Id cannot be empty.")
        {
        }
    }
}
