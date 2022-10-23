using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Infrastructure.Ef.Models;

namespace CleanArchitectureSample.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static PackingListDto AsDto(this PackingListReadModel model)
        {
            var dto = new PackingListDto
            {
                Id = model.Id,
                Name = model.Name,
                Localization = new LocalizationDto
                {
                    City = model.Localization.City,
                    Country = model.Localization.Country,
                },
            };

            dto.Items = model.Items?.Select(x => new PackingItemDto
            {
                Name = x.Name,
                IsPacked = x.IsPacked,
                Quantity = x.Quantity,
            }).ToList();

            return dto;
        }
    }
}
