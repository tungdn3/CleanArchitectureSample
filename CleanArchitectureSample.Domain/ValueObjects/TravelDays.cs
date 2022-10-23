using CleanArchitectureSample.Domain.Exceptions;

namespace CleanArchitectureSample.Domain.ValueObjects
{
    public record TravelDays
    {
        public ushort Days { get; }

        public TravelDays(ushort value)
        {
            if (value is 0 or > 100)
            {
                throw new InvalidTravelDaysException(value);
            }

            Days = value;
        }

        public static implicit operator ushort(TravelDays days) => days.Days;

        public static implicit operator TravelDays(ushort value) => new(value);
    }
}
