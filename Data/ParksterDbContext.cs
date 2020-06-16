using Microsoft.EntityFrameworkCore;
using Parkster.Domain.Entities;

namespace Parkster.Data
{
    public class ParksterDbContext : DbContext
    {

        public ParksterDbContext(DbContextOptions<ParksterDbContext>options) : base(options)
        {

        }


        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
