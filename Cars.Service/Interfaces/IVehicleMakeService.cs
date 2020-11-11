using Cars.Data.Models;
using Cars.Repository.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<IList<VehicleMake>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        Task<VehicleMake> FindVehicleMakeById(int id);
        Task<VehicleMake> CreateAsync(VehicleMake vehicleMake);
        Task<VehicleMake> UpdateAsync(int id, VehicleMake vehicleMake);
        Task<VehicleMake> DeleteAsync(int id);

    }
}
