namespace CleanArchitectureSample.Application.DTOs
{
    public class LocalizationDto
    {
        public static LocalizationDto Create(string value)
        {
            var split = value.Split(',');
            return new LocalizationDto
            {
                City = split[0],
                Country = split[1],
            };
        }

        public string City { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"{City},{Country}";
        }
    }
}
