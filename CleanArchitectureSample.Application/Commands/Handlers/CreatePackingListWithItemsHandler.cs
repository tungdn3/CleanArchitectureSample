using CleanArchitectureSample.Application.Exceptions;
using CleanArchitectureSample.Application.Services;
using CleanArchitectureSample.Domain.Factories;
using CleanArchitectureSample.Domain.Repositories;
using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Shared.Abstractions.Commands;

namespace CleanArchitectureSample.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListRepository _repository;
        private readonly IPackingListFactory _factory;
        private readonly IPackingListReadService _readService;
        private readonly IWeatherService _weatherService;

        public CreatePackingListWithItemsHandler(
            IPackingListFactory factory,
            IPackingListRepository repository,
            IPackingListReadService readService,
            IWeatherService weatherService)
        {
            _factory = factory;
            _repository = repository;
            _readService = readService;
            _weatherService = weatherService;
        }

        public async Task Handle(CreatePackingListWithItems command)
        {
            if (await _readService.ExistsByName(command.Name))
            {
                throw new PackingListAlreadyExistsExeption(command.Name);
            }

            var weather = await _weatherService.GetWeather(command.Localization.City, command.Localization.Country);
            if (weather is null)
            {
                throw new MissingLocalizationWeatherException(command.Localization.City, command.Localization.Country);
            }

            var localization = new Localization(command.Localization.City, command.Localization.Country);
            
            var packingList = _factory.CreateWithDefaultItems(command.Id, command.Name, command.Days, 
                command.Gender, localization, weather.Temperature);

            await _repository.Add(packingList);
        }
    }
}
