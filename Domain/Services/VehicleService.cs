using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parkster.Data;
using Parkster.Domain.Entities;

namespace Parkster.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ParksterDbContext _context;

        public VehicleService(ParksterDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Vehicle> CreateVehicleAsync(string registrationNumber, string owner)
        {
            var vehicle = new Vehicle()
            {
                RegistrationNumber = registrationNumber,
                Owner = owner
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);

            if(vehicle == null)
            {
                return await Task.FromResult(false);
            }

            _context.Vehicles.Remove(vehicle);
            int recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public async Task<IEnumerable<Vehicle>> GetVehicleById(int id)
        {
            var vehicle = await _context.Vehicles
                .Include(x => x.Parkings)
                .Where(x => x.Id == id)
                .ToListAsync();

            return vehicle;
        }
    }
}
