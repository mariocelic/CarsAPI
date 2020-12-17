using Cars.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.DAL.Abstract
{
    public interface IApplicationDbContext : IDbContext
    {
        DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
        DbSet<VehicleModelEntity> VehicleModels { get; set; }        

    }
}
