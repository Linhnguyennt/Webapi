using _2704.Interfaces;
using _2704.Models;

namespace _2704.Repository
{
    public class WeatherForecastRepository: IWeatherForecastRepository
    {
        private readonly WeatherForecastContext _context;
        public WeatherForecastRepository(WeatherForecastContext context)
        {
            _context = context;
        }
        public bool WeatherForecastExists(int id)
        {
            return _context.WeatherForecasts.Any(c => c.Id == id);
        }
        public ICollection<WeatherForecast> GetWeatherForecasts()
        {
            return _context.WeatherForecasts.ToList();
        }

        public WeatherForecast GetWeatherForecast(int id)
        {
            return _context.WeatherForecasts.Where(e => e.Id == id).FirstOrDefault();
        }

        public bool CreateWeatherForecast(int locationId,WeatherForecast weather)
        {
            var LocationEntity = _context.Locations.Where(a => a.Id == locationId).FirstOrDefault();
          

            var location = new WeatherForecast()
            {
               Location = LocationEntity,
             
            };

            _context.Add(location);
            _context.Add(weather);

            return Save();
        }

        public bool DeleteWeatherForecast(WeatherForecast location)
        {
            _context.Remove(location);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateWeatherForecast(int weatherid, WeatherForecast weather)
        {
            _context.Update(weather);
            return Save();
        }
    }
}
