using Cars.DAL.Entities;
using Cars.DAL.Abstract;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleMakeEntity>()
                .HasData(new VehicleMakeEntity()
                {
                    MakeId = 1,
                    Name = "Audi",
                    Abrv = "Germany"
                },
                new VehicleMakeEntity
                {
                    MakeId = 2,
                    Name = "BMW",
                    Abrv = "Germany"
                },
                new VehicleMakeEntity
                {
                    MakeId = 3,
                    Name = "Honda",
                    Abrv = "Japan"
                },
                new VehicleMakeEntity
                {
                    MakeId = 4,
                    Name = "Alfa Romeo",
                    Abrv = "Italy"
                },
                new VehicleMakeEntity
                {
                    MakeId = 5,
                    Name = "Seat",
                    Abrv = "Spain"
                },
                new VehicleMakeEntity
                {
                    MakeId = 6,
                    Name = "Subaru",
                    Abrv = "Japan"
                }
                );

            modelBuilder.Entity<VehicleModelEntity>()
                .HasData(new VehicleModelEntity()
                {
                    ModelId = 1,
                    Name = "A3",
                    Abrv = "Germany",
                    MakeId = 1
                },
                new VehicleModelEntity
                {
                    ModelId = 2,
                    Name = "A6",
                    Abrv = "Germany",
                    MakeId = 1
                },
                new VehicleModelEntity
                {
                    ModelId = 3,
                    Name = "M3",
                    Abrv = "Germany",
                    MakeId = 2
                },
                new VehicleModelEntity
                {
                    ModelId = 4,
                    Name = "530",
                    Abrv = "Germany",
                    MakeId = 2
                },
                new VehicleModelEntity
                {
                    ModelId = 5,
                    Name = "Leon",
                    Abrv = "Spain",
                    MakeId = 5
                },
                new VehicleModelEntity
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
