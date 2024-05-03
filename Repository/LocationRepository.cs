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

       
        public Location GetLocationById(int id)
        { 
            return _context.Locations.Where(x => x.Id == id).FirstOrDefault();
            
        }

        public bool LocationExists(int locationId)
        {
            return _context.Locations.Any(p => p.Id == locationId);
        }

        public bool CreateLocation(Location location)
        {
            _context.Add(location);
            return Save();
        }

        public bool DeleteLocation(Location location)
        {
            _context.Remove(location);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateLocation(Location updatelocation)
        {
            var existingLocation = _context.Locations.FirstOrDefault(r => r.Id == updatelocation.Id);
            if (existingLocation == null)
            {
                return false;
            }
            existingLocation.Id = updatelocation.Id;
            existingLocation.City = updatelocation.City;
            existingLocation.Country = updatelocation.Country;
            existingLocation.Longitude = updatelocation.Longitude;
            existingLocation.Latitude = updatelocation.Latitude;

           // _context.Update(existingLocation);
            return Save();
          
        }
    }
}
