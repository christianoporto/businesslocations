using BusinessLocationsApi.Models;
using Newtonsoft.Json;

namespace BusinessLocationsApi.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private ICollection<Location> localList { get; set; }

        public LocationRepository()
        {
            localList = new List<Location>();
            LoadLocalList();
        }

        private void LoadLocalList()
        {
            try
            {
                string filePath = @"Resources/LocationsFile.json";
                string jsonString = File.ReadAllText(filePath);
                localList = JsonConvert.DeserializeObject<List<Location>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public ICollection<Location> GeList()
        {
            return localList;
        }
        public IEnumerable<Location> GetListByHours(int open, int close)
        {
            IEnumerable<Location> filteredLocations = localList.Where(location => location.Hours.Any(hours => hours.Value.Open >= open && hours.Value.Close <= close));
            foreach (Location item in filteredLocations)
            {
                IEnumerable<KeyValuePair<string, LocationHour>> filteredHours = item.Hours.Where(hours => hours.Value.Open >= open && hours.Value.Close <= close);
                item.Hours = new Dictionary<string, LocationHour>(filteredHours);
            }

            return filteredLocations;
        }
    }
}
