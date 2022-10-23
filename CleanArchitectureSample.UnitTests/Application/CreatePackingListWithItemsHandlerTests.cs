using CleanArchitectureSample.Application.Commands;
using CleanArchitectureSample.Application.Commands.Handlers;
using CleanArchitectureSample.Application.DTOs.External;
using CleanArchitectureSample.Application.Exceptions;
using CleanArchitectureSample.Application.Services;
using CleanArchitectureSample.Domain.Consts;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Factories;
using CleanArchitectureSample.Domain.Repositories;
using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Shared.Abstractions.Commands;
using NSubstitute;
using Shouldly;

namespace CleanArchitectureSample.UnitTests.Application
{
    public class CreatePackingListWithItemsHandlerTests
    {
        Task Act(CreatePackingListWithItems command) => _commandHandler.Handle(command);

        [Fact]
        public async Task Handle_DuplicateName_ThrowsPackingListAlreadyExistsExeption()
        {
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "My list", 10, Gender.Female, default);
            _readService.ExistsByName(command.Name).Returns(true);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingListAlreadyExistsExeption>();
        }

        [Fact]
        public async Task Handle_DuplicateName_ThrowsMissingLocalizationWeatherException()
        {
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "My list", 10, Gender.Female,
                new LocalizationWriteModel("HCM", "Vietname"));

            _readService.ExistsByName(command.Name).Returns(false);
            _weatherService.GetWeather(Arg.Any<string>(), Arg.Any<string>()).Returns(Task.FromResult<WeatherDto>(null));

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingLocalizationWeatherException>();
        }

        [Fact]
        public async Task Handle_Success_CallRepository()
        {
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "My list", 10, Gender.Female,
                new LocalizationWriteModel("HCM", "Vietname"));

            _readService.ExistsByName(command.Name).Returns(false);
            
            _weatherService.GetWeather(Arg.Any<string>(), Arg.Any<string>())
                .Returns(Task.FromResult(new WeatherDto { Temperature = 10}));

            _factory.CreateWithDefaultItems(command.Id, command.Name, command.Days,
                command.Gender, Arg.Any<Localization>(), Arg.Any<Temperature>()).Returns(default(PackingList));

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldBeNull();
            await _repository.Received(1).Add(Arg.Any<PackingList>());
        }

        private readonly ICommandHandler<CreatePackingListWithItems> _commandHandler;
        private readonly IPackingListRepository _repository;
        private readonly IWeatherService _weatherService;
        private readonly IPackingListReadService _readService;
        private readonly IPackingListFactory _factory;

        public CreatePackingListWithItemsHandlerTests()
        {
            _repository = Substitute.For<IPackingListRepository>();
            _weatherService = Substitute.For<IWeatherService>();
            _readService = Substitute.For<IPackingListReadService>();
            _factory = Substitute.For<IPackingListFactory>();
            _commandHandler = new CreatePackingListWithItemsHandler(_factory, _repository, _readService, _weatherService);
        }
    }
}
