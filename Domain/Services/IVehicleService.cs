using Parkster.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parkster.Domain.Services
{
    public interface IVehicleService
    {
        Task<Vehicle> CreateVehicleAsync(string registrationNumber, string owner);
        Task<IEnumerable<Vehicle>> GetVehicleById(int id);
        Task<bool> DeleteVehicleAsync(int id);
    }
}
