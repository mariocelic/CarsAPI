using Cars.Common;
using Cars.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IList<IVehicleModelEntity>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        Task<IVehicleModelEntity> FindVehicleModelById(int id);
        Task<IVehicleModelEntity> CreateAsync(IVehicleModelEntity vehicleModel);
        Task<IVehicleModelEntity> UpdateAsync(int id, IVehicleModelEntity vehicleModel);
        Task<IVehicleModelEntity> DeleteAsync(int id);
    }
}
