using CleanArchitectureSample.Shared.Abstractions.Exceptions;

namespace CleanArchitectureSample.Domain.Exceptions
{
    public class InvalidTemperatureException : AppException
    {
        public InvalidTemperatureException(double value)
            : base($"The given temperature '{value}' is invalid. Temperature should be between -100 and 100.")
        {
            Value = value;
        }

        public double Value { get; }
    }
}
