using CleanArchitectureSample.Application.DTOs.External;

namespace CleanArchitectureSample.Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeather(string city, string country);
    }
}
