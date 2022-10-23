namespace CleanArchitectureSample.Application.DTOs
{
    public class PackingListDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public LocalizationDto? Localization { get; set; }

        public ICollection<PackingItemDto>? Items { get; set; }
    }
}
