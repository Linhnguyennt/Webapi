using _2704.Models;

namespace _2704.Interfaces
{
    public interface ILocationRepository
    {
        ICollection<Location> GetLocations();
      
        bool GetLocationById(int id);
    }
}
