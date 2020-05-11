using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parkster.Domain.Entities;
using Parkster.Domain.Services;

namespace Parkster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationsController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocationsAsync()
        {
            return Ok(await locationService.GetLocationsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocationAsync(Location location)
        {
            var newLocation = await locationService.CreateLocationAsync(location.Name, location.PricePerMinute); ;

            return Created($"/api/locations/{newLocation}", newLocation);
        }
    }
}