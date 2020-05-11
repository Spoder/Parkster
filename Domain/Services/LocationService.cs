using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parkster.Data;
using Parkster.Domain.Entities;

namespace Parkster.Domain.Services
{
    public class LocationService : ILocationService
    {
        private readonly ParksterDbContext _context;

        public LocationService(ParksterDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Location> CreateLocationAsync(string name, decimal pricePerMinute)
        {
            var location = new Location()
            {
                Name = name,
                PricePerMinute = pricePerMinute
            };

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return location;
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

    }
}
