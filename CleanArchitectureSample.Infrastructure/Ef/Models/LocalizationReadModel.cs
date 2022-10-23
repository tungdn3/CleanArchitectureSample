namespace CleanArchitectureSample.Infrastructure.Ef.Models
{
    public class LocalizationReadModel
    {
        public static LocalizationReadModel Create(string value)
        {
            var split = value.Split(',');
            return new LocalizationReadModel
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
