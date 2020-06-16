using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parkster.Domain.Entities;
using Parkster.Domain.Services;

namespace Parkster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingsController : ControllerBase
    {
        private readonly IParkingService parkingService;

        public ParkingsController(IParkingService parkingService)
        {
            this.parkingService = parkingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parking>>> GetParkingsByVehicleIdAsync(int vehicleId)
        {
            return Ok(await parkingService.GetParkingByVehicleIdAsync(vehicleId));
        }

        [HttpPost]
        public async Task<IActionResult> StartParkingAsync(Parking parking)
        {
            var newParking = await parkingService.StartParkingAsync(parking.VehicleId, parking.LocationId, parking.StartDate, parking.DurationInMinutes);

            return Created($"/api/parkings/{newParking}", newParking);
        }
    }
}