namespace CleanArchitectureSample.Application.Exceptions
{
    public class MissingLocalizationWeatherException : ApplicationException
    {
        public MissingLocalizationWeatherException(string city, string country)
            : base ($"Missing weather information for localization '{city}, {country}'.")
        {
            City = city;
            Country = country;
        }

        public string City { get; }
        public string Country { get; }
    }
}
