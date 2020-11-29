using Cars.DAL.Abstract;
using Cars.Repository.Common;
using System.Threading.Tasks;

namespace Cars.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IVehicleMakeRepository VehicleMake { get; set; }
        public IVehicleModelRepository VehicleModel { get; set; }

        private readonly IApplicationDbContext _context;

        public UnitOfWork(IVehicleMakeRepository vehicleMake, IVehicleModelRepository vehicleModel, IApplicationDbContext context)
        {
            VehicleMake = vehicleMake;
            VehicleModel = vehicleModel;
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
