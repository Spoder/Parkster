using Parkster.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parkster.Domain.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<Location> CreateLocationAsync(string name, decimal pricePerMinute);
    }
}
