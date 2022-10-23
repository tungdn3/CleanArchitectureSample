using CleanArchitectureSample.Shared.Abstractions.Exceptions;

namespace CleanArchitectureSample.Domain.Exceptions
{
    public class InvalidTravelDaysException : AppException
    {
        public ushort Days { get; }

        public InvalidTravelDaysException(ushort days)
            : base($"Travel days should be between 0 and 100. The current value is '{days}'.")
        {
            Days = days;
        }
    }
}
