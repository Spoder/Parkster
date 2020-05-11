using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parkster.Data;
using Parkster.Domain.Entities;

namespace Parkster.Domain.Services
{
    public class ParkingService : IParkingService
    {
        private readonly ParksterDbContext _context;

        public ParkingService(ParksterDbContext _context)
        {
            this._context = _context;
        }
        public Task<Parking> EndParkingAsync(string registrationNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Parking>> GetParkingByVehicleIdAsync(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public async Task<Parking> StartParkingAsync(int vehicleId, int locationId, DateTime startTime, int durationInMinutes)
        {
            var newParking = new Parking
            {
                VehicleId = vehicleId,
                LocationId = locationId,
                StartDate = startTime,
                DurationInMinutes = durationInMinutes
            };

            _context.Parkings.Add(newParking);
            await _context.SaveChangesAsync();

            return newParking;
        }

    }
}
