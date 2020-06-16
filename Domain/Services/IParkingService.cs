using Parkster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parkster.Domain.Services
{
    public interface IParkingService
    {
        Task<IEnumerable<Parking>> GetParkingByVehicleIdAsync(int vehicleId);
        Task<Parking> StartParkingAsync(int vehicleId, int locationId, DateTime startTime, int durationInMinutes);
        Task<Parking> EndParkingAsync(string registrationNumber);
    }
}
