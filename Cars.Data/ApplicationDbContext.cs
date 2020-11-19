using Cars.Data.Models;
using Cars.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Cars.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleMake>()
                .HasData(new VehicleMake()
                {
                    MakeId = 1,
                    Name = "Audi",
                    Abrv = "Germany"
                },
                new VehicleMake
                {
                    MakeId = 2,
                    Name = "BMW",
                    Abrv = "Germany"
                },
                new VehicleMake
                {
                    MakeId = 3,
                    Name = "Honda",
                    Abrv = "Japan"
                },
                new VehicleMake
                {
                    MakeId = 4,
                    Name = "Alfa Romeo",
                    Abrv = "Italy"
                },
                new VehicleMake
                {
                    MakeId = 5,
                    Name = "Seat",
                    Abrv = "Spain"
                },
                new VehicleMake
                {
                    MakeId = 6,
                    Name = "Subaru",
                    Abrv = "Japan"
                }
                );

            modelBuilder.Entity<VehicleModel>()
                .HasData(new VehicleModel()
                {
                    ModelId = 1,
                    Name = "A3",
                    Abrv = "Germany",
                    MakeId = 1
                },
                new VehicleModel
                {
                    ModelId = 2,
                    Name = "A6",
                    Abrv = "Germany",
                    MakeId = 1
                },
                new VehicleModel
                {
                    ModelId = 3,
                    Name = "M3",
                    Abrv = "Germany",
                    MakeId = 2
                },
                new VehicleModel
                {
                    ModelId = 4,
                    Name = "530",
                    Abrv = "Germany",
                    MakeId = 2
                },
                new VehicleModel
                {
                    ModelId = 5,
                    Name = "Leon",
                    Abrv = "Spain",
                    MakeId = 5
                },
                new VehicleModel
                {
                    ModelId = 6,
                    Name = "Civic",
                    Abrv = "Japan",
                    MakeId = 3
                }
                );
        }

    }
}
