using System;
using System.Threading.Tasks;

namespace Cars.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleMakeRepository VehicleMake { get; }
        IVehicleModelRepository VehicleModel { get; }
        Task CommitAsync();
    }
}
