using System.Runtime.Serialization;

namespace CleanArchitectureSample.Shared.Abstractions.Exceptions
{
    public abstract class AppException : Exception
    {
        protected AppException()
        {
        }

        protected AppException(string? message) : base(message)
        {
        }

        protected AppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected AppException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
