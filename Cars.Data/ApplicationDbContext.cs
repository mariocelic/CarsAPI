using Cars.DAL.Abstract;
using Cars.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.DAL
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
        public DbSet<VehicleModelEntity> VehicleModels { get; set; }

    }
}
