namespace CleanArchitectureSample.Infrastructure.Ef.Models
{
    public class PackingListReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public LocalizationReadModel Localization { get; set; }

        public ICollection<PackingItemReadModel> Items { get; set; }
    }
}
