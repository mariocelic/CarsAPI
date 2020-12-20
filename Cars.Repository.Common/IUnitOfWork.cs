using System;
using System.Threading.Tasks;

namespace Cars.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleMakeRepository VehicleMake { get; set; }
        IVehicleModelRepository VehicleModel { get; set; }

        Task CommitAsync();
        new void Dispose();
    }
}
