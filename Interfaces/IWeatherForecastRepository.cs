using _2704.Models;

namespace _2704.Interfaces
{
    public interface IWeatherForecastRepository
    {
        ICollection<WeatherForecast> GetWeatherForecasts();

        WeatherForecast GetWeatherForecast(int id);

        bool WeatherForecastExists(int weatherforecastId);
        bool CreateWeatherForecast(int locationId,WeatherForecast weatherforecast);
        bool UpdateWeatherForecast(int weather,WeatherForecast weatherforecast);
        bool DeleteWeatherForecast(WeatherForecast weatherforecast);
        bool Save();

    }
}
