using CleanArchitectureSample.Shared.Abstractions.Exceptions;

namespace CleanArchitectureSample.Application.Exceptions
{
    public class PackingListAlreadyExistsExeption : AppException
    {
        public PackingListAlreadyExistsExeption(string name)
            : base($"Packing list name '{name}' already existed.")
        {
            Name = name;
        }

        public string Name { get; }
    }
}
