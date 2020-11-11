using System;
using System.Threading.Tasks;

namespace Cars.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleMakeRepository VehicleMake { get; }
        IVehicleModelRepository VehicleModel { get; }
        Task CommitAsync();
    }
}
