using _2704.Models;

namespace _2704.Interfaces
{
    public interface ILocationRepository
    {
        ICollection<Location> GetLocations();

        bool LocationExists(int locationId);
        Location GetLocationById(int id);

        bool CreateLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(Location location);
        bool Save();
    }
}
