using BusinessLocationsApi.Models;

namespace BusinessLocationsApi.Repository
{
    public interface ILocationRepository
    {
        ICollection<Location> GeList();
        IEnumerable<Location> GetListByHours(int open, int close);
    }
}