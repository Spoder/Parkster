using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parkster.Domain.Entities;
using Parkster.Domain.Services;

namespace Parkster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpGet("{id}/parkings")]
        public async Task<ActionResult<Vehicle>> GetVehiclesAsync(int id)
        {
            var getParking = await vehicleService.GetVehicleById(id);

            return Ok(getParking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleAsync(Vehicle vehicle)
        {
            var newVehicle = await vehicleService.CreateVehicleAsync(vehicle.RegistrationNumber, vehicle.Owner);

            return Created($"/api/vehicles/{newVehicle}", newVehicle);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleAsync(int id)
        {
            var deleted = await vehicleService.DeleteVehicleAsync(id);

            if(deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}