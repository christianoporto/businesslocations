using System.ComponentModel.DataAnnotations;

namespace BusinessLocationsApi.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string Type { get; set; }        
        public Dictionary<string, LocationHour> Hours { get; set; }
    }  
    public class LocationHour
    {
        public int Open { get; set; }
        public int Close { get; set; }
    }
}
