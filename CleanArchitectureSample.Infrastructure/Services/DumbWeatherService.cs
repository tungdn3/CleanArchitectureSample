using CleanArchitectureSample.Application.DTOs.External;
using CleanArchitectureSample.Application.Services;

namespace CleanArchitectureSample.Infrastructure.Services
{
    internal sealed class DumbWeatherService : IWeatherService
    {
        public Task<WeatherDto> GetWeather(string city, string country)
        {
            return Task.FromResult(new WeatherDto
            {
                Temperature = new Random().Next(5, 40),
            });
        }
    }
}
