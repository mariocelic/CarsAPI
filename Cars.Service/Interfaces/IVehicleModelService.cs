using Cars.Data.Models;
using Cars.Repository.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Service.Interfaces
{
    public interface IVehicleModelService
    {
        Task<IList<VehicleModel>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        Task<VehicleModel> FindVehicleModelById(int id);
        Task<VehicleModel> CreateAsync(VehicleModel vehicleModel);
        Task<VehicleModel> UpdateAsync(int id, VehicleModel vehicleModel);
        Task<VehicleModel> DeleteAsync(int id);
    }
}
