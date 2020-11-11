using Cars.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cars.Data.Interfaces
{
    public interface IApplicationDbContext : IDbContext
    {
        DbSet<VehicleMake> VehicleMakes { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }

    }
}
