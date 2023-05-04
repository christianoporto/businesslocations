using BusinessLocationsApi.Models;
using BusinessLocationsApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLocationsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationRepository repository;

        public LocationController(ILocationRepository repository, ILogger<LocationController> logger)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpGet("/locations")]
        public IEnumerable<Location> GetList()
        {
            _logger.LogInformation("Get locations List");
            return repository.GeList();
        }

        [HttpGet("/locations/hours")]
        public IEnumerable<Location> GetListByAvailability(int open = 0, int close = 2400)
        {
            _logger.LogInformation($"Get locations with availability between {open} and {close}");
            return repository.GetListByHours(open, close);
        }
    }
}