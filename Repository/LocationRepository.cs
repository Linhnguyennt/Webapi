using _2704.Interfaces;
using _2704.Models;

namespace _2704.Repository
{
  
    public class LocationRepository : ILocationRepository
    {
        private readonly WeatherForecastContext _context;
        public LocationRepository(WeatherForecastContext context) 
        {
            _context = context;
        }

        public ICollection<Location> GetLocations()
        {

            return _context.Locations.OrderBy(propa =>propa.Id).ToList();

        }
      
        public bool GetLocationById(int id)
        {
            Location? f = _context.Locations.Where(x => x.Id == id).FirstOrDefault();
            if (f != null)
            {
                _context.Locations.Remove(f);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
